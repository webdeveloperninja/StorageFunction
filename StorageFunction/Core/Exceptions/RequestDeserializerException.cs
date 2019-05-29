using System;

namespace StorageFunction.Core.Exceptions
{
    public class RequestDeserializerException : Exception
    {
        public RequestDeserializerException()
        {
        }

        public RequestDeserializerException(string message)
            : base(message)
        {
        }

        public RequestDeserializerException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
