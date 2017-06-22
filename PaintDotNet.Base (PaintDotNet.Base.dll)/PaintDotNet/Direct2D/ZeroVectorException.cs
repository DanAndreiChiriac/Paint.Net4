namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ZeroVectorException : Direct2DException
    {
        public ZeroVectorException() : base(Direct2DError.ZeroVector)
        {
        }

        public ZeroVectorException(Exception innerException) : base(Direct2DError.ZeroVector, innerException)
        {
        }

        public ZeroVectorException(string message) : base(Direct2DError.ZeroVector, message)
        {
        }

        protected ZeroVectorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ZeroVectorException(string message, Exception innerException) : base(Direct2DError.ZeroVector, message, innerException)
        {
        }
    }
}

