namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=1)]
    public struct UnsafeByteAccessor : IUnsafeElementAccessor<byte>, IUnsafeElementAccessor
    {
        public Type ElementType =>
            typeof(byte);
        public int SizeOfElement =>
            1;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void CopyElements(void* pDst, byte[] src, int srcIndex, int length)
        {
            fixed (byte* numRef = src)
            {
                BufferUtil.CopyElements(pDst, (void*) numRef, src.Length, srcIndex, length, 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void CopyElements(byte[] dst, int dstIndex, void* pSrc, int length)
        {
            fixed (byte* numRef = dst)
            {
                BufferUtil.CopyElements((void*) numRef, dst.Length, dstIndex, pSrc, length, 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe byte ReadElement(void* pSrc) => 
            *(((byte*) pSrc));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void WriteElement(void* pDst, void* pSrc)
        {
            *((sbyte*) pDst) = *((byte*) pSrc);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void WriteElement(void* pDst, byte srcValue)
        {
            *((sbyte*) pDst) = srcValue;
        }
    }
}

