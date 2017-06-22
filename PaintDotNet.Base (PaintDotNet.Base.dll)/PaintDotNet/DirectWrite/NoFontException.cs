namespace PaintDotNet.DirectWrite
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NoFontException : DirectWriteException
    {
        public NoFontException() : base(DirectWriteError.NoFont)
        {
        }

        public NoFontException(Exception innerException) : base(DirectWriteError.NoFont, innerException)
        {
        }

        public NoFontException(string message) : base(DirectWriteError.NoFont, message)
        {
        }

        protected NoFontException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NoFontException(string message, Exception innerException) : base(DirectWriteError.NoFont, message, innerException)
        {
        }
    }
}

