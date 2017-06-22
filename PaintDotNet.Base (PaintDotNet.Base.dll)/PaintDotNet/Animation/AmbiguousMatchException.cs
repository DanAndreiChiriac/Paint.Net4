namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class AmbiguousMatchException : AnimationException
    {
        public AmbiguousMatchException() : base(AnimationError.AmbiguousMatch)
        {
        }

        public AmbiguousMatchException(Exception innerException) : base(AnimationError.AmbiguousMatch, innerException)
        {
        }

        public AmbiguousMatchException(string message) : base(AnimationError.AmbiguousMatch, message)
        {
        }

        protected AmbiguousMatchException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public AmbiguousMatchException(string message, Exception innerException) : base(AnimationError.AmbiguousMatch, message, innerException)
        {
        }
    }
}

