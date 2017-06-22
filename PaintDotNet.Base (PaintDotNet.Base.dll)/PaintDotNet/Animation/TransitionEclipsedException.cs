namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TransitionEclipsedException : AnimationException
    {
        public TransitionEclipsedException() : base(AnimationError.TransitionEclipsed)
        {
        }

        public TransitionEclipsedException(Exception innerException) : base(AnimationError.TransitionEclipsed, innerException)
        {
        }

        public TransitionEclipsedException(string message) : base(AnimationError.TransitionEclipsed, message)
        {
        }

        protected TransitionEclipsedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TransitionEclipsedException(string message, Exception innerException) : base(AnimationError.TransitionEclipsed, message, innerException)
        {
        }
    }
}

