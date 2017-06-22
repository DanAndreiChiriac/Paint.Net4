namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct SharedResource
    {
        private IntPtr handle;
        public IntPtr Handle
        {
            get => 
                this.handle;
            set
            {
                this.handle = value;
            }
        }
    }
}

