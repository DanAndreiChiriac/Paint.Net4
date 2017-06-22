namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class WrongFactoryException : Direct2DException
    {
        public WrongFactoryException() : base(Direct2DError.WrongFactory)
        {
        }

        public WrongFactoryException(Exception innerException) : base(Direct2DError.WrongFactory, innerException)
        {
        }

        public WrongFactoryException(string message) : base(Direct2DError.WrongFactory, message)
        {
        }

        protected WrongFactoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public WrongFactoryException(string message, Exception innerException) : base(Direct2DError.WrongFactory, message, innerException)
        {
        }
    }
}

