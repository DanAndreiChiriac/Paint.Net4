namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class IncompatibleBrushTypesException : Direct2DException
    {
        public IncompatibleBrushTypesException() : base(Direct2DError.IncompatibleBrushTypes)
        {
        }

        public IncompatibleBrushTypesException(Exception innerException) : base(Direct2DError.IncompatibleBrushTypes, innerException)
        {
        }

        public IncompatibleBrushTypesException(string message) : base(Direct2DError.IncompatibleBrushTypes, message)
        {
        }

        protected IncompatibleBrushTypesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public IncompatibleBrushTypesException(string message, Exception innerException) : base(Direct2DError.IncompatibleBrushTypes, message, innerException)
        {
        }
    }
}

