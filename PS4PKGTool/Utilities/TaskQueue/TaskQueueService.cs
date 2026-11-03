#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PS4PKGTool.Core.Diagnostics;

namespace PS4PKGTool.Utilities.TaskQueue;

/// <summary>Persistent, sequential queue for disk-heavy package operations.</summary>
public sealed class TaskQueueService : IDisposable
{
    private readonly object _gate = new();
    private readonly List<QueuedPackageTask> _tasks = [];
    private readonly SemaphoreSlim _signal = new(0);
    private readonly CancellationTokenSource _shutdown = new();
    private bool _workerStarted;
    private bool _shutdownRequested;
    private bool _resourcesDisposed;
    private bool _startOneRequested;
    private Guid? _requestedTaskId;
    private Task? _workerTask;
    private Task? _shutdownTask;
    private string? _persistencePath;
    private DateTime _lastSavedUtc;

    private bool _autoStart = true;
    public bool AutoStart
    {
        get { lock (_gate) return _autoStart; }
        set
        {
            bool start;
            lock (_gate)
            {
                start = value && !_autoStart;
                _autoStart = value;
            }
            if (start)
            {
                EnsureWorker();
                _signal.Release();
            }
        }
    }
    public event EventHandler? TasksChanged;

    public IReadOnlyList<QueuedPackageTask> Tasks
    {
        get { lock (_gate) return _tasks.ToArray(); }
    }

    public void EnablePersistence(string path, Func<PersistedQueueTask, QueuedPackageTask?> taskFactory)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(path);
        ArgumentNullException.ThrowIfNull(taskFactory);
        _persistencePath = path;

