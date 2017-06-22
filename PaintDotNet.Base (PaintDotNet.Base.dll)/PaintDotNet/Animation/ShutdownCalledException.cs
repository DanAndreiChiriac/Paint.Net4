namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ShutdownCalledException : AnimationException
    {
        public ShutdownCalledException() : base(AnimationError.ShutdownCalled)
        {
        }

        public ShutdownCalledException(Exception innerException) : base(AnimationError.ShutdownCalled, innerException)
        {
        }

        public ShutdownCalledException(string message) : base(AnimationError.ShutdownCalled, message)
        {
        }

        protected ShutdownCalledException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ShutdownCalledException(string message, Exception innerException) : base(AnimationError.ShutdownCalled, message, innerException)
        {
        }
    }
}

