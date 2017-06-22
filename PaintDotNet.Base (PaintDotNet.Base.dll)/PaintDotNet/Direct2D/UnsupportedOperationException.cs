namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class UnsupportedOperationException : Direct2DException
    {
        public UnsupportedOperationException() : base(Direct2DError.UnsupportedOperation)
        {
        }

        public UnsupportedOperationException(Exception innerException) : base(Direct2DError.UnsupportedOperation, innerException)
        {
        }

        public UnsupportedOperationException(string message) : base(Direct2DError.UnsupportedOperation, message)
        {
        }

        protected UnsupportedOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnsupportedOperationException(string message, Exception innerException) : base(Direct2DError.UnsupportedOperation, message, innerException)
        {
        }
    }
}

