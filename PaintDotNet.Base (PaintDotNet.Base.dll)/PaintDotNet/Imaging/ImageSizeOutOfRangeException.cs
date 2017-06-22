namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ImageSizeOutOfRangeException : ImagingException
    {
        public ImageSizeOutOfRangeException() : base(ImagingError.ImageSizeOutOfRange)
        {
        }

        public ImageSizeOutOfRangeException(Exception innerException) : base(ImagingError.ImageSizeOutOfRange, innerException)
        {
        }

        public ImageSizeOutOfRangeException(string message) : base(ImagingError.ImageSizeOutOfRange, message)
        {
        }

        protected ImageSizeOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ImageSizeOutOfRangeException(string message, Exception innerException) : base(ImagingError.ImageSizeOutOfRange, message, innerException)
        {
        }
    }
}

