![](https://img.shields.io/github/contributors/jacquesRabbit/StageGeyser)
![](https://img.shields.io/bitbucket/issues/JacquesRabbit/StageGeyser)
![](https://img.shields.io/github/license/JacquesRabbit/StageGeyser)
# StageGeyser

Stageplay  writing and production software.

I started this project because I noticed a lack of truly effective open-source software for writing stageplay scripts. The best option I could find is KITScenarist, which is very much focused on screenplays. As a playwright myself

The app is built on the Avalonia UI framework. I chose Avalonia because it is open source, and allows for easy cross-platform implementation. I initially started using Electron, but quickly realised how much I hate JS. 

## Table of Contents
- [StageGeyser](#stagegeyser)
  - [Table of Contents](#table-of-contents)
  - [How to Install](#how-to-install)
  - [PXML File Format](#pxml-file-format)

## How to Install

StageGeyser is currently being developed. It lacks the features necessary for a full release, and is thus not available to install. Installation instructions will be available here when the app is in a releasable state.

## PXML File Format
Files ending in the `.pxml` file extension are Geyser script files. GXML (Play eXtensible Markup Language) is a superset of XML created to make the code for parsing and writing files simpler. Geyser scripts were originally stored in plain text for human readability, much like Fountain scripts. In early stages, this quickly became cumbersome as the app would have to frequently and repeatedly parse a lot of text processing functions just to read or write a file. So PXML was born. It consists of a number of custom elements and implementation quirks which can be foudn in the documentation (not yet created).