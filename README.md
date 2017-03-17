# Cake.Transifex

| AppVeyor | Travis | NuGet | GitHub | Codecov |
| :------: | :----: | :---: | :----: | :-----: |
| [![AppVeyor](https://img.shields.io/appveyor/ci/AdmiringWorm/cake-transifex.svg)](https://ci.appveyor.com/project/AdmiringWorm/cake-transifex) | [![Travis](https://img.shields.io/travis/WormieCorp/Cake.Transifex.svg)](https://travis-ci.org/WormieCorp/Cake.Transifex) | [![NuGet](https://img.shields.io/nuget/v/Cake.Transifex.svg)](https://www.nuget.org/packages/Cake.Transifex/) | [![GitHub release](https://img.shields.io/github/release/WormieCorp/Cake.Transifex.svg)](https://github.com/WormieCorp/Cake.Transifex/releases) | [![Codecov](https://codecov.io/github/WormieCorp/Cake.Transifex/coverage.svg)](https://codecov.io/github/WormieCorp/Cake.Transifex) |

Cake.Transifex is a addin for the Cake Build script adding support for working with the localization service Transifex.
This addin requires that the transifex client is already installed and is available as `tx`.
To install the transifex client, install python, then run `pip install transifex-client`.


## Where to get it
Officially published versions are available on [NuGet](https://www.nuget.org/packages/Cake.Transifex/).
Development versions is available at the following nuget api endpoint: <https://www.myget.org/F/wormie-nugets/api/v2>


## Usage
The following aliases is available from the cake build script:
- `TransifexStatus` -> Get the status of the current translations in the local repository.
- `TransifexPush`   -> Push translations to the remote transifex server (Optionally also the source file)
- `TransifexPull`   -> Pull monitored translations from the remote transifex server

## Building Cake.Transifex

### 1. Building on Windows
The following are needed to build Cake.Transifex on Windows
- .NET Core 1.0.1
- Visual Studio 2017
- .NET 4.5 (.NET 4.5.2 to build the unit tests), *these should already be installed when installing Visual Studio 2017*

Open up a powershell window and call `.\build.ps1`, this should build the projects, run the unit tests and create nuget packages in the `.\artifacts\v{version}\nuget` directory.

### 2. Building on Linux or OSX
- .NET Core 1.0.1
- Mono (uncertain of which version, and it may fail on some systems)

Open up the terminal and call `sh build.sh`, this should build the projects, run the unit tests and create nuget packages in the `./artifacts/v{version}/nuget` directory.
**NOTE: If building fails saying that .NET 4.5 is not available, you may need to pass `--netcoreonly` when calling the `build.sh` script, like this: `sh build.sh --netcoreonly`, this will only build the .NET Core portion of the cake addin.**
