namespace PaintDotNet
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ReadOnlyException : NotSupportedException
    {
        public ReadOnlyException()
        {
        }

        public ReadOnlyException(string message) : base(message)
        {
        }

        protected ReadOnlyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ReadOnlyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

