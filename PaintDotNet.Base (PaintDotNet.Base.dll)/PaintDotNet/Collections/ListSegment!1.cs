namespace PaintDotNet.Collections
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public sealed class ListSegment<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>
    {
        private static readonly EqualityComparer<T> comparer;
        private readonly int length;
        private readonly IList<T> source;
        private readonly int startIndex;

        static ListSegment()
        {
            ListSegment<T>.comparer = EqualityComparer<T>.Default;
        }

        public ListSegment(IList<T> source, int startIndex, int length)
        {
            Validate.Begin().IsNotNull<IList<T>>(source, "source").Check().IsRangeValid(source.Count, startIndex, length, "source").Check();
            this.source = source;
            this.startIndex = startIndex;
            this.length = length;
        }

        public void Add(T item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(T item) => 
            (this.IndexOf(item) != -1);

        public void CopyTo(T[] array, int arrayIndex)
        {
            Validate.Begin().IsNotNull<T[]>(array, "array").Check().IsRangeValid(this.length, 0, array.Length, "this").Check();
            for (int i = 0; i < this.length; i++)
            {
                array[arrayIndex + i] = this[i];
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int FromSourceIndex(int index) => 
            (index - this.startIndex);

        [IteratorStateMachine(typeof(<GetEnumerator>d__22))]
        public IEnumerator<T> GetEnumerator() => 
            new <GetEnumerator>d__22<T>(0) { <>4__this = (ListSegment<T>) this };

        public int IndexOf(T item)
        {
            for (int i = this.startIndex; i < (this.startIndex + this.length); i++)
            {
                if (ListSegment<T>.comparer.Equals(item, this.source[i]))
                {
                    return (i - this.startIndex);
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            throw new NotSupportedException();
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int ToSourceIndex(int index) => 
            (index + this.startIndex);

        public int Count =>
            this.length;

        public bool IsReadOnly =>
            true;

        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.source[this.ToSourceIndex(index)];
            set
            {
                throw new NotSupportedException();
            }
        }

        [CompilerGenerated]
        private sealed class <GetEnumerator>d__22 : IEnumerator<T>, IDisposable, IEnumerator
        {
            private int <>1__state;
            private T <>2__current;
            public ListSegment<T> <>4__this;
            private int <i>5__1;

            [DebuggerHidden]
            public <GetEnumerator>d__22(int <>1__state)
            {
                this.<>1__state = <>1__state;
            }

            private bool MoveNext()
            {
                int num = this.<>1__state;
                if (num == 0)
                {
                    this.<>1__state = -1;
                    this.<i>5__1 = this.<>4__this.startIndex;
                    while (this.<i>5__1 < (this.<>4__this.startIndex + this.<>4__this.length))
                    {
                        this.<>2__current = this.<>4__this.source[this.<i>5__1];
                        this.<>1__state = 1;
                        return true;
                    Label_004F:
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
                goto Label_004F;
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
    }
}

