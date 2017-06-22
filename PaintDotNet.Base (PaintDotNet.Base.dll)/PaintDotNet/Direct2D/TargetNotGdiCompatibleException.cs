namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TargetNotGdiCompatibleException : Direct2DException
    {
        public TargetNotGdiCompatibleException() : base(Direct2DError.TargetNotGdiCompatible)
        {
        }

        public TargetNotGdiCompatibleException(Exception innerException) : base(Direct2DError.TargetNotGdiCompatible, innerException)
        {
        }

        public TargetNotGdiCompatibleException(string message) : base(Direct2DError.TargetNotGdiCompatible, message)
        {
        }

        protected TargetNotGdiCompatibleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TargetNotGdiCompatibleException(string message, Exception innerException) : base(Direct2DError.TargetNotGdiCompatible, message, innerException)
        {
        }
    }
}

