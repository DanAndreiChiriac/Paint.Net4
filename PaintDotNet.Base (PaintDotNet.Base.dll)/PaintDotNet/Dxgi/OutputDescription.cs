namespace PaintDotNet.Dxgi
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct OutputDescription
    {
        private const int deviceNameLength = 0x20;
        [MarshalAs(UnmanagedType.LPWStr)]
        private string deviceName;
        private int desktopCoordinatesLeft;
        private int desktopCoordinatesTop;
        private int desktopCoordinatesRight;
        private int desktopCoordinatesBottom;
        private bool isAttachedToDesktop;
        private RotationMode rotation;
        private IntPtr hMonitor;
        public OutputDescription(string deviceName, int desktopCoordinatesLeft, int desktopCoordinatesTop, int desktopCoordinatesRight, int desktopCoordinatesBottom, bool isAttachedToDesktop, RotationMode rotation, IntPtr hMonitor)
        {
            Validate.IsNotNull<string>(deviceName, "deviceName");
            if (deviceName.Length >= 0x20)
            {
                ExceptionUtil.ThrowArgumentException("deviceName.Length must be less than 32", "deviceName");
            }
            this.deviceName = deviceName;
            this.desktopCoordinatesLeft = desktopCoordinatesLeft;
            this.desktopCoordinatesTop = desktopCoordinatesTop;
            this.desktopCoordinatesRight = desktopCoordinatesRight;
            this.desktopCoordinatesBottom = desktopCoordinatesBottom;
            this.isAttachedToDesktop = isAttachedToDesktop;
            this.rotation = rotation;
            this.hMonitor = hMonitor;
        }

        public string DeviceName =>
            this.deviceName;
        public RectInt32 DesktopCoordinates =>
            RectInt32.FromEdges(this.desktopCoordinatesLeft, this.desktopCoordinatesTop, this.desktopCoordinatesRight, this.desktopCoordinatesBottom);
        public bool IsAttachedToDesktop =>
            this.isAttachedToDesktop;
        public RotationMode Rotation =>
            this.rotation;
        public IntPtr Monitor =>
            this.hMonitor;
    }
}

