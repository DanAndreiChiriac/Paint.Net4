namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public static class EnumeratorUtil
    {
        public static IEnumerator<T> Concat<T>(this IEnumerator<T> head, IEnumerator<T> tail)
        {
            Validate.Begin().IsNotNull<IEnumerator<T>>(head, "head").IsNotNull<IEnumerator<T>>(tail, "tail").Check();
            return ConcatImpl<T>(head, tail);
        }

        [IteratorStateMachine(typeof(<ConcatImpl>d__1))]
        private static IEnumerator<T> ConcatImpl<T>(IEnumerator<T> head, IEnumerator<T> tail)
        {
        Label_PostSwitchInIterator:;
            if (head.MoveNext())
            {
                yield return head.Current;
                goto Label_PostSwitchInIterator;
            }
            while (tail.MoveNext())
            {
                yield return tail.Current;
            }
        }

        public static IEnumerator<T> Empty<T>() => 
            EmptyEnumerator<T>.Instance;

        [CompilerGenerated]
        private sealed class <ConcatImpl>d__1<T> : IEnumerator<T>, IDisposable, IEnumerator
        {
            private int <>1__state;
            private T <>2__current;
            public IEnumerator<T> head;
            public IEnumerator<T> tail;

            [DebuggerHidden]
            public <ConcatImpl>d__1(int <>1__state)
            {
                this.<>1__state = <>1__state;
            }

            private bool MoveNext()
            {
                switch (this.<>1__state)
                {
                    case 0:
                        this.<>1__state = -1;
                        break;

                    case 1:
                        this.<>1__state = -1;
                        break;

                    case 2:
                        goto Label_006E;

                    default:
                        return false;
                }
                if (this.head.MoveNext())
                {
                    this.<>2__current = this.head.Current;
                    this.<>1__state = 1;
                    return true;
                }
                while (this.tail.MoveNext())
                {
                    this.<>2__current = this.tail.Current;
                    this.<>1__state = 2;
                    return true;
                Label_006E:
                    this.<>1__state = -1;
                }
                return false;
            }

            [DebuggerHidden]
            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            [DebuggerHidden]
            void IDisposable.Dispose()
            {
            }

            T IEnumerator<T>.Current =>
                this.<>2__current;

            object IEnumerator.Current =>
                this.<>2__current;
        }

        private sealed class EmptyEnumerator<T> : IEnumerator<T>, IDisposable, IEnumerator
        {
            private static readonly EnumeratorUtil.EmptyEnumerator<T> instance;

            static EmptyEnumerator()
            {
                EnumeratorUtil.EmptyEnumerator<T>.instance = new EnumeratorUtil.EmptyEnumerator<T>();
            }

            public void Dispose()
            {
            }

            public bool MoveNext() => 
                false;

            public void Reset()
            {
                throw new NotSupportedException();
            }

            public T Current
            {
                get
                {
                    ExceptionUtil.ThrowInvalidOperationException();
                    return default(T);
                }
            }

            public static IEnumerator<T> Instance =>
                EnumeratorUtil.EmptyEnumerator<T>.instance;

            object IEnumerator.Current
            {
                get
                {
                    ExceptionUtil.ThrowInvalidOperationException();
                    return null;
                }
            }
        }
    }
}

