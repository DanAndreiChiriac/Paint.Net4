namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TransitionAlreadyUsedException : AnimationException
    {
        public TransitionAlreadyUsedException() : base(AnimationError.TransitionAlreadyUsed)
        {
        }

        public TransitionAlreadyUsedException(Exception innerException) : base(AnimationError.TransitionAlreadyUsed, innerException)
        {
        }

        public TransitionAlreadyUsedException(string message) : base(AnimationError.TransitionAlreadyUsed, message)
        {
        }

        protected TransitionAlreadyUsedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TransitionAlreadyUsedException(string message, Exception innerException) : base(AnimationError.TransitionAlreadyUsed, message, innerException)
        {
        }
    }
}

