namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class UnsupportedPixelFormatException : ImagingException
    {
        public UnsupportedPixelFormatException() : base(ImagingError.UnsupportedPixelFormat)
        {
        }

        public UnsupportedPixelFormatException(Exception innerException) : base(ImagingError.UnsupportedPixelFormat, innerException)
        {
        }

        public UnsupportedPixelFormatException(string message) : base(ImagingError.UnsupportedPixelFormat, message)
        {
        }

        protected UnsupportedPixelFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnsupportedPixelFormatException(string message, Exception innerException) : base(ImagingError.UnsupportedPixelFormat, message, innerException)
        {
        }
    }
}

