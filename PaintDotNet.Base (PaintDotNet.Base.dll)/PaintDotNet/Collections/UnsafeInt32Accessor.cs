namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=1)]
    public struct UnsafeInt32Accessor : IUnsafeElementAccessor<int>, IUnsafeElementAccessor
    {
        public Type ElementType =>
            typeof(int);
        public int SizeOfElement =>
            4;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void CopyElements(void* pDst, int[] src, int srcIndex, int length)
        {
            fixed (int* numRef = src)
            {
                BufferUtil.CopyElements(pDst, (void*) numRef, src.Length, srcIndex, length, 4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void CopyElements(int[] dst, int dstIndex, void* pSrc, int length)
        {
            fixed (int* numRef = dst)
            {
                BufferUtil.CopyElements((void*) numRef, dst.Length, dstIndex, pSrc, length, 4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe int ReadElement(void* pSrc) => 
            *(((int*) pSrc));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void WriteElement(void* pDst, void* pSrc)
        {
            *((int*) pDst) = *((int*) pSrc);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void WriteElement(void* pDst, int srcValue)
        {
            *((int*) pDst) = srcValue;
        }
    }
}

