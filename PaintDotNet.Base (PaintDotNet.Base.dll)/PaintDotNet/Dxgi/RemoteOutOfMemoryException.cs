namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class RemoteOutOfMemoryException : DxgiException
    {
        public RemoteOutOfMemoryException() : base(DxgiError.RemoteOutOfMemory)
        {
        }

        public RemoteOutOfMemoryException(Exception innerException) : base(DxgiError.RemoteOutOfMemory, innerException)
        {
        }

        public RemoteOutOfMemoryException(string message) : base(DxgiError.RemoteOutOfMemory, message)
        {
        }

        protected RemoteOutOfMemoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public RemoteOutOfMemoryException(string message, Exception innerException) : base(DxgiError.RemoteOutOfMemory, message, innerException)
        {
        }
    }
}

