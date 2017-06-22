namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class StreamReadException : ImagingException
    {
        public StreamReadException() : base(ImagingError.StreamRead)
        {
        }

        public StreamReadException(Exception innerException) : base(ImagingError.StreamRead, innerException)
        {
        }

        public StreamReadException(string message) : base(ImagingError.StreamRead, message)
        {
        }

        protected StreamReadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public StreamReadException(string message, Exception innerException) : base(ImagingError.StreamRead, message, innerException)
        {
        }
    }
}

