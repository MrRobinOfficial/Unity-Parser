using System;
using System.Runtime.Serialization;

namespace uParser.Exceptions
{
    [Serializable]
    public class ParserInputException : BaseException
    {
        public ParserInputException(string message) : base(message) { }

        protected ParserInputException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext) { }
    }
}
