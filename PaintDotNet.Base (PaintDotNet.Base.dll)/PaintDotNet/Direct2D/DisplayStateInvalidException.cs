namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class DisplayStateInvalidException : Direct2DException
    {
        public DisplayStateInvalidException() : base(Direct2DError.DisplayStateInvalid)
        {
        }

        public DisplayStateInvalidException(Exception innerException) : base(Direct2DError.DisplayStateInvalid, innerException)
        {
        }

        public DisplayStateInvalidException(string message) : base(Direct2DError.DisplayStateInvalid, message)
        {
        }

        protected DisplayStateInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public DisplayStateInvalidException(string message, Exception innerException) : base(Direct2DError.DisplayStateInvalid, message, innerException)
        {
        }
    }
}

