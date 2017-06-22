namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;

    public sealed class Deque<T> : IEnumerable<T>, IEnumerable, IToArray<T>, ITrimExcess, ICollection
    {
        private T[] _array;
        private const int _DefaultCapacity = 4;
        private const int _GrowFactor = 200;
        private int _head;
        private const int _MinimumGrow = 4;
        private const int _ShrinkThreshold = 0x20;
        private int _size;
        [NonSerialized]
        private object _syncRoot;
        private int _tail;
        private int _version;

        public Deque()
        {
            this._array = Array.Empty<T>();
        }

        public Deque(IEnumerable<T> collection)
        {
            Validate.IsNotNull<IEnumerable<T>>(collection, "collection");
            this._array = new T[4];
            this._size = 0;
            this._version = 0;
            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    this.Enqueue(enumerator.Current);
                }
            }
        }

        public Deque(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this._array = new T[capacity];
            this._head = 0;
            this._tail = 0;
            this._size = 0;
        }

        public void Clear()
        {
            if (this._head < this._tail)
            {
                Array.Clear(this._array, this._head, this._size);
            }
            else
            {
                Array.Clear(this._array, this._head, this._array.Length - this._head);
                Array.Clear(this._array, 0, this._tail);
            }
            this._head = 0;
            this._tail = 0;
            this._size = 0;
            this._version++;
        }

        public void ClearAndTrim()
        {
            this._array = Array.Empty<T>();
            this._head = 0;
            this._tail = 0;
            this._size = 0;
            this._version++;
        }

        public bool Contains(T item)
        {
            int index = this._head;
            int num2 = this._size;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            while (num2-- > 0)
            {
                if (item == null)
                {
                    if (this._array[index] == null)
                    {
                        return true;
                    }
                }
                else if ((this._array[index] != null) && comparer.Equals(this._array[index], item))
                {
                    return true;
                }
                index = (index + 1) % this._array.Length;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Validate.IsNotNull<T[]>(array, "array");
            if ((arrayIndex < 0) || (arrayIndex > array.Length))
            {
                throw new ArgumentOutOfRangeException("arrayIndex");
            }
            int length = array.Length;
            if ((length - arrayIndex) < this._size)
            {
                throw new ArgumentOutOfRangeException("arrayIndex(2)");
            }
            int num2 = ((length - arrayIndex) < this._size) ? (length - arrayIndex) : this._size;
            if (num2 != 0)
            {
                int num3 = ((this._array.Length - this._head) < num2) ? (this._array.Length - this._head) : num2;
                Array.Copy(this._array, this._head, array, arrayIndex, num3);
                num2 -= num3;
                if (num2 > 0)
                {
                    Array.Copy(this._array, 0, array, (arrayIndex + this._array.Length) - this._head, num2);
                }
            }
        }

        public T Dequeue()
        {
            if (this._size == 0)
            {
                ExceptionUtil.ThrowInvalidOperationException();
            }
            this._array[this._head] = default(T);
            this._head = (this._head + 1) % this._array.Length;
            this._size--;
            this._version++;
            return this._array[this._head];
        }

        public T Dequeue(QueueSide queueSide)
        {
            if (queueSide != QueueSide.Back)
            {
                if (queueSide == QueueSide.Front)
                {
                    return this.Dequeue();
                }
            }
            else
            {
                return this.DequeueBack();
            }
            ExceptionUtil.ThrowInvalidEnumArgumentException<QueueSide>(queueSide, "queueSide");
            return default(T);
        }

        public T DequeueBack()
        {
            if (this._size == 0)
            {
                ExceptionUtil.ThrowInvalidOperationException();
            }
            int index = ((this._tail - 1) + this._array.Length) % this._array.Length;
            this._array[index] = default(T);
            this._tail = index;
            this._size--;
            this._version++;
            return this._array[index];
        }

        public void Enqueue(T item)
        {
            this.GrowCapacityIfNecessary();
            this._array[this._tail] = item;
            this._tail = (this._tail + 1) % this._array.Length;
            this._size++;
            this._version++;
        }

        public void Enqueue(T item, QueueSide queueSide)
        {
            if (queueSide != QueueSide.Back)
            {
                if (queueSide == QueueSide.Front)
                {
                    this.EnqueueFront(item);
                }
                else
                {
                    ExceptionUtil.ThrowInvalidEnumArgumentException<QueueSide>(queueSide, "queueSide");
                }
            }
            else
            {
                this.Enqueue(item);
            }
        }

        public void EnqueueFront(T item)
        {
            this.GrowCapacityIfNecessary();
            this._head = ((this._head - 1) + this._array.Length) % this._array.Length;
            this._array[this._head] = item;
            this._size++;
            this._version++;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal T GetElement(int i)
        {
            int elementOffset = this.GetElementOffset(i);
            return this._array[elementOffset];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal int GetElementOffset(int index) => 
            ((this._head + index) % this._array.Length);

        public Enumerator<T> GetEnumerator() => 
            new Enumerator<T>((Deque<T>) this);

        public IEnumerator<T> GetEnumerator(QueueSide side)
        {
            if (side == QueueSide.Front)
            {
                return this.GetEnumerator();
            }
            return this.GetReverseEnumerator();
        }

        public ReverseEnumerator<T> GetReverseEnumerator() => 
            new ReverseEnumerator<T>((Deque<T>) this);

        private void GrowCapacityIfNecessary()
        {
            if (this._size == this._array.Length)
            {
                int capacity = (int) (((long) (this._array.Length * 200)) / 100L);
                if (capacity < (this._array.Length + 4))
                {
                    capacity = this._array.Length + 4;
                }
                this.SetCapacity(capacity);
            }
        }

        public T Peek()
        {
            if (this._size == 0)
            {
                ExceptionUtil.ThrowInvalidOperationException();
            }
            return this.PeekUnchecked();
        }

        public T Peek(QueueSide queueSide)
        {
            if (queueSide != QueueSide.Back)
            {
                if (queueSide == QueueSide.Front)
                {
                    return this.Peek();
                }
            }
            else
            {
                return this.PeekBack();
            }
            ExceptionUtil.ThrowInvalidEnumArgumentException<QueueSide>(queueSide, "queueSide");
            return default(T);
        }

        public T Peek(int index)
        {
            if (index >= this._size)
            {
                ExceptionUtil.ThrowInvalidOperationException();
            }
            return this.PeekUnchecked(index);
        }

        public T Peek(QueueSide queueSide, int index)
        {
            if (queueSide != QueueSide.Back)
            {
                if (queueSide == QueueSide.Front)
                {
                    return this.Peek(index);
                }
            }
            else
            {
                return this.PeekBack(index);
            }
            ExceptionUtil.ThrowInvalidEnumArgumentException<QueueSide>(queueSide, "queueSide");
            return default(T);
        }

        public T PeekBack() => 
            this.PeekBack(0);

        public T PeekBack(int index)
        {
            if (index >= this._size)
            {
                ExceptionUtil.ThrowInvalidOperationException();
            }
            return this.PeekBackUnchecked(index);
        }

        public T PeekBackUnchecked() => 
            this.PeekBackUnchecked(0);

        public T PeekBackUnchecked(int index)
        {
            int num = (((this._tail - 1) - index) + (this._array.Length * 2)) % this._array.Length;
            return this._array[num];
        }

        public T PeekUnchecked() => 
            this._array[this._head];

        public T PeekUnchecked(QueueSide queueSide)
        {
            if (queueSide != QueueSide.Back)
            {
                if (queueSide == QueueSide.Front)
                {
                    return this.PeekUnchecked();
                }
            }
            else
            {
                return this.PeekBackUnchecked();
            }
            ExceptionUtil.ThrowInvalidEnumArgumentException<QueueSide>(queueSide, "queueSide");
            return default(T);
        }

        public T PeekUnchecked(int index)
        {
            int elementOffset = this.GetElementOffset(index);
            return this._array[elementOffset];
        }

        public T PeekUnchecked(QueueSide queueSide, int index)
        {
            if (queueSide != QueueSide.Back)
            {
                if (queueSide == QueueSide.Front)
                {
                    return this.PeekUnchecked(index);
                }
            }
            else
            {
                return this.PeekBackUnchecked(index);
            }
            ExceptionUtil.ThrowInvalidEnumArgumentException<QueueSide>(queueSide, "queueSide");
            return default(T);
        }

        private void SetCapacity(int capacity)
        {
            T[] destinationArray = new T[capacity];
            if (this._size > 0)
            {
                if (this._head < this._tail)
                {
                    Array.Copy(this._array, this._head, destinationArray, 0, this._size);
                }
                else
                {
                    Array.Copy(this._array, this._head, destinationArray, 0, this._array.Length - this._head);
                    Array.Copy(this._array, 0, destinationArray, this._array.Length - this._head, this._tail);
                }
            }
            this._array = destinationArray;
            this._head = 0;
            this._tail = (this._size == capacity) ? 0 : this._size;
            this._version++;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SetElement(int i, T value)
        {
            int elementOffset = this.GetElementOffset(i);
            this._array[elementOffset] = value;
            this._version++;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => 
            new Enumerator<T>((Deque<T>) this);

        void ICollection.CopyTo(Array array, int index)
        {
            Validate.IsNotNull<Array>(array, "array");
            if (array.Rank != 1)
            {
                throw new RankException("1");
            }
            if (array.GetLowerBound(0) != 0)
            {
                throw new RankException("2");
            }
            int length = array.Length;
            if ((index < 0) || (index > length))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if ((length - index) < this._size)
            {
                throw new ArgumentException("1");
            }
            int num2 = ((length - index) < this._size) ? (length - index) : this._size;
            if (num2 != 0)
            {
                try
                {
                    int num3 = ((this._array.Length - this._head) < num2) ? (this._array.Length - this._head) : num2;
                    Array.Copy(this._array, this._head, array, index, num3);
                    num2 -= num3;
                    if (num2 > 0)
                    {
                        Array.Copy(this._array, 0, array, (index + this._array.Length) - this._head, num2);
                    }
                }
                catch (ArrayTypeMismatchException)
                {
                    throw new ArgumentException("2", new InvalidCastException());
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => 
            new Enumerator<T>((Deque<T>) this);

        public T[] ToArray()
        {
            if (this._size == 0)
            {
                return Array.Empty<T>();
            }
            T[] destinationArray = new T[this._size];
            if (this._size != 0)
            {
                if (this._head < this._tail)
                {
                    Array.Copy(this._array, this._head, destinationArray, 0, this._size);
                    return destinationArray;
                }
                Array.Copy(this._array, this._head, destinationArray, 0, this._array.Length - this._head);
                Array.Copy(this._array, 0, destinationArray, this._array.Length - this._head, this._tail);
            }
            return destinationArray;
        }

        public void TrimExcess()
        {
            int num = (int) (this._array.Length * 0.9);
            if (this._size < num)
            {
                this.SetCapacity(this._size);
            }
        }

        public int Count =>
            this._size;

        public T this[int index]
        {
            get
            {
                if ((index < 0) || (index >= this._size))
                {
                    ExceptionUtil.ThrowArgumentOutOfRangeException();
                }
                return this.GetElement(index);
            }
            set
            {
                if ((index < 0) || (index >= this._size))
                {
                    ExceptionUtil.ThrowArgumentOutOfRangeException();
                }
                this.SetElement(index, value);
            }
        }

        bool ICollection.IsSynchronized =>
            false;

        object ICollection.SyncRoot
        {
            get
            {
                if (this._syncRoot == null)
                {
                    Interlocked.CompareExchange(ref this._syncRoot, new object(), null);
                }
                return this._syncRoot;
            }
        }

        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private Deque<T> _q;
            private int _index;
            private int _version;
            private T _currentElement;
            internal Enumerator(Deque<T> q)
            {
                this._q = q;
                this._version = this._q._version;
                this._index = -1;
                this._currentElement = default(T);
            }

            public void Dispose()
            {
                this._index = -2;
                this._currentElement = default(T);
            }

            public bool MoveNext()
            {
                if (this._version != this._q._version)
                {
                    ExceptionUtil.ThrowInvalidOperationException("collection was changed during enumeration");
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

            public T Current
            {
                get
                {
                    if (this._index < 0)
                    {
                        if (this._index == -1)
                        {
                            ExceptionUtil.ThrowInvalidOperationException("enumeration wasn't started");
                        }
                        else
                        {
                            ExceptionUtil.ThrowInvalidOperationException("enumeration already finished");
                        }
                    }
                    return this._currentElement;
                }
            }
            object IEnumerator.Current =>
                this.Current;
            void IEnumerator.Reset()
            {
                if (this._version != this._q._version)
                {
                    ExceptionUtil.ThrowInvalidOperationException("collection was changed during enumeration");
                }
                this._index = -1;
                this._currentElement = default(T);
            }
        }

        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct ReverseEnumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private Deque<T> _q;
            private int _index;
            private int _version;
            private T _currentElement;
            internal ReverseEnumerator(Deque<T> q)
            {
                this._q = q;
                this._version = this._q._version;
                this._index = this._q.Count;
                this._currentElement = default(T);
            }

            public void Dispose()
            {
                this._index = -2;
                this._currentElement = default(T);
            }

            public bool MoveNext()
            {
                if (this._version != this._q._version)
                {
                    ExceptionUtil.ThrowInvalidOperationException("collection was changed during enumeration");
                }
                if (this._index == -1)
                {
                    return false;
                }
                this._index--;
                if (this._index == -1)
                {
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
                if (this._version != this._q._version)
                {
                    ExceptionUtil.ThrowInvalidOperationException("collection was changed during enumeration");
                }
                this._index = -1;
                this._currentElement = default(T);
            }
        }
    }
}

