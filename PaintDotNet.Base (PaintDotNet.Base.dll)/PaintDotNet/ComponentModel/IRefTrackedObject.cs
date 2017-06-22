namespace PaintDotNet.ComponentModel
{
    using System;
    using System.Runtime.InteropServices;

    internal interface IRefTrackedObject
    {
        int ReleaseRef(object refOwner, bool disposing);
        bool TryAddRef(object refOwner, out int newRefCount);
    }
}

