namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ValueNotSetException : AnimationException
    {
        public ValueNotSetException() : base(AnimationError.ValueNotSet)
        {
        }

        public ValueNotSetException(Exception innerException) : base(AnimationError.ValueNotSet, innerException)
        {
        }

        public ValueNotSetException(string message) : base(AnimationError.ValueNotSet, message)
        {
        }

        protected ValueNotSetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ValueNotSetException(string message, Exception innerException) : base(AnimationError.ValueNotSet, message, innerException)
        {
        }
    }
}

