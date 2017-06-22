namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class PushPopUnbalancedException : Direct2DException
    {
        public PushPopUnbalancedException() : base(Direct2DError.PushPopUnbalanced)
        {
        }

        public PushPopUnbalancedException(Exception innerException) : base(Direct2DError.PushPopUnbalanced, innerException)
        {
        }

        public PushPopUnbalancedException(string message) : base(Direct2DError.PushPopUnbalanced, message)
        {
        }

        protected PushPopUnbalancedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PushPopUnbalancedException(string message, Exception innerException) : base(Direct2DError.PushPopUnbalanced, message, innerException)
        {
        }
    }
}

