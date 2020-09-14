---
Order: 1
Title: Building on Windows
Author: Kim Nordmo
---

## Requirements

The following are need to build Cake.Transifex on Windows:

- Visual Studio 2019
- .NET Core SDK 2.1 and 3.1
- .NET Framework 4.6

All other dependencies will be automatically downloaded when invoking the build script.

## Invoking the build itself

1. To build the Cake.Transifex library, just open powershell and navigate to the root of
downloaded/cloned repository.
2. After that just type `.\build.ps1` and everything will be automatically built and all unit tests
will run.

## Creating a redistributable nuget package

To create a nuget package you can follow the same process as when building the library,
with the exception of calling `.\build.ps1` without any arguments.
The only difference is to run the build script with the following: `.\build.ps1 -Target Package`.
