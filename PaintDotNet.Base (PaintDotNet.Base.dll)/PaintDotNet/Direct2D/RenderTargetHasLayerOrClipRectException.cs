namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class RenderTargetHasLayerOrClipRectException : Direct2DException
    {
        public RenderTargetHasLayerOrClipRectException() : base(Direct2DError.RenderTargetHasLayerOrClipRect)
        {
        }

        public RenderTargetHasLayerOrClipRectException(Exception innerException) : base(Direct2DError.RenderTargetHasLayerOrClipRect, innerException)
        {
        }

        public RenderTargetHasLayerOrClipRectException(string message) : base(Direct2DError.RenderTargetHasLayerOrClipRect, message)
        {
        }

        protected RenderTargetHasLayerOrClipRectException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public RenderTargetHasLayerOrClipRectException(string message, Exception innerException) : base(Direct2DError.RenderTargetHasLayerOrClipRect, message, innerException)
        {
        }
    }
}

