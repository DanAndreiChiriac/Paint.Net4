namespace PaintDotNet.Animation
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public abstract class AnimationException : InteropException
    {
        internal AnimationException(PaintDotNet.Animation.AnimationError error) : this(error, null, null)
        {
        }

        internal AnimationException(PaintDotNet.Animation.AnimationError error, Exception innerException) : this(error, null, innerException)
        {
        }

        internal AnimationException(PaintDotNet.Animation.AnimationError error, string message) : this(error, message, null)
        {
        }

        protected AnimationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        internal AnimationException(PaintDotNet.Animation.AnimationError error, string message, Exception innerException) : base(message, innerException, (int) error)
        {
        }

        public PaintDotNet.Animation.AnimationError AnimationError =>
            ((PaintDotNet.Animation.AnimationError) base.HResult);
    }
}

