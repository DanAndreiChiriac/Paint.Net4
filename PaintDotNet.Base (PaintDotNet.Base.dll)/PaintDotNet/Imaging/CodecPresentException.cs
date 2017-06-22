namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class CodecPresentException : ImagingException
    {
        public CodecPresentException() : base(ImagingError.CodecPresent)
        {
        }

        public CodecPresentException(Exception innerException) : base(ImagingError.CodecPresent, innerException)
        {
        }

        public CodecPresentException(string message) : base(ImagingError.CodecPresent, message)
        {
        }

        protected CodecPresentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public CodecPresentException(string message, Exception innerException) : base(ImagingError.CodecPresent, message, innerException)
        {
        }
    }
}

