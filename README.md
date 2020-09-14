# Cake.Transifex

[![All Contributors][all-contributorsimage]](#contributors)
[![license](https://img.shields.io/github/license/cake-contrib/Cake.Transifex.svg)](https://github.com/cake-contrib/Cake.Transifex/blob/master/LICENSE)
[![Open Source Helpers](https://www.codetriage.com/wormiecorp/cake.transifex/badges/users.svg)](https://www.codetriage.com/wormiecorp/cake.transifex)

Cake.Transifex is a addin for the Cake Build script adding support for working with the localization service Transifex.
This addin requires that the transifex client is already installed and is available as `tx`.

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
## Table of Contents

- [Information](#information)
  - [Where to get the addin](#where-to-get-the-addin)
  - [Usage](#usage)
- [Build Status](#build-status)
- [Code Coverage](#code-coverage)
- [Quick Links](#quick-links)
- [Chat Room](#chat-room)
- [Building Cake.Transifex](#building-caketransifex)
  - [1. Building on Windows](#1-building-on-windows)
  - [2. Building on Linux or OSX](#2-building-on-linux-or-osx)
- [Contributors](#contributors)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## Information

To install the transifex client, install python, then run `pip install transifex-client`, or using the chocolatey package `choco install transifex-client`.

| |Stable|Pre-release|
|:--:|:--:|:--:|
|GitHub Release|[![GitHub release](https://img.shields.io/github/release/cake-contrib/Cake.Transifex.svg)](https://github.com/cake-contrib/Cake.Transifex/releases/latest)|[![GitHub (pre-)release](https://img.shields.io/github/release/cake-contrib/Cake.Transifex/all.svg)](https://github.com/cake-contrib/Cake.Transifex/releases)|
|NuGet|[![NuGet](https://img.shields.io/nuget/v/Cake.Transifex.svg)](https://nuget.org/packages/Cake.Transifex)|[![NuGet Pre Release](https://img.shields.io/nuget/vpre/Cake.Transifex.svg)](https://nuget.org/packages/Cake.Transifex)|

### Where to get the addin

Officially published versions are available on [NuGet](https://www.nuget.org/packages/Cake.Transifex/).
Development versions is available at the following nuget api endpoint: <https://ci.appveyor.com/nuget/cake-transifex>

### Usage

The following aliases is available from the cake build script:

- `TransifexInit`   -> Initialize a simple configuration file in the repository
- `TransifexStatus` -> Get the status of the current translations in the local repository.
- `TransifexPush`   -> Push translations to the remote transifex server (Optionally also the source file)
- `TransifexPull`   -> Pull monitored translations from the remote transifex server

## Build Status

| | master | develop |
|:--:|:--:|:--:|
|AppVeyor|[![AppVeyor branch master](https://img.shields.io/appveyor/ci/cakecontrib/cake-transifex/master.svg)](https://ci.appveyor.com/project/cakecontrib/cake-transifex/branch/master)|[![AppVeyor branch develop](https://img.shields.io/appveyor/ci/cakecontrib/cake-transifex/develop.svg)](https://ci.appveyor.com/project/cakecontrib/cake-transifex/branch/develop)|
|Travis|[![Build Status](https://travis-ci.org/cake-contrib/Cake.Transifex.svg?branch=master)](https://travis-ci.org/cake-contrib/Cake.Transifex)|[![Build Status](https://travis-ci.org/cake-contrib/Cake.Transifex.svg?branch=develop)](https://travis-ci.org/cake-contrib/Cake.Transifex)

## Code Coverage

| |master|develop|
|:--:|:--:|:--:|
|Codecov|[![Codecov branch](https://img.shields.io/codecov/c/github/cake-contrib/Cake.Transifex/master.svg)](https://codecov.io/gh/cake-contrib/Cake.Transifex/branch/master)|[![Codecov branch](https://img.shields.io/codecov/c/github/cake-contrib/Cake.Transifex/develop.svg)](https://codecov.io/gh/cake-contrib/Cake.Transifex/branch/develop)|
|Coveralls|[![Coveralls branch](https://img.shields.io/coveralls/cake-contrib/Cake.Transifex/master.svg)](https://coveralls.io/github/cake-contrib/Cake.Transifex?branch=master)|[![Coveralls branch](https://img.shields.io/coveralls/cake-contrib/Cake.Transifex/develop.svg)](https://coveralls.io/github/cake-contrib/Cake.Transifex?branch=develop)|

## Quick Links

- [Addin Documentation](https://cake-contrib.github.io/Cake.Transifex)
- [Transifex Documentation](https://docs.transifex.com/)

## Chat Room

Come join in the conversation about Cake.Transifex in our Gitter Chat Room.

[![Join the chat at https://gitter.im/cake-contrib/Lobby](https://badges.gitter.im/cake-contrib/Lobby.svg)](https://gitter.im/cake-contrib/Lobby)

## Building Cake.Transifex

Please see [Building documentation](https://cake-contrib.github.io/Cake.Transifex/docs/building/) on how to build the Cake.Transifex addin.

## Contributors

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore -->
<table>
  <tr>
    <td align="center"><a href="https://github.com/AdmiringWorm"><img src="https://avatars3.githubusercontent.com/u/1474648?v=4" width="100px;" alt="Kim J. Nordmo"/><br /><sub><b>Kim J. Nordmo</b></sub></a><br /><a href="#maintenance-AdmiringWorm" title="Maintenance">🚧</a></td>
    <td align="center"><a href="http://www.gep13.co.uk/blog"><img src="https://avatars3.githubusercontent.com/u/1271146?v=4" width="100px;" alt="Gary Ewan Park"/><br /><sub><b>Gary Ewan Park</b></sub></a><br /><a href="#question-gep13" title="Answering Questions">💬</a> <a href="https://github.com/cake-contrib/Cake.Transifex/issues?q=author%3Agep13" title="Ideas, Planning, & Feedback">🤔</a> <a href="https://github.com/cake-contrib/Cake.Transifex/pulls?q=reviewed-by%3Agep13" title="Reviewed Pull Requests">👀</a> <a href="https://github.com/cake-contrib/Cake.Transifex/commits?author=gep13" title="Documentation">📖</a></td>
    <td align="center"><a href="https://www.codetriage.com"><img src="https://avatars0.githubusercontent.com/u/35302948?v=4" width="100px;" alt="README Bot"/><br /><sub><b>README Bot</b></sub></a><br /><a href="https://github.com/cake-contrib/Cake.Transifex/commits?author=codetriage-readme-bot" title="Documentation">📖</a></td>
    <td align="center"><a href="https://github.com/Jericho"><img src="https://avatars0.githubusercontent.com/u/112710?v=4" width="100px;" alt="jericho"/><br /><sub><b>jericho</b></sub></a><br /><a href="https://github.com/cake-contrib/Cake.Transifex/issues?q=author%3AJericho" title="Ideas, Planning, & Feedback">🤔</a> <a href="#question-Jericho" title="Answering Questions">💬</a></td>
    <td align="center"><a href="https://twitter.com/mholo65"><img src="https://avatars1.githubusercontent.com/u/7863439?v=4" width="100px;" alt="Martin Björkström"/><br /><sub><b>Martin Björkström</b></sub></a><br /><a href="#question-mholo65" title="Answering Questions">💬</a></td>
    <td align="center"><a href="https://github.com/x-jokay"><img src="https://avatars0.githubusercontent.com/u/18613935?v=4" width="100px;" alt="D. Domig"/><br /><sub><b>D. Domig</b></sub></a><br /><a href="https://github.com/cake-contrib/Cake.Transifex/commits?author=x-jokay" title="Documentation">📖</a></td>
  </tr>
</table>

<!-- ALL-CONTRIBUTORS-LIST:END -->

This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification.
Contributions of any kind welcome!

[all-contributors]: https://github.com/all-contributors/all-contributors
[all-contributorsimage]: https://img.shields.io/github/all-contributors/cake-contrib/Cake.Codecov.svg?color=orange&style=flat-square
