namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class FloatingPointOverflowException : AnimationException
    {
        public FloatingPointOverflowException() : base(AnimationError.FloatingPointOverflow)
        {
        }

        public FloatingPointOverflowException(Exception innerException) : base(AnimationError.FloatingPointOverflow, innerException)
        {
        }

        public FloatingPointOverflowException(string message) : base(AnimationError.FloatingPointOverflow, message)
        {
        }

        protected FloatingPointOverflowException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public FloatingPointOverflowException(string message, Exception innerException) : base(AnimationError.FloatingPointOverflow, message, innerException)
        {
        }
    }
}

