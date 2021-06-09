# Chocolate v0.1-alpha
[![Build](https://github.com/ChocLang/ChocolateLanguage/actions/workflows/main.yml/badge.svg)](https://github.com/ChocLang/ChocolateLanguage/actions/workflows/main.yml)
## Building Chocolate

Building is only supported on Windows and MacOS, because of Visual Studio.
But for Linux you may use MonoDevelop to build it, and use mono to run the produced exe. However, that isn't supported and may not work.
It is in progress.

Open the ChocolateLanguage.sln.
Press Ctrl+Shift+B.
Run the ChocolateCli.exe under ChocolateCLI/bin with the necessary parameters.

## Requirements

.NET Core 3.1

## Using the ChocolateCLI

The CLI parameters are:

*  --help or --h: Shows this list
* --version or --v: Shows the compiler version
* --run or --r {filename}: Runs the code in the console (for text only programs)
* --compile or --c  {filename}: compiles to an executable (for text programs) (To be added)
* --compile:graphics or --c:g {filename}: To compile with graphics, using WPF and SharpGL (To be added)

All Chocolate source files end with the .choc extension.

## Documentation

The Chocolate Documentation is currently a work in progress.
