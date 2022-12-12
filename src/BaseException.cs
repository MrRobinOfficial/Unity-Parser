using System;
using System.Runtime.Serialization;

namespace uParser
{
    [Serializable]
    public class BaseException : Exception
    {
        public BaseException(string message) : base(message) { }

        public BaseException(string message,
                             Exception innerException) : base(message, innerException) { }

        protected BaseException(SerializationInfo serializationInfo,
                                StreamingContext streamingContext) : base(serializationInfo, streamingContext) { }
    }
}
