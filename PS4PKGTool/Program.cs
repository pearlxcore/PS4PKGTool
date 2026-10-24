using DarkUI.Config;
using PS4PKGTool.Core.Diagnostics;
using PS4PKGTool.Shell;
using PS4PKGTool.Startup;
using PS4PKGTool.Utilities.PS4PKGToolHelper;
using PS4PKGTool.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PS4PKGTool.Utilities.PS4PKGToolHelper.Helper;

namespace PS4PKGTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Per-monitor v2 DPI awareness, before any window is created:
            // without it Windows renders at 96 DPI and bitmap-stretches the
            // app onto scaled displays (4K @ 200%), making all text blurry.
            // The app.manifest requests the same mode at the OS level; if
            // that already applied it, this call is a harmless no-op.
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Global exception logging: unhandled failures write the full stack
            // to crash.log next to the exe instead of dying silently.
            Application.ThreadException += (s, e) => LogCrash(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                LogCrash(e.ExceptionObject as Exception ?? new Exception(e.ExceptionObject?.ToString()));

            EnsureSettingsFileExists();

            // Bridge UI-free Core diagnostics into the app's Logger.
            CoreLog.Information = Logger.LogInformation;
            CoreLog.Warning = Logger.LogWarning;

            appSettings_ = LoadSettings(SettingFilePath);

            // Apply saved theme before showing any form (avoids flash of default)
            Theme savedTheme = ThemeManager.Presets.FirstOrDefault(theme =>
                string.Equals(theme.Name, appSettings_.ThemeName, StringComparison.Ordinal));
            int themeIdx = appSettings_.ThemeIndex;
            // Theme indices change as presets are retired. Only use the old
            // index fallback for settings files created before ThemeName existed.
            savedTheme ??= string.IsNullOrWhiteSpace(appSettings_.ThemeName)
                && themeIdx >= 0 && themeIdx < ThemeManager.Presets.Count
                ? ThemeManager.Presets[themeIdx]
                : null;
            if (savedTheme != null)
                ThemeManager.Apply(savedTheme);

            // Explorer shell integration: install/remove the .pkg context
            // menu (also available from Program Settings).
            if (args.Length == 1 && string.Equals(args[0], "--shell-register", StringComparison.OrdinalIgnoreCase))
            {
                ShellRegistry.Install();
                appSettings_.ShellIntegrationInstalled = ShellRegistry.IsInstalled();
                SettingsManager.SaveSettings(appSettings_, SettingFilePath);
                Logger.LogInformation("Shell integration registered: " + appSettings_.ShellIntegrationInstalled);
                return;
            }
            if (args.Length == 1 && string.Equals(args[0], "--shell-unregister", StringComparison.OrdinalIgnoreCase))
            {
                ShellRegistry.Remove();
                appSettings_.ShellIntegrationInstalled = false;
                SettingsManager.SaveSettings(appSettings_, SettingFilePath);
                Logger.LogInformation("Shell integration removed.");
                return;
            }

            // Explorer shell integration: PS4PKGTool.exe --shell <cmd> ...
            // Runs ONLY what the command needs - no Main form, no Mini
            // Viewer, no library scan.
            if (ShellCommandRouter.IsShellMode(args))
            {
                var shellRequest = ShellCommandRouter.Parse(args);
                string? shellError = shellRequest == null
                    ? "The shell command is not recognized.\n\n" +
                      "Usage:\n" +
                      "  PS4PKGTool.exe --shell copy <field> <package>...\n" +
                      "  PS4PKGTool.exe --shell rename <formatId> <package>...\n" +
                      "  PS4PKGTool.exe --shell validate <package>...\n" +
                      "  PS4PKGTool.exe --shell extract <package>...\n" +
                      "  PS4PKGTool.exe --shell install-shadps4 <package>..."
                    : ShellCommandRouter.ValidatePaths(shellRequest.PackagePaths);
                if (shellError != null)
                {
                    AppMessageBox.Show("PS4 PKG Tool", shellError, AppMessageType.Error, AppMessageButtons.OK);
                    return;
                }
                ShellCommands.Run(shellRequest);
                return;
            }

            StartupRoute route = StartupArgumentRouter.Route(args);
            if (route.Kind == StartupRouteKind.InvalidArguments)
            {
                AppMessageBox.Show(
                    "PKG Viewer",
                    route.ErrorMessage,
                    AppMessageType.Error,
                    AppMessageButtons.OK);
                return;
            }

            if (route.Kind == StartupRouteKind.MiniPkgViewer)
            {
                Application.Run(new MiniPkgViewerForm(route.PackagePath));
                return;
            }

            // Keep the existing no-argument startup path unchanged.
            ChooseStartupForm();
        }

        private static void LogCrash(Exception ex)
        {
            string log = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "crash.log");
            try
            {
                System.IO.File.WriteAllText(log, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}\n{ex}");
                return;
            }
            catch
            {
                // The portable exe-adjacent path is normally writable, but a
                // read-only install dir (Program Files) or a locked file can
                // silently lose the crash dump. Fall back to %TEMP% so the
                // stack trace survives - it is the only post-mortem clue.
            }

            try
            {
                string fallback = System.IO.Path.Combine(
                    System.IO.Path.GetTempPath(), "PS4PKGTool-crash.log");
                System.IO.File.WriteAllText(fallback,
                    $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} (fallback - exe dir was not writable)\n{ex}");
            }
            catch { /* nowhere left to write */ }
        }

        private static void EnsureSettingsFileExists()
        {
            // Caches stay next to the exe (portable, regenerable); durable data
            // lives in the fixed per-user folder so a new build in a new folder
            // reuses settings, the library manifest, the task queue and the
            // managed shadPS4 builds.
            if (!Directory.Exists(Helper.AppDataDirectory))
                Directory.CreateDirectory(Helper.AppDataDirectory);
            if (!Directory.Exists(Helper.UserDataDirectory))
                Directory.CreateDirectory(Helper.UserDataDirectory);

            // First-run migrations into the fixed per-user folder. The previous
            // exe-adjacent layout wins over the older %APPDATA% layout when both
            // are present (each item is only moved when the target is missing).
            MigrateDurableDataToUserProfile();
            MigrateLegacyUserSettingsBack();

            if (!File.Exists(SettingFilePath) || new FileInfo(SettingFilePath).Length == 0)
            {
                CreateDefaultSettings();
            }
        }

        /// <summary>
        /// Moves durable data from the previous exe-adjacent AppData layout into
        /// the fixed per-user folder. Best effort per item, and only when the
        /// destination is still missing, so nothing is overwritten or lost.
        /// </summary>
        private static void MigrateDurableDataToUserProfile()
        {
            string source = Helper.AppDataDirectory;
            string target = Helper.UserDataDirectory;
            // The log first: every later migration logs, which would create the
            // destination log and make this move skip.
            MigrateFile(source, target, "PS4PKGToolLog.txt");
            MigrateFile(source, target, "Settings.conf");
            MigrateFile(source, target, "manifest.json");
            MigrateFile(source, target, "task-queue.json");
            MigrateFile(source, target, "task-queue.json.bak");
            MigrateFile(source, target, "game-feedback.jsonl");
            MigrateDirectory(source, target, "Shadps4Reports");
            MigrateDirectory(source, target, "shadPS4");
        }

        /// <summary>
        /// Moves settings, feedback history and report snapshots from the
        /// historical %APPDATA%\PS4PKGTool folder into the fixed per-user
        /// folder. Best effort per item: failures are logged and skipped
        /// (missing settings fall back to defaults).
        /// </summary>
        private static void MigrateLegacyUserSettingsBack()
        {
            string legacyRoot = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "PS4PKGTool");
            if (!Directory.Exists(legacyRoot)) return;

            MigrateFile(legacyRoot, Helper.UserDataDirectory, "Settings.conf");
            MigrateFile(legacyRoot, Helper.UserDataDirectory, "game-feedback.jsonl");
            MigrateDirectory(legacyRoot, Helper.UserDataDirectory, "Shadps4Reports");

            // The legacy folder is PS4PKGTool's alone - remove it when empty.
            try
            {
                if (Directory.Exists(legacyRoot) && !Directory.EnumerateFileSystemEntries(legacyRoot).Any())
                    Directory.Delete(legacyRoot);
            }
            catch { /* best-effort: a non-empty or locked legacy folder is left behind */ }
        }

        private static void MigrateFile(string sourceRoot, string targetRoot, string fileName)
        {
            string source = Path.Combine(sourceRoot, fileName);
            string target = Path.Combine(targetRoot, fileName);
            try
            {
                if (File.Exists(target) || !File.Exists(source) || new FileInfo(source).Length == 0)
                    return;
                File.Move(source, target); // File.Move copies+deletes across volumes
                Logger.LogInformation("Migrated " + fileName + " to " + target);
            }
            catch (Exception ex)
            {
                Logger.LogInformation(fileName + " migration failed: " + ex.Message);
            }
        }

        private static void MigrateDirectory(string sourceRoot, string targetRoot, string dirName)
        {
            string source = Path.Combine(sourceRoot, dirName);
            string target = Path.Combine(targetRoot, dirName);
            try
            {
                if (Directory.Exists(target) || !Directory.Exists(source))
                    return;
                if (!Directory.EnumerateFileSystemEntries(source).Any())
                {
                    Directory.Delete(source); // empty - nothing worth moving
                    return;
                }
                try
                {
                    Directory.Move(source, target);
                }
                catch (IOException)
                {
                    CopyDirectory(source, target); // cross-volume fallback
                    Directory.Delete(source, true);
                }
                Logger.LogInformation("Migrated " + dirName + " to " + target);
            }
            catch (Exception ex)
            {
                Logger.LogInformation(dirName + " migration failed: " + ex.Message);
            }
        }

        private static void CopyDirectory(string sourceDir, string targetDir)
        {
            Directory.CreateDirectory(targetDir);
            foreach (string file in Directory.GetFiles(sourceDir))
                File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)));
            foreach (string dir in Directory.GetDirectories(sourceDir))
                CopyDirectory(dir, Path.Combine(targetDir, Path.GetFileName(dir)));
        }

        private static void CreateDefaultSettings()
        {
            string defaultSettings =
    @"pkg_directories=
scan_recursive=False
play_bgm=False
auto_sort_row=False
local_server_ip=
ps4_ip=
nodeJs_installed=
httpServer_installed=
official_update_download_directory=
pkg_color_label=False
game_pkg_forecolor=-2302756
patch_pkg_forecolor=-2302756
addon_pkg_forecolor=-2302756
app_pkg_forecolor=-2302756
game_pkg_backcolor=-12828863
patch_pkg_backcolor=-12828863
addon_pkg_backcolor=-12828863
app_pkg_backcolor=-12828863
rename_custom_format=
ps5bc_json_download_date=
psvr_neo_ps5bc_check=
pkg_titleId_column=True
pkg_contentId_column=True
pkg_region_column=True
pkg_minimum_firmware_column=True
pkg_version_column=True
pkg_type_column=True
pkg_category_column=True
pkg_size_column=True
pkg_location_column=True
pkg_backport_column=True
auto_fetch_update=False
theme_index=0
shadps4_check=False";
            File.WriteAllText(SettingFilePath, defaultSettings);
        }

        private static void ChooseStartupForm()
        {
            // Determine what's available
            bool manifestAvailable = false;
            int manifestEntryCount = 0;

            if (ManifestHelper.ManifestExists()
                && appSettings_.PkgDirectories.Count > 0
                && appSettings_.PkgDirectories.Any(d => !string.IsNullOrEmpty(d)))
            {
                var manifest = ManifestHelper.LoadManifest();
                if (manifest != null)
                {
                    var (isValid, reason) = ManifestHelper.ValidateManifest(manifest, appSettings_);
                    if (isValid)
                    {
                        manifestAvailable = true;
                        manifestEntryCount = manifest.Entries?.Count ?? 0;
                    }
                    else
                    {
                        Logger.LogInformation($"Manifest invalid: {reason}.");
                    }
                }
            }

            bool directoriesAvailable = appSettings_.PkgDirectories.Count > 0
                && appSettings_.PkgDirectories.Any(d => !string.IsNullOrEmpty(d));
            int directoryCount = appSettings_.PkgDirectories.Count(d => !string.IsNullOrEmpty(d));

            // Show 3-option startup dialog
            using (var prompt = new ManifestLoaderPrompt(
                manifestAvailable, manifestEntryCount,
                directoriesAvailable, directoryCount))
            {
                if (prompt.ShowDialog() != DialogResult.OK)
                    return; // User clicked X - exit

                switch (prompt.Choice)
                {
                    case StartupChoice.Manifest:
                        Helper.LoadFromManifest = true;
                        break;
                    case StartupChoice.Directory:
                        Helper.LoadFromManifest = false;
                        break;
                    case StartupChoice.Empty:
                        Helper.LoadFromManifest = false;
                        Helper.LaunchEmpty = true;
                        break;
                }
            }

            Application.Run(new Main());
        }
    }
}
