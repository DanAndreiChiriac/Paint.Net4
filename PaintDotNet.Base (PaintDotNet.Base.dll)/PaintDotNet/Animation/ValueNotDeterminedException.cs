namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ValueNotDeterminedException : AnimationException
    {
        public ValueNotDeterminedException() : base(AnimationError.ValueNotDetermined)
        {
        }

        public ValueNotDeterminedException(Exception innerException) : base(AnimationError.ValueNotDetermined, innerException)
        {
        }

        public ValueNotDeterminedException(string message) : base(AnimationError.ValueNotDetermined, message)
        {
        }

        protected ValueNotDeterminedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ValueNotDeterminedException(string message, Exception innerException) : base(AnimationError.ValueNotDetermined, message, innerException)
        {
        }
    }
}

