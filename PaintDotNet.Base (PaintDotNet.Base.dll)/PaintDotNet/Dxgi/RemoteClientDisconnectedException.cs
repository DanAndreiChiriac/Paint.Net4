namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class RemoteClientDisconnectedException : DxgiException
    {
        public RemoteClientDisconnectedException() : base(DxgiError.RemoteClientDisconnected)
        {
        }

        public RemoteClientDisconnectedException(Exception innerException) : base(DxgiError.RemoteClientDisconnected, innerException)
        {
        }

        public RemoteClientDisconnectedException(string message) : base(DxgiError.RemoteClientDisconnected, message)
        {
        }

        protected RemoteClientDisconnectedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public RemoteClientDisconnectedException(string message, Exception innerException) : base(DxgiError.RemoteClientDisconnected, message, innerException)
        {
        }
    }
}

