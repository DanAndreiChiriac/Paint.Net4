namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class SourceRectDoesNotMatchDimensionsException : ImagingException
    {
        public SourceRectDoesNotMatchDimensionsException() : base(ImagingError.SourceRectDoesNotMatchDimensions)
        {
        }

        public SourceRectDoesNotMatchDimensionsException(Exception innerException) : base(ImagingError.SourceRectDoesNotMatchDimensions, innerException)
        {
        }

        public SourceRectDoesNotMatchDimensionsException(string message) : base(ImagingError.SourceRectDoesNotMatchDimensions, message)
        {
        }

        protected SourceRectDoesNotMatchDimensionsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public SourceRectDoesNotMatchDimensionsException(string message, Exception innerException) : base(ImagingError.SourceRectDoesNotMatchDimensions, message, innerException)
        {
        }
    }
}

