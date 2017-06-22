namespace PaintDotNet.ComponentModel
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Threading;

    [Serializable]
    public class ObjectRefProxy : IObjectRef, IDisposable, IIsDisposed, IObjectRefProxy, ICleanupContainer, ISerializable, IDeserializationCallback
    {
        private static bool canRegister = true;
        private RefTrackedObject cleanupContainer;
        private const string cleanupContainerName = "cleanupContainer";
        private static readonly Func<Type, ObjectRefProxyFactory> createProxyFactory = new Func<Type, ObjectRefProxyFactory>(ObjectRefProxy.CreateProxyFactory);
        private static readonly ConcurrentDictionary<Type, ObjectRefProxyFactory> dynamicInterfaceTypeToProxyFactoryMap = new ConcurrentDictionary<Type, ObjectRefProxyFactory>();
        private IObjectRef innerRef;
        private const string innerRefName = "innerRef";
        private int isDisposed;
        private const string isDisposedName = "isDisposed";
        private ObjectRefProxyOptions proxyOptions;
        private const string proxyOptionsName = "proxyOptions";
        private static readonly Dictionary<Type, ObjectRefProxyFactory> staticInterfaceTypeToProxyFactoryMap = new Dictionary<Type, ObjectRefProxyFactory>(200);
        private static readonly Dictionary<Type, Type> staticInterfaceTypeToProxyFactoryTypeMap = new Dictionary<Type, Type>();

        public ObjectRefProxy(IObjectRef innerRef, ObjectRefProxyOptions proxyOptions)
        {
            Validate.IsNotNull<IObjectRef>(innerRef, "innerRef");
            this.InnerRef = innerRef;
            this.proxyOptions = proxyOptions;
            this.Initialize(true);
        }

        protected ObjectRefProxy(SerializationInfo info, StreamingContext context)
        {
            bool flag;
            if (!info.TryGetValue<bool>("isDisposed", out flag))
            {
                flag = false;
            }
            this.isDisposed = flag ? 1 : 0;
            this.InnerRef = info.GetValue<IObjectRef>("innerRef");
            this.proxyOptions = info.GetValue<ObjectRefProxyOptions>("proxyOptions");
            info.TryGetValue<RefTrackedObject>("cleanupContainer", out this.cleanupContainer);
        }

        public void AddCleanupObject(IDisposable cleanupObject)
        {
            Validate.IsNotNull<IDisposable>(cleanupObject, "cleanupObject");
            if (this.innerRef.IsNullReference<IObjectRef>())
            {
                ExceptionUtil.ThrowObjectDisposedException(base.GetType().Name);
            }
            ObjectRefProxy proxy = this;
            lock (proxy)
            {
                this.EnsureCleanupContainerCreatedWhileLocked();
                this.cleanupContainer.AddCleanupObject(cleanupObject);
            }
        }

        public static void CloseRegistration()
        {
            if (!canRegister)
            {
                ExceptionUtil.ThrowInvalidOperationException();
            }
            canRegister = false;
        }

        public static ObjectRefProxy Create(Type interfaceType, IObjectRef objectRef, ObjectRefProxyOptions proxyOptions)
        {
            Validate.Begin().IsNotNull<Type>(interfaceType, "interfaceType").IsNotNull<IObjectRef>(objectRef, "objectRef").Check();
            if (interfaceType.ContainsGenericParameters)
            {
                ExceptionUtil.ThrowArgumentException($"Only closed generic interface types are allowed (interfaceType = '{interfaceType.FullName}')");
            }
            if (interfaceType == typeof(IObjectRef))
            {
                return new ObjectRefProxy(objectRef, proxyOptions);
            }
            ObjectRefProxyFactory orAdd = null;
            if (!staticInterfaceTypeToProxyFactoryMap.TryGetValue(interfaceType, out orAdd) && !dynamicInterfaceTypeToProxyFactoryMap.TryGetValue(interfaceType, out orAdd))
            {
                orAdd = dynamicInterfaceTypeToProxyFactoryMap.GetOrAdd(interfaceType, createProxyFactory);
                if (orAdd.IsNullReference<ObjectRefProxyFactory>())
                {
                    ExceptionUtil.ThrowInvalidOperationException($"There is no proxy registered for '{interfaceType.FullName}'");
                }
            }
            return orAdd.CreateProxy(objectRef, proxyOptions);
        }

        private static ObjectRefProxyFactory CreateGenericProxyFactory(Type closedInterfaceType)
        {
            Type type2;
            Validate.IsNotNull<Type>(closedInterfaceType, "closedInterfaceType");
            Type genericTypeDefinition = closedInterfaceType.GetGenericTypeDefinition();
            if (!staticInterfaceTypeToProxyFactoryTypeMap.TryGetValue(genericTypeDefinition, out type2))
            {
                throw new KeyNotFoundException(closedInterfaceType.FullName + "(" + genericTypeDefinition.FullName + ")");
            }
            Type[] genericArguments = closedInterfaceType.GetGenericArguments();
            return (ObjectRefProxyFactory) Activator.CreateInstance(type2.MakeGenericType(genericArguments));
        }

        private static ObjectRefProxyFactory CreateProxyFactory(Type interfaceType)
        {
            Type type;
            Validate.IsNotNull<Type>(interfaceType, "interfaceType");
            if (interfaceType.IsGenericType)
            {
                return CreateGenericProxyFactory(interfaceType);
            }
            if (!staticInterfaceTypeToProxyFactoryTypeMap.TryGetValue(interfaceType, out type))
            {
                throw new KeyNotFoundException(interfaceType.FullName);
            }
            return (ObjectRefProxyFactory) Activator.CreateInstance(type);
        }

        public void Dispose()
        {
            if ((this.proxyOptions & ObjectRefProxyOptions.ProhibitDispose) == ObjectRefProxyOptions.ProhibitDispose)
            {
                throw new InvalidOperationException("This object may not be disposed");
            }
            this.DisposeCore(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        private void DisposeCore(bool disposing)
        {
            if (Interlocked.Exchange(ref this.isDisposed, 1) == 0)
            {
                try
                {
                    this.Dispose(disposing);
                }
                finally
                {
                    IObjectRef innerRef = this.innerRef;
                    this.InnerRef = null;
                    if ((this.proxyOptions & ObjectRefProxyOptions.DoNotCreateRef) != ObjectRefProxyOptions.DoNotCreateRef)
                    {
                        IRefTrackedObject obj2 = innerRef as IRefTrackedObject;
                        if (obj2 != null)
                        {
                            obj2.ReleaseRef(this, disposing);
                        }
                    }
                }
                if (disposing)
                {
                    RefTrackedObject cleanupContainer;
                    ObjectRefProxy proxy = this;
                    lock (proxy)
                    {
                        cleanupContainer = this.cleanupContainer;
                        this.cleanupContainer = null;
                    }
                    DisposableUtil.Free<RefTrackedObject>(ref cleanupContainer, disposing);
                }
            }
        }

        private void EnsureCleanupContainerCreatedWhileLocked()
        {
            if (this.cleanupContainer == null)
            {
                this.cleanupContainer = new RefTrackedObject();
            }
        }

        ~ObjectRefProxy()
        {
            this.DisposeCore(false);
        }

        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            bool isDisposed = this.IsDisposed;
            if (isDisposed)
            {
                info.AddValue("isDisposed", isDisposed);
            }
            info.AddValue("innerRef", this.innerRef, typeof(IObjectRef));
            if (this.cleanupContainer != null)
            {
                info.AddValue("cleanupContainer", this.cleanupContainer, typeof(RefTrackedObject));
            }
            info.AddValue("proxyOptions", EnumUtil.GetBoxed<ObjectRefProxyOptions>(this.proxyOptions), typeof(ObjectRefProxyOptions));
        }

        private void Initialize(bool constructing)
        {
            if ((this.proxyOptions & ObjectRefProxyOptions.DoNotCreateRef) != ObjectRefProxyOptions.DoNotCreateRef)
            {
                IRefTrackedObject innerRef = this.innerRef as IRefTrackedObject;
                if (!innerRef.IsNullReference<IRefTrackedObject>())
                {
                    innerRef.AddRef<IRefTrackedObject>(this);
                }
                else if (constructing)
                {
                    this.AddCleanupRef(this.innerRef);
                }
            }
            if (constructing && ((this.proxyOptions & ObjectRefProxyOptions.DisposeInnerRef) == ObjectRefProxyOptions.DisposeInnerRef))
            {
                this.AddCleanupObject(this.innerRef);
            }
        }

        protected virtual void OnDeserializedGraph(object sender)
        {
            this.Initialize(false);
        }

        internal virtual void OnInnerRefSet(IObjectRef innerRef)
        {
        }

        public static void Register(Type interfaceType, ObjectRefProxyFactory proxyFactory)
        {
            Validate.Begin().IsNotNull<Type>(interfaceType, "interfaceType").IsNotNull<ObjectRefProxyFactory>(proxyFactory, "proxyFactory").Check();
            if (!canRegister)
            {
                ExceptionUtil.ThrowInvalidOperationException("proxy registration has been closed");
            }
            if (staticInterfaceTypeToProxyFactoryMap.ContainsKey(interfaceType))
            {
                if (staticInterfaceTypeToProxyFactoryMap[interfaceType] == proxyFactory)
                {
                    return;
                }
                ExceptionUtil.ThrowArgumentException($"A proxy for '{interfaceType.FullName}' has already been registered with a different proxyFactory instance");
            }
            staticInterfaceTypeToProxyFactoryMap.Add(interfaceType, proxyFactory);
        }

        public static void Register(Type interfaceType, Type proxyFactoryType)
        {
            Validate.Begin().IsNotNull<Type>(interfaceType, "interfaceType").IsNotNull<Type>(proxyFactoryType, "proxyFactoryType").Check();
            if (!canRegister)
            {
                ExceptionUtil.ThrowInvalidOperationException("proxy registration has been closed");
            }
            if (staticInterfaceTypeToProxyFactoryTypeMap.ContainsKey(interfaceType))
            {
                if (staticInterfaceTypeToProxyFactoryTypeMap[interfaceType] == proxyFactoryType)
                {
                    return;
                }
                ExceptionUtil.ThrowArgumentException($"A proxy for {interfaceType.FullName} has already been registered with a different proxyFactoryType");
            }
            if (interfaceType.ContainsGenericParameters)
            {
                if (!interfaceType.ContainsGenericParameters || !interfaceType.ContainsGenericParameters)
                {
                    ExceptionUtil.ThrowArgumentException($"Open generic types must be supplied ({interfaceType.FullName}, {interfaceType.FullName})");
                }
                if (interfaceType.GetGenericArguments().Length != interfaceType.GetGenericArguments().Length)
                {
                    ExceptionUtil.ThrowArgumentException($"'{interfaceType.FullName}' has a different number of generic type arguments than '{interfaceType.FullName}'");
                }
            }
            staticInterfaceTypeToProxyFactoryTypeMap.Add(interfaceType, proxyFactoryType);
        }

        void IDeserializationCallback.OnDeserialization(object sender)
        {
            this.OnDeserializedGraph(sender);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            this.GetObjectData(info, context);
        }

        public bool? TryCreateRef(Type interfaceType, out IObjectRef newObjectRef)
        {
            RefTrackedObject cleanupContainer;
            Validate.IsNotNull<Type>(interfaceType, "interfaceType");
            IObjectRef innerRef = this.innerRef;
            if (innerRef == null)
            {
                newObjectRef = null;
                return null;
            }
            bool? nullable = innerRef.TryCreateRef(interfaceType, out newObjectRef);
            if (!nullable.GetValueOrDefault())
            {
                return null;
            }
            ObjectRefProxy proxy = this;
            lock (proxy)
            {
                this.EnsureCleanupContainerCreatedWhileLocked();
                cleanupContainer = this.cleanupContainer;
            }
            ICleanupContainer container = newObjectRef as ICleanupContainer;
            if (container == null)
            {
                ObjectRefProxy proxy2 = Create(interfaceType, newObjectRef, ObjectRefProxyOptions.AssumeOwnership);
                proxy2.AddCleanupRef(cleanupContainer);
                newObjectRef = proxy2;
                return nullable;
            }
            container.AddCleanupRef(cleanupContainer);
            return nullable;
        }

        public IObjectRef InnerRef
        {
            get => 
                this.innerRef;
            private set
            {
                this.innerRef = value;
                this.OnInnerRefSet(value);
            }
        }

        public bool IsDisposed =>
            (this.isDisposed > 0);

        public ObjectRefProxyOptions ProxyOptions =>
            this.proxyOptions;
    }
}

