namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InsufficientBufferException : ImagingException
    {
        public InsufficientBufferException() : base(ImagingError.InsufficientBuffer)
        {
        }

        public InsufficientBufferException(Exception innerException) : base(ImagingError.InsufficientBuffer, innerException)
        {
        }

        public InsufficientBufferException(string message) : base(ImagingError.InsufficientBuffer, message)
        {
        }

        protected InsufficientBufferException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InsufficientBufferException(string message, Exception innerException) : base(ImagingError.InsufficientBuffer, message, innerException)
        {
        }
    }
}

