namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class DeviceHungException : DxgiException
    {
        public DeviceHungException() : base(DxgiError.DeviceHung)
        {
        }

        public DeviceHungException(Exception innerException) : base(DxgiError.DeviceHung, innerException)
        {
        }

        public DeviceHungException(string message) : base(DxgiError.DeviceHung, message)
        {
        }

        protected DeviceHungException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public DeviceHungException(string message, Exception innerException) : base(DxgiError.DeviceHung, message, innerException)
        {
        }
    }
}

