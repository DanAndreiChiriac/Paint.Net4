namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ValueOutOfRangeException : ImagingException
    {
        public ValueOutOfRangeException() : base(ImagingError.ValueOutOfRange)
        {
        }

        public ValueOutOfRangeException(Exception innerException) : base(ImagingError.ValueOutOfRange, innerException)
        {
        }

        public ValueOutOfRangeException(string message) : base(ImagingError.ValueOutOfRange, message)
        {
        }

        protected ValueOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ValueOutOfRangeException(string message, Exception innerException) : base(ImagingError.ValueOutOfRange, message, innerException)
        {
        }
    }
}

