namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TextRendererNotReleasedException : Direct2DException
    {
        public TextRendererNotReleasedException() : base(Direct2DError.TextRendererNotReleased)
        {
        }

        public TextRendererNotReleasedException(Exception innerException) : base(Direct2DError.TextRendererNotReleased, innerException)
        {
        }

        public TextRendererNotReleasedException(string message) : base(Direct2DError.TextRendererNotReleased, message)
        {
        }

        protected TextRendererNotReleasedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TextRendererNotReleasedException(string message, Exception innerException) : base(Direct2DError.TextRendererNotReleased, message, innerException)
        {
        }
    }
}

