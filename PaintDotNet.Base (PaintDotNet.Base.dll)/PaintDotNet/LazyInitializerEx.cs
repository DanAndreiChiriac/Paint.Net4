namespace PaintDotNet
{
    using System;
    using System.Runtime.InteropServices;
    using System.Threading;

    public class LazyInitializerEx
    {
        public static T EnsureInitialized<T>(ref T target, Func<T> valueFactory) where T: class => 
            LazyInitializer.EnsureInitialized<T>(ref target, valueFactory);

        public static T EnsureInitialized<T>(ref T target, Func<T> valueFactory, out T unusedValue) where T: class
        {
            if (((T) target) != null)
            {
                unusedValue = default(T);
                return target;
            }
            T local = valueFactory();
            if (local == null)
            {
                ExceptionUtil.ThrowInvalidOperationException("valueFactory may not return null");
            }
            T local2 = Interlocked.CompareExchange<T>(ref target, local, default(T));
            if (local2 == null)
            {
                unusedValue = default(T);
                return local;
            }
            unusedValue = local;
            return local2;
        }

        public static T EnsureInitialized<T, TContext>(ref T target, TContext context, Func<TContext, T> valueFactory) where T: class
        {
            if (((T) target) != null)
            {
                return target;
            }
            T local = valueFactory(context);
            Interlocked.CompareExchange<T>(ref target, local, default(T));
            return local;
        }

        public static T EnsureInitialized<T, TContext>(ref T target, TContext context, Func<TContext, T> valueFactory, out T unusedValue) where T: class
        {
            if (((T) target) != null)
            {
                unusedValue = default(T);
                return target;
            }
            T local = valueFactory(context);
            if (local == null)
            {
                ExceptionUtil.ThrowInvalidOperationException("valueFactory may not return null");
            }
            T local2 = Interlocked.CompareExchange<T>(ref target, local, default(T));
            if (local2 == null)
            {
                unusedValue = default(T);
                return local;
            }
            unusedValue = local;
            return local2;
        }

        public static T EnsureInitializedClean<T>(ref T target, Func<T> valueFactory) where T: class, IDisposable
        {
            T local;
            T introduced1 = EnsureInitialized<T>(ref target, valueFactory, out local);
            DisposableUtil.Free<T>(ref local);
            return introduced1;
        }

        public static T EnsureInitializedClean<T, TContext>(ref T target, TContext context, Func<TContext, T> valueFactory) where T: class, IDisposable
        {
            T local;
            T introduced1 = EnsureInitialized<T, TContext>(ref target, context, valueFactory, out local);
            DisposableUtil.Free<T>(ref local);
            return introduced1;
        }
    }
}

