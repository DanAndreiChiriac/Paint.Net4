namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class BadMetadataHeaderException : ImagingException
    {
        public BadMetadataHeaderException() : base(ImagingError.BadMetadataHeader)
        {
        }

        public BadMetadataHeaderException(Exception innerException) : base(ImagingError.BadMetadataHeader, innerException)
        {
        }

        public BadMetadataHeaderException(string message) : base(ImagingError.BadMetadataHeader, message)
        {
        }

        protected BadMetadataHeaderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public BadMetadataHeaderException(string message, Exception innerException) : base(ImagingError.BadMetadataHeader, message, innerException)
        {
        }
    }
}

