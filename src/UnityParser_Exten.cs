using System;
using System.Globalization;
using uParser.Exceptions;

namespace uParser
{
    public static partial class UnityParser
    {
        private static readonly char[] k_TrimChars = new char[]
        {
            '(',
            ')',
        };

        private static readonly char[] k_SeperateChar = new char[]
        {
            ',',
            ' ',
        };

        private static ArgumentType[] GenericParser<ArgumentType, ObjectType>(string input,
                                                                              int minRange,
                                                                              int maxRange) where ArgumentType : IConvertible
        {
            if (input is null)
                throw new ArgumentNullException(nameof(input));

            string[] array = GenericSplitter<ObjectType>(input, minRange, maxRange);
            ArgumentType[] values = new ArgumentType[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Trim() == null || DBNull.Value.Equals(array[i].Trim()))
                    continue;

                try
                {
                    values[i] = (ArgumentType)Convert.ChangeType(array[i].Trim(), typeof(ArgumentType), CultureInfo.InvariantCulture);
                }
                catch (FormatException)
                {
                    //if (TryParse(array[i].Trim(), out var obj))
                    //{
                    //    values[i] = (ArgumentType)Convert.ChangeType(obj, typeof(ArgumentType), CultureInfo.InvariantCulture);
                    //}
                    //else
                    //    values[i] = default(ArgumentType);

                    values[i] = default(ArgumentType);
                }
            }

            return values;
        }

        private static string[] GenericSplitter<T>(string input,
                                                   int minRange,
                                                   int maxRange)
        {
            if (input is null)
                throw new ArgumentNullException(nameof(input));

            var array = input.Split(k_SeperateChar, StringSplitOptions.RemoveEmptyEntries);

            if (array.Length < minRange || array.Length > maxRange)
                throw new InvalidArgumentFormat(input, typeof(T));

            return array;
        }
    }
}
