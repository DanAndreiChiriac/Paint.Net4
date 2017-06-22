namespace PaintDotNet.Imaging
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public abstract class ImagingException : InteropException
    {
        internal ImagingException(ImagingError error) : this(error, null, null)
        {
        }

        internal ImagingException(ImagingError error, Exception innerException) : this(error, null, innerException)
        {
        }

        internal ImagingException(ImagingError error, string message) : this(error, message, null)
        {
        }

        protected ImagingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        internal ImagingException(ImagingError error, string message, Exception innerException) : base(message, innerException, (int) error)
        {
        }

        public ImagingError Error =>
            ((ImagingError) base.HResult);
    }
}

