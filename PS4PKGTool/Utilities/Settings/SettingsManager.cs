using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS4PKGTool.Utilities.Shadps4;

namespace PS4PKGTool.Utilities.Settings
{
    public static class SettingsManager
    {
        public static AppSettings appSettings_ = new AppSettings();
        // Durable settings live in the fixed per-user folder so they survive
        // updates and folder changes. The historical exe-adjacent AppData and
        // %APPDATA%\PS4PKGTool layouts are migrated on first run
        // (Program.EnsureSettingsFileExists).
        public static string SettingFilePath = Path.Combine(PS4PKGToolHelper.Helper.UserDataDirectory, "Settings.conf");

        // Serializes load/save so concurrent saves cannot race on the
        // temp-file move and a save cannot interleave with a reload.
        private static readonly object SyncRoot = new object();

        public static void SaveSettings(AppSettings settings, string filePath)
        {
            lock (SyncRoot)
            {
                SaveSettingsCore(settings, filePath);
            }
        }

        // Values are written one per line, so a stray CR/LF inside a string
        // value would inject arbitrary extra settings keys. No legitimate
        // setting (path, IP, rename format) contains a newline, so collapse
        // them to spaces on write; existing values are unaffected.
        private static string AsSingleLine(string? value)
            => value is null ? string.Empty : value.Replace('\r', ' ').Replace('\n', ' ');

        private static void SaveSettingsCore(AppSettings settings, string filePath)
        {
            string? temporaryPath = null;
            try
            {
                string? directory = Path.GetDirectoryName(Path.GetFullPath(filePath));
                if (!string.IsNullOrEmpty(directory))
                    Directory.CreateDirectory(directory);
                temporaryPath = filePath + "." + Guid.NewGuid().ToString("N") + ".tmp";
                using (StreamWriter writer = new StreamWriter(temporaryPath, false, new UTF8Encoding(false)))
                {
                    // One entry per line preserves legal commas in Windows paths.
                    // LoadSettings still accepts the historical comma-delimited key.
                    writer.WriteLine("pkg_directories_format=2");
                    foreach (string pkgDirectory in settings.PkgDirectories.Where(path => !string.IsNullOrWhiteSpace(path)))
                        writer.WriteLine($"pkg_directory={AsSingleLine(pkgDirectory)}");
                    writer.WriteLine($"scan_recursive={settings.ScanRecursive}");
                    writer.WriteLine($"play_bgm={settings.PlayBgm}");
                    writer.WriteLine($"auto_sort_row={settings.AutoSortRow}");
                    writer.WriteLine($"local_server_ip={AsSingleLine(settings.LocalServerIp)}");
                    writer.WriteLine($"ps4_ip={AsSingleLine(settings.Ps4Ip)}");
                    writer.WriteLine($"nodeJs_installed={settings.NodeJsInstalled}");
                    writer.WriteLine($"httpServer_installed={settings.HttpServerInstalled}");
                    writer.WriteLine($"official_update_download_directory={AsSingleLine(settings.OfficialUpdateDownloadDirectory)}");
                    writer.WriteLine($"pkg_color_label={settings.PkgColorLabel}");
                    writer.WriteLine($"game_pkg_forecolor={settings.GamePkgForeColor.ToArgb()}");
                    writer.WriteLine($"patch_pkg_forecolor={settings.PatchPkgForeColor.ToArgb()}");
                    writer.WriteLine($"addon_pkg_forecolor={settings.AddonPkgForeColor.ToArgb()}");
                    writer.WriteLine($"app_pkg_forecolor={settings.AppPkgForeColor.ToArgb()}");
                    writer.WriteLine($"game_pkg_backcolor={settings.GamePkgBackColor.ToArgb()}");
                    writer.WriteLine($"patch_pkg_backcolor={settings.PatchPkgBackColor.ToArgb()}");
                    writer.WriteLine($"addon_pkg_backcolor={settings.AddonPkgBackColor.ToArgb()}");
                    writer.WriteLine($"app_pkg_backcolor={settings.AppPkgBackColor.ToArgb()}");
                    writer.WriteLine($"rename_custom_format={AsSingleLine(settings.RenameCustomName)}");
                    string formattedDate = settings.Ps5BcJsonLastDownloadDate.ToString("d MMMM yyyy", CultureInfo.InvariantCulture);
                    writer.WriteLine($"ps5bc_json_download_date={formattedDate}");
                    writer.WriteLine($"psvr_neo_ps5bc_check={settings.psvr_neo_ps5bc_check}");

                    writer.WriteLine($"pkg_titleId_column={settings.pkgtitleIdColumn}");
                    writer.WriteLine($"pkg_contentId_column={settings.pkgcontentIdColumn}");
                    writer.WriteLine($"pkg_region_column={settings.pkgregionColumn}");
                    writer.WriteLine($"pkg_minimum_firmware_column={settings.pkgminimumFirmwareColumn}");
                    writer.WriteLine($"pkg_version_column={settings.pkgversionColumn}");
                    writer.WriteLine($"pkg_type_column={settings.pkgTypeColumn}");
                    writer.WriteLine($"pkg_category_column={settings.pkgcategoryColumn}");
                    writer.WriteLine($"pkg_size_column={settings.pkgsizeColumn}");
                    writer.WriteLine($"pkg_location_column={settings.pkgDirectoryColumn}");
                    writer.WriteLine($"pkg_backport_column={settings.pkgBackportColumn}");
                    writer.WriteLine($"auto_fetch_update={settings.AutoFetchUpdate}");
                    writer.WriteLine($"theme_index={settings.ThemeIndex}");
                    writer.WriteLine($"theme_name={AsSingleLine(settings.ThemeName)}");
                    writer.WriteLine($"shadps4_check={settings.Shadps4Check}");
                    writer.WriteLine($"shadps4_os={AsSingleLine(settings.Shadps4Os)}");
                    writer.WriteLine($"shadps4_executable={AsSingleLine(settings.Shadps4ExecutablePath)}");
                    writer.WriteLine($"shadps4_active_core={AsSingleLine(settings.Shadps4ActiveCore)}");
                    writer.WriteLine($"shadps4_active_launcher={AsSingleLine(settings.Shadps4ActiveLauncher)}");
                    writer.WriteLine($"shadps4_managed_root={AsSingleLine(settings.Shadps4ManagedRoot)}");
                    writer.WriteLine($"shadps4_install_directory={AsSingleLine(settings.Shadps4InstallDirectory)}");
                    writer.WriteLine($"orbis_temp_directory={AsSingleLine(settings.OrbisTempDirectory)}");
                    writer.WriteLine($"ignore_disk_space_check={settings.IgnoreDiskSpaceCheck}");
                    writer.WriteLine($"shadps4_config_detection_dismissed={settings.Shadps4ConfigDetectionDismissed}");
                    writer.WriteLine($"shell_integration_installed={settings.ShellIntegrationInstalled}");
                }
                File.Move(temporaryPath, filePath, true);
                temporaryPath = null;
            }
            catch (Exception ex)
            {
                ShowError("Error saving settings: " + ex.Message, true);
            }
            finally
            {
                if (!string.IsNullOrEmpty(temporaryPath))
                {
                    try { File.Delete(temporaryPath); } catch { }
                }
            }
        }

