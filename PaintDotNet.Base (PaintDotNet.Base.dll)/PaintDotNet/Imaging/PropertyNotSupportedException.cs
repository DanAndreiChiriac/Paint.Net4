namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class PropertyNotSupportedException : ImagingException
    {
        public PropertyNotSupportedException() : base(ImagingError.PropertyNotSupported)
        {
        }

        public PropertyNotSupportedException(Exception innerException) : base(ImagingError.PropertyNotSupported, innerException)
        {
        }

        public PropertyNotSupportedException(string message) : base(ImagingError.PropertyNotSupported, message)
        {
        }

        protected PropertyNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PropertyNotSupportedException(string message, Exception innerException) : base(ImagingError.PropertyNotSupported, message, innerException)
        {
        }
    }
}

