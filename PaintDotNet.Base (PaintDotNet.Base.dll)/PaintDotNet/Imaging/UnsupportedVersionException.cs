namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class UnsupportedVersionException : ImagingException
    {
        public UnsupportedVersionException() : base(ImagingError.UnsupportedVersion)
        {
        }

        public UnsupportedVersionException(Exception innerException) : base(ImagingError.UnsupportedVersion, innerException)
        {
        }

        public UnsupportedVersionException(string message) : base(ImagingError.UnsupportedVersion, message)
        {
        }

        protected UnsupportedVersionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnsupportedVersionException(string message, Exception innerException) : base(ImagingError.UnsupportedVersion, message, innerException)
        {
        }
    }
}