        foreach (PersistedQueueTask saved in TaskQueuePersistence.Load(path))
        {
            QueuedPackageTask? task = taskFactory(saved);
            if (task is null) continue;
            task.Changed += Task_Changed;
            lock (_gate) _tasks.Add(task);
        }
        RaiseChanged(forcePersistence: true);
        if (AutoStart && Tasks.Any(task => task.Status == QueueTaskStatus.Queued))
        {
            EnsureWorker();
            _signal.Release();
        }
    }

    public void Enqueue(QueuedPackageTask task)
    {
        ArgumentNullException.ThrowIfNull(task);
        lock (_gate)
        {
            task.Changed += Task_Changed;
            _tasks.Add(task);
        }
        RaiseChanged(forcePersistence: true);
        EnsureWorker();
        if (AutoStart) _signal.Release();
    }

    public void StartNext()
    {
        lock (_gate) _startOneRequested = true;
        EnsureWorker();
        _signal.Release();
    }

    public void Cancel(QueuedPackageTask task)
    {
        // Decide under the queue lock, but mutate (which raises Changed and
        // can persist) outside it.
        bool wasQueued;
        lock (_gate)
        {
            if (task.Status == QueueTaskStatus.Queued)
                wasQueued = true;
            else if (task.Status is QueueTaskStatus.Running or QueueTaskStatus.Cancelling)
                wasQueued = false;
            else return;
        }
        if (wasQueued)
            task.MarkCancelled("Cancelled before starting.");
        else
        {
            task.BeginCancellation();
            task.Cancel();
        }
        RaiseChanged(forcePersistence: true);
    }

    public void Retry(QueuedPackageTask task)
    {
        lock (_gate)
        {
            if (task.Status is not (QueueTaskStatus.Failed or QueueTaskStatus.Cancelled or QueueTaskStatus.Interrupted)) return;
        }
        task.ResetForRetry();
        RaiseChanged(forcePersistence: true);
        EnsureWorker();
        if (AutoStart) _signal.Release();
    }

    public void Remove(QueuedPackageTask task)
    {
        lock (_gate)
        {
            if (task.Status is QueueTaskStatus.Running or QueueTaskStatus.Cancelling) return;
            task.Changed -= Task_Changed;
            _tasks.Remove(task);
        }
        RaiseChanged(forcePersistence: true);
    }

    public void ClearCompleted()
    {
        lock (_gate)
        {
            foreach (QueuedPackageTask task in _tasks.Where(task => task.Status == QueueTaskStatus.Completed))
                task.Changed -= Task_Changed;
            _tasks.RemoveAll(task => task.Status == QueueTaskStatus.Completed);
        }
        RaiseChanged(forcePersistence: true);
    }

    private void EnsureWorker()
    {
        lock (_gate)
        {
            if (_workerStarted) return;
            _workerStarted = true;
            _workerTask = Task.Run(WorkerAsync);
        }
    }

    private async Task WorkerAsync()
    {
        try
        {
            while (!_shutdown.IsCancellationRequested)
            {
                await _signal.WaitAsync(_shutdown.Token).ConfigureAwait(false);
                while (true)
                {
                QueuedPackageTask? task;
                lock (_gate)
                {
                    bool mayStart = _autoStart || _startOneRequested;
                    task = mayStart && _requestedTaskId is Guid requested
                        ? _tasks.FirstOrDefault(candidate => candidate.Id == requested && candidate.Status == QueueTaskStatus.Queued)
                        : mayStart ? _tasks.FirstOrDefault(candidate => candidate.Status == QueueTaskStatus.Queued) : null;
                    if (task is null) break;
                    if (_requestedTaskId == task.Id) _requestedTaskId = null;
                    if (!_autoStart) _startOneRequested = false;
                }
                // State mutators raise Changed, whose subscriber persists the
                // queue and invokes user handlers. Run them outside _gate so we
                // never perform file I/O or call foreign code while holding it.
                task.SetStatus(QueueTaskStatus.Running);
                CoreLog.Info($"Task started: {task.Type} - {task.DisplayName}");
                RaiseChanged(forcePersistence: true);
                try
                {
                    QueueTaskExecutionResult result = await task.ExecuteAsync(_shutdown.Token).ConfigureAwait(false);
                    if (_shutdown.IsCancellationRequested)
                    {
                        task.MarkInterrupted();
                        CoreLog.Warn($"Task interrupted: {task.Type} - {task.DisplayName}");
                    }
                    else if (task.CancellationRequested)
                    {
                        task.MarkCancelled("Cancelled.");
                        CoreLog.Warn($"Task cancelled: {task.Type} - {task.DisplayName}");
                    }
                    else
                    {
                        task.SetStatus(result.Succeeded ? QueueTaskStatus.Completed : QueueTaskStatus.Failed,
                            result.Message, result.OutputPath);
                        if (result.Succeeded)
                            CoreLog.Info($"Task finished: {task.Type} - {task.DisplayName}");
                        else
                            CoreLog.Err($"Task failed: {task.Type} - {task.DisplayName}: {result.Message}");
                    }
                }
                catch (OperationCanceledException)
                {
                    if (!_shutdown.IsCancellationRequested)
                    {
                        task.MarkCancelled("Cancelled.");
                        CoreLog.Warn($"Task cancelled: {task.Type} - {task.DisplayName}");
                    }
                }
                catch (Exception ex)
                {
                    task.SetStatus(QueueTaskStatus.Failed, ex.Message);
                    CoreLog.Err($"Task failed: {task.Type} - {task.DisplayName}: {ex.Message}");
                }
                RaiseChanged(forcePersistence: true);
                    if (!AutoStart) break;
                }
            }
        }
        catch (OperationCanceledException) { }
    }

    private void RaiseChanged(bool forcePersistence = false)
    {
        SaveQueue(forcePersistence);
        TasksChanged?.Invoke(this, EventArgs.Empty);
    }

    private void SaveQueue(bool force = false)
    {
        if (string.IsNullOrWhiteSpace(_persistencePath)) return;
        DateTime now = DateTime.UtcNow;
        if (!force && now - _lastSavedUtc < TimeSpan.FromSeconds(1)) return;
        try
        {
            TaskQueuePersistence.Save(_persistencePath, Tasks.Select(PersistedQueueTask.FromTask));
            _lastSavedUtc = now;
        }
        catch (IOException) { }
        catch (UnauthorizedAccessException) { }
    }
    private void Task_Changed(object? sender, EventArgs e) => RaiseChanged();

    public void Dispose()
    {
        QueuedPackageTask[] interruptedTasks;
        lock (_gate)
        {
            if (_shutdownRequested) return;
            _shutdownRequested = true;
            interruptedTasks = _tasks.Where(task => task.Status is QueueTaskStatus.Running or QueueTaskStatus.Cancelling).ToArray();
        }

        foreach (QueuedPackageTask task in interruptedTasks)
            task.MarkInterrupted();
        SaveQueue(force: true);
        _shutdown.Cancel();
    }

    public Task ShutdownAsync()
    {
        Dispose();
        lock (_gate)
        {
            return _shutdownTask ??= ShutdownCoreAsync(_workerTask);
        }
    }

    private async Task ShutdownCoreAsync(Task? workerTask)
    {
        if (workerTask is not null) await workerTask.ConfigureAwait(false);

        lock (_gate)
        {
            if (_resourcesDisposed) return;
            _resourcesDisposed = true;
        }
        _shutdown.Dispose();
        _signal.Dispose();
    }
}

