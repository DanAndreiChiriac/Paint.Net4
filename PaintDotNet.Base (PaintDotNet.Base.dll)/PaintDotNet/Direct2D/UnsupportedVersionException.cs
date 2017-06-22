namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class UnsupportedVersionException : Direct2DException
    {
        public UnsupportedVersionException() : base(Direct2DError.UnsupportedVersion)
        {
        }

        public UnsupportedVersionException(Exception innerException) : base(Direct2DError.UnsupportedVersion, innerException)
        {
        }

        public UnsupportedVersionException(string message) : base(Direct2DError.UnsupportedVersion, message)
        {
        }

        protected UnsupportedVersionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnsupportedVersionException(string message, Exception innerException) : base(Direct2DError.UnsupportedVersion, message, innerException)
        {
        }
    }
}

