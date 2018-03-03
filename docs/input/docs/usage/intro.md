---
Order: 10
Title: Introduction
Author: Kim Nordmo
---

# Getting Started

This addin is designed to be used inside of cake scripts. To start using it, first you must add a cake [preprocessor directive](http://cakebuild.net/docs/fundamentals/preprocessor-directives) to your script as below.

```cs
// latest version 
#addin "Cake.Transifex"

// or
#addin "nuget?package=Cake.Transifex"

// for a specific version, use ?version=
#addin "Cake.Transifex?version=0.3.0"
```

When the cake script is run, this will download the latest version of the `Cake.Transifex` nuget package and will now be available to use inside of the script.


*NOTE: Remember to also install the transifex (`tx`) client on the running computer, this can be installed through
the python `pip` utility (`pip install transifex-client`) or through chocolatey `choco install transifex-client`.*
