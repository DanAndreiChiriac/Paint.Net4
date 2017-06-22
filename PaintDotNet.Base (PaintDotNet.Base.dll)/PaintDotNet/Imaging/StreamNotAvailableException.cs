namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class StreamNotAvailableException : ImagingException
    {
        public StreamNotAvailableException() : base(ImagingError.StreamNotAvailable)
        {
        }

        public StreamNotAvailableException(Exception innerException) : base(ImagingError.StreamNotAvailable, innerException)
        {
        }

        public StreamNotAvailableException(string message) : base(ImagingError.StreamNotAvailable, message)
        {
        }

        protected StreamNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public StreamNotAvailableException(string message, Exception innerException) : base(ImagingError.StreamNotAvailable, message, innerException)
        {
        }
    }
}

