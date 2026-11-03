# Changelog

## v1.9.2

- PKG merge now estimates build temp space from the original PKG size, so large merges no longer need worst-case free space.
- The disk-space check can be skipped from Program Settings or the merge dialog.
- Merge carries the update's required firmware, preserves empty directories, and fails clearly when a source file is missing.
- GP4 generation keeps the app version and reports the exact directory when a path cannot be enumerated.
- Fixed many high-DPI display issues at 125–250% scaling:
  - Scrollbar arrows are drawn as vectors and stay crisp at every scaling factor.
  - The PKG list table, the Param.sfo pane, and all PKG Internals tables show full-height rows instead of text clipped in half.
  - The Grouped view renders full-height rows the first time it is opened.
  - Section headers, the File Viewer title and info strip, filter labels, the `Expand All` button, and the Group By row are no longer clipped, overlapped, or misaligned.
  - The Shell Rename dialog's input box is visible again.
- The Settings window's `Save & Close` caption now displays the ampersand correctly (was rendered as `Save _Close`).
- These layout fixes require the matching DarkUI fork update (shipped together). Note: forms now use DPI-based autoscaling, so Windows "Text size" accessibility enlargement at 100% display scale no longer grows controls with the font.

## v1.9.1

- PKG merge now uses the configured temp and work folders instead of always using the Windows temp drive. Large merges no longer fail with a "not enough space" error on C:.
- FFPFSC conversion and trophy preview now use the configured temp folder too.
- The merge disk-space estimate now includes the output PKG and the build scratch files.

## v1.9.0

- Full PKG extraction now produces one normal game folder instead of the old `Image0`/`Sc0` split. Much easier to use.
- The file browser shows a clean single-folder layout, with no `Image0`/`Sc0` clutter.
- Existing files are never overwritten when extracting.
- Settings now persist even when the app is moved to a new folder.
- Controls now match the selected theme.
- Fixed the update page not opening.
