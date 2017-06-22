namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class MoreDataException : DxgiException
    {
        public MoreDataException() : base(DxgiError.MoreData)
        {
        }

        public MoreDataException(Exception innerException) : base(DxgiError.MoreData, innerException)
        {
        }

        public MoreDataException(string message) : base(DxgiError.MoreData, message)
        {
        }

        protected MoreDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public MoreDataException(string message, Exception innerException) : base(DxgiError.MoreData, message, innerException)
        {
        }
    }
}

