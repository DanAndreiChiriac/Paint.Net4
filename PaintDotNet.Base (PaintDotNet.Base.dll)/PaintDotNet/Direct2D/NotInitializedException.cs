namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NotInitializedException : Direct2DException
    {
        public NotInitializedException() : base(Direct2DError.NotInitialized)
        {
        }

        public NotInitializedException(Exception innerException) : base(Direct2DError.NotInitialized, innerException)
        {
        }

        public NotInitializedException(string message) : base(Direct2DError.NotInitialized, message)
        {
        }

        protected NotInitializedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NotInitializedException(string message, Exception innerException) : base(Direct2DError.NotInitialized, message, innerException)
        {
        }
    }
}

