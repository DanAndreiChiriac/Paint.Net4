namespace PaintDotNet.Functional
{
    using PaintDotNet;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ResultStruct<T>
    {
        private T value;
        private Result<T> result;
        public bool IsValue =>
            (this.result == null);
        public bool IsError =>
            (this.result > null);
        public T Value
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (this.IsError)
                {
                    ExceptionUtil.ThrowInvalidOperationException("This ResultStruct is an error", this.result.Error);
                }
                return this.value;
            }
        }
        public Exception Error
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (this.IsValue)
                {
                    ExceptionUtil.ThrowInvalidOperationException("This ResultStruct is a value");
                }
                return this.result.Error;
            }
        }
        public Result<T> Result =>
            this.result;
        internal ResultStruct(T value, Result<T> result)
        {
            this.value = value;
            this.result = result;
        }
    }
}

