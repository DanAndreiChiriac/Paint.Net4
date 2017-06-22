namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class DifferentOwnerException : AnimationException
    {
        public DifferentOwnerException() : base(AnimationError.DifferentOwner)
        {
        }

        public DifferentOwnerException(Exception innerException) : base(AnimationError.DifferentOwner, innerException)
        {
        }

        public DifferentOwnerException(string message) : base(AnimationError.DifferentOwner, message)
        {
        }

        protected DifferentOwnerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public DifferentOwnerException(string message, Exception innerException) : base(AnimationError.DifferentOwner, message, innerException)
        {
        }
    }
}

