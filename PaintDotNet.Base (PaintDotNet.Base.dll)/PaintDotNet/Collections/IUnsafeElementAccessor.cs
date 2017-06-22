namespace PaintDotNet.Collections
{
    using System;

    public interface IUnsafeElementAccessor
    {
        unsafe void WriteElement(void* pDst, void* pSrc);

        Type ElementType { get; }

        int SizeOfElement { get; }
    }
}

