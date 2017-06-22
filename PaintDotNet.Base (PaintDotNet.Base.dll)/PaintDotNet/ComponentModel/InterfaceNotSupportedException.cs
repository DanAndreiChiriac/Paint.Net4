namespace PaintDotNet.ComponentModel
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InterfaceNotSupportedException : Exception
    {
        public InterfaceNotSupportedException(Type interfaceType) : this(CreateMessage(interfaceType), null)
        {
        }

        protected InterfaceNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            base.HResult = -2147467262;
        }

        protected InterfaceNotSupportedException(string message, Exception innerException) : base(message, innerException)
        {
            base.HResult = -2147467262;
        }

        public InterfaceNotSupportedException(Type interfaceType, Exception innerException) : this(CreateMessage(interfaceType), innerException)
        {
        }

        private static string CreateMessage(Type interfaceType) => 
            $"'{interfaceType.FullName}' is not a supported interface";

        internal static void Throw(Type interfaceType)
        {
            throw new InterfaceNotSupportedException(interfaceType);
        }
    }
}

