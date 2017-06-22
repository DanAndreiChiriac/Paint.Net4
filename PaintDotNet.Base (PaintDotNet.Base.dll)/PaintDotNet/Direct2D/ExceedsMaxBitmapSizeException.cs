namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ExceedsMaxBitmapSizeException : Direct2DException
    {
        public ExceedsMaxBitmapSizeException() : base(Direct2DError.ExceedsMaxBitmapSize)
        {
        }

        public ExceedsMaxBitmapSizeException(Exception innerException) : base(Direct2DError.ExceedsMaxBitmapSize, innerException)
        {
        }

        public ExceedsMaxBitmapSizeException(string message) : base(Direct2DError.ExceedsMaxBitmapSize, message)
        {
        }

        protected ExceedsMaxBitmapSizeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ExceedsMaxBitmapSizeException(string message, Exception innerException) : base(Direct2DError.ExceedsMaxBitmapSize, message, innerException)
        {
        }
    }
}

