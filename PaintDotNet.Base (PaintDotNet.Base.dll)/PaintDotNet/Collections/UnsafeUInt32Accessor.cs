namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=1)]
    public struct UnsafeUInt32Accessor : IUnsafeElementAccessor<uint>, IUnsafeElementAccessor
    {
        public Type ElementType =>
            typeof(uint);
        public int SizeOfElement =>
            4;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void CopyElements(void* pDst, uint[] src, int srcIndex, int length)
        {
            fixed (uint* numRef = src)
            {
                BufferUtil.CopyElements(pDst, (void*) numRef, src.Length, srcIndex, length, 4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void CopyElements(uint[] dst, int dstIndex, void* pSrc, int length)
        {
            fixed (uint* numRef = dst)
            {
                BufferUtil.CopyElements((void*) numRef, dst.Length, dstIndex, pSrc, length, 4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe uint ReadElement(void* pSrc) => 
            *(((uint*) pSrc));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void WriteElement(void* pDst, void* pSrc)
        {
            *((int*) pDst) = *((uint*) pSrc);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void WriteElement(void* pDst, uint srcValue)
        {
            *((int*) pDst) = srcValue;
        }
    }
}

