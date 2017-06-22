namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ObjectSealedException : AnimationException
    {
        public ObjectSealedException() : base(AnimationError.ObjectSealed)
        {
        }

        public ObjectSealedException(Exception innerException) : base(AnimationError.ObjectSealed, innerException)
        {
        }

        public ObjectSealedException(string message) : base(AnimationError.ObjectSealed, message)
        {
        }

        protected ObjectSealedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ObjectSealedException(string message, Exception innerException) : base(AnimationError.ObjectSealed, message, innerException)
        {
        }
    }
}

