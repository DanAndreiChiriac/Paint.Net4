namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class GraphicsVidpnSourceInUseException : DxgiException
    {
        public GraphicsVidpnSourceInUseException() : base(DxgiError.GraphicsVidpnSourceInUse)
        {
        }

        public GraphicsVidpnSourceInUseException(Exception innerException) : base(DxgiError.GraphicsVidpnSourceInUse, innerException)
        {
        }

        public GraphicsVidpnSourceInUseException(string message) : base(DxgiError.GraphicsVidpnSourceInUse, message)
        {
        }

        protected GraphicsVidpnSourceInUseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public GraphicsVidpnSourceInUseException(string message, Exception innerException) : base(DxgiError.GraphicsVidpnSourceInUse, message, innerException)
        {
        }
    }
}

