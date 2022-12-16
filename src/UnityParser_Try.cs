using System;
using UnityEngine;
using System.Collections.Generic;
using uParser.Exceptions;
using NCalc;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;
using UnityEngine.SceneManagement;

namespace uParser
{
    public static partial class UnityParser
    {
        /// @brief Try Parse Vector3
        /// @param[in] input String input
        /// @param[out] result Convert string into Vector3
        /// @return Boolean whether it succeeded or not
        public static bool TryParseVector3(string input, out Vector3 result)
        {
            result = Vector3.zero;

            if (input == null)
                return false;

            input = input.Trim(k_TrimChars);

            var subStrings = input.Split(k_SeperateChar, StringSplitOptions.RemoveEmptyEntries);

            if (float.TryParse(subStrings[0], out var x) &&
                float.TryParse(subStrings[1], out var y) &&
                float.TryParse(subStrings[2], out var z))
                result.Set(x, y, z);

            return false;
        }

        /// @brief Try Parse Vector2
        /// @param[in] input String input
        /// @param[out] result Convert string into Vector3
        /// @return Boolean whether it succeeded or not
        public static bool TryParseVector2(string input, out Vector2 result)
        {
            result = Vector3.zero;

            if (input == null)
                return false;

            input = input.Trim(k_TrimChars);

            var subStrings = input.Split(k_SeperateChar);

            if (float.TryParse(subStrings[0], out var x) &&
                float.TryParse(subStrings[1], out var y))
                result.Set(x, y);

            return false;
        }

        public static bool TryParseBoolean(string input, out bool result)
        {
            result = false;

            if (input == null)
                return false;

            input = input
                .ToLower()
                .Trim(k_TrimChars);

            switch (input)
            {
                case "true":
                case "on":
                case "yes":
                case "1":
                    result = true;
                    return true;

                case "false":
                case "off":
                case "no":
                case "0":
                    result = false;
                    return true;

                default:
                    return false;
            }
        }

        public static bool TryParseMath<T>(string input, out T result) where T : unmanaged
        {
            result = default;

            var ex = new Expression(input);
            var _result = ex.Evaluate();

            if (_result.GetType() == typeof(T))
            {
                result = (T)_result;
                return true;
            }

            return false;
        }

        public static bool TryParseMath<T>(string input, out object result)
        {
            result = default;

            var ex = new Expression(input);
            result = ex.Evaluate();

            return result != null;
        }


        //public static bool TryParseScene(string value, out Scene result)
        //{
        //    try
        //    {
        //        result = ParseScene(value);
        //        return true;
        //    }
        //    catch (BaseException)
        //    {
        //        result = default(Scene);
        //        return false;
        //    }
        //}

        //public static bool TryParseQuaternion(string value, out Quaternion result)
        //{
        //    try
        //    {
        //        result = ParseQuaternion(value);
        //        return true;
        //    }
        //    catch (BaseException)
        //    {
        //        result = default(Quaternion);
        //        return false;
        //    }
        //}

        //public static bool TryParseMatrix4x4(string value, out Matrix4x4 result)
        //{
        //    try
        //    {
        //        result = ParseMatrix4x4(value);
        //        return true;
        //    }
        //    catch (BaseException)
        //    {
        //        result = default(Matrix4x4);
        //        return false;
        //    }
        //}

        //public static bool TryParseVector4(string value, out Vector4 result)
        //{
        //    try
        //    {
        //        result = ParseVector4(value);
        //        return true;
        //    }
        //    catch (BaseException)
        //    {
        //        result = default(Vector4);
        //        return false;
        //    }
        //}

        //public static bool TryParseVector3(string value, out Vector3 result)
        //{
        //    try
        //    {
        //        result = ParseVector3(value);
        //        return true;
        //    }
        //    catch (BaseException)
        //    {
        //        result = default(Vector3);
        //        return false;
        //    }
        //}

        //public static bool TryParseVector2(string value, out Vector2 result)
        //{
        //    try
        //    {
        //        result = ParseVector2(value);
        //        return true;
        //    }
        //    catch (BaseException)
        //    {
        //        result = default(Vector2);
        //        return false;
        //    }
        //}

        //public static bool TryParseVector3Int(string value, out Vector3Int result)
        //{
        //    try
        //    {
        //        result = ParseVector3Int(value);
        //        return true;
        //    }
        //    catch (BaseException)
        //    {
        //        result = default(Vector3Int);
        //        return false;
        //    }
        //}

