namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class UnsupportedOperationException : ImagingException
    {
        public UnsupportedOperationException() : base(ImagingError.UnsupportedOperation)
        {
        }

        public UnsupportedOperationException(Exception innerException) : base(ImagingError.UnsupportedOperation, innerException)
        {
        }

        public UnsupportedOperationException(string message) : base(ImagingError.UnsupportedOperation, message)
        {
        }

        protected UnsupportedOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnsupportedOperationException(string message, Exception innerException) : base(ImagingError.UnsupportedOperation, message, innerException)
        {
        }
    }
}

