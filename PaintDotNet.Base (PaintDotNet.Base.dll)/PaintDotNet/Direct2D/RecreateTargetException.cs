namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class RecreateTargetException : Direct2DException
    {
        public RecreateTargetException() : base(Direct2DError.RecreateTarget)
        {
        }

        public RecreateTargetException(Exception innerException) : base(Direct2DError.RecreateTarget, innerException)
        {
        }

        public RecreateTargetException(string message) : base(Direct2DError.RecreateTarget, message)
        {
        }

        protected RecreateTargetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public RecreateTargetException(string message, Exception innerException) : base(Direct2DError.RecreateTarget, message, innerException)
        {
        }
    }
}

