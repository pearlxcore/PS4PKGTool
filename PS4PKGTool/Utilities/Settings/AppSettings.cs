using System;
using System.Collections.Generic;
using System.Drawing;

namespace PS4PKGTool.Utilities.Settings
{
    public class AppSettings
    {
        public List<string> PkgDirectories { get; set; }
        public bool ScanRecursive { get; set; }
        public bool PlayBgm { get; set; }
        public bool AutoSortRow { get; set; }
        public string LocalServerIp { get; set; } = string.Empty;
        public string Ps4Ip { get; set; } = string.Empty;
        public string OfficialUpdateDownloadDirectory { get; set; } = string.Empty;
        public bool NodeJsInstalled { get; set; }
        public bool HttpServerInstalled { get; set; }
        public bool PkgColorLabel { get; set; }
        public Color AddonPkgForeColor { get; set; }
        public Color GamePkgForeColor { get; set; }
        public Color PatchPkgForeColor { get; set; }
        public Color AppPkgForeColor { get; set; }
        public Color AddonPkgBackColor { get; set; }
        public Color GamePkgBackColor { get; set; }
        public Color PatchPkgBackColor { get; set; }
        public Color AppPkgBackColor { get; set; }
        public string RenameCustomName { get; set; }
        public DateTime Ps5BcJsonLastDownloadDate { get; set; }
        public bool psvr_neo_ps5bc_check { get; set; }


        #region columnVisibility

        public bool pkgtitleIdColumn { get; set; }
        public bool pkgcontentIdColumn { get; set; }
        public bool pkgregionColumn { get; set; }
        public bool pkgminimumFirmwareColumn { get; set; }
        public bool pkgversionColumn { get; set; }
        public bool pkgTypeColumn { get; set; }
        public bool pkgcategoryColumn { get; set; }
        public bool pkgsizeColumn { get; set; }
        public bool pkgDirectoryColumn { get; set; }
        public bool pkgBackportColumn { get; set; }
        public bool AutoFetchUpdate { get; set; } = false;
        public bool Shadps4Check { get; set; } = false;
        /// <summary>OS whose compatibility statuses are shown: windows | linux | macos.</summary>
        public string Shadps4Os { get; set; } = "windows";
        /// <summary>
        /// User-selected shadPS4 executable - either the core (shadPS4.exe) or
        /// the Qt launcher (shadPS4QtLauncher.exe). The counterpart is detected
        /// automatically, so one setting is enough.
        /// </summary>
        public string Shadps4ExecutablePath { get; set; } = "";
        /// <summary>
        /// The explicit launch component for games: "" (none), "managed:&lt;buildId&gt;"
        /// (PS4PKGTool-managed build) or "adopted:&lt;path&gt;" (user-chosen existing
        /// installation, reference only). Launch NEVER falls back to a discovered
        /// core on disk - only this setting is authoritative.
        /// </summary>
        public string Shadps4ActiveCore { get; set; } = "";
        /// <summary>
        /// The Qt launcher used by "Open QtLauncher": same managed:/adopted:
        /// representation as Shadps4ActiveCore. The launcher is the settings
        /// UI (graphics/controllers/audio/cheats/patches); it is never used
        /// as an intermediate step for direct game launch.
        /// </summary>
        public string Shadps4ActiveLauncher { get; set; } = "";
        /// <summary>
        /// Root for PS4PKGTool-managed shadPS4 builds (default:
        /// &lt;exe directory&gt;\AppData\shadPS4, historically
        /// %LOCALAPPDATA%\PS4PKGTool\shadPS4). Chosen once; every version
        /// installs under &lt;root&gt;\builds\. Empty = the default.
        /// </summary>
        public string Shadps4ManagedRoot { get; set; } = "";
        /// <summary>
        /// Install target for "Install Game to shadPS4 Library". Auto-filled
        /// from shadPS4's own config (first enabled game library) in Program
        /// Settings; the user may override it. Empty = no preset (the folder
        /// dialog opens without a preselected directory).
        /// </summary>
        public string Shadps4InstallDirectory { get; set; } = "";
        /// <summary>
        /// Root for PS4PKGTool working files: PKG preview/drag-out staging,
        /// merge/FFPFSC default work folder and trophy scratch. Empty uses the
        /// Windows temporary directory. Full PKG extraction writes straight to
        /// the chosen output folder.
        /// </summary>
        public string OrbisTempDirectory { get; set; } = "";
        /// <summary>
        /// When true, merge builds skip the pre-flight disk-space guard.
        /// The merge dialog can override this per merge.
        /// </summary>
        public bool IgnoreDiskSpaceCheck { get; set; } = false;
        /// <summary>Legacy (superseded by Shadps4ExecutablePath - kept for migration).</summary>
        public string Shadps4CoreExePath { get; set; } = "";
        /// <summary>Legacy (superseded by Shadps4ExecutablePath - kept for migration).</summary>
        public string Shadps4LauncherExePath { get; set; } = "";
        /// <summary>
        /// Set when the user declines the "shadPS4 setup detected" prompt.
        /// The prompt only appears on fresh/wiped settings, so this flag dies
        /// with the settings file and the prompt naturally returns after a wipe.
        /// </summary>
        public bool Shadps4ConfigDetectionDismissed { get; set; } = false;

        /// <summary>True when the Explorer .pkg context menu integration is installed (HKCU).</summary>
        public bool ShellIntegrationInstalled { get; set; } = false;


        #endregion columnVisibility

        public int ThemeIndex { get; set; } = 0;
        /// <summary>
        /// Stable selected theme identity. ThemeIndex is retained for backwards
        /// compatibility with existing Settings.conf files.
        /// </summary>
        public string ThemeName { get; set; } = string.Empty;

        public AppSettings()
        {
            PkgDirectories = new List<string>();
        }
    }
}
