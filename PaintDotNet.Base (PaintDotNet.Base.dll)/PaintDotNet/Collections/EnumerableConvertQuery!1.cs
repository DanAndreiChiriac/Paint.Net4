namespace PaintDotNet.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct EnumerableConvertQuery<T>
    {
        private IEnumerable<T> items;
        [IteratorStateMachine(typeof(<To>d__1))]
        public unsafe IEnumerable<TResult> To<TResult>() where TResult: struct, IConvertibleFrom<T> => 
            new <To>d__1<T, TResult>(-2) { <>3__<>4__this = *((EnumerableConvertQuery<T>*) this) };

        internal EnumerableConvertQuery(IEnumerable<T> items)
        {
            this.items = items;
        }
        [CompilerGenerated]
        private sealed class <To>d__1<TResult> : IEnumerable<TResult>, IEnumerable, IEnumerator<TResult>, IDisposable, IEnumerator where TResult: struct, IConvertibleFrom<T>
        {
            private int <>1__state;
            private TResult <>2__current;
            public EnumerableConvertQuery<T> <>3__<>4__this;
            public EnumerableConvertQuery<T> <>4__this;
            private IEnumerator<T> <>7__wrap1;
            private int <>l__initialThreadId;

            [DebuggerHidden]
            public <To>d__1(int <>1__state)
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
                        this.<>7__wrap1 = this.<>4__this.items.GetEnumerator();
                        this.<>1__state = -3;
                        while (this.<>7__wrap1.MoveNext())
                        {
                            T current = this.<>7__wrap1.Current;
                            TResult local2 = default(TResult);
                            local2.ConvertFrom(current);
                            this.<>2__current = local2;
                            this.<>1__state = 1;
                            return true;
                        Label_0070:
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
                    goto Label_0070;
                }
                fault
                {
                    this.System.IDisposable.Dispose();
                }
            }

            [DebuggerHidden]
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator()
            {
                EnumerableConvertQuery<T>.<To>d__1<TResult> d__;
                if ((this.<>1__state == -2) && (this.<>l__initialThreadId == Environment.CurrentManagedThreadId))
                {
                    this.<>1__state = 0;
                    d__ = (EnumerableConvertQuery<T>.<To>d__1<TResult>) this;
                }
                else
                {
                    d__ = new EnumerableConvertQuery<T>.<To>d__1<TResult>(0);
                }
                d__.<>4__this = this.<>3__<>4__this;
                return d__;
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator() => 
                this.System.Collections.Generic.IEnumerable<TResult>.GetEnumerator();

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

            TResult IEnumerator<TResult>.Current =>
                this.<>2__current;

            object IEnumerator.Current =>
                this.<>2__current;
        }
    }
}

