namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NonExclusiveException : DxgiException
    {
        public NonExclusiveException() : base(DxgiError.NonExclusive)
        {
        }

        public NonExclusiveException(Exception innerException) : base(DxgiError.NonExclusive, innerException)
        {
        }

        public NonExclusiveException(string message) : base(DxgiError.NonExclusive, message)
        {
        }

        protected NonExclusiveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NonExclusiveException(string message, Exception innerException) : base(DxgiError.NonExclusive, message, innerException)
        {
        }
    }
}

