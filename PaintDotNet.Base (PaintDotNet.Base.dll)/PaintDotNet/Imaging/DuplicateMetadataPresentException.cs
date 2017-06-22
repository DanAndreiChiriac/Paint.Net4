namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class DuplicateMetadataPresentException : ImagingException
    {
        public DuplicateMetadataPresentException() : base(ImagingError.DuplicateMetadataPresent)
        {
        }

        public DuplicateMetadataPresentException(Exception innerException) : base(ImagingError.DuplicateMetadataPresent, innerException)
        {
        }

        public DuplicateMetadataPresentException(string message) : base(ImagingError.DuplicateMetadataPresent, message)
        {
        }

        protected DuplicateMetadataPresentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public DuplicateMetadataPresentException(string message, Exception innerException) : base(ImagingError.DuplicateMetadataPresent, message, innerException)
        {
        }
    }
}

