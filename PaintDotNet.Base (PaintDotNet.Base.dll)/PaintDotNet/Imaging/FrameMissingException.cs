namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class FrameMissingException : ImagingException
    {
        public FrameMissingException() : base(ImagingError.FrameMissing)
        {
        }

        public FrameMissingException(Exception innerException) : base(ImagingError.FrameMissing, innerException)
        {
        }

        public FrameMissingException(string message) : base(ImagingError.FrameMissing, message)
        {
        }

        protected FrameMissingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public FrameMissingException(string message, Exception innerException) : base(ImagingError.FrameMissing, message, innerException)
        {
        }
    }
}

