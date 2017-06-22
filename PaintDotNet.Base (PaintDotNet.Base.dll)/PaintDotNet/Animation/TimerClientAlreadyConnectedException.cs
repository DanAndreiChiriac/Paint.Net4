namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TimerClientAlreadyConnectedException : AnimationException
    {
        public TimerClientAlreadyConnectedException() : base(AnimationError.TimerClientAlreadyConnected)
        {
        }

        public TimerClientAlreadyConnectedException(Exception innerException) : base(AnimationError.TimerClientAlreadyConnected, innerException)
        {
        }

        public TimerClientAlreadyConnectedException(string message) : base(AnimationError.TimerClientAlreadyConnected, message)
        {
        }

        protected TimerClientAlreadyConnectedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TimerClientAlreadyConnectedException(string message, Exception innerException) : base(AnimationError.TimerClientAlreadyConnected, message, innerException)
        {
        }
    }
}

