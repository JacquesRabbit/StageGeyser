# StageGeyser

Stage and screenplay  writing and directing software.

I started this project because I noticed a lack of truly effective open-source software for writing stageplay scripts. The best option I could find is KITScenarist, which is very much focused on screenplays.

The app is built on the Avalonia UI framework. I chose Avalonia because it is open source, and allows for easy cross-platform implementation. I initially started using Electron, but quickly realised how much I hate JS. 

## Table of Contents
- [StageGeyser](#stagegeyser)
  - [Table of Contents](#table-of-contents)
  - [How to Install](#how-to-install)
  - [Geyser File Format](#geyser-file-format)
    - [Sections](#sections)
      - [Section Type](#section-type)
      - [Section Name](#section-name)
    - [Section Types](#section-types)

## How to Install

StageGeyser is currently being developed. It lacks the features necessary for a full release, and is thus not available to install. Release builds will be accessible here when the app is in a releasable state.

## Geyser File Format
Files ending in the .geyser file extension are Geyser script files. This is a file format based on the existing Fountain markup language, designed for more nuanced and higher-quality use. A description of the standards is shown below. Note that one does not have to understand the Geyser file format to effectively use StageGeyser, as most of its nuances are handled either automatically or manually through the UI controls. That being said, having an understanding of the language can make working in StageGeyser faster and enable you to edit StageGeyser scripts with a plain text editor, rather than SG.

### Sections
Geyser files are divided into sections, each defined by properties which StageGeyser uses to identify and format it. A section is defined by curly braces `{}`. Anything within the curly braces is considered part of that section. Properties can be defined using a `key: value` pair. While you can technically assign any string as a property key, the interpreter will ignore any it doesn't recognise. The basic section properties that apply to all sections are:

- Type
- Name
- Number
- Break

However, different section `Type`s have their own properties, as described below.

#### Section Type

There are a number of section types that the Geyser interpreter recognises by default. These include:
- Title (Title Page)
- Contents (Table of Contents)
- Chars (Character List)
- Scenes (Scene List)
- Stage (Stage Script)
- Screen (Screen Script)

The interpreter uses this property to inform its formatting of the Geyser markup contained within the rest of the section. If a `Type` is not defined within a section, it will default to `Stage`. A more detailed list of the available section types is available [below](#section-types)

#### Section Name

The `Name` property is used to inform StageGeyser what to use when referring to the section in the project navigator

### Section Types