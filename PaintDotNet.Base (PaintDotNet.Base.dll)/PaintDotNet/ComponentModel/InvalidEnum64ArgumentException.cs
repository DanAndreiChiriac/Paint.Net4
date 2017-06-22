namespace PaintDotNet.ComponentModel
{
    using System;
    using System.ComponentModel;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidEnum64ArgumentException : InvalidEnumArgumentException
    {
        public InvalidEnum64ArgumentException()
        {
        }

        public InvalidEnum64ArgumentException(string message) : base(message)
        {
        }

        protected InvalidEnum64ArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidEnum64ArgumentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InvalidEnum64ArgumentException(string argumentName, long invalidValue, Type enumClass) : base(CreateMessage(argumentName, invalidValue, enumClass))
        {
        }

        private static string CreateMessage(string argumentName, long invalidValue, Type enumClass) => 
            $"{argumentName}={invalidValue} is not a valid value for the {enumClass.Name} enumeration type";
    }
}

