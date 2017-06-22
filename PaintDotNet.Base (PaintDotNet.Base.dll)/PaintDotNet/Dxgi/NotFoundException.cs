namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NotFoundException : DxgiException
    {
        public NotFoundException() : base(DxgiError.NotFound)
        {
        }

        public NotFoundException(Exception innerException) : base(DxgiError.NotFound, innerException)
        {
        }

        public NotFoundException(string message) : base(DxgiError.NotFound, message)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(DxgiError.NotFound, message, innerException)
        {
        }
    }
}