        public static AppSettings LoadSettings(string filePath)
        {
            lock (SyncRoot)
            {
                return LoadSettingsCore(filePath);
            }
        }

        private static AppSettings LoadSettingsCore(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    bool loadedGlobalOrbisTemp = false;
                    bool loadedPkgDirectoryEntries = false;
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Equals("pkg_directories_format=2", StringComparison.Ordinal))
                            {
                                appSettings_.PkgDirectories.Clear();
                                loadedPkgDirectoryEntries = true;
                            }
                            else if (line.StartsWith("pkg_directory=", StringComparison.Ordinal))
                            {
                                if (!loadedPkgDirectoryEntries)
                                {
                                    appSettings_.PkgDirectories.Clear();
                                    loadedPkgDirectoryEntries = true;
                                }
                                string directory = line.Substring("pkg_directory=".Length);
                                if (!string.IsNullOrWhiteSpace(directory))
                                    appSettings_.PkgDirectories.Add(directory);
                            }
                            else if (line.StartsWith("pkg_directories=", StringComparison.Ordinal))
                            {
                                string directories = line.Substring("pkg_directories=".Length);
                                // Legacy format. It cannot represent commas in a path,
                                // but must remain readable for existing installations.
                                if (!loadedPkgDirectoryEntries)
                                {
                                    appSettings_.PkgDirectories.Clear();
                                    appSettings_.PkgDirectories.AddRange(directories.Split(',').Where(d => !string.IsNullOrEmpty(d)));
                                }
                            }
                            else if (line.StartsWith("scan_recursive="))
                            {
                                bool.TryParse(line.Substring("scan_recursive=".Length), out bool scan_recursive);
                                appSettings_.ScanRecursive = scan_recursive;
                            }
                            else if (line.StartsWith("play_bgm="))
                            {
                                bool.TryParse(line.Substring("play_bgm=".Length), out bool PlayBgm);
                                appSettings_.PlayBgm = PlayBgm;
                            }
                            else if (line.StartsWith("auto_sort_row"))
                            {
                                bool.TryParse(line.Substring("auto_sort_row=".Length), out bool auto_sort_row);
                                appSettings_.AutoSortRow = auto_sort_row;
                            }
                            else if (line.StartsWith("local_server_ip="))
                            {
                                appSettings_.LocalServerIp = line.Substring("local_server_ip=".Length);
                            }
                            else if (line.StartsWith("ps4_ip="))
                            {
                                appSettings_.Ps4Ip = line.Substring("ps4_ip=".Length);
                            }
                            else if (line.StartsWith("nodeJs_installed="))
                            {
                                bool.TryParse(line.Substring("nodeJs_installed=".Length), out bool nodeJs_installed);
                                appSettings_.NodeJsInstalled = nodeJs_installed;
                            }
                            else if (line.StartsWith("httpServer_installed="))
                            {
                                bool.TryParse(line.Substring("httpServer_installed=".Length), out bool httpServer_installed);
                                appSettings_.HttpServerInstalled = httpServer_installed;
                            }
                            else if (line.StartsWith("official_update_download_directory="))
                            {
                                appSettings_.OfficialUpdateDownloadDirectory = line.Substring("official_update_download_directory=".Length);
                            }
                            else if (line.StartsWith("pkg_color_label="))
                            {
                                bool.TryParse(line.Substring("pkg_color_label=".Length), out bool pkg_color_label);
                                appSettings_.PkgColorLabel = pkg_color_label;
                            }
                            else if (line.StartsWith("game_pkg_forecolor="))
                            {
                                if (int.TryParse(line.Substring("game_pkg_forecolor=".Length), out int v))
                                    appSettings_.GamePkgForeColor = Color.FromArgb(v);
                            }
                            else if (line.StartsWith("patch_pkg_forecolor="))
                            {
                                if (int.TryParse(line.Substring("patch_pkg_forecolor=".Length), out int v))
                                    appSettings_.PatchPkgForeColor = Color.FromArgb(v);
                            }
                            else if (line.StartsWith("addon_pkg_forecolor="))
                            {
                                if (int.TryParse(line.Substring("addon_pkg_forecolor=".Length), out int v))
                                    appSettings_.AddonPkgForeColor = Color.FromArgb(v);
                            }
                            else if (line.StartsWith("app_pkg_forecolor="))
                            {
                                if (int.TryParse(line.Substring("app_pkg_forecolor=".Length), out int v))
                                    appSettings_.AppPkgForeColor = Color.FromArgb(v);
                            }
                            else if (line.StartsWith("game_pkg_backcolor="))
                            {
                                if (int.TryParse(line.Substring("game_pkg_backcolor=".Length), out int v))
                                    appSettings_.GamePkgBackColor = Color.FromArgb(v);
                            }
                            else if (line.StartsWith("patch_pkg_backcolor="))
                            {
                                if (int.TryParse(line.Substring("patch_pkg_backcolor=".Length), out int v))
                                    appSettings_.PatchPkgBackColor = Color.FromArgb(v);
                            }
                            else if (line.StartsWith("addon_pkg_backcolor="))
                            {
                                if (int.TryParse(line.Substring("addon_pkg_backcolor=".Length), out int v))
                                    appSettings_.AddonPkgBackColor = Color.FromArgb(v);
                            }
                            else if (line.StartsWith("app_pkg_backcolor="))
                            {
                                if (int.TryParse(line.Substring("app_pkg_backcolor=".Length), out int v))
                                    appSettings_.AppPkgBackColor = Color.FromArgb(v);
                            }
                            else if (line.StartsWith("rename_custom_format="))
                            {
                                appSettings_.RenameCustomName = line.Substring("rename_custom_format=".Length);
                            }
                            else if (line.StartsWith("ps5bc_json_download_date="))
                            {
                                string[] formats = { "d MMMM yyyy" }; // Example: "3 June 2023", "03 June 2023"
                                string dateString = line.Substring("ps5bc_json_download_date=".Length);

                                if (!string.IsNullOrEmpty(dateString))
                                {
                                    DateTime convertedDate;
                                    if (DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out convertedDate))
                                    {
                                        appSettings_.Ps5BcJsonLastDownloadDate = convertedDate;
                                    }
                                }
                            }
                            else if (line.StartsWith("psvr_neo_ps5bc_check="))
                            {
                                bool.TryParse(line.Substring("psvr_neo_ps5bc_check=".Length), out bool psvr_neo_ps5bc_check);
                                appSettings_.psvr_neo_ps5bc_check = psvr_neo_ps5bc_check;
                            }
                            else if (line.StartsWith("pkg_titleId_column="))
                            {
                                bool.TryParse(line.Substring("pkg_titleId_column=".Length), out bool pkg_titleId_column);
                                appSettings_.pkgtitleIdColumn = pkg_titleId_column;
                            }
                            else if (line.StartsWith("pkg_contentId_column="))
                            {
                                bool.TryParse(line.Substring("pkg_contentId_column=".Length), out bool pkg_contentId_column);
                                appSettings_.pkgcontentIdColumn = pkg_contentId_column;
                            }
                            else if (line.StartsWith("pkg_region_column="))
                            {
                                bool.TryParse(line.Substring("pkg_region_column=".Length), out bool pkg_region_column);
                                appSettings_.pkgregionColumn = pkg_region_column;
                            }
                            else if (line.StartsWith("pkg_minimum_firmware_column="))
                            {
                                bool.TryParse(line.Substring("pkg_minimum_firmware_column=".Length), out bool pkg_minimum_firmware_column);
                                appSettings_.pkgminimumFirmwareColumn = pkg_minimum_firmware_column;
                            }
                            else if (line.StartsWith("pkg_version_column="))
                            {
                                bool.TryParse(line.Substring("pkg_version_column=".Length), out bool pkg_version_column);
                                appSettings_.pkgversionColumn = pkg_version_column;
                            }
                            else if (line.StartsWith("pkg_type_column="))
                            {
                                bool.TryParse(line.Substring("pkg_type_column=".Length), out bool pkg_type_column);
                                appSettings_.pkgTypeColumn = pkg_type_column;
                            }
                            else if (line.StartsWith("pkg_category_column="))
                            {
                                bool.TryParse(line.Substring("pkg_category_column=".Length), out bool pkg_category_column);
                                appSettings_.pkgcategoryColumn = pkg_category_column;
                            }
                            else if (line.StartsWith("pkg_size_column="))
                            {
                                bool.TryParse(line.Substring("pkg_size_column=".Length), out bool pkg_size_column);
                                appSettings_.pkgsizeColumn = pkg_size_column;
                            }
                            else if (line.StartsWith("pkg_location_column="))
                            {
                                bool.TryParse(line.Substring("pkg_location_column=".Length), out bool pkg_location_column);
                                appSettings_.pkgDirectoryColumn = pkg_location_column;
                            }
                            else if (line.StartsWith("pkg_backport_column="))
                            {
                                bool.TryParse(line.Substring("pkg_backport_column=".Length), out bool pkg_backport_column);
                                appSettings_.pkgBackportColumn = pkg_backport_column;
                            }
                            else if (line.StartsWith("auto_fetch_update="))
                            {
                                bool.TryParse(line.Substring("auto_fetch_update=".Length), out bool auto_fetch_update);
                                appSettings_.AutoFetchUpdate = auto_fetch_update;
                            }
                            else if (line.StartsWith("theme_index="))
                            {
                                int.TryParse(line.Substring("theme_index=".Length), out int theme_index);
                                appSettings_.ThemeIndex = theme_index;
                            }
                            else if (line.StartsWith("theme_name="))
                            {
                                appSettings_.ThemeName = line.Substring("theme_name=".Length).Trim();
                            }
                            else if (line.StartsWith("shadps4_check="))
                            {
                                bool.TryParse(line.Substring("shadps4_check=".Length), out bool shadps4_check);
                                appSettings_.Shadps4Check = shadps4_check;
                            }
                            else if (line.StartsWith("shadps4_os="))
                            {
                                string os = line.Substring("shadps4_os=".Length).Trim().ToLowerInvariant();
                                appSettings_.Shadps4Os = os is "linux" or "macos" ? os : "windows";
                            }
                            else if (line.StartsWith("shadps4_executable="))
                            {
                                appSettings_.Shadps4ExecutablePath = line.Substring("shadps4_executable=".Length).Trim();
                            }
                            else if (line.StartsWith("shadps4_active_core="))
                            {
                                appSettings_.Shadps4ActiveCore = line.Substring("shadps4_active_core=".Length).Trim();
                            }
                            else if (line.StartsWith("shadps4_active_launcher="))
                            {
                                appSettings_.Shadps4ActiveLauncher = line.Substring("shadps4_active_launcher=".Length).Trim();
                            }
                            else if (line.StartsWith("shadps4_managed_root="))
                            {
                                appSettings_.Shadps4ManagedRoot = line.Substring("shadps4_managed_root=".Length).Trim();
                            }
                            else if (line.StartsWith("shadps4_install_directory="))
                            {
                                appSettings_.Shadps4InstallDirectory = line.Substring("shadps4_install_directory=".Length).Trim();
                            }
                            else if (line.StartsWith("orbis_temp_directory="))
                            {
                                appSettings_.OrbisTempDirectory = line.Substring("orbis_temp_directory=".Length).Trim();
                                loadedGlobalOrbisTemp = true;
                            }
                            else if (line.StartsWith("ignore_disk_space_check="))
                            {
                                bool.TryParse(line.Substring("ignore_disk_space_check=".Length).Trim(), out bool ignoreDiskSpaceCheck);
                                appSettings_.IgnoreDiskSpaceCheck = ignoreDiskSpaceCheck;
                            }
                            // Migration from the short-lived shadPS4-only setting.
                            else if (line.StartsWith("shadps4_orbis_temp_directory=")
                                && !loadedGlobalOrbisTemp)
                            {
                                appSettings_.OrbisTempDirectory = line.Substring("shadps4_orbis_temp_directory=".Length).Trim();
                            }
                            else if (line.StartsWith("shadps4_core_exe="))
                            {
                                appSettings_.Shadps4CoreExePath = line.Substring("shadps4_core_exe=".Length).Trim();
                            }
                            else if (line.StartsWith("shadps4_config_detection_dismissed="))
                            {
                                bool.TryParse(line.Substring("shadps4_config_detection_dismissed=".Length).Trim(), out bool dismissed);
                                appSettings_.Shadps4ConfigDetectionDismissed = dismissed;
                            }
                            else if (line.StartsWith("shadps4_launcher_exe="))
                            {
                                appSettings_.Shadps4LauncherExePath = line.Substring("shadps4_launcher_exe=".Length).Trim();
                            }
                            else if (line.StartsWith("shell_integration_installed="))
                            {
                                bool.TryParse(line.Substring("shell_integration_installed=".Length).Trim(), out bool installed);
                                appSettings_.ShellIntegrationInstalled = installed;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                ShowError("Error loading settings: " + ex.Message, true);
            }

