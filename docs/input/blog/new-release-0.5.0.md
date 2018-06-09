---
Title: New Release - 0.5.0
Published: 2018-03-03
Category: Release
Author: AdmiringWorm
---

# 0.5.0 Compatibility Release
The main feature of this release is adding the support for Cake version 0.26.0.
The project have also now been setup as a example project with pulling/pushing translations to transifex (these are also included in the package).

EDIT:
It turns out this support, was only for partial support for Cake version 0.26.0.
It is only supported when targeting .NET Core 2.0, and not when targeting the full .NET Framework.

## Release notes

As part of this release we had [22 commits](https://github.com/cake-contrib/Cake.Transifex/compare/0.4.0...0.5.0) which resulted in [5 issues](https://github.com/cake-contrib/Cake.Transifex/issues?milestone=6&state=closed) being closed.


__Feature__

- [__#22__](https://github.com/cake-contrib/Cake.Transifex/issues/22) Support Cake.Core 0.26

__Improvement__

- [__#20__](https://github.com/cake-contrib/Cake.Transifex/issues/20) Change all hard coded strings to translatable strings

__Documentation__

- [__#23__](https://github.com/cake-contrib/Cake.Transifex/issues/23) Updated documentation to the correct .NET Core and .NET Framework versions
- [__#19__](https://github.com/cake-contrib/Cake.Transifex/issues/19) Mention which cake versions are supported in wyam documentation.
- [__#18__](https://github.com/cake-contrib/Cake.Transifex/issues/18) Documentation in Readme.md is outdated

### Where to get it
You can download this release from [nuget](https://nuget.org/packages/Cake.Transifex/0.5.0)
