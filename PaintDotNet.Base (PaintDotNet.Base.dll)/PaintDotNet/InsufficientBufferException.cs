namespace PaintDotNet
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InsufficientBufferException : Exception
    {
        public InsufficientBufferException() : this(null, null, InteropError.InsufficientBuffer)
        {
        }

        public InsufficientBufferException(Exception innerException) : this(null, innerException, InteropError.InsufficientBuffer)
        {
        }

        public InsufficientBufferException(string message) : this(message, null, InteropError.InsufficientBuffer)
        {
        }

        protected InsufficientBufferException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InsufficientBufferException(string message, Exception innerException) : this(message, innerException, InteropError.InsufficientBuffer)
        {
        }

        protected InsufficientBufferException(string message, Exception innerException, InteropError hr) : this(message, innerException, (int) hr)
        {
        }

        public InsufficientBufferException(string message, Exception innerException, int hr) : base(message, innerException)
        {
            base.HResult = hr;
        }
    }
}

