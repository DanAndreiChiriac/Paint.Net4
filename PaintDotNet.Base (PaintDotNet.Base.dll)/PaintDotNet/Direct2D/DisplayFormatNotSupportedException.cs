namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class DisplayFormatNotSupportedException : Direct2DException
    {
        public DisplayFormatNotSupportedException() : base(Direct2DError.DisplayFormatNotSupported)
        {
        }

        public DisplayFormatNotSupportedException(Exception innerException) : base(Direct2DError.DisplayFormatNotSupported, innerException)
        {
        }

        public DisplayFormatNotSupportedException(string message) : base(Direct2DError.DisplayFormatNotSupported, message)
        {
        }

        protected DisplayFormatNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public DisplayFormatNotSupportedException(string message, Exception innerException) : base(Direct2DError.DisplayFormatNotSupported, message, innerException)
        {
        }
    }
}