        //public static bool TryParseVector2Int(string value, out Vector2Int result)
        //{
        //    try
        //    {
        //        result = ParseVector2Int(value);
        //        return true;
        //    }
        //    catch (BaseException)
        //    {
        //        result = default(Vector2Int);
        //        return false;
        //    }
        //}

        //public static bool TryParseColor(string value, out Color result)
        //{
        //    try
        //    {
        //        result = ParseColor(value);
        //        return true;
        //    }
        //    catch (BaseException)
        //    {
        //        result = default(Color);
        //        return false;
        //    }
        //}

        //public static bool TryParseColor32(string value, out Color32 result)
        //{
        //    try
        //    {
        //        result = ParseColor32(value);
        //        return true;
        //    }
        //    catch (BaseException)
        //    {
        //        result = default(Color32);
        //        return false;
        //    }
        //}

        //public static bool TryParseGameObject(string value, out GameObject result)
        //{
        //    try
        //    {
        //        result = ParseGameObject(value);
        //        return true;
        //    }
        //    catch (BaseException)
        //    {
        //        result = null;
        //        return false;
        //    }
        //}

        //public static bool TryParseComponent(string value, out Component result)
        //{
        //    try
        //    {
        //        result = ParseComponent(value);
        //        return true;
        //    }
        //    catch (BaseException)
        //    {
        //        result = null;
        //        return false;
        //    }
        //}

        //public static bool TryParseRect(string value, out Rect result)
        //{
        //    try
        //    {
        //        result = ParseRect(value);
        //        return true;
        //    }
        //    catch (BaseException)
        //    {
        //        result = default(Rect);
        //        return false;
        //    }
        //}

        //public static bool TryParseMaterial(string value, out Material result)
        //{
        //    try
        //    {
        //        result = ParseMaterial(value);
        //        return true;
        //    }
        //    catch (BaseException)
        //    {
        //        result = null;
        //        return false;
        //    }
        //}

        //public static bool TryParseAudioClip(string value, out AudioClip result)
        //{
        //    try
        //    {
        //        result = ParseAudioClip(value);
        //        return true;
        //    }
        //    catch (BaseException)
        //    {
        //        result = null;
        //        return false;
        //    }
        //}

        //public static bool TryParseTexture2D(string value, out Texture2D result)
        //{
        //    try
        //    {
        //        result = ParseTexture2D(value);
        //        return true;
        //    }
        //    catch (BaseException)
        //    {
        //        result = null;
        //        return false;
        //    }
        //}

        //public static bool TryParseSprite(string value, out Sprite result)
        //{
        //    try
        //    {
        //        result = ParseSprite(value);
        //        return true;
        //    }
        //    catch (BaseException)
        //    {
        //        result = null;
        //        return false;
        //    }
        //}

        //public static bool TryParseString(string value, out string result)
        //{
        //    if (value.Contains("\""))
        //    {
        //        MatchCollection matchCollection = new Regex("\".*?\"").Matches(value);
        //        StringBuilder builder = new StringBuilder();
        //        foreach (object item in matchCollection)
        //        {
        //            builder.Append(item.ToString() + " ");
        //        }
        //        result = builder.ToString().Replace("\"", "");
        //        return true;
        //    }
        //    result = string.Empty;
        //    return false;
        //}

        //public static bool TryParseArray<T>(string value, out T[] result)
        //{
        //    result = null;
        //    return false;
        //}

        //public static bool TryParseCollection<TKey, TValue>(string value, out Dictionary<TKey, TValue> result)
        //{
        //    result = null;
        //    return false;
        //}

        //public static bool TryParseEnumerable<T>(string value, out IEnumerable<T> result)
        //{
        //    result = null;
        //    return false;
        //}

        //public static bool TryParseEnum(string value, out Enum result)
        //{
        //    result = null;
        //    return false;
        //}

        //public static bool TryParseTuple<T1>(string value, out Tuple<T1> result)
        //{
        //    result = null;
        //    return false;
        //}

        //public static bool TryParseTuple<T1, T2>(string value, out Tuple<T1, T2> result)
        //{
        //    result = null;
        //    return false;
        //}

        //public static bool TryParseTuple<T1, T2, T3>(string value, out Tuple<T1, T2, T3> result)
        //{
        //    result = null;
        //    return false;
        //}

        //public static bool TryParseTuple<T1, T2, T3, T4>(string value, out Tuple<T1, T2, T3, T4> result)
        //{
        //    result = null;
        //    return false;
        //}

        //public static bool TryParseTuple<T1, T2, T3, T4, T5>(string value, out Tuple<T1, T2, T3, T4, T5> result)
        //{
        //    result = null;
        //    return false;
        //}

