<!-- markdownlint-disable-next-line -->
<p align="center">
  <a href="#" rel="noopener" target="_blank"><img width="150" src="Resources/UnityParser_128x128.png" alt="Parser logo"></a>
</p>

<h1 align="center">Parser [Unity Engine]</h1>

*Parsing system for Unity that helps developers easily convert strings into various data types within the engine. This system supports a wide range of data types, and offers try-parse methods to avoid allocating extra memory when parsing invalid strings.*

<div align="center">

This parsing system was built using [NCalc](https://github.com/ncalc/ncalc).<br><br>

[![license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/mrrobinofficial/unity-parser/blob/HEAD/LICENSE.txt)

</div>

## Introduction

Parser is a helping system for folks who wants to parser string values into object values.<br><br>
**NOTE:** This system will try to parse string value as user input into object value (For an example: boolean as on = true and off = false), because of this is **NOT** recommend to use in serializing data. 

## Installation

Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam vel efficitur enim. Donec lobortis nibh ac commodo viverra. Curabitur scelerisque mi nisi, ac fringilla ante porta quis. Morbi aliquam posuere mauris. Fusce condimentum est accumsan lorem sagittis convallis. Curabitur egestas, arcu vitae varius tempor, turpis libero aliquam nisi, et gravida leo urna non sem. In vulputate tincidunt lectus, eget blandit tortor. Morbi id luctus urna. Vestibulum in magna at metus ultricies vulputate. Ut ultricies hendrerit tortor sit amet fringilla. Nullam nec suscipit neque. Pellentesque in vulputate lectus.

Nunc consequat diam id turpis imperdiet, id tempus turpis dictum. Vestibulum non rhoncus orci, nec vestibulum elit. Vestibulum eu blandit erat. Duis porta ultrices tellus sit amet efficitur. Morbi dignissim justo pellentesque turpis elementum dapibus. Vivamus rutrum ligula et elementum viverra. Maecenas blandit varius purus a faucibus. Aenean leo tellus, lacinia et nisl sed, iaculis sodales ipsum. Aenean sollicitudin, libero ac viverra pellentesque, odio odio rhoncus turpis, eu mattis ligula dolor ut risus. Vivamus tincidunt nisl vitae nunc aliquet pulvinar ac quis nisi. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Sed pharetra lacus aliquet porttitor tempus.

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
