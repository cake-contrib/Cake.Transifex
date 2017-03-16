# Cake.Transifex

| AppVeyor | Travis | NuGet | GitHub | Codecov |
| :------: | :----: | :---: | :----: | :-----: |
| [![AppVeyor](https://img.shields.io/appveyor/ci/AdmiringWorm/cake-transifex.svg)](https://ci.appveyor.com/project/AdmiringWorm/cake-transifex) | [![Travis](https://img.shields.io/travis/WormieCorp/Cake.Transifex.svg)](https://travis-ci.org/WormieCorp/Cake.Transifex) | [![NuGet](https://img.shields.io/nuget/v/Cake.Transifex.svg)](https://www.nuget.org/packages/Cake.Transifex/) | [![GitHub release](https://img.shields.io/github/release/WormieCorp/Cake.Transifex.svg)](https://github.com/WormieCorp/Cake.Transifex/releases) | [![Codecov](https://codecov.io/github/WormieCorp/Cake.Transifex/coverage.svg)](https://codecov.io/github/WormieCorp/Cake.Transifex) |

Cake.Transifex is a addin for the Cake Build script adding support for working with the localization service Transifex.


## Where to get it
Officially published versions are available on [NuGet](https://www.nuget.org/packages/Cake.Transifex/).
Development versions is available at the following nuget api endpoint: <https://www.myget.org/F/wormie-nugets/api/v2>


## Usage
The following aliases is available from the cake build script:
- `TransifexStatus` -> Get the status of the current translations in the local repository.
- `TransifexPush`   -> Push translations to the remote transifex server (Optionally also the source file)
- `TransifexPull`   -> Pull monitored translations from the remote transifex server
