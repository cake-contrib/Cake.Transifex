---
Order: 2
Title: Building on Linux
Author: Kim Nordmo
---

## Requirements

The following are need to build Cake.Transifex on Linux:
- .NET Core SDK 1.0.4 *(could work with other versions as well)*
- Mono 4.2.3+ *(earlier versions may work, but are not supported)*

All other dependencies will be automatically downloaded when invoking the build script.

## Invoking the build itself

1. To build the Cake.Transifex library, just open any shell and navigate to the root of
downloaded/cloned repository.
2. After that just type `sh build.sh` and everything will be automatically built and all unit tests
will run.

:::{.alert .alert-warning}
There is currently a small bug in some versions of the .NET Core library wich causes
a build failure when trying to use the `dotnet` utility,
to work around this problem you will need to export the path to the mono library directory by
doing the following before calling the build script:
`export FrameworkPathOverride=/usr/lib/mono/4.5/`
*(Change the path to the actual location of your mono installation directory)*
:::
