namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class RequestOnlyValidAtMetadataRootException : ImagingException
    {
        public RequestOnlyValidAtMetadataRootException() : base(ImagingError.RequestOnlyValidAtMetadataRoot)
        {
        }

        public RequestOnlyValidAtMetadataRootException(Exception innerException) : base(ImagingError.RequestOnlyValidAtMetadataRoot, innerException)
        {
        }

        public RequestOnlyValidAtMetadataRootException(string message) : base(ImagingError.RequestOnlyValidAtMetadataRoot, message)
        {
        }

        protected RequestOnlyValidAtMetadataRootException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public RequestOnlyValidAtMetadataRootException(string message, Exception innerException) : base(ImagingError.RequestOnlyValidAtMetadataRoot, message, innerException)
        {
        }
    }
}

