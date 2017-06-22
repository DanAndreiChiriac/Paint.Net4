namespace PaintDotNet.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public static class ConcurrentQueueExtensions
    {
        public static bool Any<T>(this ConcurrentQueue<T> queue) => 
            (queue.Count > 0);

        public static IEnumerable<T> DequeueAll<T>(this ConcurrentQueue<T> queue) => 
            queue.DequeueMany<T>(queue.Count);

        [IteratorStateMachine(typeof(<DequeueMany>d__3))]
        public static IEnumerable<T> DequeueMany<T>(this ConcurrentQueue<T> queue, int maxCount) => 
            new <DequeueMany>d__3<T>(-2) { 
                <>3__queue = queue,
                <>3__maxCount = maxCount
            };

        public static int EnqueueRange<T, TEnumerable>(this ConcurrentQueue<T> queue, TEnumerable items) where TEnumerable: IEnumerable<T>
        {
            int num = 0;
            foreach (T local in items)
            {
                queue.Enqueue(local);
                num++;
            }
            return num;
        }

        [CompilerGenerated]
        private sealed class <DequeueMany>d__3<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
        {
            private int <>1__state;
            private T <>2__current;
            public int <>3__maxCount;
            public ConcurrentQueue<T> <>3__queue;
            private int <>l__initialThreadId;
            private int <i>5__1;
            private int maxCount;
            private ConcurrentQueue<T> queue;

            [DebuggerHidden]
            public <DequeueMany>d__3(int <>1__state)
            {
                this.<>1__state = <>1__state;
                this.<>l__initialThreadId = Environment.CurrentManagedThreadId;
            }

            private bool MoveNext()
            {
                int num = this.<>1__state;
                if (num == 0)
                {
                    this.<>1__state = -1;
                    this.<i>5__1 = 0;
                    while (this.<i>5__1 < this.maxCount)
                    {
                        T local;
                        if (!this.queue.TryDequeue(out local))
                        {
                            return false;
                        }
                        this.<>2__current = local;
                        this.<>1__state = 1;
                        return true;
                    Label_003F:
                        this.<>1__state = -1;
                        int num2 = this.<i>5__1 + 1;
                        this.<i>5__1 = num2;
                    }
                    return false;
                }
                if (num != 1)
                {
                    return false;
                }
                goto Label_003F;
            }

            [DebuggerHidden]
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                ConcurrentQueueExtensions.<DequeueMany>d__3<T> d__;
                if ((this.<>1__state == -2) && (this.<>l__initialThreadId == Environment.CurrentManagedThreadId))
                {
                    this.<>1__state = 0;
                    d__ = (ConcurrentQueueExtensions.<DequeueMany>d__3<T>) this;
                }
                else
                {
                    d__ = new ConcurrentQueueExtensions.<DequeueMany>d__3<T>(0);
                }
                d__.queue = this.<>3__queue;
                d__.maxCount = this.<>3__maxCount;
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
            }

            T IEnumerator<T>.Current =>
                this.<>2__current;

            object IEnumerator.Current =>
                this.<>2__current;
        }
    }
}

