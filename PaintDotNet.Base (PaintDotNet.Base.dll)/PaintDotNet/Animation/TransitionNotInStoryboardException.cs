namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TransitionNotInStoryboardException : AnimationException
    {
        public TransitionNotInStoryboardException() : base(AnimationError.TransitionNotInStoryboard)
        {
        }

        public TransitionNotInStoryboardException(Exception innerException) : base(AnimationError.TransitionNotInStoryboard, innerException)
        {
        }

        public TransitionNotInStoryboardException(string message) : base(AnimationError.TransitionNotInStoryboard, message)
        {
        }

        protected TransitionNotInStoryboardException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TransitionNotInStoryboardException(string message, Exception innerException) : base(AnimationError.TransitionNotInStoryboard, message, innerException)
        {
        }
    }
}

