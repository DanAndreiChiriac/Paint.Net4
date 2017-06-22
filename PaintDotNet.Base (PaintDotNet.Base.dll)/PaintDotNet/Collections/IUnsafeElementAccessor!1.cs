namespace PaintDotNet.Collections
{
    using System;

    public interface IUnsafeElementAccessor<T> : IUnsafeElementAccessor where T: struct
    {
        unsafe void CopyElements(T[] dst, int dstIndex, void* pSrc, int length);
        unsafe void CopyElements(void* pDst, T[] src, int srcIndex, int length);
        unsafe T ReadElement(void* pSrc);
        unsafe void WriteElement(void* pDst, T srcValue);
    }
}

