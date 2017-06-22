namespace PaintDotNet.ComponentModel
{
    using PaintDotNet;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;

    public static class ObjectRefContainerExtensions
    {
        public static TInterface GetOrAttachObjectRef<TInterface>(this IObjectRefContainer container, object key, Func<TInterface> valueFactory) where TInterface: class, IObjectRef
        {
            int num = 0;
            while (num < 100)
            {
                IObjectRef ref2;
                bool? nullable = container.TryGetAttachedObjectRef(key, typeof(TInterface), out ref2);
                if (nullable.GetValueOrDefault())
                {
                    return (TInterface) ref2;
                }
                if (!nullable.HasValue)
                {
                    throw new InterfaceNotSupportedException(typeof(TInterface));
                }
                TInterface objectRef = valueFactory();
                if (container.TryAttachObjectRef(key, objectRef))
                {
                    return objectRef;
                }
                objectRef.Dispose();
                objectRef = default(TInterface);
                num++;
                Thread.Sleep(1);
            }
            throw new InternalErrorException();
        }

        public static bool? TryGetAttachedObjectRef<TInterface>(this IObjectRefContainer container, object key, out TInterface newObjectRef) where TInterface: class, IObjectRef
        {
            IObjectRef ref2;
            bool? nullable = container.TryGetAttachedObjectRef(key, typeof(TInterface), out ref2);
            newObjectRef = nullable.GetValueOrDefault() ? ((TInterface) ref2) : default(TInterface);
            return nullable;
        }
    }
}

