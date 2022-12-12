using System;
using System.Runtime.Serialization;

namespace uParser.Exceptions
{
    [Serializable]
    public class InvalidArgumentFormat : BaseException
    {
        public string argument { get; }

        public Type type { get; }

        public InvalidArgumentFormat(string argument, Type type)
            : base(GetMessage(argument,
                              type))
        {
            this.argument = argument;
            this.type = type;
        }

        private static string GetMessage(string argument, Type type) => $"Argument \"{argument}\" cannot be parsed into type {type.Name} because it is not in the correct format";

        protected InvalidArgumentFormat(SerializationInfo serializationInfo,
                                        StreamingContext streamingContext) : base(serializationInfo, streamingContext) { }
    }
}