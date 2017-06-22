namespace PaintDotNet.ComponentModel
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;

    [Serializable]
    public class RefTrackedObject : IObjectRef, IDisposable, IIsDisposed, IRefTrackedObject, IObjectRefContainer, ICleanupContainer, ISerializable
    {
        private object attachedObjectRefs;
        private const string attachedObjectRefsName = "attachedObjectRefs";
        private object cleanupObjects;
        private const string cleanupObjectsName = "cleanupObjects";
        private bool isPrimaryRefDisposed;
        private const string isPrimaryRefDisposedName = "isPrimaryRefDisposed";
        private int refCount;

        public RefTrackedObject()
        {
            this.refCount = 1;
            this.isPrimaryRefDisposed = false;
        }

        protected RefTrackedObject(SerializationInfo info, StreamingContext context)
        {
            if (!info.TryGetValue<bool>("isPrimaryRefDisposed", out this.isPrimaryRefDisposed))
            {
                this.isPrimaryRefDisposed = false;
            }
            this.refCount = this.isPrimaryRefDisposed ? 0 : 1;
            info.TryGetValue<object>("cleanupObjects", out this.cleanupObjects);
            info.TryGetValue<object>("attachedObjectRefs", out this.attachedObjectRefs);
        }

        public void AddCleanupObject(IDisposable cleanupObject)
        {
            this.AddUntrackedRef();
            try
            {
                object sync = this.Sync;
                lock (sync)
                {
                    if (this.cleanupObjects == null)
                    {
                        this.cleanupObjects = cleanupObject;
                    }
                    else
                    {
                        List<IDisposable> cleanupObjects = this.cleanupObjects as List<IDisposable>;
                        if (cleanupObjects != null)
                        {
                            cleanupObjects.Add(cleanupObject);
                        }
                        else
                        {
                            List<IDisposable> list2 = new List<IDisposable>(2) {
                                (IDisposable) this.cleanupObjects,
                                cleanupObject
                            };
                            this.cleanupObjects = list2;
                        }
                    }
                }
            }
            finally
            {
                this.ReleaseUntrackedRef(true);
            }
        }

        internal int AddRef(object refOwner)
        {
            int num;
            if (!this.TryAddRef(refOwner, out num))
            {
                ExceptionUtil.ThrowObjectDisposedException(base.GetType().FullName);
            }
            return num;
        }

        internal int AddUntrackedRef()
        {
            int num;
            if (!this.TryAddUntrackedRef(out num))
            {
                ExceptionUtil.ThrowObjectDisposedException(base.GetType().FullName);
            }
            return num;
        }

        protected bool CheckAccess() => 
            !this.IsDisposed;

        private int DecrementRefCountWhileLocked(out bool dispose)
        {
            if (this.refCount == 0)
            {
                ExceptionUtil.ThrowInvalidOperationException("Unbalanced reference count");
                dispose = false;
            }
            else if (this.refCount > 0)
            {
                if ((this.refCount == 1) && !this.isPrimaryRefDisposed)
                {
                    ExceptionUtil.ThrowInternalErrorException("this.refCount is about to be decremented to 0, but this.isPrimaryRefDisposed is false");
                }
                this.refCount--;
            }
            else
            {
                this.refCount++;
            }
            dispose = this.refCount == 0;
            return this.refCount;
        }

        public void Dispose()
        {
            bool flag = false;
            object sync = this.Sync;
            lock (sync)
            {
                if (!this.isPrimaryRefDisposed)
                {
                    this.isPrimaryRefDisposed = true;
                    flag = true;
                }
            }
            if (flag)
            {
                this.ReleaseRef(this, true);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        private void DisposeCore(bool disposing)
        {
            this.Dispose(disposing);
            if (disposing)
            {
                object attachedObjectRefs;
                object cleanupObjects;
                object sync = this.Sync;
                lock (sync)
                {
                    cleanupObjects = this.cleanupObjects;
                    this.cleanupObjects = null;
                    attachedObjectRefs = this.attachedObjectRefs;
                    this.attachedObjectRefs = null;
                }
                if (attachedObjectRefs != null)
                {
                    List<KeyValuePair<object, IObjectRef>> list = attachedObjectRefs as List<KeyValuePair<object, IObjectRef>>;
                    if (list != null)
                    {
                        foreach (KeyValuePair<object, IObjectRef> pair in list)
                        {
                            pair.Value.Dispose();
                        }
                    }
                    else
                    {
                        KeyValuePair<object, IObjectRef> pair2 = (KeyValuePair<object, IObjectRef>) attachedObjectRefs;
                        pair2.Value.Dispose();
                    }
                }
                if (cleanupObjects != null)
                {
                    List<IDisposable> list2 = cleanupObjects as List<IDisposable>;
                    if (list2 != null)
                    {
                        using (List<IDisposable>.Enumerator enumerator2 = list2.GetEnumerator())
                        {
                            while (enumerator2.MoveNext())
                            {
                                enumerator2.Current.Dispose();
                            }
                            return;
                        }
                    }
                    ((IDisposable) cleanupObjects).Dispose();
                }
            }
        }

        public sealed override bool Equals(object obj) => 
            base.Equals(obj);

        private void FinalDisposeIf(bool dispose, bool disposing)
        {
            if (dispose)
            {
                this.DisposeCore(disposing);
                if (disposing)
                {
                    GC.SuppressFinalize(this);
                }
            }
        }

        ~RefTrackedObject()
        {
            object sync = this.Sync;
            lock (sync)
            {
                if (!this.isPrimaryRefDisposed)
                {
                    int refCount = this.refCount;
                    this.isPrimaryRefDisposed = true;
                    this.refCount--;
                }
                this.refCount = -this.refCount;
            }
            this.DisposeCore(false);
        }

        public sealed override int GetHashCode() => 
            base.GetHashCode();

        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (this.isPrimaryRefDisposed)
            {
                info.AddValue("isPrimaryRefDisposed", this.isPrimaryRefDisposed);
            }
            if (this.cleanupObjects != null)
            {
                info.AddValue("cleanupObjects", this.cleanupObjects);
            }
            if (this.attachedObjectRefs != null)
            {
                info.AddValue("attachedObjectRefs", this.attachedObjectRefs);
            }
        }

        int IRefTrackedObject.ReleaseRef(object refOwner, bool disposing) => 
            this.ReleaseRef(refOwner, disposing);

        bool IRefTrackedObject.TryAddRef(object refOwner, out int newRefCount) => 
            this.TryAddRef(refOwner, out newRefCount);

        internal int ReleaseRef(object refOwner, bool disposing)
        {
            int num;
            bool flag;
            Validate.IsNotNull<object>(refOwner, "refOwner");
            object sync = this.Sync;
            lock (sync)
            {
                num = this.DecrementRefCountWhileLocked(out flag);
                if ((num <= 0) && !this.isPrimaryRefDisposed)
                {
                    ExceptionUtil.ThrowInternalErrorException("newRefCount <= 0 && !this.isPrimaryRefDisposed");
                }
            }
            this.FinalDisposeIf(flag, disposing);
            return num;
        }

        internal int ReleaseUntrackedRef(bool disposing)
        {
            int num;
            bool flag;
            object sync = this.Sync;
            lock (sync)
            {
                num = this.DecrementRefCountWhileLocked(out flag);
            }
            this.FinalDisposeIf(flag, disposing);
            return num;
        }

        [Conditional("PRINT_LIFETIME_STATS")]
        private static void ReportConstruction(Type type)
        {
        }

        [Conditional("DEBUG")]
        private static void ReportFinalization(Type type)
        {
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            this.GetObjectData(info, context);
        }

        internal bool TryAddRef(object refOwner)
        {
            int num;
            return this.TryAddRef(refOwner, out num);
        }

        internal bool TryAddRef(object refOwner, out int newRefCount)
        {
            Validate.IsNotNull<object>(refOwner, "refOwner");
            object sync = this.Sync;
            lock (sync)
            {
                int refCount = this.refCount;
                if (this.refCount <= 0)
                {
                    newRefCount = 0;
                    return false;
                }
                this.refCount++;
                newRefCount = this.refCount;
                return true;
            }
        }

        internal bool TryAddUntrackedRef()
        {
            int num;
            return this.TryAddUntrackedRef(out num);
        }

        internal bool TryAddUntrackedRef(out int newRefCount)
        {
            object sync = this.Sync;
            lock (sync)
            {
                if (this.refCount <= 0)
                {
                    newRefCount = 0;
                    return false;
                }
                this.refCount++;
                newRefCount = this.refCount;
                return true;
            }
        }

        public bool TryAttachObjectRef(object key, IObjectRef objectRef)
        {
            bool flag3;
            Validate.Begin().IsNotNull<object>(key, "key").IsNotNull<IObjectRef>(objectRef, "objectRef").Check();
            if ((key is KeyValuePair<object, IObjectRef>) || (key is List<KeyValuePair<object, IObjectRef>>))
            {
                ExceptionUtil.ThrowArgumentException($"{key.GetType().Name} is a disallowed key type");
            }
            IObjectRef ref2 = objectRef.CreateRef();
            bool flag = false;
            KeyValuePair<object, IObjectRef> item = new KeyValuePair<object, IObjectRef>(key, ref2);
            try
            {
                object sync = this.Sync;
                lock (sync)
                {
                    if (this.attachedObjectRefs == null)
                    {
                        this.attachedObjectRefs = item;
                        return true;
                    }
                    List<KeyValuePair<object, IObjectRef>> attachedObjectRefs = this.attachedObjectRefs as List<KeyValuePair<object, IObjectRef>>;
                    if (attachedObjectRefs != null)
                    {
                        foreach (KeyValuePair<object, IObjectRef> pair2 in attachedObjectRefs)
                        {
                            if (pair2.Key.Equals(key))
                            {
                                flag = true;
                                return false;
                            }
                        }
                        attachedObjectRefs.Add(item);
                        return true;
                    }
                    KeyValuePair<object, IObjectRef> pair3 = (KeyValuePair<object, IObjectRef>) this.attachedObjectRefs;
                    if (pair3.Key.Equals(key))
                    {
                        flag = true;
                        return false;
                    }
                    List<KeyValuePair<object, IObjectRef>> list2 = new List<KeyValuePair<object, IObjectRef>>(2) {
                        pair3,
                        item
                    };
                    this.attachedObjectRefs = list2;
                    flag3 = true;
                }
            }
            finally
            {
                if (flag)
                {
                    ref2.Dispose();
                }
            }
            return flag3;
        }

        protected virtual IObjectRefProxy TryCreateProxy(Type interfaceType, ObjectRefProxyOptions proxyOptions)
        {
            if (!typeof(IObjectRefProxy).IsAssignableFrom(interfaceType) && interfaceType.IsAssignableFrom(base.GetType()))
            {
                return ObjectRefProxy.Create(interfaceType, this, proxyOptions);
            }
            return null;
        }

        public bool? TryCreateRef(Type interfaceType, out IObjectRef newObjectRef)
        {
            Validate.IsNotNull<Type>(interfaceType, "interfaceType");
            if (!this.TryAddUntrackedRef())
            {
                newObjectRef = null;
                return null;
            }
            try
            {
                newObjectRef = this.TryCreateProxy(interfaceType, ObjectRefProxyOptions.Default);
                if (newObjectRef == null)
                {
                    return false;
                }
            }
            finally
            {
                this.ReleaseUntrackedRef(true);
            }
            return true;
        }

        public bool? TryGetAttachedObjectRef(object key, Type interfaceType, out IObjectRef newObjectRef)
        {
            Validate.IsNotNull<object>(key, "key");
            IObjectRef ref2 = null;
            object sync = this.Sync;
            lock (sync)
            {
                if (this.attachedObjectRefs == null)
                {
                    newObjectRef = null;
                    return false;
                }
                List<KeyValuePair<object, IObjectRef>> attachedObjectRefs = this.attachedObjectRefs as List<KeyValuePair<object, IObjectRef>>;
                if (attachedObjectRefs != null)
                {
                    foreach (KeyValuePair<object, IObjectRef> pair in attachedObjectRefs)
                    {
                        if (pair.Key.Equals(key))
                        {
                            ref2 = pair.Value;
                            goto Label_00BB;
                        }
                    }
                }
                else
                {
                    KeyValuePair<object, IObjectRef> pair2 = (KeyValuePair<object, IObjectRef>) this.attachedObjectRefs;
                    if (pair2.Key.Equals(key))
                    {
                        ref2 = pair2.Value;
                    }
                }
            }
        Label_00BB:
            if (ref2 != null)
            {
                return ref2.TryCreateRef(interfaceType, out newObjectRef).GetValueOrDefault();
            }
            newObjectRef = null;
            return false;
        }

        [Conditional("ENABLE_REF_TRACKING")]
        private void UntrackRefWhileLocked(object refOwner)
        {
        }

        protected void VerifyAccess()
        {
            if (!this.CheckAccess())
            {
                ExceptionUtil.ThrowObjectDisposedException(base.GetType().Name);
            }
        }

        public bool IsDisposed =>
            (this.refCount <= 0);

        public static bool IsFullRefTrackingEnabled =>
            false;

        internal object Sync =>
            this;
    }
}

