namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class FrameStatisticsDisjointException : DxgiException
    {
        public FrameStatisticsDisjointException() : base(DxgiError.FrameStatisticsDisjoint)
        {
        }

        public FrameStatisticsDisjointException(Exception innerException) : base(DxgiError.FrameStatisticsDisjoint, innerException)
        {
        }

        public FrameStatisticsDisjointException(string message) : base(DxgiError.FrameStatisticsDisjoint, message)
        {
        }

        protected FrameStatisticsDisjointException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public FrameStatisticsDisjointException(string message, Exception innerException) : base(DxgiError.FrameStatisticsDisjoint, message, innerException)
        {
        }
    }
}

