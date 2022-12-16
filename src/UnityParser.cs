using System;
using UnityEngine;
using System.Collections.Generic;
using uParser.Exceptions;
using NCalc;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

namespace uParser
{
    /// @brief
    public static partial class UnityParser
    {
        public static ulong ParseUnsignedLong(string input)
        {
            if (input == null)
                return 0ul;

            input = input
                .Trim(k_TrimChars);

            return 0ul;
        }

        public static uint ParseUnsignedInteger(string input)
        {
            if (input == null)
                return 0u;

            input = input
                .Trim(k_TrimChars);

            return 0u;
        }

        public static ushort ParseUnsignedShort(string input)
        {
            if (input == null)
                return 0;

            input = input
                .Trim(k_TrimChars);

            return 0;
        }

        public static short ParseShort(string input)
        {
            if (input == null)
                return 0;

            input = input
                .Trim(k_TrimChars);

            return 0;
        }

        public static int ParseInteger(string input)
        {
            if (input == null)
                return 0;

            input = input
                .Trim(k_TrimChars);

            return 0;
        }

        public static long ParseLong(string input)
        {
            if (input == null)
                return 0L;

            input = input
                .Trim(k_TrimChars);

            return 0L;
        }

        public static float ParseFloat(string input)
        {
            if (input == null)
                return 0f;

            input = input
                .Trim(k_TrimChars);

            return 0f;
        }

        public static double ParseDouble(string input)
        {
            if (input == null)
                return 0d;

            input = input
                .Trim(k_TrimChars);

            return 0d;
        }

        public static decimal ParseDecimal(string input)
        {
            if (input == null)
                return 0m;

            input = input
                .Trim(k_TrimChars);

            return 0m;
        }

        public static sbyte ParseSignedByte(string input)
        {
            if (input == null)
                return 0;

            input = input
                .Trim(k_TrimChars);

            return 0;
        }

        public static bool ParseBoolean(string input)
        {
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
                    return true;

                case "false":
                case "off":
                case "no":
                case "0":
                    return false;

                default:
                    throw new ParserInputException(message: $"Cannot parse '{input}' to a boolean");
            }
        }

        public static byte ParseByte(string input)
        {
            if (input == null)
                return 0;

            input = input
                .Trim(k_TrimChars);

            return 0;
        }

        public static char ParseChar(string input)
        {
            if (input == null)
                return char.MinValue;

            input = input
                .Trim(k_TrimChars);

            return char.MinValue;
        }

        public static Matrix4x4 ParseMatrix4x4(string input)
        {
            if (input == null)
                return Matrix4x4.identity;

            input = input
                .ToLower()
                .Trim(k_TrimChars);

            return Matrix4x4.identity;
        }

        public static Quaternion ParseQuaternion(string input)
        {
            if (input == null)
                return Quaternion.identity;

            input = input
                .ToLower()
                .Trim(k_TrimChars);

            float[] values = GenericParser<float, Quaternion>(input, 4, 4);
            return new Quaternion(values[0], values[1], values[2], values[3]);
        }

        public static Vector4 ParseVector4(string input)
        {
            if (input == null)
                return Vector4.zero;

            input = input
                .ToLower()
                .Trim(k_TrimChars);

            float[] values = GenericParser<float, Vector4>(input, 2, 4);
            return new Vector4(values[0], values[1], (values.Length > 2) ? values[2] : 0f, (values.Length > 3) ? values[3] : 0f);
        }

        /// @brief Parse Vector3
        /// @param[in] input String input
        /// @return Result in [Vector2]
        public static Vector3 ParseVector3(string input)
        {
            if (input == null)
                return Vector3.zero;

            input = input
                .ToLower()
                .Trim(k_TrimChars);

            var subStrings = input.Split(k_SeperateChar, StringSplitOptions.RemoveEmptyEntries);

            if (subStrings.Length < 3)
                throw new ParserInputException(message: "Parsing into <Vector3> requires 3 float values");

            return new Vector3
            {
                x = float.Parse(subStrings[0]),
                y = float.Parse(subStrings[1]),
                z = float.Parse(subStrings[2]),
            };
        }

        /// @brief Parse Vector2
        /// @param[in] input String input
        /// @return Result in [Vector2]
        public static Vector2 ParseVector2(string input)
        {
            if (input == null)
                return Vector2.zero;

            input = input
                .ToLower()
                .Trim(k_TrimChars);

            var subStrings = input.Split(k_SeperateChar);

            if (subStrings.Length < 2)
                throw new ParserInputException(message: "Parsing into <Vector3> requires 2 float values");

            return new Vector2
            {
                x = float.Parse(subStrings[0]),
                y = float.Parse(subStrings[1]),
            };
        }

        //public static Vector3 ParseVector3(string value)
        //{
        //    float[] values = GenericParser<float, Vector3>(value.Trim('(', ')'), 2, 3);
        //    return new Vector3(values[0], values[1], (values.Length > 2) ? values[2] : 0f);
        //}

        //public static Vector2 ParseVector2(string value)
        //{
        //    float[] values = GenericParser<float, Vector2>(value.Trim('(', ')'), 2, 2);
        //    return new Vector2(values[0], values[1]);
        //}

        public static Vector3Int ParseVector3Int(string input)
        {
            if (input == null)
                return Vector3Int.zero;

            input = input
                .ToLower()
                .Trim(k_TrimChars);

            int[] values = GenericParser<int, Vector3Int>(input, 2, 3);
            return new Vector3Int(values[0], values[1], (values.Length > 2) ? values[2] : 0);
        }

