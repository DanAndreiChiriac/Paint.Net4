namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class IllegalReentrancyException : AnimationException
    {
        public IllegalReentrancyException() : base(AnimationError.IllegalReentrancy)
        {
        }

        public IllegalReentrancyException(Exception innerException) : base(AnimationError.IllegalReentrancy, innerException)
        {
        }

        public IllegalReentrancyException(string message) : base(AnimationError.IllegalReentrancy, message)
        {
        }

        protected IllegalReentrancyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public IllegalReentrancyException(string message, Exception innerException) : base(AnimationError.IllegalReentrancy, message, innerException)
        {
        }
    }
}

