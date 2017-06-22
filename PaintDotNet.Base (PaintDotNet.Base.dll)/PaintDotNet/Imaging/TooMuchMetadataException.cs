namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TooMuchMetadataException : ImagingException
    {
        public TooMuchMetadataException() : base(ImagingError.TooMuchMetadata)
        {
        }

        public TooMuchMetadataException(Exception innerException) : base(ImagingError.TooMuchMetadata, innerException)
        {
        }

        public TooMuchMetadataException(string message) : base(ImagingError.TooMuchMetadata, message)
        {
        }

        protected TooMuchMetadataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TooMuchMetadataException(string message, Exception innerException) : base(ImagingError.TooMuchMetadata, message, innerException)
        {
        }
    }
}

