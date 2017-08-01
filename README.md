# Cake.Transifex

[![license](https://img.shields.io/github/license/cake-contrib/Cake.Transifex.svg)](https://github.com/cake-contrib/Cake.Transifex/blob/master/LICENSE)

Cake.Transifex is a addin for the Cake Build script adding support for working with the localization service Transifex.
This addin requires that the transifex client is already installed and is available as `tx`.

## Information

To install the transifex client, install python, then run `pip install transifex-client`.

| |Stable|Pre-release|
|:--:|:--:|:--:|
|GitHub Release|[![GitHub release](https://img.shields.io/github/release/cake-contrib/Cake.Transifex.svg)](https://github.com/cake-contrib/Cake.Transifex/releases/latest)|[![GitHub (pre-)release](https://img.shields.io/github/release/cake-contrib/Cake.Transifex/all.svg)](https://github.com/cake-contrib/Cake.Transifex/releases)|
|NuGet|[![NuGet](https://img.shields.io/nuget/v/Cake.Transifex.svg)](https://nuget.org/packages/Cake.Transifex)|[![NuGet Pre Release](https://img.shields.io/nuget/vpre/Cake.Transifex.svg)](https://nuget.org/packages/Cake.Transifex)|

### Where to get the addin
Officially published versions are available on [NuGet](https://www.nuget.org/packages/Cake.Transifex/).
Development versions is available at the following nuget api endpoint: <https://www.myget.org/F/cake-contrib/api/v2>

### Usage
The following aliases is available from the cake build script:
- `TransifexStatus` -> Get the status of the current translations in the local repository.
- `TransifexPush`   -> Push translations to the remote transifex server (Optionally also the source file)
- `TransifexPull`   -> Pull monitored translations from the remote transifex server

## Build Status
| | master | develop |
|:--:|:--:|:--:|
|AppVeyor|[![AppVeyor branch master](https://img.shields.io/appveyor/ci/cakecontrib/cake-transifex/master.svg)](https://ci.appveyor.com/project/cakecontrib/cake-transifex/branch/master)|[![AppVeyor branch develop](https://img.shields.io/appveyor/ci/cakecontrib/cake-transifex/develop.svg)](https://ci.appveyor.com/project/cakecontrib/cake-transifex/branch/develop)|
|Travis CI|[![Travis branch](https://img.shields.io/travis/cake-contrib/Cake.Transifex/master.svg)](https://travis-ci.org/cake-contrib/Cake.Transifex)|[![Travis branch](https://img.shields.io/travis/cake-contrib/Cake.Transifex/develop.svg)](https://travis-ci.org/cake-contrib/Cake.Transifex)|

## Code Coverage

| |master|develop|
|:--:|:--:|:--:|
|Codecov|[![Codecov branch](https://img.shields.io/codecov/c/github/cake-contrib/Cake.Transifex/master.svg)](https://codecov.io/github/cake-contrib/Cake.Transifex)|[![Codecov branch](https://img.shields.io/codecov/c/github/cake-contrib/Cake.Transifex/develop.svg)](https://codecov.io/github/cake-contrib/Cake.Transifex)|
|Coveralls|[![Coveralls branch](https://img.shields.io/coveralls/cake-contrib/Cake.Transifex/master.svg)](https://coveralls.io/github/cake-contrib/Cake.Transifex?branch=master)|[![Coveralls branch](https://img.shields.io/coveralls/cake-contrib/Cake.Transifex/develop.svg)](https://coveralls.io/github/cake-contrib/Cake.Transifex?branch=develop)|

## Quick Links

- [Addin Documentation](https://cake-contrib.github.io/Cake.Transifex) *Not yet created*
- [Transifex Documentation](https://docs.transifex.com/)

## Chat Room

Come join in the conversation about Cake.Transifex in our Gitter Chat Room

[![Join the chat at https://gitter.im/cake-contrib/Lobby](https://badges.gitter.im/cake-contrib/Lobby.svg)]((https://gitter.im/cake-contrib/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

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
**NOTE: By default we do not enable building of .NET Full on Linux and OSX, to also build .NET Full pass `--with-netfull` when calling `sh build.sh`**
