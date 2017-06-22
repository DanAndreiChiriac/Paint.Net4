namespace PaintDotNet.Interop
{
    using System;
    using System.Runtime.InteropServices;

    public interface IComObjectRef
    {
        bool TryQueryInterfaceNative(Guid iid, out SafeIUnknownRef newIUnknownRef);
    }
}

