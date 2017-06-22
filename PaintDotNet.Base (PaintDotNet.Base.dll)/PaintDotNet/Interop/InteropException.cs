namespace PaintDotNet.Interop
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;

    [Serializable]
    public abstract class InteropException : COMException
    {
        public InteropException() : this(null, null, InteropError.Fail)
        {
        }

        public InteropException(Exception innerException) : this(null, innerException, InteropError.Fail)
        {
        }

        public InteropException(string message) : this(message, null, InteropError.Fail)
        {
        }

        protected InteropException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InteropException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InteropException(string message, Exception innerException, InteropError hr) : this(message, innerException, (int) hr)
        {
        }

        public InteropException(string message, Exception innerException, int hr) : base(message, innerException)
        {
            base.HResult = hr;
        }
    }
}

