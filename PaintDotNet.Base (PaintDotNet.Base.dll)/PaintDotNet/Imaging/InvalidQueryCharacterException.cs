namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidQueryCharacterException : ImagingException
    {
        public InvalidQueryCharacterException() : base(ImagingError.InvalidQueryCharacter)
        {
        }

        public InvalidQueryCharacterException(Exception innerException) : base(ImagingError.InvalidQueryCharacter, innerException)
        {
        }

        public InvalidQueryCharacterException(string message) : base(ImagingError.InvalidQueryCharacter, message)
        {
        }

        protected InvalidQueryCharacterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidQueryCharacterException(string message, Exception innerException) : base(ImagingError.InvalidQueryCharacter, message, innerException)
        {
        }
    }
}

