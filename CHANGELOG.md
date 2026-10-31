# Changelog

## v1.9.0

- Full PKG extraction now produces one normal game folder instead of the old `Image0`/`Sc0` split. Much easier to use.
- The file browser shows a clean single-folder layout, with no `Image0`/`Sc0` clutter.
- Existing files are never overwritten when extracting.
- Settings now persist even when the app is moved to a new folder.
- Controls now match the selected theme.
- Fixed the update page not opening.
- Fixed many high-DPI display issues at 125–250% scaling:
  - Scrollbar arrows are drawn as vectors and stay crisp at every scaling factor.
  - The PKG list table, the Param.sfo pane, and all PKG Internals tables show full-height rows instead of text clipped in half.
  - The Grouped view renders full-height rows the first time it is opened.
  - Section headers, the File Viewer title and info strip, filter labels, the `Expand All` button, and the Group By row are no longer clipped, overlapped, or misaligned.
  - The Shell Rename dialog's input box is visible again.
- The Settings window's `Save & Close` caption now displays the ampersand correctly (was rendered as `Save _Close`).
- These layout fixes require the matching DarkUI fork update (shipped together). Note: forms now use DPI-based autoscaling, so Windows "Text size" accessibility enlargement at 100% display scale no longer grows controls with the font.