public enum QueueTaskStatus { Queued, Running, Cancelling, Completed, Failed, Cancelled, Interrupted }

public sealed record QueueTaskProgress(string Stage, int Step = 0, int TotalSteps = 0,
    long CurrentBytes = 0, long TotalBytes = 0, int CurrentItems = 0, int TotalItems = 0, string? CurrentFile = null);

public sealed record QueueTaskExecutionResult(bool Succeeded, string Message = "", string? OutputPath = null);

public sealed class QueuedPackageTask
{
    private readonly object _stateGate = new();
    private readonly object _logGate = new();
    private readonly List<string> _logLines = [];
    private long _logVersion;
    private const int MaxLogLines = 2000;
    private readonly Func<QueuedPackageTask, CancellationToken, Task<QueueTaskExecutionResult>> _execute;
    private CancellationTokenSource _cancellation = new();

    public QueuedPackageTask(string type, string displayName, string source, string? outputPath,
        Func<QueuedPackageTask, CancellationToken, Task<QueueTaskExecutionResult>> execute, string? persistencePayload = null, Guid? id = null)
    {
        Type = type;
        DisplayName = displayName;
        Source = source;
        OutputPath = outputPath;
        _execute = execute;
        PersistencePayload = persistencePayload;
        Id = id ?? Guid.NewGuid();
    }

    public Guid Id { get; }
    public string Type { get; }
    public string DisplayName { get; }
    public string Source { get; }
    public string? OutputPath { get; private set; }
    public QueueTaskStatus Status { get; private set; } = QueueTaskStatus.Queued;
    public QueueTaskProgress Progress { get; private set; } = new("Waiting");
    /// <summary>Read-only UI projection; the queue remains the source of truth for progress.</summary>
    public int ProgressPercent => Progress.TotalBytes > 0
        ? (int)Math.Clamp(Progress.CurrentBytes * 100 / Progress.TotalBytes, 0, 100)
        : Progress.TotalSteps > 0 ? (int)Math.Clamp(Progress.Step * 100 / Progress.TotalSteps, 0, 100) : 0;
    public string Message { get; private set; } = "Waiting";
    public string? PersistencePayload { get; }
    public DateTime? StartedAtUtc { get; private set; }
    public DateTime? CompletedAtUtc { get; private set; }

    public event EventHandler? Changed;

    /// <summary>Timestamped process log shown in the Tasks tab (last 2000 lines).</summary>
    public IReadOnlyList<string> LogLines
    {
        get { lock (_logGate) return _logLines.ToArray(); }
    }

    /// <summary>Monotonic version of <see cref="LogLines"/>; changes on every append.</summary>
    public long LogVersion
    {
        get { lock (_logGate) return _logVersion; }
    }

    /// <summary>Appends one timestamped process-log line (thread-safe).</summary>
    public void Log(string message)
    {
        if (string.IsNullOrWhiteSpace(message)) return;
        lock (_logGate)
        {
            _logLines.Add($"{DateTime.Now:HH:mm:ss}  {message}");
            if (_logLines.Count > MaxLogLines)
                _logLines.RemoveRange(0, _logLines.Count - MaxLogLines);
            _logVersion++;
        }
        Changed?.Invoke(this, EventArgs.Empty);
    }

    public void Report(QueueTaskProgress progress)
    {
        // A worker can emit one final progress callback after cancellation was
        // requested. Keep the cancelled state at zero instead of letting that
        // late callback redraw either progress bar as complete.
        lock (_stateGate)
        {
            if (Status != QueueTaskStatus.Running) return;
            Progress = progress;
            Message = progress.Stage;
        }
        Changed?.Invoke(this, EventArgs.Empty);
    }

    internal async Task<QueueTaskExecutionResult> ExecuteAsync(CancellationToken shutdown)
    {
        using var linked = CancellationTokenSource.CreateLinkedTokenSource(_cancellation.Token, shutdown);
        return await _execute(this, linked.Token).ConfigureAwait(false);
    }

