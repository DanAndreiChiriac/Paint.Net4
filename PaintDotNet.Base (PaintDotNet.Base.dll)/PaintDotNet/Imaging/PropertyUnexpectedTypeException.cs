namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class PropertyUnexpectedTypeException : ImagingException
    {
        public PropertyUnexpectedTypeException() : base(ImagingError.PropertyUnexpectedType)
        {
        }

        public PropertyUnexpectedTypeException(Exception innerException) : base(ImagingError.PropertyUnexpectedType, innerException)
        {
        }

        public PropertyUnexpectedTypeException(string message) : base(ImagingError.PropertyUnexpectedType, message)
        {
        }

        protected PropertyUnexpectedTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PropertyUnexpectedTypeException(string message, Exception innerException) : base(ImagingError.PropertyUnexpectedType, message, innerException)
        {
        }
    }
}

