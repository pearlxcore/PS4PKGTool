# Building PS4 PKG Tool

How to build and publish this app from source. Everything below was validated end-to-end with .NET SDK **10.0.402** on Windows.

## Prerequisites

- **Windows 10 or later** (the app is Windows-only WinForms).
- **[.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)** — check with `dotnet --list-sdks`; you need a `10.0.x` entry. An older SDK fails restore with `NETSDK1045`.
- **Git**.

## 1. Get the two sibling repositories

The solution references two external projects **by relative path**, so they must be cloned **next to this repo** (as siblings, not inside it), with exactly these folder names:

```
<your-dev-folder>\
├── PS4PKGTool\        ← this repository
├── DarkUI\            ← https://github.com/EthanBlazkowicz/DarkUI (fork with the DPI fixes)
└── OrbisPkgTool\      ← https://github.com/pearlxcore/OrbisPkgTool
```

```bash
cd <your-dev-folder>
git clone https://github.com/EthanBlazkowicz/DarkUI.git
git clone https://github.com/pearlxcore/OrbisPkgTool.git
```

Why:

| Dependency | How it is referenced |
|---|---|
| **DarkUI** | **Project reference** to `..\..\DarkUI\DarkUI\DarkUI.csproj` — every app build compiles the fork automatically. Just **clone it**; no manual build needed. |
| **OrbisPkgTool** | Project reference in Debug builds; for Release publish, MSBuild builds it as a library automatically and bundles the DLL. Just **clone it** — no manual build needed. |

> Upstream note: these paths live in `PS4PKGTool\PS4PKGTool.csproj`. The original DarkUI (RobinPerris) will not work here — the fork targets `net10.0-windows` and carries the per-monitor v2 DPI fixes this app depends on.

## 2. Build the app (Debug)

From the repository root:

```bash
dotnet build PS4PKGTool\PS4PKGTool.sln
```

or just the startup project (`dotnet build` pulls in `PS4PKGTool.Core` and `PS4PKGTool.Assets` automatically):

```bash
dotnet build PS4PKGTool\PS4PKGTool.csproj -c Debug
```

Output: `PS4PKGTool\bin\Debug\net10.0-windows\PS4 PKG Tool.exe`

A flood of `CS0649` / `CA1416` / nullable warnings is pre-existing and harmless; the build succeeds with 0 errors.

## 3. Publish (Release single file)

```bash
dotnet publish PS4PKGTool\PS4PKGTool.csproj -c Release
```

Output: `PS4PKGTool\bin\Release\net10.0-windows\win-x64\publish\PS4 PKG Tool.exe`

Properties of the published build (set in `PS4PKGTool\PS4PKGTool.csproj`):

- **Single file**, win-x64, ~17 MB.
- **Framework-dependent** (`SelfContained=false`): end users need the free **[.NET 10 Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)** installed.
- During publish, OrbisPkgTool is built in library mode automatically and cleanup targets strip the OrbisPkgTool CLI, stray PDBs, and the legacy `.dll.config` from the output.

## Project notes

- **Assembly name is `PS4 PKG Tool`** (with spaces) — that's the exe filename everywhere.
- **`PS4PKGTool\App.config` is legacy** from the .NET Framework era; .NET 10 ignores it. It is kept only for build compatibility and deleted from publish output.
- **`PS4PKGTool.Core` must stay `net10.0-windows`**: it references the Windows-specific OrbisPkgTool project; plain `net10.0` fails restore with `NU1201`.
- **`PS4PKGTool\app.manifest`** is the application manifest (per-monitor v2 DPI awareness + long paths), wired in via `<ApplicationManifest>`. Keep it if you touch the csproj.
- `PS4PKGTool\PS4PKGTool.sln` (nested solution) additionally loads the OrbisPkgTool project — handy when developing against both at once.
- **Windows Defender may flag the published single-file exe** (e.g. `Trojan:Win32/Bearfoos.A!ml`). That is a machine-learning false positive: unsigned single-file .NET bundles with zero file reputation look like packers. Restore the file, exclude the publish folder locally, and submit a false-positive report via [Microsoft's file submission portal](https://www.microsoft.com/en-us/wdsi/filesubmission) (choose the *Software developer* option). Code signing is the only durable fix.

## High-DPI testing harness (optional, not committed)

`artifacts\scale-probe\` is a gitignored console project used to verify layout at scaled displays. It instantiates the real `Main`/`ProgramSetting`/dialog forms at the machine's monitor DPI, prints layout metrics (bounds, fonts, row heights), and captures **on-screen** screenshots via `CopyFromScreen` — screen content is the only truth for stale-pixel/z-order bugs; `DrawToBitmap` repaints children and can hide them.

To recreate it: a console csproj targeting `net10.0-windows` with `UseWindowsForms`, a `HintPath` reference to `PS4PKGTool\bin\Debug\net10.0-windows\PS4 PKG Tool.dll` (plus the DarkUI Release DLL and `HighDpiMode.PerMonitorV2` in code), and a `Program.cs` that drives the forms. Gotcha: incremental rebuilds with identical timestamps can leave a **stale app DLL** in the probe's output — delete it from the probe's bin folder and rebuild if measured values look impossible.

## Troubleshooting

| Symptom | Fix |
|---|---|
| `error NETSDK1045: The current .NET SDK does not support targeting .NET 10.0` | Install the .NET 10 SDK (an older one, e.g. 9.x, is active). |
| `error NU1201: Project OrbisPkgTool is not compatible with net10.0` | `PS4PKGTool.Core` was reverted to a plain `net10.0` TFM — set it back to `net10.0-windows`. |
| Project `..\..\DarkUI\DarkUI\DarkUI.csproj` not found | The DarkUI sibling folder is missing or misnamed: redo step 1, keeping the exact folder names. |
| Published exe won't start on another PC | Install the .NET 10 Desktop Runtime there (framework-dependent build). |
