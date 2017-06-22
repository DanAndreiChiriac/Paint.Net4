namespace PaintDotNet.Dxgi
{
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public abstract class DxgiException : RenderingException
    {
        internal DxgiException(PaintDotNet.Dxgi.DxgiError error) : this(error, null, null)
        {
        }

        internal DxgiException(PaintDotNet.Dxgi.DxgiError error, Exception innerException) : this(error, null, innerException)
        {
        }

        internal DxgiException(PaintDotNet.Dxgi.DxgiError error, string message) : this(error, message, null)
        {
        }

        protected DxgiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        internal DxgiException(PaintDotNet.Dxgi.DxgiError error, string message, Exception innerException) : base(message, innerException, (int) error)
        {
        }

        public PaintDotNet.Dxgi.DxgiError DxgiError =>
            ((PaintDotNet.Dxgi.DxgiError) base.HResult);
    }
}

