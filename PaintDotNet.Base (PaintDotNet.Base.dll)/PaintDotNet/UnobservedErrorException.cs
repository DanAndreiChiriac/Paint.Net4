namespace PaintDotNet
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class UnobservedErrorException : Exception
    {
        public UnobservedErrorException()
        {
        }

        public UnobservedErrorException(Exception innerException) : base(null, innerException)
        {
        }

        public UnobservedErrorException(string message) : base(message)
        {
        }

        protected UnobservedErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnobservedErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

