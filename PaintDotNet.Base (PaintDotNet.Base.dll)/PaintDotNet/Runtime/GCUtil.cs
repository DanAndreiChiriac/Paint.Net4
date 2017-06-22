namespace PaintDotNet.Runtime
{
    using System;

    public static class GCUtil
    {
        public static void AddMemoryPressure(long bytesAllocated)
        {
            if (bytesAllocated < 0L)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (bytesAllocated > 0L)
            {
                GC.AddMemoryPressure(bytesAllocated);
            }
        }

        public static void RemoveMemoryPressure(long bytesDeallocated)
        {
            if (bytesDeallocated < 0L)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (bytesDeallocated > 0L)
            {
                GC.RemoveMemoryPressure(bytesDeallocated);
            }
        }
    }
}

