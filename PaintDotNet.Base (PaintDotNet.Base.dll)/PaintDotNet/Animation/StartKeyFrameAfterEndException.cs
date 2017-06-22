namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class StartKeyFrameAfterEndException : AnimationException
    {
        public StartKeyFrameAfterEndException() : base(AnimationError.StartKeyFrameAfterEnd)
        {
        }

        public StartKeyFrameAfterEndException(Exception innerException) : base(AnimationError.StartKeyFrameAfterEnd, innerException)
        {
        }

        public StartKeyFrameAfterEndException(string message) : base(AnimationError.StartKeyFrameAfterEnd, message)
        {
        }

        protected StartKeyFrameAfterEndException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public StartKeyFrameAfterEndException(string message, Exception innerException) : base(AnimationError.StartKeyFrameAfterEnd, message, innerException)
        {
        }
    }
}

