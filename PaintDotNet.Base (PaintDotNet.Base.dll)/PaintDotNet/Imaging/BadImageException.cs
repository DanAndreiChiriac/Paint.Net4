namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class BadImageException : ImagingException
    {
        public BadImageException() : base(ImagingError.BadImage)
        {
        }

        public BadImageException(Exception innerException) : base(ImagingError.BadImage, innerException)
        {
        }

        public BadImageException(string message) : base(ImagingError.BadImage, message)
        {
        }

        protected BadImageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public BadImageException(string message, Exception innerException) : base(ImagingError.BadImage, message, innerException)
        {
        }
    }
}

