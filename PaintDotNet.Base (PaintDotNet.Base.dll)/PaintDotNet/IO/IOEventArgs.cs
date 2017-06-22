namespace PaintDotNet.IO
{
    using System;

    public sealed class IOEventArgs : EventArgs
    {
        private readonly int count;
        private readonly PaintDotNet.IO.IOOperationType ioOperationType;
        private readonly long position;

        public IOEventArgs(PaintDotNet.IO.IOOperationType ioOperationType, long position, int count)
        {
            this.ioOperationType = ioOperationType;
            this.position = position;
            this.count = count;
        }

        public int Count =>
            this.count;

        public PaintDotNet.IO.IOOperationType IOOperationType =>
            this.ioOperationType;

        public long Position =>
            this.position;
    }
}

