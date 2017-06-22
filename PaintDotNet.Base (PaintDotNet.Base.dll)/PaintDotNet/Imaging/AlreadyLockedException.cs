namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class AlreadyLockedException : ImagingException
    {
        public AlreadyLockedException() : base(ImagingError.AlreadyLocked)
        {
        }

        public AlreadyLockedException(Exception innerException) : base(ImagingError.AlreadyLocked, innerException)
        {
        }

        public AlreadyLockedException(string message) : base(ImagingError.AlreadyLocked, message)
        {
        }

        protected AlreadyLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public AlreadyLockedException(string message, Exception innerException) : base(ImagingError.AlreadyLocked, message, innerException)
        {
        }
    }
}

