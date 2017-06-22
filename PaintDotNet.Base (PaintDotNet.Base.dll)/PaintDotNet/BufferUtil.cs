namespace PaintDotNet
{
    using System;

    public static class BufferUtil
    {
        private static Action<IntPtr, long> zeroMemoryFn;

        public static unsafe void CopyElements(void* pDst, void* pSrc, int srcLength, int srcIndex, int elementCount, int elementSize)
        {
            if ((pDst == null) || (pSrc == null))
            {
                ExceptionUtil.ThrowArgumentNullException();
            }
            if (((srcLength < 0) || (srcIndex < 0)) || (((elementCount < 0) || (elementSize < 1)) || ((srcIndex + elementCount) > srcLength)))
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException();
            }
            if (elementCount != 0)
            {
                Buffer.MemoryCopy(pSrc + ((void*) (srcIndex * elementSize)), pDst, (long) (elementCount * elementSize), (long) (elementCount * elementSize));
            }
        }

        public static unsafe void CopyElements(void* pDst, int dstLength, int dstIndex, void* pSrc, int elementCount, int elementSize)
        {
            if ((pDst == null) || (pSrc == null))
            {
                ExceptionUtil.ThrowArgumentNullException();
            }
            if (((dstLength < 0) || (dstIndex < 0)) || (((elementCount < 0) || (elementSize < 1)) || ((dstIndex + elementCount) > dstLength)))
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException();
            }
            if (elementCount != 0)
            {
                Buffer.MemoryCopy(pSrc, pDst + ((void*) (dstIndex * elementSize)), (long) (elementCount * elementSize), (long) (elementCount * elementSize));
            }
        }

        internal static void InitializeZeroMemoryFunction(Action<IntPtr, long> zeroMemoryFn)
        {
            BufferUtil.zeroMemoryFn = zeroMemoryFn;
        }

        public static unsafe void ZeroMemory(byte* pBuffer, long length)
        {
            Action<IntPtr, long> zeroMemoryFn = BufferUtil.zeroMemoryFn;
            if (zeroMemoryFn != null)
            {
                zeroMemoryFn((IntPtr) pBuffer, length);
            }
            else
            {
                for (long i = 0L; i < length; i += 1L)
                {
                    pBuffer[(int) i] = 0;
                }
            }
        }
    }
}

