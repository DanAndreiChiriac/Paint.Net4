namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ModeChangedException : DxgiException
    {
        public ModeChangedException() : base(DxgiError.ModeChanged)
        {
        }

        public ModeChangedException(Exception innerException) : base(DxgiError.ModeChanged, innerException)
        {
        }

        public ModeChangedException(string message) : base(DxgiError.ModeChanged, message)
        {
        }

        protected ModeChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ModeChangedException(string message, Exception innerException) : base(DxgiError.ModeChanged, message, innerException)
        {
        }
    }
}

