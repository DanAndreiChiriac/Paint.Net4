namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class EndKeyFrameNotDeterminedException : AnimationException
    {
        public EndKeyFrameNotDeterminedException() : base(AnimationError.EndKeyFrameNotDetermined)
        {
        }

        public EndKeyFrameNotDeterminedException(Exception innerException) : base(AnimationError.EndKeyFrameNotDetermined, innerException)
        {
        }

        public EndKeyFrameNotDeterminedException(string message) : base(AnimationError.EndKeyFrameNotDetermined, message)
        {
        }

        protected EndKeyFrameNotDeterminedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public EndKeyFrameNotDeterminedException(string message, Exception innerException) : base(AnimationError.EndKeyFrameNotDetermined, message, innerException)
        {
        }
    }
}

