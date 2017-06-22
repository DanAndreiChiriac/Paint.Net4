namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ComponentNotFoundException : ImagingException
    {
        public ComponentNotFoundException() : base(ImagingError.ComponentNotFound)
        {
        }

        public ComponentNotFoundException(Exception innerException) : base(ImagingError.ComponentNotFound, innerException)
        {
        }

        public ComponentNotFoundException(string message) : base(ImagingError.ComponentNotFound, message)
        {
        }

        protected ComponentNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ComponentNotFoundException(string message, Exception innerException) : base(ImagingError.ComponentNotFound, message, innerException)
        {
        }
    }
}

