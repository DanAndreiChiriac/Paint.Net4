namespace PaintDotNet.DirectWrite
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class AlreadyRegisteredException : DirectWriteException
    {
        public AlreadyRegisteredException() : base(DirectWriteError.AlreadyRegistered)
        {
        }

        public AlreadyRegisteredException(Exception innerException) : base(DirectWriteError.AlreadyRegistered, innerException)
        {
        }

        public AlreadyRegisteredException(string message) : base(DirectWriteError.AlreadyRegistered, message)
        {
        }

        protected AlreadyRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public AlreadyRegisteredException(string message, Exception innerException) : base(DirectWriteError.AlreadyRegistered, message, innerException)
        {
        }
    }
}

