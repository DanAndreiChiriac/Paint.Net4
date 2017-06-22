namespace PaintDotNet.Interop
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct InteropErrorInfo
    {
        private string message;
        private unsafe byte* szMessageUnsafeNeverFreed;
        private Exception innerException;
        private int hr;
        public static InteropErrorInfo Ok =>
            new InteropErrorInfo();
        public int HResult =>
            this.hr;
        public string Message
        {
            get
            {
                if (this.message != null)
                {
                    return this.message;
                }
                if (this.szMessageUnsafeNeverFreed != null)
                {
                    return Marshal.PtrToStringAnsi((IntPtr) this.szMessageUnsafeNeverFreed);
                }
                return null;
            }
        }
        public Exception InnerException =>
            this.innerException;
        public bool IsError =>
            (this.hr < 0);
        public Exception ToException()
        {
            if (!this.IsError)
            {
                ExceptionUtil.ThrowInvalidOperationException("ToException() may only be called if IsError is true");
            }
            return ExceptionFactory.CreateFromHR(this.hr, this.Message, this.innerException);
        }

        public void ThrowIfError()
        {
            if (this.IsError)
            {
                ExceptionFactory.ThrowOnError(this.hr, this.Message, this.innerException);
            }
        }

        internal unsafe InteropErrorInfo(int hr, byte* szMessageUnsafeNeverFreed, Exception innerException)
        {
            this.hr = hr;
            this.message = null;
            this.szMessageUnsafeNeverFreed = szMessageUnsafeNeverFreed;
            this.innerException = innerException;
        }

        public unsafe InteropErrorInfo(int hr, string message, Exception innerException)
        {
            this.hr = hr;
            this.message = message;
            this.szMessageUnsafeNeverFreed = null;
            this.innerException = innerException;
        }
    }
}

