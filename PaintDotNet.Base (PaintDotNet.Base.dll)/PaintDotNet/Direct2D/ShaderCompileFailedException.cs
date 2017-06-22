namespace PaintDotNet.Direct2D
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ShaderCompileFailedException : Direct2DException
    {
        public ShaderCompileFailedException() : base(Direct2DError.ShaderCompileFailed)
        {
        }

        public ShaderCompileFailedException(Exception innerException) : base(Direct2DError.ShaderCompileFailed, innerException)
        {
        }

        public ShaderCompileFailedException(string message) : base(Direct2DError.ShaderCompileFailed, message)
        {
        }

        protected ShaderCompileFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ShaderCompileFailedException(string message, Exception innerException) : base(Direct2DError.ShaderCompileFailed, message, innerException)
        {
        }
    }
}

