namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class UnexpectedSizeException : ImagingException
    {
        public UnexpectedSizeException() : base(ImagingError.UnexpectedSize)
        {
        }

        public UnexpectedSizeException(Exception innerException) : base(ImagingError.UnexpectedSize, innerException)
        {
        }

        public UnexpectedSizeException(string message) : base(ImagingError.UnexpectedSize, message)
        {
        }

        protected UnexpectedSizeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnexpectedSizeException(string message, Exception innerException) : base(ImagingError.UnexpectedSize, message, innerException)
        {
        }
    }
}

