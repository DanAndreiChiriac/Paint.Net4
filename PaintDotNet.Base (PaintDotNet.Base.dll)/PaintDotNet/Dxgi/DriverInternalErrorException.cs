namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class DriverInternalErrorException : DxgiException
    {
        public DriverInternalErrorException() : base(DxgiError.DriverInternalError)
        {
        }

        public DriverInternalErrorException(Exception innerException) : base(DxgiError.DriverInternalError, innerException)
        {
        }

        public DriverInternalErrorException(string message) : base(DxgiError.DriverInternalError, message)
        {
        }

        protected DriverInternalErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public DriverInternalErrorException(string message, Exception innerException) : base(DxgiError.DriverInternalError, message, innerException)
        {
        }
    }
}

