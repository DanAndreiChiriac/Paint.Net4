namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class LoopsOverlapException : AnimationException
    {
        public LoopsOverlapException() : base(AnimationError.LoopsOverlap)
        {
        }

        public LoopsOverlapException(Exception innerException) : base(AnimationError.LoopsOverlap, innerException)
        {
        }

        public LoopsOverlapException(string message) : base(AnimationError.LoopsOverlap, message)
        {
        }

        protected LoopsOverlapException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public LoopsOverlapException(string message, Exception innerException) : base(AnimationError.LoopsOverlap, message, innerException)
        {
        }
    }
}

