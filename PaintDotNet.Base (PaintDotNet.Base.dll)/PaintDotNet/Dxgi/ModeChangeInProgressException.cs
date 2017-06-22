namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ModeChangeInProgressException : DxgiException
    {
        public ModeChangeInProgressException() : base(DxgiError.ModeChangeInProgress)
        {
        }

        public ModeChangeInProgressException(Exception innerException) : base(DxgiError.ModeChangeInProgress, innerException)
        {
        }

        public ModeChangeInProgressException(string message) : base(DxgiError.ModeChangeInProgress, message)
        {
        }

        protected ModeChangeInProgressException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ModeChangeInProgressException(string message, Exception innerException) : base(DxgiError.ModeChangeInProgress, message, innerException)
        {
        }
    }
}

