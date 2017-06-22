namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;

    [Serializable]
    public sealed class SparseList<T> : ISegmentedList<T>, ISegmentedCollection<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>, IReadOnlyCollection<T>, ISerializable, ITrimExcess
    {
        private static readonly EqualityComparer<T> comparer;
        private int count;
        public const int DefaultSegmentLengthLog2 = 6;
        private static readonly DefaultValueComparer<T> defaultValueComparer;
        [NonSerialized]
        private bool isInitialized;
        [NonSerialized]
        private SegmentAllocator<T> segmentAllocator;
        private int segmentLengthLog2;
        private SegmentedList<int> segmentNonNullCount;
        private SegmentedList<T[]> segments;
        [NonSerialized]
        private int segmentSubIndexMask;
        [NonSerialized]
        private long version;

        static SparseList()
        {
            SparseList<T>.defaultValueComparer = DefaultValueComparer<T>.Instance;
            SparseList<T>.comparer = EqualityComparer<T>.Default;
        }

        public SparseList(int segmentLengthLog2 = 6)
        {
            if (segmentLengthLog2 < 0)
            {
                throw new ArgumentOutOfRangeException($"{"segmentLengthLog2"}={segmentLengthLog2.ToString()} but must be non-negative");
            }
            this.segmentLengthLog2 = segmentLengthLog2;
            this.Initialize();
        }

        public SparseList(IEnumerable<T> items, int segmentLengthLog2 = 6) : this(segmentLengthLog2)
        {
            if (segmentLengthLog2 < 0)
            {
                throw new ArgumentOutOfRangeException($"{"segmentLengthLog2"}={segmentLengthLog2.ToString()} but must be non-negative");
            }
            this.segmentLengthLog2 = segmentLengthLog2;
            this.Initialize();
            ICollection<T> is2 = items as ICollection<T>;
            if (is2 != null)
            {
                this.EnsureCapacity(is2.Count);
            }
            foreach (T local in items)
            {
                this.Add(local);
            }
        }

        private SparseList(SerializationInfo info, StreamingContext context)
        {
            this.segmentLengthLog2 = info.GetInt32("segmentLengthLog2");
            if (this.segmentLengthLog2 < 0)
            {
                throw new FormatException($"segmentLengthLog2({this.segmentLengthLog2}) must not be negative");
            }
            this.count = info.GetInt32("count");
            if (this.count < 0)
            {
                throw new FormatException($"count({this.count}) must not be negative");
            }
            if (this.count != 0)
            {
                IList<T[]> items = info.GetValue<IList<T[]>>("segments");
                this.segments = (items as SegmentedList<T[]>) ?? new SegmentedList<T[]>(items, 7);
            }
            this.Initialize();
            if (this.count == 0)
            {
                this.ClearReset();
            }
            else
            {
                this.EnsureCapacity(this.count);
                int segmentLength = this.SegmentLength;
                for (int i = 0; i < this.segments.Count; i++)
                {
                    T[] array = this.segments[i];
                    if (array != null)
                    {
                        if (array.Length != segmentLength)
                        {
                            Array.Resize<T>(ref array, segmentLength);
                        }
                        int segmentSize = this.GetSegmentSize(i);
                        if (array.Length > segmentSize)
                        {
                            Array.Clear(array, segmentSize, segmentSize - array.Length);
                        }
                        for (int j = 0; j < segmentSize; j++)
                        {
                            if (!SparseList<T>.defaultValueComparer.IsDefaultValue(ref array[j]))
                            {
                                int num5 = i;
                                int num6 = this.segmentNonNullCount[num5] + 1;
                                this.segmentNonNullCount[num5] = num6;
                            }
                        }
                        if (this.segmentNonNullCount[i] == 0)
                        {
                            this.segments[i] = null;
                        }
                    }
                }
            }
        }

        public void Add(T item)
        {
            this.Insert(this.count, item);
        }

        private T[] AllocateSegment(int segmentIndex)
        {
            T[] localArray = this.segmentAllocator.Get();
            this.segments[segmentIndex] = localArray;
            return localArray;
        }

        public bool Any() => 
            (this.Count > 0);

        public void Clear()
        {
            if (this.count == 0)
            {
                this.IncrementVersion();
            }
            else
            {
                this.ClearBoundedByCount(0, this.Count);
            }
        }

        public void Clear(int startIndex, int length)
        {
            this.ClearBoundedByCount(startIndex, length);
        }

        private void ClearBoundedByCapacity(int startIndex, int length)
        {
            Validate.Begin().IsNotNegative(startIndex, "startIndex").IsNotNegative(length, "length").Check().IsRangeValid(this.Capacity, startIndex, length, "this").Check();
            this.ClearInternal(startIndex, length);
        }

        private void ClearBoundedByCount(int startIndex, int length)
        {
            Validate.Begin().IsNotNegative(startIndex, "startIndex").IsNotNegative(length, "length").Check().IsRangeValid(this.Count, startIndex, length, "this").Check();
            this.ClearInternal(startIndex, length);
        }

        private void ClearInternal(int startIndex, int length)
        {
            if (length != 0)
            {
                if (((startIndex == 0) && (length >= this.Count)) && (length <= this.Capacity))
                {
                    this.ClearReset();
                }
                else
                {
                    int listIndex = startIndex;
                    int num2 = listIndex + length;
                    int segmentIndex = this.GetSegmentIndex(listIndex);
                    for (int i = this.GetSegmentSubIndex(listIndex); listIndex < num2; i = 0)
                    {
                        int num5 = Math.Min(num2, this.GetSegmentStartListIndex(segmentIndex + 1));
                        this.ClearSegment(segmentIndex, i, num5 - listIndex);
                        listIndex = num5;
                        segmentIndex++;
                    }
                }
            }
            this.IncrementVersion();
        }

        private void ClearReset()
        {
            if (this.count != 0)
            {
                this.count = 0;
                for (int i = 0; i < this.segments.Count; i++)
                {
                    this.FreeSegment(i);
                }
            }
            this.segments.Resize(0);
            this.segments.TrimExcess();
            this.segmentNonNullCount.Resize(0);
            this.segmentNonNullCount.TrimExcess();
            this.segmentAllocator.Clear();
            this.IncrementVersion();
        }

        private void ClearSegment(int segmentIndex, int startSegmentSubIndex, int length)
        {
            Validate.Begin().IsNotNegative(segmentIndex, "segmentIndex").IsNotNegative(startSegmentSubIndex, "startSegmentSubIndex").IsNotNegative(length, "length").Check().IsValueInRange(segmentIndex, 0, this.segments.Count, "segmentIndex").Check();
            if (length != 0)
            {
                T[] localArray = this.segments[segmentIndex];
                if (localArray == null)
                {
                    this.IncrementVersion();
                }
                else
                {
                    int segmentSize = this.GetSegmentSize(segmentIndex);
                    if (((startSegmentSubIndex == 0) && (length >= segmentSize)) && (length <= this.SegmentLength))
                    {
                        this.FreeSegment(segmentIndex);
                    }
                    else
                    {
                        for (int i = startSegmentSubIndex; i < (startSegmentSubIndex + length); i++)
                        {
                            if (!SparseList<T>.defaultValueComparer.IsDefaultValue(ref localArray[i]))
                            {
                                localArray[i] = default(T);
                                int num3 = segmentIndex;
                                int num4 = this.segmentNonNullCount[num3] - 1;
                                this.segmentNonNullCount[num3] = num4;
                            }
                        }
                        if (this.segmentNonNullCount[segmentIndex] == 0)
                        {
                            this.FreeSegment(segmentIndex);
                        }
                    }
                    this.IncrementVersion();
                }
            }
        }

        public bool Contains(T item) => 
            (this.IndexOf(item) != -1);

        public void CopyTo(T[] array, int arrayIndex)
        {
            Validate.Begin().IsNotNull<T[]>(array, "array").Check().IsRangeValid(array.Length, arrayIndex, (arrayIndex + this.count), "array").Check();
            for (int i = 0; i < this.count; i++)
            {
                array[i + arrayIndex] = this[i];
            }
        }

        public void EnsureCapacity(int newCapacity)
        {
            if (newCapacity < 0)
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException($"{"newCapacity"}={newCapacity.ToString("N0")}, but must be non-negative");
            }
            if (this.Capacity < newCapacity)
            {
                int requiredSegmentCount = this.GetRequiredSegmentCount(newCapacity);
                this.segments.Resize(requiredSegmentCount);
                this.segmentNonNullCount.Resize(requiredSegmentCount);
            }
        }

        private T[] EnsureSegmentIsAllocated(int segmentIndex)
        {
            T[] localArray = this.segments[segmentIndex];
            if (localArray != null)
            {
                return localArray;
            }
            return this.AllocateSegment(segmentIndex);
        }

        private void FreeSegment(int segmentIndex)
        {
            T[] segment = this.segments[segmentIndex];
            if (segment != null)
            {
                bool isDirty = this.segmentNonNullCount[segmentIndex] > 0;
                this.segmentAllocator.Release(segment, isDirty);
                this.segments[segmentIndex] = null;
            }
        }

        private void FreeSegmentIfAllNull(int segmentIndex)
        {
            if (this.segmentNonNullCount[segmentIndex] == 0)
            {
                this.FreeSegment(segmentIndex);
            }
        }

        public Enumerator<T> GetEnumerator() => 
            new Enumerator<T>((SparseList<T>) this);

        private int GetRequiredSegmentCount(int elementCount)
        {
            Validate.IsNotNegative(elementCount, "elementCount");
            if (elementCount == 0)
            {
                return 0;
            }
            return (1 + this.GetSegmentIndex(elementCount - 1));
        }

        private int GetSegmentEndListIndex(int segmentIndex) => 
            (this.GetSegmentStartListIndex(segmentIndex) + this.GetSegmentSize(segmentIndex));

        private int GetSegmentIndex(int listIndex) => 
            (listIndex >> this.segmentLengthLog2);

        private int GetSegmentSize(int segmentIndex)
        {
            if (segmentIndex >= (this.segments.Count - 1))
            {
                int num = this.Count & this.segmentSubIndexMask;
                if (num != 0)
                {
                    return num;
                }
            }
            return this.SegmentLength;
        }

        private int GetSegmentStartListIndex(int segmentIndex) => 
            (segmentIndex << this.SegmentLengthLog2);

        private int GetSegmentSubIndex(int listIndex) => 
            (listIndex & this.segmentSubIndexMask);

        private void IncrementVersion()
        {
            this.version += 1L;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (SparseList<T>.comparer.Equals(this[i], item))
                {
                    return i;
                }
            }
            return -1;
        }

        private void Initialize()
        {
            this.segmentSubIndexMask = (((int) 1) << this.segmentLengthLog2) - 1;
            if (this.segments == null)
            {
                if (this.count != 0)
                {
                    throw new InternalErrorException("this.segments is null, but this.count != 0");
                }
                this.segments = new SegmentedList<T[]>();
                this.segmentNonNullCount = new SegmentedList<int>();
            }
            if (this.segmentNonNullCount == null)
            {
                this.segmentNonNullCount = new SegmentedList<int>();
                this.segmentNonNullCount.Resize(this.segments.Count);
            }
            this.segmentAllocator = SegmentAllocator<T>.GetInstance(this.segmentLengthLog2);
            this.isInitialized = true;
        }

        public void Insert(int index, T item)
        {
            Validate.IsClamped(index, 0, this.count, "index");
            this.EnsureCapacity(this.count + 1);
            this.count++;
            for (int i = this.count - 1; i > index; i--)
            {
                this[i] = this[i - 1];
            }
            this[index] = item;
            this.IncrementVersion();
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);
            if (index == -1)
            {
                return false;
            }
            this.RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            if (this.Count == 0)
            {
                ExceptionUtil.ThrowInvalidOperationException("The collection is empty");
            }
            Validate.IsClamped(index, 0, this.count - 1, "index");
            for (int i = index; i < (this.count - 1); i++)
            {
                this[i] = this[i + 1];
            }
            this[this.count - 1] = default(T);
            this.count--;
            this.IncrementVersion();
        }

        public void RemoveRangeAt(int startIndex, int count)
        {
            Validate.Begin().IsNotNegative(startIndex, "startIndex").IsNotNegative(count, "count").Check().IsRangeValid(this.Count, startIndex, count, "this").Check();
            for (int i = (startIndex + count) - 1; i >= startIndex; i--)
            {
                this.RemoveAt(i);
            }
        }

        public void Resize(int newCount)
        {
            this.Resize(newCount, true, true);
        }

        public void Resize(int newCount, bool trimExcess)
        {
            this.Resize(newCount, trimExcess, true);
        }

        internal void Resize(int newCount, bool trimExcess, bool zeroExcess)
        {
            Validate.IsNotNegative(newCount, "newCount");
            int count = this.Count;
            if (newCount != count)
            {
                if (newCount > this.Count)
                {
                    this.EnsureCapacity(newCount);
                    this.count = newCount;
                }
                else if (newCount < this.Count)
                {
                    this.count = newCount;
                    if (zeroExcess)
                    {
                        this.ClearBoundedByCapacity(newCount, this.Capacity - newCount);
                    }
                }
            }
            if (trimExcess)
            {
                this.TrimExcess();
            }
            this.IncrementVersion();
        }

        internal void RotateSegments(int firstInclusiveSegmentIndex, int middleSegmentIndex, int lastExclusiveSegmentIndex)
        {
            if (this.Count == 0)
            {
                ExceptionUtil.ThrowInvalidOperationException("The collection is empty");
            }
            if (((firstInclusiveSegmentIndex > middleSegmentIndex) || (middleSegmentIndex > lastExclusiveSegmentIndex)) || ((firstInclusiveSegmentIndex < 0) || (lastExclusiveSegmentIndex > this.segments.Count)))
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException();
            }
            ListUtil.RotateElementRange<T[], SegmentedList<T[]>>(this.segments, firstInclusiveSegmentIndex, middleSegmentIndex, lastExclusiveSegmentIndex);
            ListUtil.RotateElementRange<int, SegmentedList<int>>(this.segmentNonNullCount, firstInclusiveSegmentIndex, middleSegmentIndex, lastExclusiveSegmentIndex);
        }

        public void RotateToBeginning(int pivotIndex)
        {
            if (this.Count == 0)
            {
                ExceptionUtil.ThrowInvalidOperationException("The collection is empty");
            }
            if (pivotIndex != 0)
            {
                Validate.IsClamped(pivotIndex, 0, this.Count - 1, "pivotIndex");
                int segmentIndex = this.GetSegmentIndex(pivotIndex);
                int segmentSubIndex = this.GetSegmentSubIndex(pivotIndex);
                if (segmentIndex != 0)
                {
                    this.RotateSegments(0, segmentIndex, this.segments.Count);
                }
                if (segmentSubIndex != 0)
                {
                    ListUtil.RotateElementRange<T, SparseList<T>>((SparseList<T>) this, 0, segmentSubIndex, this.Count);
                }
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => 
            this.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("segmentLengthLog2", this.segmentLengthLog2);
            info.AddValue("segments", this.segments);
            info.AddValue("count", this.count);
        }

        public void TrimExcess()
        {
            int requiredSegmentCount = this.GetRequiredSegmentCount(this.count);
            if (this.segments.Count > requiredSegmentCount)
            {
                this.segments.Resize(requiredSegmentCount);
                this.segmentNonNullCount.Resize(requiredSegmentCount);
            }
            this.segments.TrimExcess();
            this.segmentNonNullCount.TrimExcess();
            this.segmentAllocator.Clear();
        }

        [Conditional("DEBUG")]
        private void VerifyIsInitialized()
        {
            if (!this.isInitialized)
            {
                ExceptionUtil.ThrowInvalidOperationException("this.isInitialized is false");
            }
        }

        private void VerifyVersion(long requiredVersion)
        {
            if (this.version != requiredVersion)
            {
                ExceptionUtil.ThrowInvalidOperationException("The collection has changed");
            }
        }

        public int Capacity =>
            (this.segments.Count * this.SegmentLength);

        public int Count =>
            this.count;

        public bool IsReadOnly =>
            false;

        public T this[int index]
        {
            get
            {
                if (this.count == 0)
                {
                    ExceptionUtil.ThrowArgumentOutOfRangeException();
                }
                Validate.IsClamped(index, 0, this.count - 1, "index");
                int segmentIndex = this.GetSegmentIndex(index);
                int segmentSubIndex = this.GetSegmentSubIndex(index);
                T[] localArray = this.segments[segmentIndex];
                if (localArray == null)
                {
                    return default(T);
                }
                return localArray[segmentSubIndex];
            }
            set
            {
                if (this.count == 0)
                {
                    ExceptionUtil.ThrowArgumentOutOfRangeException();
                }
                Validate.IsClamped(index, 0, this.count - 1, "index");
                bool flag = SparseList<T>.defaultValueComparer.IsDefaultValue(ref value);
                int segmentIndex = this.GetSegmentIndex(index);
                int segmentSubIndex = this.GetSegmentSubIndex(index);
                T[] localArray = this.segments[segmentIndex];
                if (!((localArray == null) & flag))
                {
                    if ((localArray == null) && !flag)
                    {
                        this.AllocateSegment(segmentIndex)[segmentSubIndex] = value;
                        this.segmentNonNullCount[segmentIndex] = 1;
                    }
                    else
                    {
                        int num3;
                        int num4;
                        bool flag2 = SparseList<T>.defaultValueComparer.IsDefaultValue(ref localArray[segmentSubIndex]);
                        if (flag)
                        {
                            localArray[segmentSubIndex] = default(T);
                            if (!flag2)
                            {
                                num3 = segmentIndex;
                                num4 = this.segmentNonNullCount[num3] - 1;
                                this.segmentNonNullCount[num3] = num4;
                                this.FreeSegmentIfAllNull(segmentIndex);
                            }
                        }
                        else
                        {
                            localArray[segmentSubIndex] = value;
                            if (flag2)
                            {
                                num4 = segmentIndex;
                                num3 = this.segmentNonNullCount[num4] + 1;
                                this.segmentNonNullCount[num4] = num3;
                            }
                        }
                    }
                }
                this.IncrementVersion();
            }
        }

        public int SegmentLength =>
            (((int) 1) << this.segmentLengthLog2);

        public int SegmentLengthLog2 =>
            this.segmentLengthLog2;

        [StructLayout(LayoutKind.Sequential)]
        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private SparseList<T> list;
            private int currentIndex;
            private long requiredVersion;
            private T currentValue;
            internal Enumerator(SparseList<T> list)
            {
                if (list == null)
                {
                    throw new InternalErrorException(new ArgumentNullException("list"));
                }
                this.list = list;
                this.currentIndex = -1;
                this.requiredVersion = this.list.version;
                this.currentValue = default(T);
            }

            private void VerifyIsNotDisposed()
            {
                if (this.list == null)
                {
                    ExceptionUtil.ThrowObjectDisposedException(base.GetType().Name);
                }
            }

            public T Current =>
                this.currentValue;
            public void Dispose()
            {
                this.list = null;
                this.currentIndex = -2;
                this.currentValue = default(T);
            }

            object IEnumerator.Current =>
                this.Current;
            public bool MoveNext()
            {
                this.VerifyIsNotDisposed();
                this.list.VerifyVersion(this.requiredVersion);
                if (this.currentIndex != this.list.Count)
                {
                    if (this.list.Count == 0)
                    {
                        return false;
                    }
                    this.currentIndex++;
                    if (this.currentIndex < this.list.count)
                    {
                        this.currentValue = this.list[this.currentIndex];
                        return true;
                    }
                    this.currentValue = default(T);
                }
                return false;
            }

            void IEnumerator.Reset()
            {
                this.VerifyIsNotDisposed();
                this.requiredVersion = this.list.version;
                this.currentIndex = -1;
            }
        }
    }
}

