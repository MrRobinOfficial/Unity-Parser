using UnityEngine;

namespace uParser
{
    public static partial class UnityParser
    {
        public static bool TryParseVector3(string input, out Vector3 value)
        {
            value = Vector3.zero;
            return false;
        }
    }
}