namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class Win32ErrorException : Direct2DException
    {
        public Win32ErrorException() : base(Direct2DError.Win32Error)
        {
        }

        public Win32ErrorException(Exception innerException) : base(Direct2DError.Win32Error, innerException)
        {
        }

        public Win32ErrorException(string message) : base(Direct2DError.Win32Error, message)
        {
        }

        protected Win32ErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public Win32ErrorException(string message, Exception innerException) : base(Direct2DError.Win32Error, message, innerException)
        {
        }
    }
}

