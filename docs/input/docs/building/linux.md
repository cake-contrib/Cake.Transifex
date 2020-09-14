---
Order: 2
Title: Building on Linux
Author: Kim Nordmo
---

## Requirements

The following are need to build Cake.Transifex on Linux:

- .NET Core SDK 2.1 and 3.1
- Mono 5.16+ *(earlier versions may work, but are not supported)*

All other dependencies will be automatically downloaded when invoking the build script.

## Invoking the build itself

1. To build the Cake.Transifex library, just open any shell and navigate to the root of
downloaded/cloned repository.
2. After that just type `sh build.sh` and everything will be automatically built and all unit tests
will run.
