namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InternalErrorException : ImagingException
    {
        public InternalErrorException() : base(ImagingError.InternalError)
        {
        }

        public InternalErrorException(Exception innerException) : base(ImagingError.InternalError, innerException)
        {
        }

        public InternalErrorException(string message) : base(ImagingError.InternalError, message)
        {
        }

        protected InternalErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InternalErrorException(string message, Exception innerException) : base(ImagingError.InternalError, message, innerException)
        {
        }
    }
}

