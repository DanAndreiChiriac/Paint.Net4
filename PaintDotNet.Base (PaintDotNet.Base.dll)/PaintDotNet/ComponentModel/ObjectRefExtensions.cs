namespace PaintDotNet.ComponentModel
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class ObjectRefExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IObjectRef CreateRef(this IObjectRef objectRef) => 
            objectRef.CreateRef(typeof(IObjectRef));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TInterface CreateRef<TInterface>(this IObjectRef objectRef) where TInterface: class, IObjectRef => 
            ((TInterface) objectRef.CreateRef(typeof(TInterface)));

        public static IObjectRef CreateRef(this IObjectRef objectRef, Type interfaceType)
        {
            IObjectRef ref2;
            bool? nullable = objectRef.TryCreateRef(interfaceType, out ref2);
            if (!nullable.HasValue)
            {
                throw new ObjectDisposedException(objectRef.GetType().FullName);
            }
            if (!nullable.Value)
            {
                throw new InterfaceNotSupportedException(interfaceType);
            }
            return ref2;
        }

        public static IObjectRef GetInnermostRef(this IObjectRef objectRef)
        {
            Validate.IsNotNull<IObjectRef>(objectRef, "objectRef");
            while (true)
            {
                IObjectRefProxy proxy = objectRef as IObjectRefProxy;
                if (proxy == null)
                {
                    return objectRef;
                }
                objectRef = proxy.InnerRef;
            }
        }

        public static bool InnermostRefEquals(this IObjectRef objectRef1, IObjectRef objectRef2) => 
            ((objectRef1 == objectRef2) || (((objectRef1 != null) && (objectRef2 != null)) && (objectRef1.GetInnermostRef() == objectRef2.GetInnermostRef())));

        public static CastOrRefHolder<T> TryCastOrCreateRef<T>(this IObjectRef objectRef) where T: class, IObjectRef
        {
            T objectRefT = objectRef as T;
            if (objectRefT != null)
            {
                return new CastOrRefHolder<T>(objectRefT, false);
            }
            T local2 = objectRef.TryCreateRef<T>();
            if (local2 != null)
            {
                return new CastOrRefHolder<T>(local2, true);
            }
            return new CastOrRefHolder<T>();
        }

        public static TInterface TryCreateRef<TInterface>(this IObjectRef objectRef) where TInterface: class, IObjectRef
        {
            TInterface local;
            if (!objectRef.TryCreateRef<TInterface>(out local).GetValueOrDefault())
            {
                return default(TInterface);
            }
            return local;
        }

        public static bool? TryCreateRef<TInterface>(this IObjectRef objectRef, out TInterface newObjectRefT) where TInterface: class, IObjectRef
        {
            IObjectRef ref2;
            Validate.IsNotNull<IObjectRef>(objectRef, "objectRef");
            bool? nullable = objectRef.TryCreateRef(typeof(TInterface), out ref2);
            if (!nullable.GetValueOrDefault())
            {
                newObjectRefT = default(TInterface);
                return nullable;
            }
            newObjectRefT = (TInterface) ref2;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnsafeObjectRef? TryUseUnsafeRef(this IObjectRef objectRef) => 
            UnsafeObjectRef.TryCreate(objectRef);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnsafeObjectRef UseUnsafeRef(this IObjectRef objectRef) => 
            UnsafeObjectRef.Create(objectRef);
    }
}

