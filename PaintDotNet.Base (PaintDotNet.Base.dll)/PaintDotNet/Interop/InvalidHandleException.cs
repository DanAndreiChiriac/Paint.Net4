namespace PaintDotNet.Interop
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidHandleException : InteropException
    {
        public InvalidHandleException() : this(null, null, InteropError.InvalidHandle)
        {
        }

        public InvalidHandleException(Exception innerException) : this(null, innerException, InteropError.InvalidHandle)
        {
        }

        public InvalidHandleException(string message) : this(message, null, InteropError.InvalidHandle)
        {
        }

        protected InvalidHandleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidHandleException(string message, Exception innerException) : this(message, innerException, InteropError.InvalidHandle)
        {
        }

        protected InvalidHandleException(string message, Exception innerException, InteropError hr) : this(message, innerException, (int) hr)
        {
        }

        public InvalidHandleException(string message, Exception innerException, int hr) : base(message, innerException)
        {
            base.HResult = hr;
        }
    }
}

