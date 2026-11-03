# Changelog

## v1.9.2

- PKG merge now estimates build temp space from the original PKG size, so large merges no longer need worst-case free space.
- The disk-space check can be skipped from Program Settings or the merge dialog.
- Merge carries the update's required firmware, preserves empty directories, and fails clearly when a source file is missing.
- GP4 generation keeps the app version and reports the exact directory when a path cannot be enumerated.

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
