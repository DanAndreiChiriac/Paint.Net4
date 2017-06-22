namespace PaintDotNet
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static class DisposableUtil
    {
        public static IDisposable Combine(IDisposable first, IDisposable second)
        {
            Validate.IsNotNull<IDisposable>(second, "second");
            if (first == null)
            {
                return second;
            }
            return Disposable.FromAction(delegate {
                first.Dispose();
                second.Dispose();
            }, false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Free<T>(ref T disposeMe) where T: class, IDisposable
        {
            if (((T) disposeMe) != null)
            {
                disposeMe.Dispose();
                disposeMe = default(T);
            }
        }

        public static void Free<T>(ref T disposeMe, bool callerIsNotFinalizing) where T: class, IDisposable
        {
            if (((T) disposeMe) != null)
            {
                if (callerIsNotFinalizing)
                {
                    disposeMe.Dispose();
                }
                disposeMe = default(T);
            }
        }

        public static void FreeContents<T>(T[] disposeUs) where T: class, IDisposable
        {
            if (disposeUs != null)
            {
                for (int i = 0; i < disposeUs.Length; i++)
                {
                    Free<T>(ref disposeUs[i]);
                }
            }
        }

        public static void FreeContents<T>(T[][] disposeUs2D) where T: class, IDisposable
        {
            if (disposeUs2D != null)
            {
                for (int i = 0; i < disposeUs2D.Length; i++)
                {
                    FreeContents<T>(disposeUs2D[i]);
                }
            }
        }

        public static void FreeContentsAndClear<TKey, TValue>(Dictionary<TKey, TValue> dictionary) where TValue: IDisposable
        {
            if (dictionary != null)
            {
                foreach (IDisposable disposable in dictionary.Values)
                {
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
                dictionary.Clear();
            }
        }

        public static void FreeContentsAndClear<T>(IList<T> disposeUs) where T: class, IDisposable
        {
            if (disposeUs != null)
            {
                foreach (T local in disposeUs)
                {
                    if (local != null)
                    {
                        local.Dispose();
                    }
                }
                disposeUs.Clear();
            }
        }

        public static bool FreeIfDisposable<T>(ref T target) where T: class
        {
            if (((T) target) != null)
            {
                IDisposable disposable = ((T) target) as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                    target = default(T);
                    return true;
                }
            }
            return false;
        }

        public static void VerifyNotDisposed<T>(ref T theObject) where T: struct, IIsDisposed
        {
            if (theObject.IsDisposed)
            {
                ExceptionUtil.ThrowObjectDisposedException<T>();
            }
        }
    }
}

