# UnityParsers
A parsing system for Unity

# Intro

UnityParsers is a helping system for folks who wants to parser string values into object values. NOTE: This system will try to parse string value as user input into object value (For an example: boolean as on = true and off = false), because of this is NOT recommend to use in serializing data. 

This parsing system was built using [NCalc](https://github.com/ncalc/ncalc).

# How To Use It:

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
