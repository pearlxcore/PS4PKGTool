#nullable enable
using OrbisPkgTool;
using OrbisPkgTool.Pkg;
using PS4PKGTool.Utilities.Ffpfsc;
using PS4PKGTool.Utilities.PkgInspection;
using PS4PKGTool.Utilities.PS4PKGToolHelper;
using PS4PKGTool.Utilities.Shadps4;
using PS4PKGTool.Utilities.TaskQueue;
using PS4PKGTool.Core.Tasks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS4PKGTool;

public partial class Main
{
    private int _taskRefreshPending;
    private Guid? _lastRunningTaskId;
    private readonly Dictionary<Guid, DataGridViewRow> _taskRows = new();
    private Font? _taskProgressLabelDefaultFont;
    private Font? _taskProgressLabelCompletedFont;
    private Color _taskProgressLabelDefaultColor;
    private bool _taskProgressLabelAppearanceInitialized;
    private bool _taskQueueShutdownInProgress;
    private bool _taskQueueShutdownCompleted;
    private readonly HashSet<Guid> _taskQueueBatchTaskIds = [];
    private bool _taskQueueRunObserved;
    private bool _taskQueueCompletionDialogPending;
    private int _taskQueueSummaryGeneration;
    private readonly IPackageTaskFactory _packageTaskFactory = new PackageTaskFactory();

    private void InitializeTaskQueue()
    {
                _taskQueue.EnablePersistence(Path.Combine(Helper.UserDataDirectory, "task-queue.json"), RestoreQueuedTask);
        _taskQueue.TasksChanged += TaskQueue_TasksChanged;
        FormClosing += Main_FormClosing;
        taskRefreshTimer.Interval = 250;
        taskRefreshTimer.Tick += TaskRefreshTimer_Tick;
        RefreshTaskGrid();
    }

    private async void Main_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (_taskQueueShutdownCompleted) return;

        // A queued operation may still own output files. Keep the form alive
        // until its cancellation path has returned and the interrupted state is
        // safely persisted, rather than letting Application.Exit terminate it.
        e.Cancel = true;
        if (_taskQueueShutdownInProgress) return;

