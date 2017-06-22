namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class WrongStateException : Direct2DException
    {
        public WrongStateException() : base(Direct2DError.WrongState)
        {
        }

        public WrongStateException(Exception innerException) : base(Direct2DError.WrongState, innerException)
        {
        }

        public WrongStateException(string message) : base(Direct2DError.WrongState, message)
        {
        }

        protected WrongStateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public WrongStateException(string message, Exception innerException) : base(Direct2DError.WrongState, message, innerException)
        {
        }
    }
}

