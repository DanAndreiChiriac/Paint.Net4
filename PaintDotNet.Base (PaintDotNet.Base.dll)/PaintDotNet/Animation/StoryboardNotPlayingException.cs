namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class StoryboardNotPlayingException : AnimationException
    {
        public StoryboardNotPlayingException() : base(AnimationError.StoryboardNotPlaying)
        {
        }

        public StoryboardNotPlayingException(Exception innerException) : base(AnimationError.StoryboardNotPlaying, innerException)
        {
        }

        public StoryboardNotPlayingException(string message) : base(AnimationError.StoryboardNotPlaying, message)
        {
        }

        protected StoryboardNotPlayingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public StoryboardNotPlayingException(string message, Exception innerException) : base(AnimationError.StoryboardNotPlaying, message, innerException)
        {
        }
    }
}

