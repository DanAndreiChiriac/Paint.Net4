namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class MaxTextureSizeExceededException : Direct2DException
    {
        public MaxTextureSizeExceededException() : base(Direct2DError.MaxTextureSizeExceeded)
        {
        }

        public MaxTextureSizeExceededException(Exception innerException) : base(Direct2DError.MaxTextureSizeExceeded, innerException)
        {
        }

        public MaxTextureSizeExceededException(string message) : base(Direct2DError.MaxTextureSizeExceeded, message)
        {
        }

        protected MaxTextureSizeExceededException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public MaxTextureSizeExceededException(string message, Exception innerException) : base(Direct2DError.MaxTextureSizeExceeded, message, innerException)
        {
        }
    }
}

