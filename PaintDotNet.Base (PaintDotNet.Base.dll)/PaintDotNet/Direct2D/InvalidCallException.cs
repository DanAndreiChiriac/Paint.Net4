namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidCallException : Direct2DException
    {
        public InvalidCallException() : base(Direct2DError.InvalidCall)
        {
        }

        public InvalidCallException(Exception innerException) : base(Direct2DError.InvalidCall, innerException)
        {
        }

        public InvalidCallException(string message) : base(Direct2DError.InvalidCall, message)
        {
        }

        protected InvalidCallException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidCallException(string message, Exception innerException) : base(Direct2DError.InvalidCall, message, innerException)
        {
        }
    }
}

