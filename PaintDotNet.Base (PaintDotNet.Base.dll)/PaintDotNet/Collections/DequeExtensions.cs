namespace PaintDotNet.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public static class DequeExtensions
    {
        public static bool Any<T>(this Deque<T> queue) => 
            (queue.Count > 0);

        public static int EnqueueRange<T>(this Deque<T> queue, IEnumerable<T> items) => 
            queue.EnqueueRange<T>(items, QueueSide.Back);

        public static int EnqueueRange<T>(this Deque<T> queue, IEnumerable<T> items, QueueSide queueSide)
        {
            int num = 0;
            foreach (T local in items)
            {
                queue.Enqueue(local, queueSide);
                num++;
            }
            return num;
        }

        [IteratorStateMachine(typeof(<Reverse>d__3))]
        public static IEnumerable<T> Reverse<T>(this Deque<T> queue) => 
            new <Reverse>d__3<T>(-2) { <>3__queue = queue };

        [CompilerGenerated]
        private sealed class <Reverse>d__3<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
        {
            private int <>1__state;
            private T <>2__current;
            public Deque<T> <>3__queue;
            private int <>l__initialThreadId;
            private IEnumerator<T> <reverseEnum>5__1;
            private Deque<T> queue;

            [DebuggerHidden]
            public <Reverse>d__3(int <>1__state)
            {
                this.<>1__state = <>1__state;
                this.<>l__initialThreadId = Environment.CurrentManagedThreadId;
            }

            private void <>m__Finally1()
            {
                this.<>1__state = -1;
                if (this.<reverseEnum>5__1 != null)
                {
                    this.<reverseEnum>5__1.Dispose();
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
                        this.<reverseEnum>5__1 = this.queue.GetReverseEnumerator();
                        this.<>1__state = -3;
                        while (this.<reverseEnum>5__1.MoveNext())
                        {
                            this.<>2__current = this.<reverseEnum>5__1.Current;
                            this.<>1__state = 1;
                            return true;
                        Label_0055:
                            this.<>1__state = -3;
                        }
                        this.<>m__Finally1();
                        this.<reverseEnum>5__1 = null;
                        return false;
                    }
                    if (num != 1)
                    {
                        return false;
                    }
                    goto Label_0055;
                }
                fault
                {
                    this.System.IDisposable.Dispose();
                }
            }

            [DebuggerHidden]
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                DequeExtensions.<Reverse>d__3<T> d__;
                if ((this.<>1__state == -2) && (this.<>l__initialThreadId == Environment.CurrentManagedThreadId))
                {
                    this.<>1__state = 0;
                    d__ = (DequeExtensions.<Reverse>d__3<T>) this;
                }
                else
                {
                    d__ = new DequeExtensions.<Reverse>d__3<T>(0);
                }
                d__.queue = this.<>3__queue;
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

