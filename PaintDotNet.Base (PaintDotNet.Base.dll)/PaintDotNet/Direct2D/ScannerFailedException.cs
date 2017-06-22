namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ScannerFailedException : Direct2DException
    {
        public ScannerFailedException() : base(Direct2DError.ScannerFailed)
        {
        }

        public ScannerFailedException(Exception innerException) : base(Direct2DError.ScannerFailed, innerException)
        {
        }

        public ScannerFailedException(string message) : base(Direct2DError.ScannerFailed, message)
        {
        }

        protected ScannerFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ScannerFailedException(string message, Exception innerException) : base(Direct2DError.ScannerFailed, message, innerException)
        {
        }
    }
}

