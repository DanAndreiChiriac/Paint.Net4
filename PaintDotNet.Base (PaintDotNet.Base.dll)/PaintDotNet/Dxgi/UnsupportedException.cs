namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class UnsupportedException : DxgiException
    {
        public UnsupportedException() : base(DxgiError.Unsupported)
        {
        }

        public UnsupportedException(Exception innerException) : base(DxgiError.Unsupported, innerException)
        {
        }

        public UnsupportedException(string message) : base(DxgiError.Unsupported, message)
        {
        }

        protected UnsupportedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnsupportedException(string message, Exception innerException) : base(DxgiError.Unsupported, message, innerException)
        {
        }
    }
}

