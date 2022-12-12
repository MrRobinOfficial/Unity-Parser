using System;
using System.Runtime.Serialization;

namespace uParser.Exceptions
{
    [Serializable]
    public class NoValidParserFound : BaseException
    {
        public Type type { get; }

        public NoValidParserFound(Type type)
            : base(GetMessage(type)) { this.type = type; }

        private static string GetMessage(Type type) => 
            $"No valid Parser method found for type '{type.Name}'";

        protected NoValidParserFound(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext) { }
    }
}