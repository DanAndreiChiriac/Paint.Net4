namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class BadNumberException : Direct2DException
    {
        public BadNumberException() : base(Direct2DError.BadNumber)
        {
        }

        public BadNumberException(Exception innerException) : base(Direct2DError.BadNumber, innerException)
        {
        }

        public BadNumberException(string message) : base(Direct2DError.BadNumber, message)
        {
        }

        protected BadNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public BadNumberException(string message, Exception innerException) : base(Direct2DError.BadNumber, message, innerException)
        {
        }
    }
}

