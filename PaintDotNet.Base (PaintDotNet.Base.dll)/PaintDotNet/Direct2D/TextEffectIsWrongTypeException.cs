namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TextEffectIsWrongTypeException : Direct2DException
    {
        public TextEffectIsWrongTypeException() : base(Direct2DError.TextEffectIsWrongType)
        {
        }

        public TextEffectIsWrongTypeException(Exception innerException) : base(Direct2DError.TextEffectIsWrongType, innerException)
        {
        }

        public TextEffectIsWrongTypeException(string message) : base(Direct2DError.TextEffectIsWrongType, message)
        {
        }

        protected TextEffectIsWrongTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TextEffectIsWrongTypeException(string message, Exception innerException) : base(Direct2DError.TextEffectIsWrongType, message, innerException)
        {
        }
    }
}

