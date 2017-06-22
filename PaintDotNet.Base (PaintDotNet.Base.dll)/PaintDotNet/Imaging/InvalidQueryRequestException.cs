namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidQueryRequestException : ImagingException
    {
        public InvalidQueryRequestException() : base(ImagingError.InvalidQueryRequest)
        {
        }

        public InvalidQueryRequestException(Exception innerException) : base(ImagingError.InvalidQueryRequest, innerException)
        {
        }

        public InvalidQueryRequestException(string message) : base(ImagingError.InvalidQueryRequest, message)
        {
        }

        protected InvalidQueryRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidQueryRequestException(string message, Exception innerException) : base(ImagingError.InvalidQueryRequest, message, innerException)
        {
        }
    }
}

