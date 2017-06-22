namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidOutputException : AnimationException
    {
        public InvalidOutputException() : base(AnimationError.InvalidOutput)
        {
        }

        public InvalidOutputException(Exception innerException) : base(AnimationError.InvalidOutput, innerException)
        {
        }

        public InvalidOutputException(string message) : base(AnimationError.InvalidOutput, message)
        {
        }

        protected InvalidOutputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidOutputException(string message, Exception innerException) : base(AnimationError.InvalidOutput, message, innerException)
        {
        }
    }
}

