namespace PaintDotNet.Rendering
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class RenderingException : InteropException
    {
        public RenderingException() : this(null, null, InteropError.Fail)
        {
        }

        public RenderingException(Exception innerException) : this(null, innerException, InteropError.Fail)
        {
        }

        public RenderingException(string message) : this(message, null, InteropError.Fail)
        {
        }

        protected RenderingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public RenderingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RenderingException(string message, Exception innerException, InteropError hr) : this(message, innerException, (int) hr)
        {
        }

        public RenderingException(string message, Exception innerException, int hr) : base(message, innerException)
        {
            base.HResult = hr;
        }
    }
}