        _taskQueueShutdownInProgress = true;
        Enabled = false;
        try
        {
            await _taskQueue.ShutdownAsync();
            _taskQueueShutdownCompleted = true;
            BeginInvoke((Action)Close);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Task queue shutdown failed: {ex}");
            Enabled = true;
            _taskQueueShutdownInProgress = false;
            ShowError("The active task could not be stopped safely. Close it before exiting.", true);
        }
    }

    private QueuedPackageTask? SelectedTask => _tasksGrid?.SelectedRows.Count > 0 ? _tasksGrid.SelectedRows[0].Tag as QueuedPackageTask : null;

    private void TaskQueue_TasksChanged(object? sender, EventArgs e)
    {
        if (IsDisposed || !IsHandleCreated) return;
        // Compression and extraction can report hundreds of progress events per
        // second. A timer limits UI redraws to four updates per second.
        if (Interlocked.Exchange(ref _taskRefreshPending, 1) != 0) return;
        try
        {
            BeginInvoke((Action)(() => taskRefreshTimer.Start()));
        }
        catch (InvalidOperationException)
        {
            Interlocked.Exchange(ref _taskRefreshPending, 0);
        }
    }

    private void TaskRefreshTimer_Tick(object? sender, EventArgs e)
    {
        taskRefreshTimer.Stop();
        Interlocked.Exchange(ref _taskRefreshPending, 0);
        RefreshTaskGrid();
    }

    private void taskAutoStart_CheckedChanged(object? sender, EventArgs e) => _taskQueue.AutoStart = _taskAutoStart.Checked;
    private void taskStartNext_Click(object? sender, EventArgs e)
    {
        QueuedPackageTask? next = _taskQueue.Tasks.FirstOrDefault(task => task.Status == QueueTaskStatus.Queued);
        if (next is not null) TrackTaskQueueBatch(next);
        _taskQueue.StartNext();
    }

    private void taskClearFinished_Click(object? sender, EventArgs e)
    {
        _taskQueueSummaryGeneration++;
        _taskQueueCompletionDialogPending = false;
        _taskQueueRunObserved = false;
        _taskQueueBatchTaskIds.Clear();
        _taskQueue.ClearCompleted();
    }
    private void tasksGrid_SelectionChanged(object? sender, EventArgs e) => UpdateSelectedTaskDetails();
    private void taskCancel_Click(object? sender, EventArgs e) { if (SelectedTask is { } task) _taskQueue.Cancel(task); }
    private void taskRetry_Click(object? sender, EventArgs e)
    {
        if (SelectedTask is not { } task) return;
        TrackTaskQueueBatch(task);
        _taskQueue.Retry(task);
    }
    private void taskRemove_Click(object? sender, EventArgs e) { if (SelectedTask is { } task) _taskQueue.Remove(task); }
    private void taskOpenOutput_Click(object? sender, EventArgs e) => OpenSelectedTaskOutput();

    /// <summary>True when the selected task failed on the build's disk-space pre-flight.</summary>
    private static bool CanIgnoreDiskSpaceCheck(QueuedPackageTask task)
        => task.Status == QueueTaskStatus.Failed
            && task.Type == "Merge PKG"
            && task.Message.Contains("Aborting before build", StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Re-runs the failed merge with the disk-space guard disabled. The failed
    /// task is kept for history; the new task carries the flag (and persists it
    /// in the queue payload), so a later restore keeps the same choice.
    /// </summary>
    private void taskIgnoreDisk_Click(object? sender, EventArgs e)
    {
        if (SelectedTask is not { } task || !CanIgnoreDiskSpaceCheck(task)) return;
        if (string.IsNullOrWhiteSpace(task.PersistencePayload)) return;

        MergeQueuePayload? payload;
        try { payload = JsonSerializer.Deserialize<MergeQueuePayload>(task.PersistencePayload); }
        catch (JsonException) { return; }
        if (payload is null) return;

        var request = new PkgMergeRequest
        {
            BasePkgPath = payload.BasePkgPath, UpdatePkgPath = payload.UpdatePkgPath, OutputPkgPath = payload.OutputPkgPath,
            BasePasscode = payload.BasePasscode, UpdatePasscode = payload.UpdatePasscode, ValidateAfterBuild = payload.ValidateAfterBuild,
            PfscMode = payload.PfscMode, WorkerCount = payload.WorkerCount, WorkDirectory = payload.WorkDirectory,
            KeepWorkDirectory = payload.KeepWorkDirectory, CleanupWorkDirectoryOnFailure = payload.CleanupWorkDirectoryOnFailure,
            Title = payload.Title, TitleId = payload.TitleId, ContentId = payload.ContentId,
            SkipDiskSpaceCheck = true
        };
        EnqueueMerge(request, task.DisplayName + " (ignore disk check)");
    }

    private void RefreshTaskGrid()
    {
        if (_tasksGrid is null) return;
        QueuedPackageTask[] tasks = _taskQueue.Tasks.ToArray();
        UpdateTaskQueueCompletionSummary(tasks);
        _taskStartNext.Enabled = !_taskQueue.AutoStart && tasks.Any(task => task.Status == QueueTaskStatus.Queued);
        _taskClearFinished.Enabled = tasks.Any(task => task.Status == QueueTaskStatus.Completed);
        Guid? selected = SelectedTask?.Id;
        Guid? runningTaskId = tasks.FirstOrDefault(task => task.Status is QueueTaskStatus.Running or QueueTaskStatus.Cancelling)?.Id;
        bool runningTaskChanged = runningTaskId != _lastRunningTaskId;
        _lastRunningTaskId = runningTaskId;
        bool taskListChanged = _taskRows.Count != tasks.Length || tasks.Any(task => !_taskRows.ContainsKey(task.Id));
        if (taskListChanged)
        {
            _tasksGrid.SuspendLayout();
            _tasksGrid.Rows.Clear();
            _taskRows.Clear();
            foreach (QueuedPackageTask task in tasks)
            {
                int rowIndex = _tasksGrid.Rows.Add(task.Type, task.DisplayName, task.Status, FormatQueueProgress(task));
                DataGridViewRow row = _tasksGrid.Rows[rowIndex];
                row.Tag = task;
                _taskRows.Add(task.Id, row);
            }
            _tasksGrid.ResumeLayout();
        }

        foreach (QueuedPackageTask task in tasks)
        {
            DataGridViewRow row = _taskRows[task.Id];
            row.Cells[0].Value = task.Type;
            row.Cells[1].Value = task.DisplayName;
            row.Cells[2].Value = task.Status;
            row.Cells[3].Value = FormatQueueProgress(task);
            row.Tag = task;
            // Keep the Type, Task, and Status cells on the normal DarkUI text
            // color. Progress is the single visual task-state indicator.
            row.DefaultCellStyle.ForeColor = Color.Empty;
            row.DefaultCellStyle.SelectionForeColor = Color.Empty;
            row.Cells[3].Style.ForeColor = TaskStatusColor(task.Status);
            row.Cells[3].Style.SelectionForeColor = TaskStatusColor(task.Status);
        }

        // Do not touch selection while progress is advancing. Changing
        // DataGridViewRow.Selected during every timer tick clears the user's
        // current row and forces them to click it again. Selection changes
        // only when the row set changes or a queued task starts running.
        if (runningTaskChanged && runningTaskId.HasValue)
            SelectTaskRow(runningTaskId, focusGrid: true);
        else if (taskListChanged)
            SelectTaskRow(selected, focusGrid: false);

        UpdateSelectedTaskDetails();
    }

    private void TrackTaskQueueBatch(QueuedPackageTask task) => _taskQueueBatchTaskIds.Add(task.Id);

    private void UpdateTaskQueueCompletionSummary(QueuedPackageTask[] tasks)
    {
        if (_taskQueueBatchTaskIds.Count == 0) return;

        bool hasPendingWork = tasks.Any(task => task.Status is QueueTaskStatus.Queued or QueueTaskStatus.Running or QueueTaskStatus.Cancelling);
        bool batchHasStarted = tasks.Any(task => _taskQueueBatchTaskIds.Contains(task.Id) && task.StartedAtUtc is not null);
        _taskQueueRunObserved |= batchHasStarted;
        if (!_taskQueueRunObserved || hasPendingWork || _taskQueueCompletionDialogPending) return;

        QueuedPackageTask[] batch = tasks
            .Where(task => _taskQueueBatchTaskIds.Contains(task.Id) && task.StartedAtUtc is not null)
            .ToArray();
        _taskQueueBatchTaskIds.Clear();
        _taskQueueRunObserved = false;
        if (batch.Length == 0) return;

        _taskQueueCompletionDialogPending = true;
        int generation = _taskQueueSummaryGeneration;
        BeginInvoke((Action)(() =>
        {
            _taskQueueCompletionDialogPending = false;
            if (IsDisposed || generation != _taskQueueSummaryGeneration) return;
            ShowTaskQueueCompletionSummary(batch);
        }));
    }

    private void ShowTaskQueueCompletionSummary(IReadOnlyCollection<QueuedPackageTask> tasks)
    {
        int completed = tasks.Count(task => task.Status == QueueTaskStatus.Completed);
        int failed = tasks.Count(task => task.Status == QueueTaskStatus.Failed);
        int cancelled = tasks.Count(task => task.Status == QueueTaskStatus.Cancelled);
        int interrupted = tasks.Count(task => task.Status == QueueTaskStatus.Interrupted);
        DateTime? startedAt = tasks.Where(task => task.StartedAtUtc is not null).Select(task => task.StartedAtUtc!.Value).DefaultIfEmpty().Min();
        DateTime? finishedAt = tasks.Where(task => task.CompletedAtUtc is not null).Select(task => task.CompletedAtUtc!.Value).DefaultIfEmpty().Max();
        TimeSpan? elapsed = startedAt is not null && finishedAt is not null && finishedAt >= startedAt ? finishedAt - startedAt : null;

        var summary = new List<string>();
        if (completed > 0) summary.Add($"{completed} completed");
        if (failed > 0) summary.Add($"{failed} failed");
        if (cancelled > 0) summary.Add($"{cancelled} cancelled");
        if (interrupted > 0) summary.Add($"{interrupted} interrupted");
        string duration = elapsed is null ? "" : $" in {FormatQueueDuration(elapsed.Value)}";
        bool allCompleted = completed == tasks.Count;

        AppMessageBox.Show(allCompleted ? "All tasks completed" : "Task queue finished",
            string.Join(", ", summary) + duration + ".",
            allCompleted ? AppMessageType.Info : AppMessageType.Warning, AppMessageButtons.OK);
    }

    private static string FormatQueueDuration(TimeSpan elapsed) => elapsed.TotalHours >= 1
        ? $"{(int)elapsed.TotalHours:00}:{elapsed.Minutes:00}:{elapsed.Seconds:00}"
        : $"{(int)elapsed.TotalMinutes:00}:{elapsed.Seconds:00}";

    private void SelectTaskRow(Guid? taskId, bool focusGrid)
    {
        if (taskId is not Guid id || !_taskRows.TryGetValue(id, out DataGridViewRow? row)) return;

        _tasksGrid.ClearSelection();
        row.Selected = true;
        _tasksGrid.CurrentCell = row.Cells[0];
        if (focusGrid) _tasksGrid.Focus();
    }

    private static string FormatQueueProgress(QueuedPackageTask task)
    {
        if (task.Status == QueueTaskStatus.Completed) return FormatCompletedStatus(task);
        if (task.Status == QueueTaskStatus.Failed) return $"Failed - {task.Message}";
        if (task.Status == QueueTaskStatus.Cancelled) return $"Cancelled - {task.Message}";
        if (task.Status == QueueTaskStatus.Interrupted) return "Interrupted during previous session";

        QueueTaskProgress p = task.Progress;
        if (p.TotalItems > 0) return $"{p.Stage} · {Math.Min(p.CurrentItems, p.TotalItems)}/{p.TotalItems} files";
        if (p.TotalBytes > 0) return $"{p.Stage} · {p.CurrentBytes / 1048576d:F1}/{p.TotalBytes / 1048576d:F1} MB";
        return p.TotalSteps > 0 ? $"{p.Stage} · step {p.Step}/{p.TotalSteps}" : task.Message;
    }

    private static string FormatCompletedStatus(QueuedPackageTask task)
    {
        if (task.StartedAtUtc is not DateTime startedAt || task.CompletedAtUtc is not DateTime completedAt || completedAt < startedAt)
            return "Completed";

        TimeSpan elapsed = completedAt - startedAt;
        return elapsed.TotalHours >= 1
            ? $"Completed in {(int)elapsed.TotalHours:00}:{elapsed.Minutes:00}:{elapsed.Seconds:00}"
            : $"Completed in {(int)elapsed.TotalMinutes:00}:{elapsed.Seconds:00}";
    }

    private static Color TaskStatusColor(QueueTaskStatus status) => status switch
    {
        QueueTaskStatus.Completed => Color.FromArgb(128, 220, 128),
        QueueTaskStatus.Failed or QueueTaskStatus.Interrupted => Color.FromArgb(255, 125, 125),
        QueueTaskStatus.Cancelled or QueueTaskStatus.Cancelling => Color.FromArgb(255, 190, 90),
        _ => Color.Empty
    };

    private void UpdateSelectedTaskDetails()
    {
        if (_taskStageLabel is null || _taskOverallProgress is null || _taskCurrentProgress is null || _taskProgressLabel is null || _taskDetailLabel is null || _taskIgnoreDisk is null) return;
        QueuedPackageTask? task = SelectedTask;
        if (task is null)
        {
            _taskStageLabel.Text = "Select a task to see details.";
            _taskProgressLabel.Text = "Current task";
            SetTaskProgressLabelAppearance(completed: false);
            _taskOverallLabel.Text = "Overall progress";
            _taskDetailLabel.Text = "";
            SetProgressValue(_taskOverallProgress, 0);
            SetProgressValue(_taskCurrentProgress, 0);
            _taskIgnoreDisk.Visible = false;
            _taskIgnoreDisk.Enabled = false;
            return;
        }
        QueueTaskProgress p = task.Progress;
        bool completed = task.Status == QueueTaskStatus.Completed;
        _taskStageLabel.Text = $"{task.Type}: {task.DisplayName} - {task.Status}";
        int overallProgress = CalculateOverallProgress(p, task.Status);
        SetProgressValue(_taskOverallProgress, overallProgress);
        _taskOverallLabel.Text = $"Overall progress: {overallProgress}%";
        int currentProgress = completed ? 100 : p.TotalBytes > 0 ? (int)Math.Clamp(p.CurrentBytes * 100 / p.TotalBytes, 0, 100)
            : p.TotalItems > 0 ? Math.Clamp(p.CurrentItems * 100 / p.TotalItems, 0, 100) : 0;
        SetProgressValue(_taskCurrentProgress, currentProgress);
        _taskProgressLabel.Text = completed ? FormatCompletedStatus(task) : p.TotalSteps > 0
            ? $"Current task - Step {p.Step} of {p.TotalSteps} · {p.Stage}"
            : $"Current task - {p.Stage}";
        SetTaskProgressLabelAppearance(completed);
        _taskDetailLabel.Text = completed ? task.Message :
            p.TotalItems > 0 ? $"{p.CurrentItems} / {p.TotalItems} files · {p.CurrentFile}" :
            p.TotalBytes > 0 ? $"{p.CurrentBytes / 1048576d:F1} MB / {p.TotalBytes / 1048576d:F1} MB · {p.CurrentFile}" :
            string.IsNullOrWhiteSpace(p.CurrentFile) ? task.Message : $"{p.Stage}: {p.CurrentFile}";
        _taskCancel!.Enabled = task.Status is QueueTaskStatus.Queued or QueueTaskStatus.Running;
        _taskRetry!.Enabled = task.Status is QueueTaskStatus.Failed or QueueTaskStatus.Cancelled or QueueTaskStatus.Interrupted;
        _taskRemove!.Enabled = task.Status is not (QueueTaskStatus.Running or QueueTaskStatus.Cancelling);
        _taskOpenOutput!.Enabled = task.Status == QueueTaskStatus.Completed && !string.IsNullOrWhiteSpace(task.OutputPath);
        bool canIgnoreDisk = CanIgnoreDiskSpaceCheck(task);
        _taskIgnoreDisk!.Visible = canIgnoreDisk;
        _taskIgnoreDisk.Enabled = canIgnoreDisk;
    }

    private void SetTaskProgressLabelAppearance(bool completed)
    {
        if (_taskProgressLabel is null) return;
        if (!_taskProgressLabelAppearanceInitialized)
        {
            _taskProgressLabelDefaultFont = _taskProgressLabel.Font;
            _taskProgressLabelDefaultColor = _taskProgressLabel.ForeColor;
            _taskProgressLabelCompletedFont = new Font(_taskProgressLabel.Font.FontFamily,
                _taskProgressLabel.Font.Size + 2F, FontStyle.Bold);
            _taskProgressLabelAppearanceInitialized = true;
        }

        _taskProgressLabel.Font = completed ? _taskProgressLabelCompletedFont! : _taskProgressLabelDefaultFont!;
        _taskProgressLabel.ForeColor = completed ? Color.FromArgb(126, 230, 140) : _taskProgressLabelDefaultColor;
    }

    private static void SetProgressValue(DarkUI.Controls.DarkProgressBar progressBar, int value)
    {
        if (progressBar.Maximum != 100) progressBar.Maximum = 100;
        if (progressBar.Value != value) progressBar.Value = value;
    }

    private static int CalculateOverallProgress(QueueTaskProgress progress, QueueTaskStatus status)
    {
        if (status == QueueTaskStatus.Completed) return 100;
        int current = progress.TotalBytes > 0 ? (int)Math.Clamp(progress.CurrentBytes * 100 / progress.TotalBytes, 0, 99) :
            progress.TotalItems > 0 ? Math.Clamp(progress.CurrentItems * 100 / progress.TotalItems, 0, 99) : 0;
        if (progress.TotalSteps <= 1) return current;
        int completedStages = Math.Clamp(progress.Step - 1, 0, progress.TotalSteps - 1);
        return Math.Clamp((completedStages * 100 + current) / progress.TotalSteps, 0, 99);
    }

    private void OpenSelectedTaskOutput()
    {
        if (SelectedTask?.OutputPath is not string path) return;
        string target = File.Exists(path) ? Path.GetDirectoryName(path)! : path;
        if (Directory.Exists(target)) Process.Start(new ProcessStartInfo { FileName = target, UseShellExecute = true });
    }

    private void EnqueueMerge(PkgMergeRequest request, string displayName)
    {
        ShowNewQueuedTask(CreateMergeTask(request, displayName));
    }

    private QueuedPackageTask CreateMergeTask(PkgMergeRequest request, string displayName, Guid? id = null, PersistedQueueTask? saved = null)
        => _packageTaskFactory.CreateMerge(request, displayName, id, saved);

    private void EnqueueFfpfsc(FfpfscConvertOptions options, string displayName)
    {
        ShowNewQueuedTask(CreateFfpfscTask(options, displayName));
    }

    private QueuedPackageTask CreateFfpfscTask(FfpfscConvertOptions options, string displayName, Guid? id = null, PersistedQueueTask? saved = null)
        => _packageTaskFactory.CreateFfpfsc(options, displayName, id, saved);

    private void EnqueueFullExtraction(string pkgPath, string outputDirectory)
    {
        ShowNewQueuedTask(CreateExtractionTask(pkgPath, outputDirectory));
    }

    private QueuedPackageTask CreateExtractionTask(string pkgPath, string outputDirectory, string? displayName = null, Guid? id = null, PersistedQueueTask? saved = null)
        => _packageTaskFactory.CreateFullExtraction(pkgPath, outputDirectory, displayName, id, saved);

    private void EnqueueShadps4Install(Shadps4Manager.InstallRequest request)
    {
        ShowNewQueuedTask(CreateShadps4InstallTask(request));
    }

    private QueuedPackageTask CreateShadps4InstallTask(Shadps4Manager.InstallRequest request, Guid? id = null, PersistedQueueTask? saved = null)
    {
        string outputPath = Path.Combine(request.Library, request.TitleId);
        var payload = new Shadps4InstallQueuePayload(request.PkgPath, request.TitleId, request.Title, request.IsPatch,
            request.Library, request.Replace, request.Version, request.InstalledVersion);
        string packageRole = request.IsPatch ? "Patch" : "Base";
        var task = new QueuedPackageTask("ShadPS4 Install", $"{request.TitleId} {request.Title} ({packageRole})", request.PkgPath, outputPath,
            async (queued, ct) =>
            {
                if (Shadps4Manager.IsInstallationActive)
                    return new QueueTaskExecutionResult(false, "A direct shadPS4 installation is already running.");

                var stageProgress = new Progress<string>(stage =>
                {
                    int step = stage.StartsWith("Extracting", StringComparison.OrdinalIgnoreCase) ? 2
                        : stage.StartsWith("Arranging", StringComparison.OrdinalIgnoreCase) ? 3
                        : stage.StartsWith("Validating", StringComparison.OrdinalIgnoreCase) ? 4 : 5;
                    queued.Report(new QueueTaskProgress(stage, step, 5));
                });
                var fileProgress = new Progress<(int Current, int Total, string CurrentFile)>(p =>
                    queued.Report(new QueueTaskProgress("Extracting PKG", 2, 5, CurrentItems: p.Current + 1,
                        TotalItems: p.Total, CurrentFile: p.CurrentFile)));
                Shadps4InstallResult result = await Task.Run(() => new Shadps4InstallService().Install(
                    request.PkgPath, request.TitleId, request.Library, request.Replace, stageProgress, ct,
                    mergeIntoExisting: request.IsPatch, fileProgress: fileProgress), ct).ConfigureAwait(false);
                if (result.Status == Shadps4InstallStatus.Success)
                {
                    NotifyShadps4ManagerOfQueuedInstall();
                    RefreshShadps4InstalledFilterState();
                }
                return new QueueTaskExecutionResult(result.Status == Shadps4InstallStatus.Success, result.Message,
                    result.InstalledPath ?? outputPath);
            }, JsonSerializer.Serialize(payload), id);
        if (saved is not null) task.RestoreState(saved);
        return task;
    }

    private void NotifyShadps4ManagerOfQueuedInstall()
    {
        if (_shadps4Manager is null || _shadps4Manager.IsDisposed || !_shadps4Manager.IsHandleCreated) return;
        try { _shadps4Manager.BeginInvoke((Action)_shadps4Manager.RefreshGamesFromQueuedInstall); }
        catch (InvalidOperationException) { }
    }

    private void RefreshShadps4InstalledFilterState()
    {
        if (IsDisposed || !IsHandleCreated) return;
        try
        {
            BeginInvoke((Action)(() =>
            {
                if (PKGGridView.DataSource is not DataTable table) return;
                ApplyShadps4Status(table);
                ApplyFilters();
                PopulateGroupedView();
            }));
        }
        catch (InvalidOperationException) { }
    }

    private QueuedPackageTask? RestoreQueuedTask(PersistedQueueTask saved)
    {
        try
        {
            return saved.Type switch
            {
                "Merge PKG" => RestoreMergeTask(saved),
                "PKG → FFPFSC" => RestoreFfpfscTask(saved),
                "Full Extract" => RestoreExtractionTask(saved),
                "ShadPS4 Install" => RestoreShadps4InstallTask(saved),
                _ => null
            };
        }
        catch (JsonException) { return null; }
    }

    private QueuedPackageTask? RestoreMergeTask(PersistedQueueTask saved)
    {
        MergeQueuePayload? payload = JsonSerializer.Deserialize<MergeQueuePayload>(saved.Payload);
        if (payload is null) return null;
        var request = new PkgMergeRequest
        {
            BasePkgPath = payload.BasePkgPath, UpdatePkgPath = payload.UpdatePkgPath, OutputPkgPath = payload.OutputPkgPath,
            BasePasscode = payload.BasePasscode, UpdatePasscode = payload.UpdatePasscode, ValidateAfterBuild = payload.ValidateAfterBuild,
            PfscMode = payload.PfscMode, WorkerCount = payload.WorkerCount, WorkDirectory = payload.WorkDirectory,
            KeepWorkDirectory = payload.KeepWorkDirectory, CleanupWorkDirectoryOnFailure = payload.CleanupWorkDirectoryOnFailure,
            Title = payload.Title, TitleId = payload.TitleId, ContentId = payload.ContentId,
            SkipDiskSpaceCheck = payload.SkipDiskSpaceCheck
        };
        return CreateMergeTask(request, saved.DisplayName, saved.Id, saved);
    }

    private QueuedPackageTask? RestoreFfpfscTask(PersistedQueueTask saved)
    {
        FfpfscConvertOptions? options = JsonSerializer.Deserialize<FfpfscConvertOptions>(saved.Payload);
        return options is null ? null : CreateFfpfscTask(options, saved.DisplayName, saved.Id, saved);
    }

    private QueuedPackageTask? RestoreExtractionTask(PersistedQueueTask saved)
        => _packageTaskFactory.Restore(saved);

    private QueuedPackageTask? RestoreShadps4InstallTask(PersistedQueueTask saved)
    {
        Shadps4InstallQueuePayload? payload = JsonSerializer.Deserialize<Shadps4InstallQueuePayload>(saved.Payload);
        if (payload is null) return null;
        return CreateShadps4InstallTask(new Shadps4Manager.InstallRequest(payload.PkgPath, payload.TitleId,
            payload.Title, payload.IsPatch, payload.Library, payload.Replace, payload.Version, payload.InstalledVersion), saved.Id, saved);
    }

    private sealed record MergeQueuePayload(string BasePkgPath, string UpdatePkgPath, string? OutputPkgPath,
        string? BasePasscode, string? UpdatePasscode, bool ValidateAfterBuild, PfscMode PfscMode, int WorkerCount,
        string? WorkDirectory, bool KeepWorkDirectory, bool CleanupWorkDirectoryOnFailure, string? Title, string? TitleId, string? ContentId,
        bool SkipDiskSpaceCheck);

    private sealed record Shadps4InstallQueuePayload(string PkgPath, string TitleId, string Title, bool IsPatch,
        string Library, bool Replace, string Version, string InstalledVersion);

    private void SelectTasksTab()
    {
        if (_tasksTab is not null) mainTabControl.SelectedTab = _tasksTab;
    }

    private void ShowNewQueuedTask(QueuedPackageTask task)
    {
        TrackTaskQueueBatch(task);
        _taskQueue.Enqueue(task);
        SelectTasksTab();
        RefreshTaskGrid();
        Guid? runningTaskId = _taskQueue.Tasks.FirstOrDefault(queuedTask =>
            queuedTask.Status is QueueTaskStatus.Running or QueueTaskStatus.Cancelling)?.Id;
        SelectTaskRow(runningTaskId ?? task.Id, focusGrid: true);
        UpdateSelectedTaskDetails();
    }
}
