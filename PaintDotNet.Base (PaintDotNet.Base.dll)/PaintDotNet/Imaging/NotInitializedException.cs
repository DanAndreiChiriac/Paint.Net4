namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NotInitializedException : ImagingException
    {
        public NotInitializedException() : base(ImagingError.NotInitialized)
        {
        }

        public NotInitializedException(Exception innerException) : base(ImagingError.NotInitialized, innerException)
        {
        }

        public NotInitializedException(string message) : base(ImagingError.NotInitialized, message)
        {
        }

        protected NotInitializedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NotInitializedException(string message, Exception innerException) : base(ImagingError.NotInitialized, message, innerException)
        {
        }
    }
}

