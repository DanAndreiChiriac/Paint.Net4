namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class BadHeaderException : ImagingException
    {
        public BadHeaderException() : base(ImagingError.BadHeader)
        {
        }

        public BadHeaderException(Exception innerException) : base(ImagingError.BadHeader, innerException)
        {
        }

        public BadHeaderException(string message) : base(ImagingError.BadHeader, message)
        {
        }

        protected BadHeaderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public BadHeaderException(string message, Exception innerException) : base(ImagingError.BadHeader, message, innerException)
        {
        }
    }
}

