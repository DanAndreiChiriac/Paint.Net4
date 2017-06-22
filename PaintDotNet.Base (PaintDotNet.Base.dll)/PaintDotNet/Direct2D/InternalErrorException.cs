namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InternalErrorException : Direct2DException
    {
        public InternalErrorException() : base(Direct2DError.InternalError)
        {
        }

        public InternalErrorException(Exception innerException) : base(Direct2DError.InternalError, innerException)
        {
        }

        public InternalErrorException(string message) : base(Direct2DError.InternalError, message)
        {
        }

        protected InternalErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InternalErrorException(string message, Exception innerException) : base(Direct2DError.InternalError, message, innerException)
        {
        }
    }
}

