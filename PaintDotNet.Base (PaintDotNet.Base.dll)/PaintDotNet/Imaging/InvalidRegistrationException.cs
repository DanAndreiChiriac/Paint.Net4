namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidRegistrationException : ImagingException
    {
        public InvalidRegistrationException() : base(ImagingError.InvalidRegistration)
        {
        }

        public InvalidRegistrationException(Exception innerException) : base(ImagingError.InvalidRegistration, innerException)
        {
        }

        public InvalidRegistrationException(string message) : base(ImagingError.InvalidRegistration, message)
        {
        }

        protected InvalidRegistrationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidRegistrationException(string message, Exception innerException) : base(ImagingError.InvalidRegistration, message, innerException)
        {
        }
    }
}

