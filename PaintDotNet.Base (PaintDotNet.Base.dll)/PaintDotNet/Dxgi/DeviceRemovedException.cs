namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class DeviceRemovedException : DxgiException
    {
        public DeviceRemovedException() : base(DxgiError.DeviceRemoved)
        {
        }

        public DeviceRemovedException(Exception innerException) : base(DxgiError.DeviceRemoved, innerException)
        {
        }

        public DeviceRemovedException(string message) : base(DxgiError.DeviceRemoved, message)
        {
        }

        protected DeviceRemovedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public DeviceRemovedException(string message, Exception innerException) : base(DxgiError.DeviceRemoved, message, innerException)
        {
        }
    }
}

