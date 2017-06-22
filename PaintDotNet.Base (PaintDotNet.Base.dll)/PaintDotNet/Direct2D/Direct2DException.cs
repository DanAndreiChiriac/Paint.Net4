namespace PaintDotNet.Direct2D
{
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public abstract class Direct2DException : RenderingException
    {
        internal Direct2DException(PaintDotNet.Direct2D.Direct2DError error) : this(error, null, null)
        {
        }

        internal Direct2DException(PaintDotNet.Direct2D.Direct2DError error, Exception innerException) : this(error, null, innerException)
        {
        }

        internal Direct2DException(PaintDotNet.Direct2D.Direct2DError error, string message) : this(error, message, null)
        {
        }

        protected Direct2DException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        internal Direct2DException(PaintDotNet.Direct2D.Direct2DError error, string message, Exception innerException) : base(message, innerException, (int) error)
        {
        }

        public PaintDotNet.Direct2D.Direct2DError Direct2DError =>
            ((PaintDotNet.Direct2D.Direct2DError) base.HResult);
    }
}

