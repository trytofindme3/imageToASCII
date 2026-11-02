# Image to ASCII

A C# console application that converts an image into ASCII art right in the console.

Each sampled pixel's brightness is mapped to one of ten characters (`@ $ # * ! + : ~ - .`), from darkest to lightest. Two characters are printed per sample horizontally, because a console character is roughly twice as tall as it is wide.

## Usage

Run the program and enter:

```
path; pixel interval; brightness multiplier
```

Example:

```
C:\Users\User\Pictures\FunnyCat.png; 8; 1
```

- **path** — path to the image (PNG, JPG, BMP…)
- **pixel interval** — how many pixels to skip between samples (default `8`); smaller = more detailed and wider output
- **brightness multiplier** — lightens or darkens the result (default `1`)

Tip: for large images, decrease the console font size or increase the pixel interval.

## Build

- Visual Studio 2022, .NET Framework 4.8
- NuGet dependency: `System.Drawing.Common` 4.7.3 (restored automatically on build)

Open `imageToASCII.sln` and press **F5**.
