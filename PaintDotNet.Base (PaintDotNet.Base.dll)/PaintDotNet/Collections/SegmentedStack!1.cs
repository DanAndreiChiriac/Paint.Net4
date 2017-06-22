namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public sealed class SegmentedStack<T> : ISegmentedCollection<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, ITrimExcess
    {
        public const int DefaultSegmentLengthLog2 = 7;
        private SegmentedList<T> list;

        public SegmentedStack() : this(0, 7)
        {
        }

        public SegmentedStack(IEnumerable<T> items, int segmentLengthLog2 = 7)
        {
            this.list = new SegmentedList<T>(items, segmentLengthLog2);
        }

        public SegmentedStack(int capacity, int segmentLengthLog2 = 7)
        {
            this.list = new SegmentedList<T>(capacity, segmentLengthLog2);
        }

        public bool Any() => 
            (this.list.Count > 0);

        public void Clear()
        {
            this.list.Clear();
        }

        public bool Contains(T item) => 
            this.list.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.list.CopyTo(array, arrayIndex);
        }

        public void EnsureCapacity(int capacity)
        {
            this.list.EnsureCapacity(capacity);
        }

        public Enumerator<T> GetEnumerator() => 
            new Enumerator<T>(this.list);

        public T Peek()
        {
            if (this.list.Any())
            {
                return this.list[this.list.Count - 1];
            }
            ExceptionUtil.ThrowInvalidOperationException();
            return default(T);
        }

        public T Pop()
        {
            if (this.list.Any())
            {
                int index = this.list.Count - 1;
                this.list.RemoveAt(index);
                return this.list[index];
            }
            ExceptionUtil.ThrowInvalidOperationException();
            return default(T);
        }

        public void Push(T item)
        {
            this.list.Add(item);
        }

        void ICollection<T>.Add(T item)
        {
            this.Push(item);
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => 
            this.list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            this.list.GetEnumerator();

        public void TrimExcess()
        {
            this.list.TrimExcess();
        }

        public int Capacity =>
            this.list.Capacity;

        public int Count =>
            this.list.Count;

        public bool IsReadOnly =>
            false;

        public int SegmentLength =>
            this.list.SegmentLength;

        public int SegmentLengthLog2 =>
            this.list.SegmentLengthLog2;

        [StructLayout(LayoutKind.Sequential)]
        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private SegmentedList<T>.Enumerator enumerator;
            public Enumerator(SegmentedList<T> source)
            {
                this.enumerator = source.GetEnumerator();
            }

            public T Current =>
                this.enumerator.Current;
            public void Dispose()
            {
                this.enumerator.Dispose();
            }

            object IEnumerator.Current =>
                this.Current;
            public bool MoveNext() => 
                this.enumerator.MoveNext();

            public void Reset()
            {
                this.enumerator.Reset();
            }
        }
    }
}

