namespace PaintDotNet.DirectWrite
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class FontFileAccessException : DirectWriteException
    {
        public FontFileAccessException() : base(DirectWriteError.FontFileAccess)
        {
        }

        public FontFileAccessException(Exception innerException) : base(DirectWriteError.FontFileAccess, innerException)
        {
        }

        public FontFileAccessException(string message) : base(DirectWriteError.FontFileAccess, message)
        {
        }

        protected FontFileAccessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public FontFileAccessException(string message, Exception innerException) : base(DirectWriteError.FontFileAccess, message, innerException)
        {
        }
    }
}

