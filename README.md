<!-- markdownlint-disable-next-line -->
<p align="center">
  <a href="#" rel="noopener" target="_blank"><img width="150" src="Resources/UnityParser_128x128.png" alt="Parser logo"></a>
</p>

<h1 align="center">Parser [Unity Engine]</h1>

*Parsing system for Unity that helps developers easily convert strings into various data types within the engine. This system supports a wide range of data types, and offers try-parse methods to avoid allocating extra memory when parsing invalid strings.*

<div align="center">

This parsing system was built using [NCalc](https://github.com/ncalc/ncalc).<br><br>

[![license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/mrrobinofficial/unity-parser/blob/HEAD/LICENSE.txt)
![maintenance-status](https://img.shields.io/badge/maintenance-as--is-yellow.svg)

</div>

## Introduction

Parser is a helping system for folks who wants to parser string values into object values.<br><br>
**NOTE:** This system will try to parse string value as user input into object value.
For an example:

```c#
string input = "on"; // True
```

```c#
string input = "off"; // False
```

I do **NOT** recommend using this parsing system for serializing data. Instead, I highly recommend checking out my other project on [uJSON](https://github.com/MrRobinOfficial/Unity-JSON) for a more suitable solution for serializing data.

## Installation

* [Add package](https://docs.unity3d.com/Manual/upm-ui-giturl.html) from this git URL: ```com.mrrobin.parser``` or https://github.com/MrRobinOfficial/Unity-Parser.git

Or

* Clone repo and build via Visual Studio as an .DLL

## Quick guide

```c#
using UnityParsers;
```
Avoid regular parse method (Can cause errors if not parse correct!)
```c#
private const string VECTOR3 = "(-50, 30, 100)";
Parsers.Parse<UnityEngine.Vector2Int>(VECTOR3); // This will gives us error! Use TryParse instead for error-proud solution!
```
For an example
```c#
if (Parsers.TryParseVector3(VECTOR3, out UnityEngine.Vector3 result))
{

}

```
Avoid boxing/unboxing if you can. [Read more about it](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing)
```c#
private const string VECTOR3 = "(-50, 30, 100)";
if (Parsers.TryParse(VECTOR3, out object result))
{
    // This take more performance because of boxing/unboxing values.
}
```
Tries to convert string with "off" into boolean
```c#
bool value = Parsers.ParseBoolean("off"); // This will return false
```
Tries to convert string with "bytes color format" into Color32
```c#
private const string COLOR_32 = "(255, 0, 0)";
Parsers.TryParseColor32(COLOR_32, out var color32); // Will return value as Color32
```
