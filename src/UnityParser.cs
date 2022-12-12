using System;
using UnityEngine;
using System.Collections.Generic;
using uParser.Exceptions;
using NCalc;
using System.Globalization;

namespace uParser
{
    /// @brief
    public static partial class UnityParser
    {
      //public static bool TryParseVector3(ReadOnlySpan<char> input, out Vector3 result)
        //{
        //    result = default;

        //    // Split the input string by commas and whitespace.
        //    var parts = input.Split(new char[] { ',', ' ' });

        //    if (parts.Length != 3)
        //    {
        //        // The input string does not have the correct number of parts.
        //        return false;
        //    }

        //    // Try to parse the x, y, and z components of the vector.
        //    if (!float.TryParse(parts[0], out float x) ||
        //        !float.TryParse(parts[1], out float y) ||
        //        !float.TryParse(parts[2], out float z))
        //    {
        //        // One or more of the components could not be parsed.
        //        return false;
        //    }

        //    result = new Vector3(x, y, z);
        //    return true;
        //}
        
        /// <summary>
        /// Hello World
        /// </summary>
        public static void Test()
        {
            
        }

        /// @brief Try Parse Vector3
        /// @param[in] input String input
        /// @param[out] result Convert string into Vector3
        /// @return Boolean whether it succeeded or not
        public static bool TryParseVector3(string input, out Vector3 result)
        {
            result = Vector3.zero;
            input = input.Trim(k_TrimChars);

            var subStrings = input.Split(k_SeperateChar, StringSplitOptions.RemoveEmptyEntries);

            if (float.TryParse(subStrings[0], out var x) &&
                float.TryParse(subStrings[1], out var y) &&
                float.TryParse(subStrings[2], out var z))
                result.Set(x, y, z);

            return false;
        }

        /// @brief Parse Vector3
        /// @param[in] input String input
        /// @return Result in [Vector2]
        public static Vector3 ParseVector3(string input)
        {
            input = input.Trim(k_TrimChars);

            var subStrings = input.Split(k_SeperateChar, StringSplitOptions.RemoveEmptyEntries);

            return new Vector3
            {
                x = float.Parse(subStrings[0]),
                y = float.Parse(subStrings[1]),
                z = float.Parse(subStrings[2]),
            };
        }

        /// @brief Try Parse Vector2
        /// @param[in] input String input
        /// @param[out] result Convert string into Vector3
        /// @return Boolean whether it succeeded or not
        public static bool TryParseVector2(string input, out Vector2 result)
        {
            result = Vector3.zero;
            input = input.Trim(k_TrimChars);

            var subStrings = input.Split(k_SeperateChar);

            if (float.TryParse(subStrings[0], out var x) &&
                float.TryParse(subStrings[1], out var y))
                result.Set(x, y);

            return false;
        }

        /// @brief Parse Vector2
        /// @param[in] input String input
        /// @return Result in [Vector2]
        public static Vector2 ParseVector2(string input)
        {
            input = input.Trim(k_TrimChars);

            var subStrings = input.Split(k_SeperateChar);

            return new Vector2
            {
                x = float.Parse(subStrings[0]),
                y = float.Parse(subStrings[1]),
            };
        }

        //public static bool TryParse<T>(string value, out object result) where T : struct
        //{
        //    if (float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var b))
        //    {
        //        result = b;
        //        return true;
        //    }
        //    if (int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var a))
        //    {
        //        result = a;
        //        return true;
        //    }
        //    if (double.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var c))
        //    {
        //        result = c;
        //        return true;
        //    }
        //    if (decimal.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var d))
        //    {
        //        result = d;
        //        return true;
        //    }
        //    if (long.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var e))
        //    {
        //        result = e;
        //        return true;
        //    }
        //    if (ulong.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var f))
        //    {
        //        result = f;
        //        return true;
        //    }
        //    if (short.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var g))
        //    {
        //        result = g;
        //        return true;
        //    }
        //    if (ushort.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var h))
        //    {
        //        result = h;
        //        return true;
        //    }
        //    if (byte.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var i))
        //    {
        //        result = i;
        //        return true;
        //    }
        //    if (sbyte.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var j))
        //    {
        //        result = j;
        //        return true;
        //    }
        //    if (TryParseBoolean(value, out var k))
        //    {
        //        result = k;
        //        return true;
        //    }
        //    if (char.TryParse(value, out var l))
        //    {
        //        result = l;
        //        return true;
        //    }
        //    if (uint.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var m))
        //    {
        //        result = m;
        //        return true;
        //    }
        //    if (TryParseString(value, out var str))
        //    {
        //        result = str;
        //        return true;
        //    }
        //    string[] array = value.Replace(" ", "").Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //    for (int x = 0; x < array.Length; x++)
        //    {
        //        Expression exp = new Expression(array[x], EvaluateOptions.IgnoreCase);
        //        array[x] = $"{exp.Evaluate()}";
        //        array[x] = array[x].Replace(',', '.');
        //        value = string.Join(", ", array);
        //    }
        //    if (TryParseVector2Int(value, out var vector2Int))
        //    {
        //        result = vector2Int;
        //        return true;
        //    }
        //    if (TryParseVector3Int(value, out var vector3Int))
        //    {
        //        result = vector3Int;
        //        return true;
        //    }
        //    if (TryParseVector2(value, out var vector2))
        //    {
        //        result = vector2;
        //        return true;
        //    }
        //    if (TryParseVector3(value, out var vector3))
        //    {
        //        result = vector3;
        //        return true;
        //    }
        //    if (TryParseVector4(value, out var vector4))
        //    {
        //        result = vector4;
        //        return true;
        //    }
        //    if (TryParseQuaternion(value, out var rot))
        //    {
        //        result = rot;
        //        return true;
        //    }
        //    if (TryParseColor(value, out var color))
        //    {
        //        result = color;
        //        return true;
        //    }
        //    if (TryParseColor32(value, out var color2))
        //    {
        //        result = color2;
        //        return true;
        //    }
        //    if (TryParseGameObject(value, out var obj))
        //    {
        //        result = obj;
        //        return true;
        //    }
        //    if (TryParseTexture2D(value, out var tex2D))
        //    {
        //        result = tex2D;
        //        return true;
        //    }
        //    if (TryParseAudioClip(value, out var clip))
        //    {
        //        result = clip;
        //        return true;
        //    }
        //    if (TryParseSprite(value, out var sprite))
        //    {
        //        result = sprite;
        //        return true;
        //    }
        //    if (TryParseMaterial(value, out var mat))
        //    {
        //        result = mat;
        //        return true;
        //    }
        //    if (TryParseRect(value, out var rect))
        //    {
        //        result = rect;
        //        return true;
        //    }
        //    result = null;
        //    return false;
        //}
    }
}