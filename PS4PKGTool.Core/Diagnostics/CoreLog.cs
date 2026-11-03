namespace PS4PKGTool.Core.Diagnostics;

/// <summary>
/// Minimal logging seam so UI-free Core code can report diagnostics without
/// referencing the WinForms app's <c>Logger</c>. The app wires these delegates
/// to <c>Logger.LogInformation</c> / <c>Logger.LogWarning</c> at startup; when
/// unset (e.g. library consumers, tests) logging is a no-op.
/// </summary>
public static class CoreLog
{
    public static Action<string>? Information { get; set; }
    public static Action<string>? Warning { get; set; }
    public static Action<string>? Error { get; set; }

    public static void Info(string message) => Information?.Invoke(message);

    public static void Warn(string message) => Warning?.Invoke(message);

    public static void Err(string message) => Error?.Invoke(message);
}