        public static Vector2Int ParseVector2Int(string input)
        {
            if (input == null)
                return Vector2Int.zero;

            input = input
                .ToLower()
                .Trim(k_TrimChars);

            int[] values = GenericParser<int, Vector2Int>(input, 2, 2);
            return new Vector2Int(values[0], values[1]);
        }

        public static Color32 ParseColor32(string input)
        {
            if (input == null)
                return default;

            input = input
                .ToLower()
                .Trim(k_TrimChars);

            var match = Regex.Match(input, k_HexColorRegxPattern, RegexOptions.Compiled);

            if (match.Success &&
                ColorUtility.TryParseHtmlString(input, out var color))
                return color;

            byte[] values = GenericParser<byte, Color32>(input, 3, 4);

            return new Color32(values[0],
                               values[1],
                               values[2],
                               (values.Length > 3) ? values[3] : byte.MaxValue);
        }

        public static Color ParseColor(string input)
        {
            if (input == null)
                return default;

            input = input
                .ToLower()
                .Trim(k_TrimChars);

            var match = Regex.Match(input, k_HexColorRegxPattern, RegexOptions.Compiled);

            if (match.Success &&
                ColorUtility.TryParseHtmlString(input, out var color))
                return color;

            float[] values = GenericParser<float, Color>(input, 3, 4);

            return new Color(values[0],
                             values[1],
                             values[2],
                             (values.Length > 3) ? values[3] : 1f);
        }

        public static Rect ParseRect(string input)
        {
            if (input == null)
                return Rect.zero;

            input = input
                .ToLower()
                .Trim(k_TrimChars);

            float[] values = GenericParser<float, Rect>(input, 4, 4);
            return new Rect(values[0], values[1], values[2], values[3]);
        }

        public static Hash128 ParseHash128(string input)
        {
            if (input == null)
                return default;

            input = input
                .ToLower()
                .Trim(k_TrimChars);

            return Hash128.Parse(input);
        }

        public static Scene ParseScene(string input)
        {
            if (input == null)
                return default;

            input = input
                .Trim(k_TrimChars);

            return SceneManager.GetSceneByName(input);
        }

        public static Texture2D ParseTexture2D(string input)
        {
            if (input == null)
                return null;

            input = input
                .ToLower()
                .Trim(k_TrimChars);

            if (!input.StartsWith(k_PathPrefix, StringComparison.InvariantCultureIgnoreCase))
                return null;

            return Resources.Load<Texture2D>(input);
        }

        public static Sprite ParseSprite(string input)
        {
            if (input == null)
                return null;

            input = input
                .ToLower()
                .Trim(k_TrimChars);

            if (!input.StartsWith(k_PathPrefix, StringComparison.InvariantCultureIgnoreCase))
                return null;

            return Resources.Load<Sprite>(input);
        }

        public static Material ParseMaterial(string input)
        {
            if (input == null)
                return null;

            input = input
                .ToLower()
                .Trim(k_TrimChars);

            if (!input.StartsWith(k_PathPrefix, StringComparison.InvariantCultureIgnoreCase))
                return null;

            return Resources.Load<Material>(input);
        }

        public static GameObject ParseGameObject(string input)
        {
            if (input == null)
                return null;

            input = input
                .ToLower()
                .Trim(k_TrimChars);

            if (input.StartsWith(k_PathPrefix, StringComparison.InvariantCultureIgnoreCase))
            {
                input = input
                    .Substring(startIndex: 4)
                    .Trim(k_TrimChars);

                return Resources.Load<GameObject>(input);
            }

            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                GameObject[] objects = SceneManager.GetSceneAt(i).GetRootGameObjects();

                for (int j = 0; j < objects.Length; j++)
                {
                    Transform[] children = objects[j].GetComponentsInChildren<Transform>(includeInactive: true);

                    for (int k = 0; k < children.Length; k++)
                    {
                        if (string.Equals(children[k].name, input, StringComparison.InvariantCultureIgnoreCase))
                            return children[k].gameObject;
                    }
                }
            }

            return null;
        }

        public static Component ParseComponent(string input)
        {
            if (input == null)
                return null;

            input = input
                .ToLower()
                .Trim(k_TrimChars);

            if (input.StartsWith(k_PathPrefix, StringComparison.InvariantCultureIgnoreCase))
            {
                input = input
                    .Substring(startIndex: 4)
                    .Trim(k_TrimChars);

                return Resources.Load<Component>(input);
            }

            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                GameObject[] objects = SceneManager.GetSceneAt(i).GetRootGameObjects();

                for (int j = 0; j < objects.Length; j++)
                {
                    Transform[] children = objects[j].GetComponentsInChildren<Transform>(includeInactive: true);

                    for (int k = 0; k < children.Length; k++)
                    {
                        if (string.Equals(children[k].name, input, StringComparison.CurrentCultureIgnoreCase))
                            return children[k];
                    }
                }
            }

            return null;
        }

        public static T ParseMath<T>(string input) where T : unmanaged
        {
            var ex = new Expression(input);
            var result = ex.Evaluate();

            if (result.GetType() != typeof(T))
                throw new ParserInputException(message: $"Failed casting into <{typeof(T).Name}>");

            return (T)result;
        }

        public static object ParseMath(string input)
        {
            var ex = new Expression(input);
            return ex.Evaluate();
        }

        // public static AudioClip ParseAudioClip(string input) => Resources.Load<AudioClip>(input);

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
    }
}