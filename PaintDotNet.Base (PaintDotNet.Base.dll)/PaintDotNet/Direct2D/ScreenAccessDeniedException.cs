namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ScreenAccessDeniedException : Direct2DException
    {
        public ScreenAccessDeniedException() : base(Direct2DError.ScreenAccessDenied)
        {
        }

        public ScreenAccessDeniedException(Exception innerException) : base(Direct2DError.ScreenAccessDenied, innerException)
        {
        }

        public ScreenAccessDeniedException(string message) : base(Direct2DError.ScreenAccessDenied, message)
        {
        }

        protected ScreenAccessDeniedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ScreenAccessDeniedException(string message, Exception innerException) : base(Direct2DError.ScreenAccessDenied, message, innerException)
        {
        }
    }
}

