namespace PaintDotNet.ComponentModel
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct UnsafeObjectRef : IDisposable
    {
        private IObjectRef objectRef;
        public static UnsafeObjectRef Create(IObjectRef objectRef)
        {
            Validate.IsNotNull<IObjectRef>(objectRef, "objectRef");
            UnsafeObjectRef? nullable = TryCreate(objectRef);
            if (!nullable.HasValue)
            {
                ExceptionUtil.ThrowObjectDisposedException(objectRef.GetType().FullName);
            }
            return nullable.Value;
        }

        public static UnsafeObjectRef Create(RefTrackedObject objectRef)
        {
            Validate.IsNotNull<RefTrackedObject>(objectRef, "objectRef");
            UnsafeObjectRef? nullable = TryCreate(objectRef);
            if (!nullable.HasValue)
            {
                ExceptionUtil.ThrowObjectDisposedException(objectRef.GetType().FullName);
            }
            return nullable.Value;
        }

        public static UnsafeObjectRef? TryCreate(IObjectRef objectRef)
        {
            IObjectRef ref2;
            Validate.IsNotNull<IObjectRef>(objectRef, "objectRef");
            RefTrackedObject obj2 = objectRef as RefTrackedObject;
            if (obj2 != null)
            {
                return TryCreate(obj2);
            }
            if (objectRef.TryCreateRef(typeof(IObjectRef), out ref2).GetValueOrDefault())
            {
                return new UnsafeObjectRef(ref2);
            }
            return null;
        }

        public static UnsafeObjectRef? TryCreate(RefTrackedObject objectRef)
        {
            Validate.IsNotNull<RefTrackedObject>(objectRef, "objectRef");
            if (objectRef.TryAddUntrackedRef())
            {
                return new UnsafeObjectRef(objectRef);
            }
            return null;
        }

        private UnsafeObjectRef(IObjectRef objectRef)
        {
            this.objectRef = objectRef;
        }

        public void Dispose()
        {
            if (this.objectRef != null)
            {
                RefTrackedObject objectRef = this.objectRef as RefTrackedObject;
                if (objectRef != null)
                {
                    objectRef.ReleaseUntrackedRef(true);
                }
                else
                {
                    this.objectRef.Dispose();
                }
                this.objectRef = null;
            }
        }
    }
}