            NormalizePkgDirectories(appSettings_.PkgDirectories);
            MigrateShadps4ActiveKeys(appSettings_);
            return appSettings_;
        }

        /// <summary>
        /// One-time migration to the explicit active-core/launcher model.
        /// Runs only when the new keys are empty, so it never overrides a
        /// value the user set, and the migrated value is persisted on the
        /// next settings save (legacy keys are then never consulted again).
        /// Rules: legacy core/launcher paths become adopted references; the
        /// legacy single executable becomes the adopted core or launcher
        /// depending on its filename.
        /// </summary>
        private static void MigrateShadps4ActiveKeys(AppSettings s)
        {
            if (string.IsNullOrWhiteSpace(s.Shadps4ActiveCore))
            {
                string core = s.Shadps4CoreExePath ?? "";
                if (string.IsNullOrWhiteSpace(core) && IsCoreFileName(s.Shadps4ExecutablePath))
                    core = s.Shadps4ExecutablePath;
                if (!string.IsNullOrWhiteSpace(core))
                    s.Shadps4ActiveCore = Shadps4ActiveCore.ForAdopted(core);
            }

            if (string.IsNullOrWhiteSpace(s.Shadps4ActiveLauncher))
            {
                string launcher = s.Shadps4LauncherExePath ?? "";
                if (string.IsNullOrWhiteSpace(launcher) && IsLauncherFileName(s.Shadps4ExecutablePath))
                    launcher = s.Shadps4ExecutablePath;
                if (!string.IsNullOrWhiteSpace(launcher))
                    s.Shadps4ActiveLauncher = Shadps4ActiveCore.ForAdopted(launcher);
            }
        }

        /// <summary>
        /// True when the shadPS4 setup can be offered for reuse: settings
        /// have no active core/launcher AND the managed store holds builds
        /// AND the user has not previously declined the prompt. The caller
        /// shows a confirmation dialog before applying (AutoHealShadps4Settings).
        /// </summary>
        public static bool CanHealShadps4Settings(AppSettings s, Shadps4ManagedBuilds? store = null)
        {
            if (s.Shadps4ConfigDetectionDismissed) return false;
            if (!string.IsNullOrWhiteSpace(s.Shadps4ActiveCore)
                || !string.IsNullOrWhiteSpace(s.Shadps4ActiveLauncher))
                return false;

            store ??= new Shadps4ManagedBuilds(s.Shadps4ManagedRoot);
            return store.ListBuilds(Shadps4Component.Core).Count > 0
                || store.ListBuilds(Shadps4Component.QtLauncher).Count > 0;
        }

        /// <summary>
        /// Rebuilds the shadPS4 setup from the managed store when settings
        /// are missing or empty (wiped file, fresh machine, copied install).
        /// Each field is healed only when it is empty - a value the user set
        /// is never overridden. Rules are deterministic, never guessed:
        /// newest installed core/launcher build wins, install dir falls back
        /// to &lt;managed root&gt;\Data, and the root is recorded explicitly so the
        /// config stays self-describing.
        /// </summary>
        public static bool AutoHealShadps4Settings(AppSettings s, Shadps4ManagedBuilds? store = null)
        {
            store ??= new Shadps4ManagedBuilds(s.Shadps4ManagedRoot);
            bool changed = false;

            var cores = store.ListBuilds(Shadps4Component.Core);
            var launchers = store.ListBuilds(Shadps4Component.QtLauncher);

            if (string.IsNullOrWhiteSpace(s.Shadps4ManagedRoot))
            {
                // Record the root only when there is content to anchor - on a
                // fresh machine an empty store means nothing was recovered.
                if (cores.Count > 0 || launchers.Count > 0)
                {
                    s.Shadps4ManagedRoot = store.RootPath;
                    changed = true;
                }
            }

            if (string.IsNullOrWhiteSpace(s.Shadps4ActiveCore))
            {
                var core = cores.FirstOrDefault();
                if (core != null)
                {
                    s.Shadps4ActiveCore = Shadps4ActiveCore.ForManaged(core.BuildId);
                    changed = true;
                }
            }

            if (string.IsNullOrWhiteSpace(s.Shadps4ActiveLauncher))
            {
                var launcher = launchers.FirstOrDefault();
                if (launcher != null)
                {
                    s.Shadps4ActiveLauncher = Shadps4ActiveCore.ForManaged(launcher.BuildId);
                    changed = true;
                }
            }

            if (string.IsNullOrWhiteSpace(s.Shadps4InstallDirectory))
            {
                string data = Path.Combine(store.RootPath, "Data");
                if (Directory.Exists(data))
                {
                    s.Shadps4InstallDirectory = data;
                    changed = true;
                }
            }

            return changed;
        }

        private static bool IsCoreFileName(string? path)
        {
            string name = Path.GetFileName(path ?? "");
            return name.Equals(Shadps4EnvironmentResolver.CoreExeFileName, StringComparison.OrdinalIgnoreCase);
        }

        private static bool IsLauncherFileName(string? path)
        {
            string name = Path.GetFileName(path ?? "");
            return name.Equals(Shadps4EnvironmentResolver.QtLauncherFileName, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Keeps the configured directory list clean without broadening the
        /// user's explicitly selected scan scope.
        /// Rules:
        ///  - empty and exact-duplicate entries are dropped;
        ///  - entries still nested inside a kept entry are dropped.
        /// </summary>
        private static void NormalizePkgDirectories(List<string> dirs)
        {
            var unique = new List<string>();
            foreach (string raw in dirs)
            {
                string d = raw?.Trim() ?? "";
                if (d.Length == 0) continue;
                if (!unique.Any(c => string.Equals(c, d, StringComparison.OrdinalIgnoreCase)))
                    unique.Add(d);
            }

            // Preserve explicitly selected siblings. Collapsing C:\Games and
            // C:\Downloads produced the drive-relative path C:, and collapsing
            // normal siblings silently broadened the user's scan scope.
            var final = unique.Where(d => !unique.Any(other =>
                !string.Equals(other, d, StringComparison.OrdinalIgnoreCase)
                && IsStrictChildOf(d, other))).ToList();

            dirs.Clear();
            dirs.AddRange(final);
        }

        private static bool IsStrictChildOf(string child, string parent)
        {
            string p = parent.TrimEnd('\\', '/');
            return child.StartsWith(p + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase)
                || child.StartsWith(p + "/", StringComparison.OrdinalIgnoreCase);
        }
    }
}
