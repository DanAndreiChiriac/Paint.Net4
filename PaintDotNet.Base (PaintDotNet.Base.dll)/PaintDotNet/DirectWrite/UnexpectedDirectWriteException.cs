namespace PaintDotNet.DirectWrite
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class UnexpectedDirectWriteException : DirectWriteException
    {
        public UnexpectedDirectWriteException() : base(DirectWriteError.UnexpectedDirectWrite)
        {
        }

        public UnexpectedDirectWriteException(Exception innerException) : base(DirectWriteError.UnexpectedDirectWrite, innerException)
        {
        }

        public UnexpectedDirectWriteException(string message) : base(DirectWriteError.UnexpectedDirectWrite, message)
        {
        }

        protected UnexpectedDirectWriteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnexpectedDirectWriteException(string message, Exception innerException) : base(DirectWriteError.UnexpectedDirectWrite, message, innerException)
        {
        }
    }
}

