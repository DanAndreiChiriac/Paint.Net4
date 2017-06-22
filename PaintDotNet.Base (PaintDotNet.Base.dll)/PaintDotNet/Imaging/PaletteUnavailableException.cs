namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class PaletteUnavailableException : ImagingException
    {
        public PaletteUnavailableException() : base(ImagingError.PaletteUnavailable)
        {
        }

        public PaletteUnavailableException(Exception innerException) : base(ImagingError.PaletteUnavailable, innerException)
        {
        }

        public PaletteUnavailableException(string message) : base(ImagingError.PaletteUnavailable, message)
        {
        }

        protected PaletteUnavailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PaletteUnavailableException(string message, Exception innerException) : base(ImagingError.PaletteUnavailable, message, innerException)
        {
        }
    }
}

