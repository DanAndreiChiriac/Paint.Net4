namespace PaintDotNet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public static class WeakReferenceExtensions
    {
        public static T FirstTargetOrDefault<T>(this IEnumerable<WeakReferenceT<T>> weakItems, T target) where T: class
        {
            if (target != null)
            {
                using (IEnumerator<WeakReferenceT<T>> enumerator = weakItems.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        T local2 = enumerator.Current.Target;
                        if ((local2 != null) && (local2 == target))
                        {
                            return local2;
                        }
                    }
                }
            }
            return default(T);
        }

        public static int RemoveFinalizedTargets<T>(this IList<WeakReferenceT<T>> weakItems) where T: class
        {
            int num = 0;
            for (int i = weakItems.Count - 1; i >= 0; i--)
            {
                if (weakItems[i].Target == null)
                {
                    weakItems.RemoveAt(i);
                    num++;
                }
            }
            return num;
        }

        [IteratorStateMachine(typeof(<SelectLiveTargets>d__1))]
        public static IEnumerable<T> SelectLiveTargets<T>(this IEnumerable<WeakReferenceT<T>> weakItems) where T: class => 
            new <SelectLiveTargets>d__1<T>(-2) { <>3__weakItems = weakItems };

        [IteratorStateMachine(typeof(<SelectTargets>d__0))]
        public static IEnumerable<T> SelectTargets<T>(this IEnumerable<WeakReferenceT<T>> weakItems) where T: class => 
            new <SelectTargets>d__0<T>(-2) { <>3__weakItems = weakItems };

        [CompilerGenerated]
        private sealed class <SelectLiveTargets>d__1<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator where T: class
        {
            private int <>1__state;
            private T <>2__current;
            public IEnumerable<WeakReferenceT<T>> <>3__weakItems;
            private IEnumerator<WeakReferenceT<T>> <>7__wrap1;
            private int <>l__initialThreadId;
            private IEnumerable<WeakReferenceT<T>> weakItems;

            [DebuggerHidden]
            public <SelectLiveTargets>d__1(int <>1__state)
            {
                this.<>1__state = <>1__state;
                this.<>l__initialThreadId = Environment.CurrentManagedThreadId;
            }

            private void <>m__Finally1()
            {
                this.<>1__state = -1;
                if (this.<>7__wrap1 != null)
                {
                    this.<>7__wrap1.Dispose();
                }
            }

            private bool MoveNext()
            {
                try
                {
                    int num = this.<>1__state;
                    if (num == 0)
                    {
                        this.<>1__state = -1;
                        this.<>7__wrap1 = this.weakItems.GetEnumerator();
                        this.<>1__state = -3;
                        while (this.<>7__wrap1.MoveNext())
                        {
                            T target = this.<>7__wrap1.Current.Target;
                            if (target == null)
                            {
                                continue;
                            }
                            this.<>2__current = target;
                            this.<>1__state = 1;
                            return true;
                        Label_005F:
                            this.<>1__state = -3;
                        }
                        this.<>m__Finally1();
                        this.<>7__wrap1 = null;
                        return false;
                    }
                    if (num != 1)
                    {
                        return false;
                    }
                    goto Label_005F;
                }
                fault
                {
                    this.System.IDisposable.Dispose();
                }
            }

            [DebuggerHidden]
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                WeakReferenceExtensions.<SelectLiveTargets>d__1<T> d__;
                if ((this.<>1__state == -2) && (this.<>l__initialThreadId == Environment.CurrentManagedThreadId))
                {
                    this.<>1__state = 0;
                    d__ = (WeakReferenceExtensions.<SelectLiveTargets>d__1<T>) this;
                }
                else
                {
                    d__ = new WeakReferenceExtensions.<SelectLiveTargets>d__1<T>(0);
                }
                d__.weakItems = this.<>3__weakItems;
                return d__;
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator() => 
                this.System.Collections.Generic.IEnumerable<T>.GetEnumerator();

            [DebuggerHidden]
            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            [DebuggerHidden]
            void IDisposable.Dispose()
            {
                switch (this.<>1__state)
                {
                    case -3:
                    case 1:
                        try
                        {
                        }
                        finally
                        {
                            this.<>m__Finally1();
                        }
                        break;
                }
            }

            T IEnumerator<T>.Current =>
                this.<>2__current;

            object IEnumerator.Current =>
                this.<>2__current;
        }

        [CompilerGenerated]
        private sealed class <SelectTargets>d__0<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator where T: class
        {
            private int <>1__state;
            private T <>2__current;
            public IEnumerable<WeakReferenceT<T>> <>3__weakItems;
            private IEnumerator<WeakReferenceT<T>> <>7__wrap1;
            private int <>l__initialThreadId;
            private IEnumerable<WeakReferenceT<T>> weakItems;

            [DebuggerHidden]
            public <SelectTargets>d__0(int <>1__state)
            {
                this.<>1__state = <>1__state;
                this.<>l__initialThreadId = Environment.CurrentManagedThreadId;
            }

            private void <>m__Finally1()
            {
                this.<>1__state = -1;
                if (this.<>7__wrap1 != null)
                {
                    this.<>7__wrap1.Dispose();
                }
            }

            private bool MoveNext()
            {
                try
                {
                    int num = this.<>1__state;
                    if (num == 0)
                    {
                        this.<>1__state = -1;
                        this.<>7__wrap1 = this.weakItems.GetEnumerator();
                        this.<>1__state = -3;
                        while (this.<>7__wrap1.MoveNext())
                        {
                            T target = this.<>7__wrap1.Current.Target;
                            this.<>2__current = target;
                            this.<>1__state = 1;
                            return true;
                        Label_0057:
                            this.<>1__state = -3;
                        }
                        this.<>m__Finally1();
                        this.<>7__wrap1 = null;
                        return false;
                    }
                    if (num != 1)
                    {
                        return false;
                    }
                    goto Label_0057;
                }
                fault
                {
                    this.System.IDisposable.Dispose();
                }
            }

            [DebuggerHidden]
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                WeakReferenceExtensions.<SelectTargets>d__0<T> d__;
                if ((this.<>1__state == -2) && (this.<>l__initialThreadId == Environment.CurrentManagedThreadId))
                {
                    this.<>1__state = 0;
                    d__ = (WeakReferenceExtensions.<SelectTargets>d__0<T>) this;
                }
                else
                {
                    d__ = new WeakReferenceExtensions.<SelectTargets>d__0<T>(0);
                }
                d__.weakItems = this.<>3__weakItems;
                return d__;
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator() => 
                this.System.Collections.Generic.IEnumerable<T>.GetEnumerator();

            [DebuggerHidden]
            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            [DebuggerHidden]
            void IDisposable.Dispose()
            {
                switch (this.<>1__state)
                {
                    case -3:
                    case 1:
                        try
                        {
                        }
                        finally
                        {
                            this.<>m__Finally1();
                        }
                        break;
                }
            }

            T IEnumerator<T>.Current =>
                this.<>2__current;

            object IEnumerator.Current =>
                this.<>2__current;
        }
    }
}

