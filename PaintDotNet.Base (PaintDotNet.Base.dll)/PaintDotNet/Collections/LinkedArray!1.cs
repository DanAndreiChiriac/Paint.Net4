namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public sealed class LinkedArray<T> : ICollection<T>, IEnumerable<T>, IEnumerable
    {
        private static readonly EqualityComparer<T> comparer;
        private int count;
        private int? freeHeadIndex;
        private int? headIndex;
        private Node<T>[] nodes;
        private const int nullIndex = -1;
        private int? tailIndex;
        private int version;

        static LinkedArray()
        {
            LinkedArray<T>.comparer = EqualityComparer<T>.Default;
        }

        public LinkedArray()
        {
            this.nodes = Array.Empty<Node<T>>();
        }

        public LinkedArray(IEnumerable<T> items)
        {
            this.nodes = Array.Empty<Node<T>>();
            this.AddRange<T>(items);
        }

        public int AddFirst(T value)
        {
            int num = this.AllocateIndex();
            if (!this.headIndex.HasValue && !this.tailIndex.HasValue)
            {
                this.headIndex = new int?(num);
                this.tailIndex = new int?(num);
                int? previousIndex = null;
                this.nodes[num] = new Node<T>(value, previousIndex, null);
                return num;
            }
            int valueOrDefault = this.headIndex.GetValueOrDefault();
            Node<T> node = this.nodes[valueOrDefault];
            this.nodes[valueOrDefault] = new Node<T>(node.Value, new int?(num), node.NextIndex);
            this.nodes[num] = new Node<T>(value, null, new int?(valueOrDefault));
            this.headIndex = new int?(num);
            return num;
        }

        public int AddLast(T value)
        {
            int num = this.AllocateIndex();
            if (!this.headIndex.HasValue && !this.tailIndex.HasValue)
            {
                this.headIndex = new int?(num);
                this.tailIndex = new int?(num);
                int? previousIndex = null;
                this.nodes[num] = new Node<T>(value, previousIndex, null);
                return num;
            }
            int valueOrDefault = this.tailIndex.GetValueOrDefault();
            Node<T> node = this.nodes[valueOrDefault];
            this.nodes[valueOrDefault] = new Node<T>(node.Value, node.PreviousIndex, new int?(num));
            this.nodes[num] = new Node<T>(value, new int?(valueOrDefault), null);
            this.tailIndex = new int?(num);
            return num;
        }

        private int AllocateIndex()
        {
            int count;
            this.IncrementVersion();
            if (this.freeHeadIndex.HasValue)
            {
                int valueOrDefault = this.freeHeadIndex.GetValueOrDefault();
                this.freeHeadIndex = this.nodes[valueOrDefault].NextIndex;
                count = valueOrDefault;
            }
            else
            {
                if (this.count == this.nodes.Length)
                {
                    this.EnsureCapacity(this.nodes.Length + 1);
                }
                count = this.count;
            }
            this.count++;
            return count;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Any() => 
            (this.count > 0);

        public void Clear()
        {
            Array.Clear(this.nodes, 0, this.nodes.Length);
            this.headIndex = null;
            this.tailIndex = null;
            this.count = 0;
            this.IncrementVersion();
        }

        public bool Contains(T item) => 
            this.Contains<T>(item, null);

        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T> node;
            for (int? nullable = this.headIndex; nullable.HasValue; nullable = node.NextIndex)
            {
                node = this.nodes[nullable.GetValueOrDefault()];
                array[arrayIndex] = node.Value;
                arrayIndex++;
            }
        }

        private void EnsureCapacity(int min)
        {
            if (this.nodes.Length < min)
            {
                int num = (this.nodes.Length == 0) ? 4 : (this.nodes.Length * 2);
                if (num < min)
                {
                    num = min;
                }
                this.Capacity = num;
            }
        }

        private void FreeIndex(int index)
        {
            this.IncrementVersion();
            this.nodes[index] = new Node<T>(default(T), null, this.freeHeadIndex);
            this.freeHeadIndex = new int?(index);
            this.count--;
        }

        public Enumerator<T> GetEnumerator() => 
            new Enumerator<T>((LinkedArray<T>) this);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LinkedArrayNode<T> GetNode(int index) => 
            this.nodes[index].ToLinkedArrayNode(index);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetValue(int index) => 
            this.nodes[index].Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void IncrementVersion()
        {
            this.version++;
        }

        public bool Remove(T item)
        {
            Node<T> node;
            for (int? nullable = this.headIndex; nullable.HasValue; nullable = node.NextIndex)
            {
                node = this.nodes[nullable.GetValueOrDefault()];
                if (LinkedArray<T>.comparer.Equals(item, node.Value))
                {
                    this.RemoveAt(nullable.GetValueOrDefault());
                    return true;
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (this.count == 0)
            {
                ExceptionUtil.ThrowInvalidOperationException();
            }
            Node<T> node = this.nodes[index];
            if (node.PreviousIndex.HasValue)
            {
                int valueOrDefault = node.PreviousIndex.GetValueOrDefault();
                Node<T> node2 = this.nodes[valueOrDefault];
                this.nodes[valueOrDefault] = new Node<T>(node2.Value, node2.PreviousIndex, node.NextIndex);
            }
            else
            {
                this.headIndex = node.NextIndex;
            }
            if (node.NextIndex.HasValue)
            {
                int num2 = node.NextIndex.GetValueOrDefault();
                Node<T> node3 = this.nodes[num2];
                this.nodes[num2] = new Node<T>(node3.Value, node.PreviousIndex, node3.NextIndex);
            }
            else
            {
                this.tailIndex = node.PreviousIndex;
            }
            this.FreeIndex(index);
        }

        public void RemoveFirst()
        {
            if (this.count == 0)
            {
                ExceptionUtil.ThrowInvalidOperationException();
            }
            int valueOrDefault = this.headIndex.GetValueOrDefault();
            if (this.count == 1)
            {
                this.FreeIndex(valueOrDefault);
                this.headIndex = null;
                this.tailIndex = null;
            }
            else
            {
                Node<T> node = this.nodes[valueOrDefault];
                int index = node.NextIndex.GetValueOrDefault();
                Node<T> node2 = this.nodes[index];
                this.FreeIndex(valueOrDefault);
                this.nodes[index] = new Node<T>(node2.Value, null, node2.NextIndex);
                this.headIndex = new int?(index);
            }
        }

        public void RemoveLast()
        {
            if (this.count == 0)
            {
                ExceptionUtil.ThrowInvalidOperationException();
            }
            int valueOrDefault = this.tailIndex.GetValueOrDefault();
            if (this.count == 1)
            {
                this.FreeIndex(valueOrDefault);
                this.headIndex = null;
                this.tailIndex = null;
            }
            else
            {
                Node<T> node = this.nodes[valueOrDefault];
                int index = node.PreviousIndex.GetValueOrDefault();
                Node<T> node2 = this.nodes[index];
                this.FreeIndex(index);
                this.nodes[index] = new Node<T>(node2.Value, node2.PreviousIndex, null);
                this.tailIndex = new int?(index);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetValue(int index, T value)
        {
            this.nodes[index].Value = value;
            this.IncrementVersion();
        }

        void ICollection<T>.Add(T item)
        {
            this.AddLast(item);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => 
            this.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void VerifyVersion(int version)
        {
            if (version != this.version)
            {
                ExceptionUtil.ThrowInvalidOperationException();
            }
        }

        public int Capacity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.nodes.Length;
            set
            {
                if (value < this.count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (value != this.nodes.Length)
                {
                    if (value > 0)
                    {
                        Array.Resize<Node<T>>(ref this.nodes, value);
                    }
                    else
                    {
                        this.nodes = Array.Empty<Node<T>>();
                    }
                }
            }
        }

        public int Count =>
            this.count;

        public LinkedArrayNode<T> First
        {
            get
            {
                if (!this.headIndex.HasValue)
                {
                    ExceptionUtil.ThrowInvalidOperationException();
                }
                int valueOrDefault = this.headIndex.GetValueOrDefault();
                return this.nodes[valueOrDefault].ToLinkedArrayNode(valueOrDefault);
            }
        }

        public bool IsReadOnly =>
            false;

        public LinkedArrayNode<T> Last
        {
            get
            {
                if (!this.tailIndex.HasValue)
                {
                    ExceptionUtil.ThrowInvalidOperationException();
                }
                int valueOrDefault = this.tailIndex.GetValueOrDefault();
                return this.nodes[valueOrDefault].ToLinkedArrayNode(valueOrDefault);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private LinkedArray<T> source;
            private T current;
            private int? index;
            private int version;
            public Enumerator(LinkedArray<T> source)
            {
                this.source = source;
                this.current = default(T);
                this.index = source.headIndex;
                this.version = this.source.version;
            }

            public T Current =>
                this.current;
            public void Dispose()
            {
                this.source = null;
                this.current = default(T);
                this.index = null;
            }

            object IEnumerator.Current =>
                this.current;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
            {
                this.source.VerifyVersion(this.version);
                if (!this.index.HasValue)
                {
                    return false;
                }
                LinkedArray<T>.Node node = this.source.nodes[this.index.GetValueOrDefault()];
                this.current = node.Value;
                this.index = node.NextIndex;
                return true;
            }

            public void Reset()
            {
                throw new InvalidOperationException();
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Node
        {
            private T value;
            private int previousIndex;
            private int nextIndex;
            public T Value
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => 
                    this.value;
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                set
                {
                    this.value = value;
                }
            }
            public int? PreviousIndex
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (this.previousIndex != -1)
                    {
                        return new int?(this.previousIndex);
                    }
                    return null;
                }
                set
                {
                    this.previousIndex = value.HasValue ? value.GetValueOrDefault() : -1;
                }
            }
            public int? NextIndex
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (this.nextIndex != -1)
                    {
                        return new int?(this.nextIndex);
                    }
                    return null;
                }
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                set
                {
                    this.nextIndex = value.HasValue ? value.GetValueOrDefault() : -1;
                }
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Node(T value, int? previousIndex, int? nextIndex)
            {
                this.value = value;
                this.previousIndex = previousIndex.HasValue ? previousIndex.GetValueOrDefault() : -1;
                this.nextIndex = nextIndex.HasValue ? nextIndex.GetValueOrDefault() : -1;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public LinkedArrayNode<T> ToLinkedArrayNode(int index) => 
                new LinkedArrayNode<T>(this.value, index, this.PreviousIndex, this.NextIndex);
        }
    }
}

