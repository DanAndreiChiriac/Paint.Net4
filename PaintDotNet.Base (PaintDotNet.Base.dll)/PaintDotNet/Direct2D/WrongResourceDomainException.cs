namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class WrongResourceDomainException : Direct2DException
    {
        public WrongResourceDomainException() : base(Direct2DError.WrongResourceDomain)
        {
        }

        public WrongResourceDomainException(Exception innerException) : base(Direct2DError.WrongResourceDomain, innerException)
        {
        }

        public WrongResourceDomainException(string message) : base(Direct2DError.WrongResourceDomain, message)
        {
        }

        protected WrongResourceDomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public WrongResourceDomainException(string message, Exception innerException) : base(Direct2DError.WrongResourceDomain, message, innerException)
        {
        }
    }
}

