namespace PaintDotNet.ObjectModel
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    internal sealed class ResourceCache : RefTrackedObject, IResourceCache, IServiceProvider
    {
        private List<IDisposable> cleanupObjects;
        private Dictionary<TupleStruct<ResourceID, long>, IObjectRef>[] genCaches;
        private List<KeyValuePair<Type, IObjectRef>> services;
        private readonly object sync;

        internal ResourceCache()
        {
            this.sync = new object();
            this.OnConstructing();
            this.OnConstructed();
        }

        public ResourceCache(IEnumerable<KeyValuePair<Type, IObjectRef>> services)
        {
            this.sync = new object();
            this.OnConstructing();
            foreach (KeyValuePair<Type, IObjectRef> pair in services)
            {
                this.AddService(pair.Key, pair.Value);
            }
            this.OnConstructed();
        }

        internal void AddService(Type serviceType, IObjectRef service)
        {
            Validate.Begin().IsNotNull<Type>(serviceType, "serviceType").IsNotNull<IObjectRef>(service, "service").Check();
            object sync = this.sync;
            lock (sync)
            {
                this.services.Add(KeyValuePairUtil.Create<Type, IObjectRef>(serviceType, service));
            }
        }

        public void Collect()
        {
            object sync = this.sync;
            lock (sync)
            {
                Dictionary<TupleStruct<ResourceID, long>, IObjectRef> dictionary = this.genCaches.Last<Dictionary<TupleStruct<ResourceID, long>, IObjectRef>>();
                foreach (KeyValuePair<TupleStruct<ResourceID, long>, IObjectRef> pair in dictionary)
                {
                    pair.Value.Dispose();
                }
                dictionary.Clear();
                for (int i = this.genCaches.Length - 1; i > 0; i--)
                {
                    this.genCaches[i] = this.genCaches[i - 1];
                }
                this.genCaches[0] = dictionary;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                object sync = this.sync;
                lock (sync)
                {
                    Dictionary<TupleStruct<ResourceID, long>, IObjectRef>[] genCaches = this.genCaches;
                    for (int i = 0; i < genCaches.Length; i++)
                    {
                        using (Dictionary<TupleStruct<ResourceID, long>, IObjectRef>.ValueCollection.Enumerator enumerator = genCaches[i].Values.GetEnumerator())
                        {
                            while (enumerator.MoveNext())
                            {
                                enumerator.Current.Dispose();
                            }
                        }
                    }
                    this.genCaches = null;
                    this.services = null;
                    if (this.cleanupObjects != null)
                    {
                        using (List<IDisposable>.Enumerator enumerator2 = this.cleanupObjects.GetEnumerator())
                        {
                            while (enumerator2.MoveNext())
                            {
                                enumerator2.Current.Dispose();
                            }
                        }
                        this.cleanupObjects = null;
                    }
                }
            }
            base.Dispose(disposing);
        }

        public IObjectRef GetCachedOrCreateResource(IResourceSource resourceSource, Type interfaceType) => 
            this.GetCachedOrCreateResource(resourceSource, interfaceType, false);

        private IObjectRef GetCachedOrCreateResource(IResourceSource resourceSource, Type interfaceType, bool addRef = true)
        {
            object obj2;
            IObjectRef ref3;
            Validate.IsNotNull<IResourceSource>(resourceSource, "resourceSource");
            if (resourceSource.IsResource)
            {
                return GetRef((IObjectRef) resourceSource, interfaceType, addRef);
            }
            TupleStruct<ResourceID, long> resourceKey = TupleStruct.Create<ResourceID, long>(resourceSource.ResourceID, resourceSource.Version);
        Label_0036:
            obj2 = this.sync;
            lock (obj2)
            {
                IObjectRef objectRef = this.TryGetCachedResourceImpl(resourceKey, interfaceType, addRef);
                if (objectRef != null)
                {
                    return GetRef(objectRef, interfaceType, addRef);
                }
                objectRef = resourceSource.CreateResource(this);
                if (this.genCaches[0].TryAdd<TupleStruct<ResourceID, long>, IObjectRef>(resourceKey, objectRef))
                {
                    ref3 = GetRef(objectRef, interfaceType, addRef);
                }
                else
                {
                    objectRef.Dispose();
                    goto Label_0036;
                }
            }
            return ref3;
        }

        private static IObjectRef GetRef(IObjectRef objectRef, Type interfaceType, bool addRef)
        {
            if (!addRef)
            {
                return objectRef;
            }
            return objectRef.CreateRef(interfaceType);
        }

        public object GetService(Type serviceType)
        {
            Validate.IsNotNull<Type>(serviceType, "serviceType");
            object sync = this.sync;
            lock (sync)
            {
                foreach (KeyValuePair<Type, IObjectRef> pair in this.services)
                {
                    if (pair.Key == serviceType)
                    {
                        return pair.Value;
                    }
                }
                foreach (KeyValuePair<Type, IObjectRef> pair2 in this.services)
                {
                    if (serviceType.IsAssignableFrom(pair2.Value.GetType()))
                    {
                        return pair2.Value;
                    }
                }
                if (typeof(IObjectRef).IsAssignableFrom(serviceType) && serviceType.IsInterface)
                {
                    foreach (KeyValuePair<Type, IObjectRef> pair3 in this.services)
                    {
                        IObjectRef ref2;
                        if (pair3.Value.TryCreateRef(serviceType, out ref2).GetValueOrDefault())
                        {
                            this.services.Add(KeyValuePairUtil.Create<Type, IObjectRef>(serviceType, ref2));
                            this.cleanupObjects = this.cleanupObjects ?? new List<IDisposable>();
                            this.cleanupObjects.Add(ref2);
                            return ref2;
                        }
                    }
                }
            }
            throw new KeyNotFoundException(serviceType.FullName);
        }

        private void OnConstructed()
        {
            this.genCaches = new Dictionary<TupleStruct<ResourceID, long>, IObjectRef>[6];
            for (int i = 0; i < this.genCaches.Length; i++)
            {
                this.genCaches[i] = new Dictionary<TupleStruct<ResourceID, long>, IObjectRef>();
            }
        }

        private void OnConstructing()
        {
            this.services = new List<KeyValuePair<Type, IObjectRef>>();
            this.services.Add(KeyValuePairUtil.Create<Type, IObjectRef>(typeof(IResourceCache), this));
        }

        public IObjectRef TryGetCachedResource(IResourceSource resourceSource, Type interfaceType) => 
            this.TryGetCachedResource(resourceSource, interfaceType, false);

        private IObjectRef TryGetCachedResource(IResourceSource resourceSource, Type interfaceType, bool addRef = true)
        {
            Validate.IsNotNull<IResourceSource>(resourceSource, "resourceSource");
            if (resourceSource.IsResource)
            {
                return null;
            }
            TupleStruct<ResourceID, long> resourceKey = TupleStruct.Create<ResourceID, long>(resourceSource.ResourceID, resourceSource.Version);
            return this.TryGetCachedResourceImpl(resourceKey, interfaceType, addRef);
        }

        private IObjectRef TryGetCachedResourceImpl(TupleStruct<ResourceID, long> resourceKey, Type interfaceType, bool addRef)
        {
            object sync = this.sync;
            lock (sync)
            {
                IObjectRef ref2;
                if (this.genCaches[0].TryGetValue(resourceKey, out ref2))
                {
                    return GetRef(ref2, interfaceType, addRef);
                }
                for (int i = 1; i < this.genCaches.Length; i++)
                {
                    IObjectRef ref4;
                    if (this.genCaches[i].TryRemove<TupleStruct<ResourceID, long>, IObjectRef>(resourceKey, out ref4))
                    {
                        if (this.genCaches[0].TryAdd<TupleStruct<ResourceID, long>, IObjectRef>(resourceKey, ref4))
                        {
                            return GetRef(ref4, interfaceType, addRef);
                        }
                        ref4.Dispose();
                    }
                }
                return null;
            }
        }

        public bool SupportsResourceCaching =>
            true;
    }
}

