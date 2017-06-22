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

    public sealed class UnsafeList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>, IModifyElementByRef<T>, IRemoveRange, IToArray<T>, ITrimExcess
    {
        private T[] array;
        private static readonly EqualityComparer<T> comparer;
        private int count;

        static UnsafeList()
        {
            UnsafeList<T>.comparer = EqualityComparer<T>.Default;
        }

        public UnsafeList() : this(0)
        {
        }

        public UnsafeList(IEnumerable<T> copyMe)
        {
            copyMe.ToArrayNonTrimmed<T>(out this.array, out this.count);
        }

        public UnsafeList(int capacity)
        {
            if (capacity == 0)
            {
                this.array = Array.Empty<T>();
            }
            else
            {
                this.array = new T[capacity];
            }
        }

        internal UnsafeList(ref T[] array, int count)
        {
            Validate.Begin().IsNotNull<T[]>(array, "array").Check().IsGreaterThanOrEqualTo(array.Length, count, "array.Length >= count").Check();
            this.array = array;
            this.count = count;
            array = null;
        }

        public void Add(T item)
        {
            if (this.count >= this.array.Length)
            {
                this.GrowCapacity(this.count + 1);
            }
            this.array[this.count] = item;
            this.count++;
        }

        public void AddRange(IEnumerable<T> items)
        {
            Validate.IsNotNull<IEnumerable<T>>(items, "items");
            T[] localArray = items as T[];
            if (localArray != null)
            {
                this.AddRange(localArray);
            }
            else
            {
                ICollection<T> is2 = items as ICollection<T>;
                if (is2 != null)
                {
                    int count = is2.Count;
                    this.GrowCapacity(this.count + count);
                    is2.CopyTo(this.array, this.count);
                    this.count += count;
                }
                else
                {
                    using (IEnumerator<T> enumerator = items.GetEnumerator())
                    {
                        bool flag = enumerator.MoveNext();
                        goto Label_00C0;
                    Label_006F:
                        this.array[this.count] = enumerator.Current;
                        this.count++;
                        flag = enumerator.MoveNext();
                    Label_009C:
                        if (flag && (this.count < this.Capacity))
                        {
                            goto Label_006F;
                        }
                        if (flag)
                        {
                            this.GrowCapacity(this.count + 1);
                        }
                    Label_00C0:
                        if (flag)
                        {
                            goto Label_009C;
                        }
                    }
                }
            }
        }

        public void AddRange(params T[] items)
        {
            Validate.IsNotNull<T[]>(items, "items");
            if (items.Length != 0)
            {
                this.GrowCapacity(this.count + items.Length);
                Array.Copy(items, 0, this.array, this.count, items.Length);
                this.count += items.Length;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
            this.count = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ClearAndTrim()
        {
            this.array = Array.Empty<T>();
            this.count = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(T item) => 
            (this.IndexOf(item) != -1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(this.array, 0, array, arrayIndex, this.count);
        }

        public void EnsureCapacity(int capacity)
        {
            if (capacity > this.array.Length)
            {
                Array.Resize<T>(ref this.array, capacity);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Get(int index)
        {
            if ((index < 0) || (index >= this.count))
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException("index", "0 <= index < count");
            }
            return this.GetUnchecked(index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetArray(out T[] array, out int count)
        {
            this.GetArrayReadOnly(out array, out count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetArrayReadOnly(out T[] array, out int count)
        {
            array = this.array;
            count = this.count;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Enumerator<T> GetEnumerator() => 
            new Enumerator<T>((UnsafeList<T>) this);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetUnchecked(int index) => 
            this.array[index];

        public void GrowCapacity(int minCapacity)
        {
            int length = this.array.Length;
            if (length <= 0)
            {
                length = 1;
            }
            while (length <= minCapacity)
            {
                length = Math.Max(length + 1, (int) ((length * 3L) / 2L));
            }
            if (length < minCapacity)
            {
                length = minCapacity;
            }
            if (length != this.array.Length)
            {
                Array.Resize<T>(ref this.array, length);
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (UnsafeList<T>.comparer.Equals(item, this.array[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (this.count >= this.array.Length)
            {
                this.GrowCapacity(this.count + 1);
            }
            this.count++;
            Array.Copy(this.array, index, this.array, index + 1, this.count - index);
            this.array[index] = item;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ModifyByRef<TActionByRef>(int index, TActionByRef modifyAction) where TActionByRef: struct, IActionByRef<T>
        {
            if ((index < 0) || (index >= this.count))
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException("index", "0 <= index < count");
            }
            this.ModifyByRefUnchecked<TActionByRef>(index, modifyAction);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ModifyByRefUnchecked<TActionByRef>(int index, TActionByRef modifyAction) where TActionByRef: struct, IActionByRef<T>
        {
            modifyAction.Invoke(ref this.array[index]);
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
            this.RemoveRange(index, 1);
        }

        public void RemoveRange(int startIndex, int count)
        {
            Validate.Begin().IsRangeValid(this.Count, startIndex, count, "this").Check();
            if (count != 0)
            {
                this.count -= count;
                if (startIndex < this.count)
                {
                    Array.Copy(this.array, startIndex + count, this.array, startIndex, this.count - startIndex);
                }
            }
        }

        public void Resize(int newCount, bool trimExcess, bool zeroExcess)
        {
            Validate.IsNotNegative(newCount, "newCount");
            if (newCount != this.count)
            {
                if (newCount < this.count)
                {
                    if (zeroExcess)
                    {
                        Array.Clear(this.array, newCount, this.count - newCount);
                    }
                    this.count = newCount;
                    if (trimExcess)
                    {
                        this.TrimExcess();
                    }
                }
                else if (newCount <= this.array.Length)
                {
                    this.count = newCount;
                }
                else
                {
                    this.GrowCapacity(newCount);
                    this.count = newCount;
                }
            }
        }

        public void Set(int index, T value)
        {
            if (index < 0)
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException("index", "0 <= index");
            }
            if (index >= this.array.Length)
            {
                this.GrowCapacity(index + 1);
            }
            this.array[index] = value;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => 
            this.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        public T[] ToArray()
        {
            if (this.count == 0)
            {
                return Array.Empty<T>();
            }
            T[] destinationArray = new T[this.count];
            Array.Copy(this.array, destinationArray, this.count);
            return destinationArray;
        }

        public void TrimExcess()
        {
            if (this.count == 0)
            {
                this.array = Array.Empty<T>();
            }
            else if (this.count < (this.array.Length - (this.array.Length / 10)))
            {
                Array.Resize<T>(ref this.array, this.count);
            }
        }

        public int Capacity =>
            this.array.Length;

        public int Count
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.count;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                Validate.IsNotNegative(value, "value");
                this.Resize(value, false, false);
            }
        }

        public bool IsReadOnly =>
            false;

        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.Get(index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.Set(index, value);
            }
        }

        public T[] UnsafeArray =>
            this.array;

        [StructLayout(LayoutKind.Sequential)]
        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private UnsafeList<T> source;
            private int currentIndex;
            internal Enumerator(UnsafeList<T> source)
            {
                this.source = source;
                this.currentIndex = -1;
            }

            public T Current =>
                this.source.GetUnchecked(this.currentIndex);
            public void Dispose()
            {
                this.source = null;
            }

            object IEnumerator.Current =>
                this.Current;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
            {
                if (this.source == null)
                {
                    return false;
                }
                this.currentIndex++;
                return (this.currentIndex < this.source.Count);
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}

