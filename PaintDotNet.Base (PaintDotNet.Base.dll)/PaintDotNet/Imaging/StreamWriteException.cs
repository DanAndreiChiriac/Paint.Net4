namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class StreamWriteException : ImagingException
    {
        public StreamWriteException() : base(ImagingError.StreamWrite)
        {
        }

        public StreamWriteException(Exception innerException) : base(ImagingError.StreamWrite, innerException)
        {
        }

        public StreamWriteException(string message) : base(ImagingError.StreamWrite, message)
        {
        }

        protected StreamWriteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public StreamWriteException(string message, Exception innerException) : base(ImagingError.StreamWrite, message, innerException)
        {
        }
    }
}

