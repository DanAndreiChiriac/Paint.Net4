namespace PaintDotNet
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InternalErrorException : Exception
    {
        public InternalErrorException()
        {
        }

        public InternalErrorException(Exception innerException) : this(null, innerException)
        {
        }

        public InternalErrorException(string message) : base(message)
        {
        }

        protected InternalErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InternalErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

