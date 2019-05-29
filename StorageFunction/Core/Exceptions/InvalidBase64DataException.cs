namespace StorageFunction.Core.Exceptions
{
    using System;

    public class InvalidBase64DataException : Exception
    {
        public InvalidBase64DataException()
        {
        }

        public InvalidBase64DataException(string message)
            : base(message)
        {
        }

        public InvalidBase64DataException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
