namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class PropertySizeException : ImagingException
    {
        public PropertySizeException() : base(ImagingError.PropertySize)
        {
        }

        public PropertySizeException(Exception innerException) : base(ImagingError.PropertySize, innerException)
        {
        }

        public PropertySizeException(string message) : base(ImagingError.PropertySize, message)
        {
        }

        protected PropertySizeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PropertySizeException(string message, Exception innerException) : base(ImagingError.PropertySize, message, innerException)
        {
        }
    }
}

