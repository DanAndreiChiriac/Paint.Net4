namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ComponentInitializeFailureException : ImagingException
    {
        public ComponentInitializeFailureException() : base(ImagingError.ComponentInitializeFailure)
        {
        }

        public ComponentInitializeFailureException(Exception innerException) : base(ImagingError.ComponentInitializeFailure, innerException)
        {
        }

        public ComponentInitializeFailureException(string message) : base(ImagingError.ComponentInitializeFailure, message)
        {
        }

        protected ComponentInitializeFailureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ComponentInitializeFailureException(string message, Exception innerException) : base(ImagingError.ComponentInitializeFailure, message, innerException)
        {
        }
    }
}

