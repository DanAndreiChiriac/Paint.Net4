namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class WasStillDrawingException : DxgiException
    {
        public WasStillDrawingException() : base(DxgiError.WasStillDrawing)
        {
        }

        public WasStillDrawingException(Exception innerException) : base(DxgiError.WasStillDrawing, innerException)
        {
        }

        public WasStillDrawingException(string message) : base(DxgiError.WasStillDrawing, message)
        {
        }

        protected WasStillDrawingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public WasStillDrawingException(string message, Exception innerException) : base(DxgiError.WasStillDrawing, message, innerException)
        {
        }
    }
}

