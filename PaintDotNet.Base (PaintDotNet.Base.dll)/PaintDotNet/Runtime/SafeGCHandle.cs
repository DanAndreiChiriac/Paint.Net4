namespace PaintDotNet.Runtime
{
    using System;
    using System.Runtime.InteropServices;

    public abstract class SafeGCHandle : SafeHandle
    {
        protected SafeGCHandle() : base(IntPtr.Zero, true)
        {
        }

        protected SafeGCHandle(System.Runtime.InteropServices.GCHandle gcHandle) : this()
        {
            base.SetHandle(System.Runtime.InteropServices.GCHandle.ToIntPtr(gcHandle));
        }

        public IntPtr AddrOfPinnedObject() => 
            this.GCHandle.AddrOfPinnedObject();

        public static SafeGCHandle<T> Alloc<T>(T value) where T: class => 
            Alloc<T>(value, GCHandleType.Normal);

        public static SafeGCHandle<T> Alloc<T>(T value, GCHandleType type) where T: class
        {
            SafeGCHandle<T> handle3;
            SafeGCHandle<T> handle = new SafeGCHandle<T>();
            System.Runtime.InteropServices.GCHandle gcHandle = new System.Runtime.InteropServices.GCHandle();
            try
            {
                gcHandle = System.Runtime.InteropServices.GCHandle.Alloc(value, type);
                handle.TakeHandle(ref gcHandle);
                handle3 = handle;
            }
            catch (Exception)
            {
                if (gcHandle.IsAllocated)
                {
                    gcHandle.Free();
                }
                throw;
            }
            return handle3;
        }

        protected override bool ReleaseHandle()
        {
            System.Runtime.InteropServices.GCHandle.FromIntPtr(base.handle).Free();
            return true;
        }

        private void TakeHandle(ref System.Runtime.InteropServices.GCHandle gcHandle)
        {
            base.SetHandle(System.Runtime.InteropServices.GCHandle.ToIntPtr(gcHandle));
            gcHandle = new System.Runtime.InteropServices.GCHandle();
        }

        public System.Runtime.InteropServices.GCHandle GCHandle =>
            System.Runtime.InteropServices.GCHandle.FromIntPtr(base.handle);

        public bool IsAllocated =>
            this.GCHandle.IsAllocated;

        public override bool IsInvalid =>
            (base.handle == IntPtr.Zero);

        public object Target =>
            this.GCHandle.Target;
    }
}

