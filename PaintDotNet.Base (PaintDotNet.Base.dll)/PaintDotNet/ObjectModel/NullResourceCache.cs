namespace PaintDotNet.ObjectModel
{
    using PaintDotNet.Collections;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;

    public sealed class NullResourceCache : RefTrackedObject, IResourceCache, IServiceProvider
    {
        private List<IDisposable> cleanupObjects;
        private List<KeyValuePair<Type, IObjectRef>> services;
        private readonly object sync;

        internal NullResourceCache()
        {
            this.sync = new object();
            this.OnConstructing();
            this.OnConstructed();
        }

        public NullResourceCache(IEnumerable<KeyValuePair<Type, IObjectRef>> services)
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
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                object sync = this.sync;
                lock (sync)
                {
                    this.services = null;
                    if (this.cleanupObjects != null)
                    {
                        using (List<IDisposable>.Enumerator enumerator = this.cleanupObjects.GetEnumerator())
                        {
                            while (enumerator.MoveNext())
                            {
                                enumerator.Current.Dispose();
                            }
                        }
                        this.cleanupObjects = null;
                    }
                }
            }
            base.Dispose(disposing);
        }

        public IObjectRef GetCachedOrCreateResource(IResourceSource resourceSource, Type interfaceType)
        {
            Validate.IsNotNull<IResourceSource>(resourceSource, "resourceSource");
            if (resourceSource.IsResource)
            {
                return GetRef((IObjectRef) resourceSource, interfaceType, false);
            }
            return resourceSource.CreateResource(this);
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
        }

        private void OnConstructing()
        {
            this.services = new List<KeyValuePair<Type, IObjectRef>>();
            this.services.Add(KeyValuePairUtil.Create<Type, IObjectRef>(typeof(IResourceCache), this));
        }

        public IObjectRef TryGetCachedResource(IResourceSource resourceSource, Type interfaceType) => 
            null;

        public bool SupportsResourceCaching =>
            true;
    }
}

