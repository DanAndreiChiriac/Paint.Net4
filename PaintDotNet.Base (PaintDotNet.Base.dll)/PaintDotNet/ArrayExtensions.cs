namespace PaintDotNet
{
    using PaintDotNet.Collections;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public static class ArrayExtensions
    {
        public static ArrayStruct<T> AsStruct<T>(this T[] array) => 
            new ArrayStruct<T>(array);

        public static T[] CloneT<T>(this T[] array)
        {
            T[] destinationArray = new T[array.Length];
            Array.Copy(array, destinationArray, (long) array.Length);
            return destinationArray;
        }

        public static IEnumerable<T> Range<T>(this T[] array, int start, int length)
        {
            Validate.Begin().IsNotNull<T[]>(array, "array").IsIndexInBounds<T>(array, start, "start").IsIndexInBounds<T>(array, ((start + length) - 1), "start + length - 1").Check();
            return RangeImpl<T>(array, start, length);
        }

        [IteratorStateMachine(typeof(<RangeImpl>d__3))]
        private static IEnumerable<T> RangeImpl<T>(T[] array, int start, int length) => 
            new <RangeImpl>d__3<T>(-2) { 
                <>3__array = array,
                <>3__start = start,
                <>3__length = length
            };

        [CompilerGenerated]
        private sealed class <RangeImpl>d__3<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
        {
            private int <>1__state;
            private T <>2__current;
            public T[] <>3__array;
            public int <>3__length;
            public int <>3__start;
            private int <>l__initialThreadId;
            private int <i>5__1;
            private T[] array;
            private int length;
            private int start;

            [DebuggerHidden]
            public <RangeImpl>d__3(int <>1__state)
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
                    this.<i>5__1 = this.start;
                    while (this.<i>5__1 < (this.start + this.length))
                    {
                        this.<>2__current = this.array[this.<i>5__1];
                        this.<>1__state = 1;
                        return true;
                    Label_0045:
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
                goto Label_0045;
            }

            [DebuggerHidden]
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                ArrayExtensions.<RangeImpl>d__3<T> d__;
                if ((this.<>1__state == -2) && (this.<>l__initialThreadId == Environment.CurrentManagedThreadId))
                {
                    this.<>1__state = 0;
                    d__ = (ArrayExtensions.<RangeImpl>d__3<T>) this;
                }
                else
                {
                    d__ = new ArrayExtensions.<RangeImpl>d__3<T>(0);
                }
                d__.array = this.<>3__array;
                d__.start = this.<>3__start;
                d__.length = this.<>3__length;
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

