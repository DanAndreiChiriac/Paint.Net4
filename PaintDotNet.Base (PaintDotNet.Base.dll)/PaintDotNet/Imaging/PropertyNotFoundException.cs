namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class PropertyNotFoundException : ImagingException
    {
        public PropertyNotFoundException() : base(ImagingError.PropertyNotFound)
        {
        }

        public PropertyNotFoundException(Exception innerException) : base(ImagingError.PropertyNotFound, innerException)
        {
        }

        public PropertyNotFoundException(string message) : base(ImagingError.PropertyNotFound, message)
        {
        }

        protected PropertyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PropertyNotFoundException(string message, Exception innerException) : base(ImagingError.PropertyNotFound, message, innerException)
        {
        }
    }
}

