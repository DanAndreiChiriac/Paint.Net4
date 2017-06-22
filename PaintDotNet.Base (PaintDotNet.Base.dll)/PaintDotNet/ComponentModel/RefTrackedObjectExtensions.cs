namespace PaintDotNet.ComponentModel
{
    using PaintDotNet;
    using System;
    using System.Runtime.CompilerServices;

    internal static class RefTrackedObjectExtensions
    {
        public static int AddRef<T>(this T objectRef, object refOwner) where T: IRefTrackedObject
        {
            int num;
            if (!objectRef.TryAddRef(refOwner, out num))
            {
                ExceptionUtil.ThrowObjectDisposedException(objectRef.GetType().FullName);
            }
            return num;
        }

        public static UnsafeObjectRef? TryUseUnsafeRef(this RefTrackedObject objectRef) => 
            UnsafeObjectRef.TryCreate(objectRef);

        public static UnsafeObjectRef UseUnsafeRef(this RefTrackedObject objectRef) => 
            UnsafeObjectRef.Create(objectRef);
    }
}

