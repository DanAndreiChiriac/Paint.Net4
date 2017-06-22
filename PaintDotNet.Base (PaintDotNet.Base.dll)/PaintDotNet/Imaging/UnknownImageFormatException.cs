namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class UnknownImageFormatException : ImagingException
    {
        public UnknownImageFormatException() : base(ImagingError.UnknownImageFormat)
        {
        }

        public UnknownImageFormatException(Exception innerException) : base(ImagingError.UnknownImageFormat, innerException)
        {
        }

        public UnknownImageFormatException(string message) : base(ImagingError.UnknownImageFormat, message)
        {
        }

        protected UnknownImageFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnknownImageFormatException(string message, Exception innerException) : base(ImagingError.UnknownImageFormat, message, innerException)
        {
        }
    }
}

