namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class CodecNoThumbnailException : ImagingException
    {
        public CodecNoThumbnailException() : base(ImagingError.CodecNoThumbnail)
        {
        }

        public CodecNoThumbnailException(Exception innerException) : base(ImagingError.CodecNoThumbnail, innerException)
        {
        }

        public CodecNoThumbnailException(string message) : base(ImagingError.CodecNoThumbnail, message)
        {
        }

        protected CodecNoThumbnailException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public CodecNoThumbnailException(string message, Exception innerException) : base(ImagingError.CodecNoThumbnail, message, innerException)
        {
        }
    }
}

