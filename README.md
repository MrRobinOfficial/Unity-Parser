# UnityParsers
A parsing system for Unity

#Intro

UnityParsers is a helping system for folks who wants to parser string values into object values. NOTE: This system will try to parse string value as user input into object value (For an example: boolean as on = true and off = false), because of this is NOT recommend to use in serializing data. 

This parsing system was built using [NCalc](https://github.com/ncalc/ncalc).

#How To Use It:

`
using UnityParsers;

public class ParsingExample
{
    private const string VECTOR3 = "(-50, 30, 100)";
    private const string COLOR_32 = "(255, 0, 0)";

    private void Main()
    {
        if (Parsers.TryParseVector3(VECTOR3, out UnityEngine.Vector3 vector3))
            vector3.x += 50;

        Parsers.Parse<UnityEngine.Vector2Int>(VECTOR3); // This will gives us error! Use TryParse instead for error-proud solution!

        if (Parsers.TryParse(VECTOR3, out object result))
        {
            // This take more performance because of boxing/unboxing values.
        }

        Parsers.TryParseColor32(COLOR_32, out var color32);

        bool value = Parsers.ParseBoolean("off"); // This will return false
    }
}
`
