namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TooManyShaderElementsException : Direct2DException
    {
        public TooManyShaderElementsException() : base(Direct2DError.TooManyShaderElements)
        {
        }

        public TooManyShaderElementsException(Exception innerException) : base(Direct2DError.TooManyShaderElements, innerException)
        {
        }

        public TooManyShaderElementsException(string message) : base(Direct2DError.TooManyShaderElements, message)
        {
        }

        protected TooManyShaderElementsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TooManyShaderElementsException(string message, Exception innerException) : base(Direct2DError.TooManyShaderElements, message, innerException)
        {
        }
    }
}

