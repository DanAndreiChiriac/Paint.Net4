namespace PaintDotNet.Threading
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class DispatcherShutdownException : DispatcherException
    {
        public DispatcherShutdownException() : this("The dispatcher that this work item was assigned to has shutdown")
        {
        }

        public DispatcherShutdownException(string message) : base(message)
        {
        }

        protected DispatcherShutdownException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public DispatcherShutdownException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

