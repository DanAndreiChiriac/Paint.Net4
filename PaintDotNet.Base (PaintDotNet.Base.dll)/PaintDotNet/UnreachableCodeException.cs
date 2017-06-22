namespace PaintDotNet
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class UnreachableCodeException : InternalErrorException
    {
        public UnreachableCodeException()
        {
        }

        public UnreachableCodeException(Exception innerException) : this(null, innerException)
        {
        }

        public UnreachableCodeException(string message) : base(message)
        {
        }

        protected UnreachableCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnreachableCodeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

