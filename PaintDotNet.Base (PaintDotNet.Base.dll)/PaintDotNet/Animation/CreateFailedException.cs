namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class CreateFailedException : AnimationException
    {
        public CreateFailedException() : base(AnimationError.CreateFailed)
        {
        }

        public CreateFailedException(Exception innerException) : base(AnimationError.CreateFailed, innerException)
        {
        }

        public CreateFailedException(string message) : base(AnimationError.CreateFailed, message)
        {
        }

        protected CreateFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public CreateFailedException(string message, Exception innerException) : base(AnimationError.CreateFailed, message, innerException)
        {
        }
    }
}

