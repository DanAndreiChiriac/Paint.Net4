namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class DeviceResetException : DxgiException
    {
        public DeviceResetException() : base(DxgiError.DeviceReset)
        {
        }

        public DeviceResetException(Exception innerException) : base(DxgiError.DeviceReset, innerException)
        {
        }

        public DeviceResetException(string message) : base(DxgiError.DeviceReset, message)
        {
        }

        protected DeviceResetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public DeviceResetException(string message, Exception innerException) : base(DxgiError.DeviceReset, message, innerException)
        {
        }
    }
}

