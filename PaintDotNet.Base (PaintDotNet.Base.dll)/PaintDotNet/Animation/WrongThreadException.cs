namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class WrongThreadException : AnimationException
    {
        public WrongThreadException() : base(AnimationError.WrongThread)
        {
        }

        public WrongThreadException(Exception innerException) : base(AnimationError.WrongThread, innerException)
        {
        }

        public WrongThreadException(string message) : base(AnimationError.WrongThread, message)
        {
        }

        protected WrongThreadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public WrongThreadException(string message, Exception innerException) : base(AnimationError.WrongThread, message, innerException)
        {
        }
    }
}

