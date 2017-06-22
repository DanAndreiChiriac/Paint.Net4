namespace PaintDotNet.Collections
{
    using PaintDotNet.Rendering;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public static class EnumerableUtil
    {
        [IteratorStateMachine(typeof(<ForRange>d__2))]
        public static IEnumerable<T> ForRange<T>(T start, Func<T, bool> endPredicate, Func<T, T> incrementFn) => 
            new <ForRange>d__2<T>(-2) { 
                <>3__start = start,
                <>3__endPredicate = endPredicate,
                <>3__incrementFn = incrementFn
            };

        public static IEnumerable<T> One<T>(T head) => 
            new T[] { head };

        [IteratorStateMachine(typeof(<Range2D>d__1))]
        public static IEnumerable<PointInt32> Range2D(int startY, int yCount, int startX, int xCount) => 
            new <Range2D>d__1(-2) { 
                <>3__startY = startY,
                <>3__yCount = yCount,
                <>3__startX = startX,
                <>3__xCount = xCount
            };

        [CompilerGenerated]
        private sealed class <ForRange>d__2<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
        {
            private int <>1__state;
            private T <>2__current;
            public Func<T, bool> <>3__endPredicate;
            public Func<T, T> <>3__incrementFn;
            public T <>3__start;
            private int <>l__initialThreadId;
            private T <index>5__1;
            private Func<T, bool> endPredicate;
            private Func<T, T> incrementFn;
            private T start;

            [DebuggerHidden]
            public <ForRange>d__2(int <>1__state)
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
                    this.<index>5__1 = this.start;
                    while (this.endPredicate(this.<index>5__1))
                    {
                        this.<>2__current = this.<index>5__1;
                        this.<>1__state = 1;
                        return true;
                    Label_003A:
                        this.<>1__state = -1;
                        this.<index>5__1 = this.incrementFn(this.<index>5__1);
                    }
                    this.<index>5__1 = default(T);
                    return false;
                }
                if (num != 1)
                {
                    return false;
                }
                goto Label_003A;
            }

            [DebuggerHidden]
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                EnumerableUtil.<ForRange>d__2<T> d__;
                if ((this.<>1__state == -2) && (this.<>l__initialThreadId == Environment.CurrentManagedThreadId))
                {
                    this.<>1__state = 0;
                    d__ = (EnumerableUtil.<ForRange>d__2<T>) this;
                }
                else
                {
                    d__ = new EnumerableUtil.<ForRange>d__2<T>(0);
                }
                d__.start = this.<>3__start;
                d__.endPredicate = this.<>3__endPredicate;
                d__.incrementFn = this.<>3__incrementFn;
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

        [CompilerGenerated]
        private sealed class <Range2D>d__1 : IEnumerable<PointInt32>, IEnumerable, IEnumerator<PointInt32>, IDisposable, IEnumerator
        {
            private int <>1__state;
            private PointInt32 <>2__current;
            public int <>3__startX;
            public int <>3__startY;
            public int <>3__xCount;
            public int <>3__yCount;
            private int <>l__initialThreadId;
            private int <x>5__2;
            private int <y>5__1;
            private int startX;
            private int startY;
            private int xCount;
            private int yCount;

            [DebuggerHidden]
            public <Range2D>d__1(int <>1__state)
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
                    this.<y>5__1 = this.startY;
                    while (this.<y>5__1 < (this.startY + this.yCount))
                    {
                        int num2;
                        this.<x>5__2 = this.startX;
                        while (this.<x>5__2 < (this.startX + this.xCount))
                        {
                            this.<>2__current = new PointInt32(this.<x>5__2, this.<y>5__1);
                            this.<>1__state = 1;
                            return true;
                        Label_0053:
                            this.<>1__state = -1;
                            num2 = this.<x>5__2 + 1;
                            this.<x>5__2 = num2;
                        }
                        num2 = this.<y>5__1 + 1;
                        this.<y>5__1 = num2;
                    }
                    return false;
                }
                if (num != 1)
                {
                    return false;
                }
                goto Label_0053;
            }

            [DebuggerHidden]
            IEnumerator<PointInt32> IEnumerable<PointInt32>.GetEnumerator()
            {
                EnumerableUtil.<Range2D>d__1 d__;
                if ((this.<>1__state == -2) && (this.<>l__initialThreadId == Environment.CurrentManagedThreadId))
                {
                    this.<>1__state = 0;
                    d__ = this;
                }
                else
                {
                    d__ = new EnumerableUtil.<Range2D>d__1(0);
                }
                d__.startY = this.<>3__startY;
                d__.yCount = this.<>3__yCount;
                d__.startX = this.<>3__startX;
                d__.xCount = this.<>3__xCount;
                return d__;
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator() => 
                this.System.Collections.Generic.IEnumerable<PaintDotNet.Rendering.PointInt32>.GetEnumerator();

            [DebuggerHidden]
            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            [DebuggerHidden]
            void IDisposable.Dispose()
            {
            }

            PointInt32 IEnumerator<PointInt32>.Current =>
                this.<>2__current;

            object IEnumerator.Current =>
                this.<>2__current;
        }
    }
}

