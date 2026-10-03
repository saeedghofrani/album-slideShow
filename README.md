# Album Slideshow

A historical Windows desktop project for organizing images into albums, editing
album metadata, saving custom album archives, and presenting images as a
slideshow.

## Features visible in the source

- Import JPG, JPEG, GIF, and BMP images
- Create and edit album metadata such as name, creator, and description
- Save and reopen custom `.saeed` album archives
- Browse images as thumbnails and select individual entries
- Run a timed slideshow with navigation controls
- Optionally apply a password when writing the ZIP-based album archive

## Technology

- C# and Windows Forms
- .NET Framework 4.5.2
- Ionic.Zip for archive handling
- Material Design WPF packages and DevExpress 19.2 references

## Build requirements

Open `album project.sln` in a Windows Visual Studio installation that includes
the .NET Framework 4.5.2 developer tools. Restore the packages listed in
`album project/packages.config` and provide compatible DevExpress 19.2
assemblies before building.

The current environment does not include the historical DevExpress toolchain,
so a clean rebuild has not been reproduced during this documentation update.

## Archive format

The application copies selected images into a temporary directory, writes album
metadata to `settings.txt`, and packages the directory as a ZIP archive with a
`.saeed` extension. Opening an album reverses that process and loads the images
and metadata into the application.

## Security and data limitations

This code is an educational snapshot and should not be used for sensitive or
untrusted photo archives:

- The archive password is also written into the archive metadata.
- Archive extraction does not validate entry paths before extraction.
- A shared temporary directory is deleted and recreated during save/open flows.
- Image paths are stored in the archive metadata.
- The project uses old framework and third-party library versions.

Use disposable sample images when evaluating the project.

## Status

Historical learning project. It is retained as evidence of early C# desktop,
file-processing, and UI work and is not an actively maintained application.
