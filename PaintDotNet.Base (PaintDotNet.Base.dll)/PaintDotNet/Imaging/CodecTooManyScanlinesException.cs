namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class CodecTooManyScanlinesException : ImagingException
    {
        public CodecTooManyScanlinesException() : base(ImagingError.CodecTooManyScanlines)
        {
        }

        public CodecTooManyScanlinesException(Exception innerException) : base(ImagingError.CodecTooManyScanlines, innerException)
        {
        }

        public CodecTooManyScanlinesException(string message) : base(ImagingError.CodecTooManyScanlines, message)
        {
        }

        protected CodecTooManyScanlinesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public CodecTooManyScanlinesException(string message, Exception innerException) : base(ImagingError.CodecTooManyScanlines, message, innerException)
        {
        }
    }
}

