namespace PaintDotNet.DirectWrite
{
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public abstract class DirectWriteException : RenderingException
    {
        internal DirectWriteException(PaintDotNet.DirectWrite.DirectWriteError error) : this(error, null, null)
        {
        }

        internal DirectWriteException(PaintDotNet.DirectWrite.DirectWriteError error, Exception innerException) : this(error, null, innerException)
        {
        }

        internal DirectWriteException(PaintDotNet.DirectWrite.DirectWriteError error, string message) : this(error, message, null)
        {
        }

        protected DirectWriteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        internal DirectWriteException(PaintDotNet.DirectWrite.DirectWriteError error, string message, Exception innerException) : base(message, innerException, (int) error)
        {
        }

        public PaintDotNet.DirectWrite.DirectWriteError DirectWriteError =>
            ((PaintDotNet.DirectWrite.DirectWriteError) base.HResult);
    }
}

