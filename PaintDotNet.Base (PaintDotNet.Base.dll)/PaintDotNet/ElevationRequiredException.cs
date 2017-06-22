namespace PaintDotNet
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.Serialization;
    using System.Security;

    [Serializable]
    public class ElevationRequiredException : SecurityException
    {
        public ElevationRequiredException() : this(null, null, InteropError.ElevationRequired)
        {
        }

        public ElevationRequiredException(Exception innerException) : this(null, innerException, InteropError.ElevationRequired)
        {
        }

        public ElevationRequiredException(string message) : this(message, null, InteropError.ElevationRequired)
        {
        }

        protected ElevationRequiredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ElevationRequiredException(string message, Exception innerException) : this(message, innerException, InteropError.ElevationRequired)
        {
        }

        protected ElevationRequiredException(string message, Exception innerException, InteropError hr) : this(message, innerException, (int) hr)
        {
        }

        public ElevationRequiredException(string message, Exception innerException, int hr) : base(message, innerException)
        {
            base.HResult = hr;
        }
    }
}