    internal void Cancel() => _cancellation.Cancel();
    internal bool CancellationRequested => _cancellation.IsCancellationRequested;
    internal void SetStatus(QueueTaskStatus status, string? message = null, string? outputPath = null)
    {
        lock (_stateGate)
        {
            Status = status;
            if (status == QueueTaskStatus.Running)
            {
                StartedAtUtc = DateTime.UtcNow;
                CompletedAtUtc = null;
            }
            else if (status is QueueTaskStatus.Completed or QueueTaskStatus.Failed)
            {
                CompletedAtUtc = DateTime.UtcNow;
            }
            if (message is not null) Message = message;
            if (outputPath is not null) OutputPath = outputPath;
        }
        Changed?.Invoke(this, EventArgs.Empty);
    }

    internal void ResetForRetry()
    {
        _cancellation.Dispose();
        _cancellation = new CancellationTokenSource();
        Status = QueueTaskStatus.Queued;
        Progress = new QueueTaskProgress("Waiting");
        Message = "Waiting";
        StartedAtUtc = null;
        CompletedAtUtc = null;
        Changed?.Invoke(this, EventArgs.Empty);
    }

    internal void BeginCancellation()
    {
        lock (_stateGate)
        {
            Status = QueueTaskStatus.Cancelling;
            Progress = new QueueTaskProgress("Cancelled");
            Message = "Cancelling...";
        }
        Changed?.Invoke(this, EventArgs.Empty);
    }

    internal void MarkCancelled(string message)
    {
        lock (_stateGate)
        {
            Status = QueueTaskStatus.Cancelled;
            Progress = new QueueTaskProgress("Cancelled");
            Message = message;
            CompletedAtUtc = DateTime.UtcNow;
        }
        Changed?.Invoke(this, EventArgs.Empty);
    }

    internal void MarkInterrupted()
    {
        lock (_stateGate)
        {
            Status = QueueTaskStatus.Interrupted;
            Progress = new QueueTaskProgress("Interrupted");
            Message = "Interrupted during previous session.";
            CompletedAtUtc = DateTime.UtcNow;
        }
        Changed?.Invoke(this, EventArgs.Empty);
    }

    public void RestoreState(PersistedQueueTask saved)
    {
        Status = saved.Status is QueueTaskStatus.Running or QueueTaskStatus.Cancelling ? QueueTaskStatus.Interrupted : saved.Status;
        Progress = saved.Progress ?? new QueueTaskProgress("Waiting");
        Message = saved.Status is QueueTaskStatus.Running or QueueTaskStatus.Cancelling
            ? "Interrupted during previous session."
            : saved.Message ?? "Waiting";
        StartedAtUtc = saved.StartedAtUtc;
        CompletedAtUtc = saved.CompletedAtUtc;
    }
}

public sealed record PersistedQueueTask(Guid Id, string Type, string DisplayName, string Source, string? OutputPath,
    QueueTaskStatus Status, QueueTaskProgress? Progress, string? Message, string? Payload,
    DateTime? StartedAtUtc = null, DateTime? CompletedAtUtc = null)
{
    public static PersistedQueueTask FromTask(QueuedPackageTask task) => new(task.Id, task.Type, task.DisplayName,
        task.Source, task.OutputPath, task.Status, task.Progress, task.Message, task.PersistencePayload,
        task.StartedAtUtc, task.CompletedAtUtc);
}

internal static class TaskQueuePersistence
{
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

    public static IReadOnlyList<PersistedQueueTask> Load(string path)
    {
        try
        {
            return Read(path) ?? Read(path + ".bak") ?? [];
        }
        catch (JsonException) { return Read(path + ".bak") ?? []; }
        catch (IOException) { return []; }
        catch (UnauthorizedAccessException) { return []; }
    }

    public static void Save(string path, IEnumerable<PersistedQueueTask> tasks)
    {
        string? directory = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(directory)) Directory.CreateDirectory(directory);
        string temp = path + ".tmp";
        File.WriteAllText(temp, JsonSerializer.Serialize(tasks, Options));
        if (File.Exists(path)) File.Copy(path, path + ".bak", overwrite: true);
        File.Move(temp, path, overwrite: true);
    }

    private static IReadOnlyList<PersistedQueueTask>? Read(string path) => File.Exists(path)
        ? JsonSerializer.Deserialize<List<PersistedQueueTask>>(File.ReadAllText(path), Options) : null;
}
