namespace PaintDotNet.DirectWrite
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class FontFileFormatException : DirectWriteException
    {
        public FontFileFormatException() : base(DirectWriteError.FontFileFormat)
        {
        }

        public FontFileFormatException(Exception innerException) : base(DirectWriteError.FontFileFormat, innerException)
        {
        }

        public FontFileFormatException(string message) : base(DirectWriteError.FontFileFormat, message)
        {
        }

        protected FontFileFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public FontFileFormatException(string message, Exception innerException) : base(DirectWriteError.FontFileFormat, message, innerException)
        {
        }
    }
}

