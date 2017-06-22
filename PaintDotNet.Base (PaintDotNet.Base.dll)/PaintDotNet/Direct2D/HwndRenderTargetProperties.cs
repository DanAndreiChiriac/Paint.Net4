namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct HwndRenderTargetProperties : IEquatable<HwndRenderTargetProperties>
    {
        private IntPtr hwnd;
        private SizeInt32 pixelSize;
        private PaintDotNet.Direct2D.PresentOptions presentOptions;
        public IntPtr Hwnd
        {
            get => 
                this.hwnd;
            set
            {
                this.hwnd = value;
            }
        }
        public SizeInt32 PixelSize
        {
            get => 
                this.pixelSize;
            set
            {
                this.pixelSize = value;
            }
        }
        public PaintDotNet.Direct2D.PresentOptions PresentOptions
        {
            get => 
                this.presentOptions;
            set
            {
                this.presentOptions = value;
            }
        }
        public HwndRenderTargetProperties(IntPtr hwnd, SizeInt32 pixelSize, PaintDotNet.Direct2D.PresentOptions presentOptions)
        {
            this.hwnd = hwnd;
            this.pixelSize = pixelSize;
            this.presentOptions = presentOptions;
        }

        public bool Equals(HwndRenderTargetProperties other) => 
            (((this.hwnd == other.hwnd) && (this.pixelSize == other.pixelSize)) && (this.presentOptions == other.presentOptions));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<HwndRenderTargetProperties, object>(this, obj);

        public static bool operator ==(HwndRenderTargetProperties a, HwndRenderTargetProperties b) => 
            a.Equals(b);

        public static bool operator !=(HwndRenderTargetProperties a, HwndRenderTargetProperties b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.hwnd.GetHashCode(), this.pixelSize.GetHashCode(), (int) this.presentOptions);
    }
}

