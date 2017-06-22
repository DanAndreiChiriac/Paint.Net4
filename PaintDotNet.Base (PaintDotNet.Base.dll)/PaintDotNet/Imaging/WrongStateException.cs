namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class WrongStateException : ImagingException
    {
        public WrongStateException() : base(ImagingError.WrongState)
        {
        }

        public WrongStateException(Exception innerException) : base(ImagingError.WrongState, innerException)
        {
        }

        public WrongStateException(string message) : base(ImagingError.WrongState, message)
        {
        }

        protected WrongStateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public WrongStateException(string message, Exception innerException) : base(ImagingError.WrongState, message, innerException)
        {
        }
    }
}

