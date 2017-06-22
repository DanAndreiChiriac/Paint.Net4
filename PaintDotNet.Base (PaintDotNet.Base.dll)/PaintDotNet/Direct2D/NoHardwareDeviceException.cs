namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NoHardwareDeviceException : Direct2DException
    {
        public NoHardwareDeviceException() : base(Direct2DError.NoHardwareDevice)
        {
        }

        public NoHardwareDeviceException(Exception innerException) : base(Direct2DError.NoHardwareDevice, innerException)
        {
        }

        public NoHardwareDeviceException(string message) : base(Direct2DError.NoHardwareDevice, message)
        {
        }

        protected NoHardwareDeviceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NoHardwareDeviceException(string message, Exception innerException) : base(Direct2DError.NoHardwareDevice, message, innerException)
        {
        }
    }
}

