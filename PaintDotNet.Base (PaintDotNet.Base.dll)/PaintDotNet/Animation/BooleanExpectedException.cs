namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class BooleanExpectedException : AnimationException
    {
        public BooleanExpectedException() : base(AnimationError.BooleanExpected)
        {
        }

        public BooleanExpectedException(Exception innerException) : base(AnimationError.BooleanExpected, innerException)
        {
        }

        public BooleanExpectedException(string message) : base(AnimationError.BooleanExpected, message)
        {
        }

        protected BooleanExpectedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public BooleanExpectedException(string message, Exception innerException) : base(AnimationError.BooleanExpected, message, innerException)
        {
        }
    }
}

