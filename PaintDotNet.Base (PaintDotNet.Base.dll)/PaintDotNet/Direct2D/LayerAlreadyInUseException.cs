namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class LayerAlreadyInUseException : Direct2DException
    {
        public LayerAlreadyInUseException() : base(Direct2DError.LayerAlreadyInUse)
        {
        }

        public LayerAlreadyInUseException(Exception innerException) : base(Direct2DError.LayerAlreadyInUse, innerException)
        {
        }

        public LayerAlreadyInUseException(string message) : base(Direct2DError.LayerAlreadyInUse, message)
        {
        }

        protected LayerAlreadyInUseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public LayerAlreadyInUseException(string message, Exception innerException) : base(Direct2DError.LayerAlreadyInUse, message, innerException)
        {
        }
    }
}

