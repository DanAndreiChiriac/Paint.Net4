namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class StoryboardActiveException : AnimationException
    {
        public StoryboardActiveException() : base(AnimationError.StoryboardActive)
        {
        }

        public StoryboardActiveException(Exception innerException) : base(AnimationError.StoryboardActive, innerException)
        {
        }

        public StoryboardActiveException(string message) : base(AnimationError.StoryboardActive, message)
        {
        }

        protected StoryboardActiveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public StoryboardActiveException(string message, Exception innerException) : base(AnimationError.StoryboardActive, message, innerException)
        {
        }
    }
}

