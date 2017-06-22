namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class BadStreamDataException : ImagingException
    {
        public BadStreamDataException() : base(ImagingError.BadStreamData)
        {
        }

        public BadStreamDataException(Exception innerException) : base(ImagingError.BadStreamData, innerException)
        {
        }

        public BadStreamDataException(string message) : base(ImagingError.BadStreamData, message)
        {
        }

        protected BadStreamDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public BadStreamDataException(string message, Exception innerException) : base(ImagingError.BadStreamData, message, innerException)
        {
        }
    }
}

