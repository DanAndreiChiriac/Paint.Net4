namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NotCurrentlyAvailableException : DxgiException
    {
        public NotCurrentlyAvailableException() : base(DxgiError.NotCurrentlyAvailable)
        {
        }

        public NotCurrentlyAvailableException(Exception innerException) : base(DxgiError.NotCurrentlyAvailable, innerException)
        {
        }

        public NotCurrentlyAvailableException(string message) : base(DxgiError.NotCurrentlyAvailable, message)
        {
        }

        protected NotCurrentlyAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NotCurrentlyAvailableException(string message, Exception innerException) : base(DxgiError.NotCurrentlyAvailable, message, innerException)
        {
        }
    }
}

