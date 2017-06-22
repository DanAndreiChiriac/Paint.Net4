namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class UnexpectedMetadataTypeException : ImagingException
    {
        public UnexpectedMetadataTypeException() : base(ImagingError.UnexpectedMetadataType)
        {
        }

        public UnexpectedMetadataTypeException(Exception innerException) : base(ImagingError.UnexpectedMetadataType, innerException)
        {
        }

        public UnexpectedMetadataTypeException(string message) : base(ImagingError.UnexpectedMetadataType, message)
        {
        }

        protected UnexpectedMetadataTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnexpectedMetadataTypeException(string message, Exception innerException) : base(ImagingError.UnexpectedMetadataType, message, innerException)
        {
        }
    }
}

