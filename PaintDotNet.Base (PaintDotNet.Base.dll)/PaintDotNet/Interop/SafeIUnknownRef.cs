namespace PaintDotNet.Interop
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    [SecurityCritical]
    public class SafeIUnknownRef : SafeHandleZeroIsInvalid, IComObjectRef
    {
        private SafeIUnknownRef() : base(true)
        {
        }

        public SafeIUnknownRef(IntPtr pExistingRef, bool ownsHandle) : base(ownsHandle)
        {
            base.SetHandle(pExistingRef);
        }

        public static SafeIUnknownRef AddRef(IntPtr pObject)
        {
            Marshal.AddRef(pObject);
            SafeIUnknownRef ref1 = new SafeIUnknownRef();
            ref1.SetHandle(pObject);
            return ref1;
        }

        public SafeIUnknownRef CreateRef()
        {
            Marshal.AddRef(base.handle);
            SafeIUnknownRef ref1 = new SafeIUnknownRef();
            ref1.SetHandle(base.handle);
            return ref1;
        }

        public static SafeIUnknownRef QueryInterface(IntPtr pObject, ref Guid iid)
        {
            IntPtr ptr;
            ExceptionFactory.ThrowOnError(Marshal.QueryInterface(pObject, ref iid, out ptr), null, null);
            SafeIUnknownRef ref1 = new SafeIUnknownRef();
            ref1.SetHandle(ptr);
            return ref1;
        }

        [SecurityCritical]
        protected override bool ReleaseHandle() => 
            (Marshal.Release(base.handle) >= 0);

        public bool TryQueryInterfaceNative(Guid iid, out SafeIUnknownRef newIUnknownRef)
        {
            IntPtr ptr;
            if (Marshal.QueryInterface(base.handle, ref iid, out ptr) >= 0)
            {
                newIUnknownRef = new SafeIUnknownRef(ptr, true);
                return true;
            }
            newIUnknownRef = null;
            return false;
        }
    }
}

