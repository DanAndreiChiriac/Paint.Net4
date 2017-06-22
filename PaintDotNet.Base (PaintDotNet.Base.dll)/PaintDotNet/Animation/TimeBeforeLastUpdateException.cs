namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TimeBeforeLastUpdateException : AnimationException
    {
        public TimeBeforeLastUpdateException() : base(AnimationError.TimeBeforeLastUpdate)
        {
        }

        public TimeBeforeLastUpdateException(Exception innerException) : base(AnimationError.TimeBeforeLastUpdate, innerException)
        {
        }

        public TimeBeforeLastUpdateException(string message) : base(AnimationError.TimeBeforeLastUpdate, message)
        {
        }

        protected TimeBeforeLastUpdateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TimeBeforeLastUpdateException(string message, Exception innerException) : base(AnimationError.TimeBeforeLastUpdate, message, innerException)
        {
        }
    }
}

