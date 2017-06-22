namespace PaintDotNet.Threading
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class DispatcherException : Exception
    {
        public DispatcherException()
        {
        }

        public DispatcherException(Exception innerException) : base(null, innerException)
        {
        }

        public DispatcherException(string message) : base(message)
        {
        }

        protected DispatcherException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public DispatcherException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

