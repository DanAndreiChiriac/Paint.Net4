namespace PaintDotNet.DirectWrite
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class FontFileNotFoundException : DirectWriteException
    {
        public FontFileNotFoundException() : base(DirectWriteError.FontFileNotFound)
        {
        }

        public FontFileNotFoundException(Exception innerException) : base(DirectWriteError.FontFileNotFound, innerException)
        {
        }

        public FontFileNotFoundException(string message) : base(DirectWriteError.FontFileNotFound, message)
        {
        }

        protected FontFileNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public FontFileNotFoundException(string message, Exception innerException) : base(DirectWriteError.FontFileNotFound, message, innerException)
        {
        }
    }
}

