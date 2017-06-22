namespace PaintDotNet.DirectWrite
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class FontCollectionObsoleteException : DirectWriteException
    {
        public FontCollectionObsoleteException() : base(DirectWriteError.FontCollectionObsolete)
        {
        }

        public FontCollectionObsoleteException(Exception innerException) : base(DirectWriteError.FontCollectionObsolete, innerException)
        {
        }

        public FontCollectionObsoleteException(string message) : base(DirectWriteError.FontCollectionObsolete, message)
        {
        }

        protected FontCollectionObsoleteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public FontCollectionObsoleteException(string message, Exception innerException) : base(DirectWriteError.FontCollectionObsolete, message, innerException)
        {
        }
    }
}