        //public static bool TryParseTuple<T1, T2, T3, T4, T5, T6>(string value, out Tuple<T1, T2, T3, T4, T5, T6> result)
        //{
        //    result = null;
        //    return false;
        //}

        //public static bool TryParseTuple<T1, T2, T3, T4, T5, T6, T7>(string value, out Tuple<T1, T2, T3, T4, T5, T6, T7> result)
        //{
        //    result = null;
        //    return false;
        //}

        //public static bool TryParseTuple<T1, T2, T3, T4, T5, T6, T7, TRest>(string value, out Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> result)
        //{
        //    result = null;
        //    return false;
        //}

        //public static bool TryParseType(string value, out Type result)
        //{
        //    result = null;
        //    return false;
        //}

        //public static bool TryParsePrimitive(string value, out ValueType result)
        //{
        //    if (int.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var a))
        //    {
        //        result = a;
        //        return true;
        //    }
        //    if (float.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var b))
        //    {
        //        result = b;
        //        return true;
        //    }
        //    if (double.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var c))
        //    {
        //        result = c;
        //        return true;
        //    }
        //    if (decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var d))
        //    {
        //        result = d;
        //        return true;
        //    }
        //    if (long.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var e))
        //    {
        //        result = e;
        //        return true;
        //    }
        //    if (ulong.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var f))
        //    {
        //        result = f;
        //        return true;
        //    }
        //    if (short.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var g))
        //    {
        //        result = g;
        //        return true;
        //    }
        //    if (ushort.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var h))
        //    {
        //        result = h;
        //        return true;
        //    }
        //    if (byte.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var i))
        //    {
        //        result = i;
        //        return true;
        //    }
        //    if (sbyte.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var j))
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
        //    result = null;
        //    return false;
        //}

        //public static bool TryParsePrimitive<T>(string value, out T result) where T : struct
        //{
        //    if (typeof(T) == typeof(int) && int.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var a))
        //    {
        //        result = (T)Convert.ChangeType(a, typeof(T));
        //        return true;
        //    }
        //    if (typeof(T) == typeof(float) && float.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var b))
        //    {
        //        result = (T)Convert.ChangeType(b, typeof(T));
        //        return true;
        //    }
        //    if (typeof(T) == typeof(double) && double.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var c))
        //    {
        //        result = (T)Convert.ChangeType(c, typeof(T));
        //        return true;
        //    }
        //    if (typeof(T) == typeof(decimal) && decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var d))
        //    {
        //        result = (T)Convert.ChangeType(d, typeof(T));
        //        return true;
        //    }
        //    if (typeof(T) == typeof(long) && long.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var e))
        //    {
        //        result = (T)Convert.ChangeType(e, typeof(T));
        //        return true;
        //    }
        //    if (typeof(T) == typeof(ulong) && ulong.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var f))
        //    {
        //        result = (T)Convert.ChangeType(f, typeof(T));
        //        return true;
        //    }
        //    if (typeof(T) == typeof(short) && short.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var g))
        //    {
        //        result = (T)Convert.ChangeType(g, typeof(T));
        //        return true;
        //    }
        //    if (typeof(T) == typeof(ushort) && ushort.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var h))
        //    {
        //        result = (T)Convert.ChangeType(h, typeof(T));
        //        return true;
        //    }
        //    if (typeof(T) == typeof(byte) && byte.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var i))
        //    {
        //        result = (T)Convert.ChangeType(i, typeof(T));
        //        return true;
        //    }
        //    if (typeof(T) == typeof(sbyte) && sbyte.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var j))
        //    {
        //        result = (T)Convert.ChangeType(j, typeof(T));
        //        return true;
        //    }
        //    if (typeof(T) == typeof(bool) && TryParseBoolean(value, out var k))
        //    {
        //        result = (T)Convert.ChangeType(k, typeof(T));
        //        return true;
        //    }
        //    if (typeof(T) == typeof(char) && char.TryParse(value, out var l))
        //    {
        //        result = (T)Convert.ChangeType(l, typeof(T));
        //        return true;
        //    }
        //    if (typeof(T) == typeof(uint) && uint.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var m))
        //    {
        //        result = (T)Convert.ChangeType(m, typeof(T));
        //        return true;
        //    }
        //    result = default(T);
        //    return false;
        //}

        //public static string ToHexColor(this Color value)
        //{
        //    return "#" + ColorUtility.ToHtmlStringRGB(value);
        //}

        //public static T Parse<T>(string value)
        //{
        //    return (T)Parse(value, typeof(T));
        //}

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
