using System.Reflection;
using System.Runtime.InteropServices;
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
// ──────────────────────────────────────────────────────────────
// VERSION: single source of truth for the app version.
//   * AssemblyInformationalVersion is what the app displays and
//     what the GitHub update check compares ("v" + this value).
//   * Keep the same 1.x format; bump the minor on each feature
//     release (1.7 → 1.8). Use a patch bump for bugfix-only
//     releases (1.8 → 1.8.1); the update checker handles it.
//   * AssemblyVersion / AssemblyFileVersion must track the same
//     number so Explorer and the built exe don't disagree.
//   * The Version / FileVersion properties in PS4PKGTool.csproj
//     are ignored at build time (GenerateAssemblyInfo=false).
//     Edit them only to keep the file readable.
// RELEASE RULES (checked against GitHubUpdate 1.2.0's UpdateChecker):
//   * Tag the GitHub release exactly "v1.8" (with the "v"). Tags without
//     "v" also work; tags that are not valid versions (e.g. "latest")
//     make the update check throw.
//   * NEVER publish the release marked "Pre-release" because pre-releases are
//     filtered out and the app will claim it is up to date.
//   * NEVER publish as a draft because drafts are invisible to the API.
// ──────────────────────────────────────────────────────────────
[assembly: AssemblyVersion("1.9.2.0")]
[assembly: AssemblyFileVersion("1.9.2.0")]
[assembly: AssemblyInformationalVersion("1.9.2")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("5a44036b-b799-4956-ac1a-5c33e0e5c0f7")]
