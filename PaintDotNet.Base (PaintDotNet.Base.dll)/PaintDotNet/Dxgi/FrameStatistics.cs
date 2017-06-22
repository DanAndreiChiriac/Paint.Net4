namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct FrameStatistics
    {
        private uint presentCount;
        private uint presentRefreshCount;
        private uint syncRefreshCount;
        private long syncQpcTime;
        private long syncGpuTime;
        public long PresentCount =>
            ((long) this.presentCount);
        public long PresentRefreshCount =>
            ((long) this.presentRefreshCount);
        public long SyncRefreshCount =>
            ((long) this.syncRefreshCount);
        public long SyncQpcTime =>
            this.syncQpcTime;
        public long SyncGpuTime =>
            this.syncGpuTime;
    }
}

