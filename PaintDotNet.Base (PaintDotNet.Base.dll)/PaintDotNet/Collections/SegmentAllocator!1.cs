namespace PaintDotNet.Collections
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal struct SegmentAllocator<T>
    {
        private int segmentLengthLog2;
        private T[] spareSegment;
        public static SegmentAllocator<T> GetInstance(int segmentLengthLog2) => 
            new SegmentAllocator<T>(segmentLengthLog2);

        private SegmentAllocator(int segmentLengthLog2)
        {
            Validate.IsNotNegative(segmentLengthLog2, "segmentLengthLog2");
            this.segmentLengthLog2 = segmentLengthLog2;
            this.spareSegment = null;
        }

        public int SegmentLength =>
            (((int) 1) << this.segmentLengthLog2);
        public int SegmentLengthLog2 =>
            this.segmentLengthLog2;
        public int Count
        {
            get
            {
                if (this.spareSegment != null)
                {
                    return 1;
                }
                return 0;
            }
        }
        public bool IsFull =>
            (this.spareSegment > null);
        public bool IsEmpty =>
            (this.spareSegment == null);
        public void Clear()
        {
            this.spareSegment = null;
        }

        public T[] Get()
        {
            if (this.spareSegment == null)
            {
                return new T[this.SegmentLength];
            }
            T[] spareSegment = this.spareSegment;
            this.spareSegment = null;
            return spareSegment;
        }

        public void Release(T[] segment)
        {
            this.Release(segment, true);
        }

        internal void Release(T[] segment, bool isDirty)
        {
            if (this.spareSegment == null)
            {
                if (isDirty)
                {
                    Array.Clear(segment, 0, segment.Length);
                }
                this.spareSegment = segment;
            }
        }
    }
}

