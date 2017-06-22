namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public sealed class SparseQueue<T> : ISegmentedCollection<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, ITrimExcess
    {
        private SparseList<T> _array;
        private int _head;
        private int _size;
        private int _tail;
        private int _version;
        private static readonly EqualityComparer<T> comparer;
        public const int DefaultSegmentLengthLog2 = 7;

        static SparseQueue()
        {
            SparseQueue<T>.comparer = EqualityComparer<T>.Default;
        }

        public SparseQueue() : this(0, 7)
        {
        }

        public SparseQueue(IEnumerable<T> items, int segmentLengthLog2 = 7) : this(0, segmentLengthLog2)
        {
            Validate.IsNotNull<IEnumerable<T>>(items, "items");
            ICollection<T> is2 = items as ICollection<T>;
            if (is2 != null)
            {
                this._array.Resize(this.RoundUpToSegmentBoundary(is2.Count));
            }
            foreach (T local in items)
            {
                this.Enqueue(local);
            }
        }

        public SparseQueue(int capacity, int segmentLengthLog2 = 7)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("Must be non-negative", "capacity");
            }
            if (segmentLengthLog2 < 0)
            {
                throw new ArgumentOutOfRangeException($"segmentLengthLog2={segmentLengthLog2.ToString()} but must be non-negative");
            }
            this._array = new SparseList<T>(segmentLengthLog2);
            this._array.Resize(this.RoundUpToSegmentBoundary(capacity));
        }

        public void Clear()
        {
            if (this._head != this._tail)
            {
                if (this._head < this._tail)
                {
                    this._array.Clear(this._head, this._size);
                }
                else
                {
                    this._array.Clear(this._head, this._array.Count - this._head);
                    this._array.Clear(0, this._tail);
                }
            }
            this._head = 0;
            this._tail = 0;
            this._size = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this._size; i++)
            {
                if (SparseQueue<T>.comparer.Equals(item, this.GetElement(i)))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Validate.Begin().IsNotNull<T[]>(array, "array").Check().IsNotNegative(arrayIndex, "arrayIndex").IsRangeValid(array.Length, arrayIndex, this.Count, "array").Check();
            int index = arrayIndex;
            foreach (T local in this)
            {
                array[index] = local;
                index++;
            }
        }

        public T Dequeue()
        {
            if (this._size == 0)
            {
                ExceptionUtil.ThrowInvalidOperationException("The queue is empty");
            }
            this._array[this._head] = default(T);
            this._head = (this._head + 1) % this._array.Count;
            this._size--;
            return this._array[this._head];
        }

        public void Enqueue(T item)
        {
            if (this._size == this._array.Count)
            {
                int newCapacity = this.Capacity + this._array.SegmentLength;
                this.SetCapacity(newCapacity);
            }
            this._array[this._tail] = item;
            this._tail = (this._tail + 1) % this._array.Count;
            this._size++;
        }

        public void EnsureCapacity(int newCapacity)
        {
            if (newCapacity > this.Capacity)
            {
                this.SetCapacity(newCapacity);
            }
        }

        internal T GetElement(int i) => 
            this._array[this.GetElementIndex(i)];

        private int GetElementIndex(int i) => 
            ((this._head + i) % this._array.Count);

        public Enumerator<T> GetEnumerator() => 
            new Enumerator<T>((SparseQueue<T>) this);

        public T Peek()
        {
            if (this._size == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            return this._array[this._head];
        }

        private int RoundUpToSegmentBoundary(int count) => 
            ((((count + this._array.SegmentLength) - 1) >> (this._array.SegmentLengthLog2 & 0x1f)) << this._array.SegmentLengthLog2);

        private void SetCapacity(int newCapacity)
        {
            if (newCapacity < this.Count)
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException();
            }
            if (newCapacity == 0)
            {
                this.Clear();
                this._array.Resize(0);
            }
            else if (this._size == 0)
            {
                this.Clear();
                this._array.Resize(this.RoundUpToSegmentBoundary(newCapacity));
            }
            else
            {
                if (this._head != 0)
                {
                    this._array.RotateToBeginning(this._head);
                    this._head = 0;
                }
                this._array.Resize(this.RoundUpToSegmentBoundary(newCapacity));
                this._tail = this._size % this._array.Count;
            }
            this._version++;
        }

        void ICollection<T>.Add(T item)
        {
            this.Enqueue(item);
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => 
            new Enumerator<T>((SparseQueue<T>) this);

        IEnumerator IEnumerable.GetEnumerator() => 
            new Enumerator<T>((SparseQueue<T>) this);

        public T[] ToArray() => 
            this.ToArrayEx<T>();

        public void TrimExcess()
        {
            this.SetCapacity(this.Count);
            this._array.TrimExcess();
        }

        public int Capacity =>
            this._array.Count;

        public int Count =>
            this._size;

        public bool IsReadOnly =>
            false;

        public int SegmentLength =>
            this._array.SegmentLength;

        public int SegmentLengthLog2 =>
            this._array.SegmentLengthLog2;

        [StructLayout(LayoutKind.Sequential)]
        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private SparseQueue<T> _q;
            private int _index;
            private int _version;
            private T _currentElement;
            internal Enumerator(SparseQueue<T> q)
            {
                this._q = q;
                this._version = this._q._version;
                this._index = -1;
                this._currentElement = default(T);
            }

            public void Dispose()
            {
                this._q = null;
                this._currentElement = default(T);
            }

            private void VerifyIsNotDisposed()
            {
                if (this._q == null)
                {
                    ExceptionUtil.ThrowObjectDisposedException(base.GetType().Name);
                }
            }

            public bool MoveNext()
            {
                this.VerifyIsNotDisposed();
                if (this._version != this._q._version)
                {
                    ExceptionUtil.ThrowInvalidOperationException("The collection changed");
                }
                if (this._index == -2)
                {
                    return false;
                }
                this._index++;
                if (this._index == this._q._size)
                {
                    this._index = -2;
                    this._currentElement = default(T);
                    return false;
                }
                this._currentElement = this._q.GetElement(this._index);
                return true;
            }

            public T Current =>
                this._currentElement;
            object IEnumerator.Current =>
                this.Current;
            void IEnumerator.Reset()
            {
                this._version = this._q._version;
                this._index = -1;
                this._currentElement = default(T);
            }
        }
    }
}

