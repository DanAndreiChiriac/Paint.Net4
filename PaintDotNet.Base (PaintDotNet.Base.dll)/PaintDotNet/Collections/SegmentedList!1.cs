namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;

    [Serializable]
    public sealed class SegmentedList<T> : ISegmentedList<T>, ISegmentedCollection<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>, IReadOnlyList<T>, IReadOnlyCollection<T>, IModifyElementByRef<T>, ISerializable, IAddRange<T>, IToArray<T>, ITrimExcess
    {
        private int count;
        private const string countName = "count";
        public const int DefaultSegmentLengthLog2 = 7;
        [NonSerialized]
        private bool isInitialized;
        [NonSerialized]
        private SegmentAllocator<T> segmentAllocator;
        private int segmentLengthLog2;
        private const string segmentLengthLog2Name = "segmentLengthLog2";
        private List<T[]> segments;
        private const string segmentsName = "segments";
        [NonSerialized]
        private int segmentSubIndexMask;
        [NonSerialized]
        private int version;

        public SegmentedList() : this(0, 7)
        {
        }

        public SegmentedList(IEnumerable<T> items, int segmentLengthLog2 = 7)
        {
            this.segmentLengthLog2 = -1;
            if (segmentLengthLog2 < 0)
            {
                throw new ArgumentOutOfRangeException($"{"segmentLengthLog2"}={segmentLengthLog2.ToString()} but must be non-negative");
            }
            this.segmentLengthLog2 = segmentLengthLog2;
            this.Initialize();
            int segmentLength = this.SegmentLength;
            SegmentedList<T> list = items as SegmentedList<T>;
            if ((list != null) && (list.SegmentLengthLog2 == this.SegmentLengthLog2))
            {
                this.count = list.count;
                int count = list.segments.Count;
                this.segments.Capacity = count;
                for (int i = 0; i < count; i++)
                {
                    T[] destinationArray = this.segmentAllocator.Get();
                    Array.Copy(list.segments[i], destinationArray, segmentLength);
                    this.segments.Add(destinationArray);
                }
            }
            else
            {
                this.AddRange(items);
            }
        }

        public SegmentedList(int capacity, int segmentLengthLog2 = 7)
        {
            this.segmentLengthLog2 = -1;
            if (segmentLengthLog2 < 0)
            {
                throw new ArgumentOutOfRangeException($"{"segmentLengthLog2"}={segmentLengthLog2.ToString()} but must be non-negative");
            }
            this.segmentLengthLog2 = segmentLengthLog2;
            this.Initialize();
            if (capacity > 0)
            {
                this.EnsureCapacity(capacity);
            }
        }

        private SegmentedList(SerializationInfo info, StreamingContext context)
        {
            this.segmentLengthLog2 = -1;
            this.segmentLengthLog2 = info.GetInt32("segmentLengthLog2");
            T[][] collection = info.GetValue<T[][]>("segments");
            this.segments = new List<T[]>(collection);
            this.count = info.GetInt32("count");
            this.Initialize();
        }

        public void Add(T item)
        {
            T[] localArray;
            this.count++;
            int segmentSubIndex = this.GetSegmentSubIndex(this.count - 1);
            if ((segmentSubIndex == 0) && (this.count > this.Capacity))
            {
                localArray = this.segmentAllocator.Get();
                this.segments.Add(localArray);
            }
            else
            {
                int segmentIndex = this.GetSegmentIndex(this.count - 1);
                localArray = this.segments[segmentIndex];
            }
            localArray[segmentSubIndex] = item;
            this.IncrementVersion();
        }

        public void AddRange(IEnumerable<T> items)
        {
            Validate.IsNotNull<IEnumerable<T>>(items, "items");
            T[] localArray = items as T[];
            if (localArray != null)
            {
                this.AddRange(localArray, 0, localArray.Length);
            }
            else
            {
                using (IEnumerator<T> enumerator = items.GetEnumerator())
                {
                    bool flag = enumerator.MoveNext();
                    if (flag)
                    {
                        this.IncrementVersion();
                        int segmentLength = this.SegmentLength;
                        int segmentIndex = this.GetSegmentIndex(this.count);
                        for (int i = this.GetSegmentSubIndex(this.count); flag; i = 0)
                        {
                            T[] localArray2;
                            if (segmentIndex < this.segments.Count)
                            {
                                localArray2 = this.segments[segmentIndex];
                            }
                            else
                            {
                                localArray2 = this.segmentAllocator.Get();
                                this.segments.Add(localArray2);
                            }
                            do
                            {
                                localArray2[i] = enumerator.Current;
                                i++;
                                this.count++;
                                flag = enumerator.MoveNext();
                            }
                            while (flag && (i < segmentLength));
                            segmentIndex++;
                        }
                    }
                }
            }
        }

        public void AddRange(T[] items)
        {
            Validate.IsNotNull<T[]>(items, "items");
            if (items.Length != 0)
            {
                this.AddRange(items, 0, items.Length);
            }
        }

        public void AddRange(T[] items, int startIndex, int length)
        {
            Validate.IsNotNull<T[]>(items, "items");
            if (length != 0)
            {
                this.IncrementVersion();
                int sourceIndex = startIndex;
                int num2 = sourceIndex + length;
                int segmentLength = this.SegmentLength;
                int segmentIndex = this.GetSegmentIndex(this.count);
                for (int i = this.GetSegmentSubIndex(this.count); sourceIndex < num2; i = 0)
                {
                    T[] localArray;
                    if (segmentIndex < this.segments.Count)
                    {
                        localArray = this.segments[segmentIndex];
                    }
                    else
                    {
                        localArray = this.segmentAllocator.Get();
                        this.segments.Add(localArray);
                    }
                    int num6 = Math.Min((int) (num2 - sourceIndex), (int) (segmentLength - i));
                    Array.Copy(items, sourceIndex, localArray, i, num6);
                    this.count += num6;
                    sourceIndex += num6;
                    segmentIndex++;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Any() => 
            (this.Count > 0);

        public void Clear()
        {
            this.count = 0;
            this.TrimExcess();
            this.IncrementVersion();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(T item) => 
            (this.IndexOf(item) != -1);

        public void Copy(int startIndex, int length, T[] array, int arrayStartIndex)
        {
            Validate.Begin().IsNotNull<T[]>(array, "array").Check().IsNotNegative(startIndex, "startIndex").IsNotNegative(length, "length").Check().IsRangeValid(this.Count, startIndex, length, "this").IsRangeValid(array.Length, arrayStartIndex, length, "array").Check();
            if (length != 0)
            {
                int num = startIndex + length;
                int destinationIndex = arrayStartIndex;
                SegmentIterator<T> iterator = new SegmentIterator<T>((SegmentedList<T>) this, startIndex);
                int count = length;
                while (iterator.ListIndex < num)
                {
                    int segmentSubIndex = iterator.SegmentSubIndex;
                    int num5 = iterator.ClampForwardCountToListEndOrNextSegment(count);
                    Array.Copy(iterator.Segment, segmentSubIndex, array, destinationIndex, num5);
                    count -= num5;
                    destinationIndex += num5;
                    iterator.ListIndex += num5;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] array, int arrayIndex)
        {
            this.Copy(0, this.Count, array, arrayIndex);
        }

        public T[] DrainToArray()
        {
            int count = this.Count;
            if (count == 0)
            {
                return Array.Empty<T>();
            }
            T[] destinationArray = new T[count];
            int destinationIndex = 0;
            int num3 = this.segments.Count;
            for (int i = 0; i < num3; i++)
            {
                T[] sourceArray = this.segments[i];
                int length = Math.Min(sourceArray.Length, count - destinationIndex);
                Array.Copy(sourceArray, 0, destinationArray, destinationIndex, length);
                this.segments[i] = null;
                destinationIndex += length;
            }
            this.segments = new List<T[]>();
            this.count = 0;
            this.IncrementVersion();
            return destinationArray;
        }

        public void EnsureCapacity(int newCapacity)
        {
            if (newCapacity < 0)
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException($"{"newCapacity"}={newCapacity.ToString()} but must be non-negative");
            }
            if (this.Capacity < newCapacity)
            {
                int requiredSegmentCount = this.GetRequiredSegmentCount(newCapacity);
                this.SetSegmentCount(requiredSegmentCount);
            }
        }

        public Enumerator<T> GetEnumerator() => 
            new Enumerator<T>((SegmentedList<T>) this);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int GetRequiredSegmentCount(int elementCount)
        {
            Validate.IsNotNegative(elementCount, "elementCount");
            if (elementCount == 0)
            {
                return 0;
            }
            return (1 + this.GetSegmentIndex(elementCount - 1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal T[] GetSegment(int segmentIndex) => 
            this.segments[segmentIndex];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal int GetSegmentEndListIndex(int segmentIndex)
        {
            int segmentStartListIndex = this.GetSegmentStartListIndex(segmentIndex + 1);
            return Math.Min(this.Count, segmentStartListIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal int GetSegmentIndex(int listIndex) => 
            (listIndex >> this.segmentLengthLog2);

        internal IList<T[]> GetSegments() => 
            new ReadOnlyListFromSource<T[]>(new SegmentsListSource<T>((SegmentedList<T>) this));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal int GetSegmentStartListIndex(int segmentIndex) => 
            (segmentIndex << this.segmentLengthLog2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal int GetSegmentSubIndex(int listIndex) => 
            (listIndex & this.segmentSubIndexMask);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal T GetUnchecked(int index)
        {
            int segmentIndex = this.GetSegmentIndex(index);
            int segmentSubIndex = this.GetSegmentSubIndex(index);
            return this.segments[segmentIndex][segmentSubIndex];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void IncrementVersion()
        {
            this.version++;
        }

        public int IndexOf(T item)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < this.count; i++)
            {
                if (comparer.Equals(item, this[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        private void Initialize()
        {
            if (this.segmentLengthLog2 < 0)
            {
                ExceptionUtil.ThrowInternalErrorException("this.segmentLengthLog2 has not been set");
            }
            if (this.segments == null)
            {
                this.segments = new List<T[]>();
            }
            this.segmentAllocator = SegmentAllocator<T>.GetInstance(this.segmentLengthLog2);
            this.segmentSubIndexMask = (((int) 1) << this.segmentLengthLog2) - 1;
            int requiredSegmentCount = this.GetRequiredSegmentCount(this.count);
            if (((this.segments == null) ? 0 : this.segments.Count) < requiredSegmentCount)
            {
                throw new FormatException("this.segments.Count is less than the number of segments required for this.Count");
            }
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ModifyByRef<TActionByRef>(int index, TActionByRef modifyAction) where TActionByRef: struct, IActionByRef<T>
        {
            Validate.IsClamped(index, 0, this.count - 1, "index");
            this.ModifyByRefUnchecked<TActionByRef>(index, modifyAction);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void ModifyByRefUnchecked<TActionByRef>(int index, TActionByRef modifyAction) where TActionByRef: struct, IActionByRef<T>
        {
            int segmentIndex = this.GetSegmentIndex(index);
            int segmentSubIndex = this.GetSegmentSubIndex(index);
            modifyAction.Invoke(ref this.segments[segmentIndex][segmentSubIndex]);
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
            Validate.IsClamped(index, 0, this.count - 1, "index");
            for (int i = index; i < (this.count - 1); i++)
            {
                this[i] = this[i + 1];
            }
            this[this.count - 1] = default(T);
            this.count--;
            this.IncrementVersion();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Resize(int newCount)
        {
            this.Resize(newCount, true, true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
                    int num2 = this.count;
                    this.count = newCount;
                    if (trimExcess)
                    {
                        this.TrimExcess();
                    }
                    if (zeroExcess)
                    {
                        int num3 = Math.Min(this.Capacity, num2);
                        this.SetRangeToDefault(newCount, num3 - newCount);
                    }
                }
            }
            this.IncrementVersion();
        }

        private void SetCapacity(int newCapacity)
        {
            int requiredSegmentCount = this.GetRequiredSegmentCount(newCapacity);
            this.SetSegmentCount(requiredSegmentCount);
        }

        public void SetRange(int startIndex, int length, T value)
        {
            Validate.Begin().IsNotNegative(startIndex, "startIndex").IsNotNegative(length, "length").IsRangeValid(this.Count, startIndex, length, "this").Check();
            for (int i = startIndex; i < (startIndex + length); i++)
            {
                this[i] = value;
            }
        }

        public void SetRange(int startIndex, T[] items, int offset, int count)
        {
            Validate.IsNotNegative(startIndex, "startIndex");
            Validate.IsNotNegative(offset, "offset");
            Validate.IsNotNegative(count, "count");
            Validate.IsLessThanOrEqualTo(offset + count, (long) items.Length, "offset, count, items.Length");
            int newCount = startIndex + count;
            if (newCount > this.Count)
            {
                this.Resize(newCount);
            }
            int sourceIndex = offset;
            int listIndex = startIndex;
            int num4 = startIndex + count;
            int segmentIndex = this.GetSegmentIndex(listIndex);
            int segmentSubIndex = this.GetSegmentSubIndex(listIndex);
            T[] destinationArray = null;
            while (listIndex < num4)
            {
                destinationArray = this.segments[segmentIndex];
                int num1 = Math.Min(listIndex + (destinationArray.Length - segmentSubIndex), num4);
                int length = num1 - listIndex;
                Array.Copy(items, sourceIndex, destinationArray, segmentSubIndex, length);
                listIndex = num1;
                sourceIndex += length;
                segmentSubIndex = 0;
                segmentIndex++;
            }
            this.IncrementVersion();
        }

        private void SetRangeToDefault(int startIndex, int length)
        {
            Validate.Begin().IsNotNegative(startIndex, "startIndex").IsNotNegative(length, "length").IsRangeValid(this.Capacity, startIndex, length, "this").Check();
            if (length != 0)
            {
                int segmentLength = this.SegmentLength;
                int segmentIndex = this.GetSegmentIndex(startIndex);
                int segmentSubIndex = this.GetSegmentSubIndex(startIndex);
                int num4 = length;
                while (num4 > 0)
                {
                    int num5 = Math.Min(num4, segmentLength - segmentSubIndex);
                    Array.Clear(this.segments[segmentIndex], segmentSubIndex, num5);
                    num4 -= num5;
                    segmentSubIndex += num5;
                    if (segmentSubIndex == segmentLength)
                    {
                        segmentSubIndex = 0;
                        segmentIndex++;
                    }
                }
            }
        }

        private void SetSegmentCount(int newSegmentCount)
        {
            Validate.IsNotNegative(newSegmentCount, "newSegmentCount");
            int count = this.segments.Count;
            if (newSegmentCount != count)
            {
                if (newSegmentCount == (count + 1))
                {
                    T[] item = this.segmentAllocator.Get();
                    this.segments.Add(item);
                }
                else
                {
                    for (int i = newSegmentCount; i < count; i++)
                    {
                        if (this.segments[i] != null)
                        {
                            this.segmentAllocator.Release(this.segments[i]);
                            this.segments[i] = null;
                        }
                    }
                    ListUtil.Resize<T[]>(this.segments, newSegmentCount);
                    for (int j = count; j < newSegmentCount; j++)
                    {
                        this.segments[j] = this.segmentAllocator.Get();
                    }
                }
            }
        }

        internal void SetUnchecked(int index, T value)
        {
            int segmentIndex = this.GetSegmentIndex(index);
            int segmentSubIndex = this.GetSegmentSubIndex(index);
            this.segments[segmentIndex][segmentSubIndex] = value;
            this.IncrementVersion();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => 
            this.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("segmentLengthLog2", this.segmentLengthLog2);
            info.AddValue("segments", this.segments.ToArrayEx<T[]>());
            info.AddValue("count", this.count);
        }

        public T[] ToArray()
        {
            int count = this.Count;
            if (count == 0)
            {
                return Array.Empty<T>();
            }
            T[] destinationArray = new T[count];
            int destinationIndex = 0;
            foreach (T[] local1 in this.segments)
            {
                int length = Math.Min(local1.Length, count - destinationIndex);
                Array.Copy(local1, 0, destinationArray, destinationIndex, length);
                destinationIndex += length;
            }
            return destinationArray;
        }

        public void TrimExcess()
        {
            if (this.count == 0)
            {
                this.SetSegmentCount(0);
            }
            else
            {
                int requiredSegmentCount = this.GetRequiredSegmentCount(this.count);
                if (this.segments.Count > requiredSegmentCount)
                {
                    this.SetSegmentCount(requiredSegmentCount);
                }
            }
            if (this.segments != null)
            {
                this.segments.TrimExcess();
            }
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void VerifyVersion(int requiredVersion)
        {
            if (requiredVersion != this.version)
            {
                ExceptionUtil.ThrowInvalidOperationException("The collection has changed");
            }
        }

        public int Capacity =>
            (this.segments.Count << this.segmentLengthLog2);

        public int Count =>
            this.count;

        public bool IsReadOnly =>
            false;

        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                Validate.IsClamped(index, 0, this.count - 1, "index");
                return this.GetUnchecked(index);
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                Validate.IsClamped(index, 0, this.count - 1, "index");
                this.SetUnchecked(index, value);
            }
        }

        public int SegmentLength =>
            (((int) 1) << this.segmentLengthLog2);

        public int SegmentLengthLog2 =>
            this.segmentLengthLog2;

        internal int Version =>
            this.version;

        [StructLayout(LayoutKind.Sequential)]
        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private SegmentedList<T> list;
            private int currentIndex;
            private int requiredVersion;
            internal Enumerator(SegmentedList<T> list)
            {
                if (list == null)
                {
                    throw new InternalErrorException(new ArgumentNullException("list"));
                }
                this.list = list;
                this.currentIndex = -1;
                this.requiredVersion = this.list.Version;
            }

            public T Current =>
                this.list.GetUnchecked(this.currentIndex);
            public void Dispose()
            {
                this.list = null;
                this.currentIndex = -1;
                this.requiredVersion = -1;
            }

            object IEnumerator.Current =>
                this.Current;
            public bool MoveNext()
            {
                this.list.VerifyVersion(this.requiredVersion);
                if (this.currentIndex == this.list.Count)
                {
                    return false;
                }
                if (this.list.Count == 0)
                {
                    return false;
                }
                this.currentIndex++;
                return (this.currentIndex < this.list.count);
            }

            public void Reset()
            {
                this.list.VerifyVersion(this.requiredVersion);
                this.currentIndex = -1;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SegmentIterator
        {
            private SegmentedList<T> list;
            private int listIndex;
            public SegmentIterator(SegmentedList<T> list, int listIndex)
            {
                this.list = list;
                this.listIndex = listIndex;
            }

            public bool IsBegin =>
                (this.listIndex == 0);
            public bool IsEnd =>
                (this.listIndex >= this.list.Count);
            public int ListIndex
            {
                get => 
                    this.listIndex;
                set
                {
                    this.listIndex = value;
                }
            }
            public T[] Segment =>
                this.list.segments[this.SegmentIndex];
            public int SegmentIndex =>
                this.list.GetSegmentIndex(this.listIndex);
            public int SegmentSubIndex =>
                this.list.GetSegmentSubIndex(this.listIndex);
            public int CountToEndOrNextSegment
            {
                get
                {
                    int segmentStartListIndex = this.list.GetSegmentStartListIndex(this.SegmentIndex);
                    return (this.list.GetSegmentEndListIndex(this.SegmentIndex) - segmentStartListIndex);
                }
            }
            public int ClampForwardCountToListEnd(int count)
            {
                if (count == 0)
                {
                    return 0;
                }
                return (Math.Min(this.listIndex + count, this.list.Count) - this.listIndex);
            }

            public int ClampForwardCountToListEndOrNextSegment(int count)
            {
                if (count == 0)
                {
                    return 0;
                }
                return (Math.Min(this.listIndex + count, this.list.GetSegmentEndListIndex(this.SegmentIndex)) - this.listIndex);
            }
        }

        private sealed class SegmentsListSource : IListSource<T[]>
        {
            private SegmentedList<T> owner;

            public SegmentsListSource(SegmentedList<T> owner)
            {
                Validate.IsNotNull<SegmentedList<T>>(owner, "owner");
                this.owner = owner;
            }

            public IList<T[]> List =>
                (this.owner.segments ?? Array.Empty<T[]>());

            public int Version =>
                this.owner.version;
        }
    }
}

