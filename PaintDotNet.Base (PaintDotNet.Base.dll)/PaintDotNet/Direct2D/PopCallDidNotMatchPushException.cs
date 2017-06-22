namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class PopCallDidNotMatchPushException : Direct2DException
    {
        public PopCallDidNotMatchPushException() : base(Direct2DError.PopCallDidNotMatchPush)
        {
        }

        public PopCallDidNotMatchPushException(Exception innerException) : base(Direct2DError.PopCallDidNotMatchPush, innerException)
        {
        }

        public PopCallDidNotMatchPushException(string message) : base(Direct2DError.PopCallDidNotMatchPush, message)
        {
        }

        protected PopCallDidNotMatchPushException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PopCallDidNotMatchPushException(string message, Exception innerException) : base(Direct2DError.PopCallDidNotMatchPush, message, innerException)
        {
        }
    }
}

