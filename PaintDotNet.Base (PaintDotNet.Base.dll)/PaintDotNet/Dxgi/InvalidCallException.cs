namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidCallException : DxgiException
    {
        public InvalidCallException() : base(DxgiError.InvalidCall)
        {
        }

        public InvalidCallException(Exception innerException) : base(DxgiError.InvalidCall, innerException)
        {
        }

        public InvalidCallException(string message) : base(DxgiError.InvalidCall, message)
        {
        }

        protected InvalidCallException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidCallException(string message, Exception innerException) : base(DxgiError.InvalidCall, message, innerException)
        {
        }
    }
}

