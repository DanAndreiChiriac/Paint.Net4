namespace PaintDotNet.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public sealed class PriorityDequeDictionary<TPri, TKey, TValue>
    {
        private SortedList<TPri, LinkedList<KeyValuePair<TKey, TValue>>> deques;
        private SegmentedStack<LinkedList<KeyValuePair<TKey, TValue>>> freeDeques;
        private SegmentedStack<LinkedListNode<KeyValuePair<TKey, TValue>>> freeNodes;
        private Dictionary<TKey, PriorityAndNode<TPri, TKey, TValue>> keyMap;

        public PriorityDequeDictionary()
        {
            this.deques = new SortedList<TPri, LinkedList<KeyValuePair<TKey, TValue>>>();
            this.keyMap = new Dictionary<TKey, PriorityAndNode<TPri, TKey, TValue>>();
            this.freeDeques = new SegmentedStack<LinkedList<KeyValuePair<TKey, TValue>>>();
            this.freeNodes = new SegmentedStack<LinkedListNode<KeyValuePair<TKey, TValue>>>();
        }

        public bool Any() => 
            (this.keyMap.Count > 0);

        public bool ContainsKey(TKey key) => 
            this.keyMap.ContainsKey(key);

        private LinkedList<KeyValuePair<TKey, TValue>> GetDeque(TPri pri)
        {
            LinkedList<KeyValuePair<TKey, TValue>> list;
            if (!this.deques.TryGetValue(pri, out list))
            {
                if (this.freeDeques.Any())
                {
                    list = this.freeDeques.Pop();
                }
                else
                {
                    list = new LinkedList<KeyValuePair<TKey, TValue>>();
                }
                this.deques.Add(pri, list);
            }
            return list;
        }

        private LinkedListNode<KeyValuePair<TKey, TValue>> GetNode(KeyValuePair<TKey, TValue> item)
        {
            if (this.freeNodes.Any())
            {
                LinkedListNode<KeyValuePair<TKey, TValue>> node = this.freeNodes.Pop();
                node.Value = item;
                return node;
            }
            return new LinkedListNode<KeyValuePair<TKey, TValue>>(item);
        }

        private void RecycleDeque(LinkedList<KeyValuePair<TKey, TValue>> deque)
        {
            this.freeDeques.Push(deque);
        }

        private void RecycleNode(LinkedListNode<KeyValuePair<TKey, TValue>> node)
        {
            node.Value = new KeyValuePair<TKey, TValue>();
            this.freeNodes.Push(node);
        }

        public void TrimExcess()
        {
            this.freeDeques.Clear();
            this.freeDeques.TrimExcess();
            this.freeNodes.Clear();
            this.freeNodes.TrimExcess();
        }

        public bool TryDequeue(out KeyValuePair<TKey, TValue> item)
        {
            if (!this.Any())
            {
                item = new KeyValuePair<TKey, TValue>();
                return false;
            }
            TPri key = this.deques.Keys[0];
            LinkedList<KeyValuePair<TKey, TValue>> collection = this.deques.Values[0];
            LinkedListNode<KeyValuePair<TKey, TValue>> first = collection.First;
            item = first.Value;
            collection.RemoveFirst();
            this.keyMap.Remove(item.Key);
            this.RecycleNode(first);
            if (!collection.Any<KeyValuePair<TKey, TValue>>())
            {
                this.deques.Remove(key);
                this.RecycleDeque(collection);
            }
            return true;
        }

        public bool TryDequeueThenUpdateAndRequeueIf<TUpdateValueFactory, TRequeuePredicate>(out KeyValuePair<TKey, TValue> item, out bool wasRequeued) where TUpdateValueFactory: struct, IFunc<TValue, TValue> where TRequeuePredicate: struct, IFunc<TValue, bool>
        {
            if (!this.Any())
            {
                item = new KeyValuePair<TKey, TValue>();
                wasRequeued = false;
                return false;
            }
            TPri key = this.deques.Keys[0];
            LinkedList<KeyValuePair<TKey, TValue>> collection = this.deques.Values[0];
            LinkedListNode<KeyValuePair<TKey, TValue>> first = collection.First;
            item = first.Value;
            collection.RemoveFirst();
            TUpdateValueFactory local3 = default(TUpdateValueFactory);
            TValue local2 = local3.Invoke(item.Value);
            item = new KeyValuePair<TKey, TValue>(item.Key, local2);
            TRequeuePredicate local4 = default(TRequeuePredicate);
            if (local4.Invoke(local2))
            {
                first.Value = item;
                collection.AddLast(first);
                wasRequeued = true;
            }
            else
            {
                this.keyMap.Remove(item.Key);
                this.RecycleNode(first);
                if (!collection.Any<KeyValuePair<TKey, TValue>>())
                {
                    this.deques.Remove(key);
                    this.RecycleDeque(collection);
                }
                wasRequeued = false;
            }
            return true;
        }

        public bool TryEnqueue(TPri pri, TKey key, TValue value)
        {
            if (this.keyMap.ContainsKey(key))
            {
                return false;
            }
            LinkedListNode<KeyValuePair<TKey, TValue>> node = this.GetNode(new KeyValuePair<TKey, TValue>(key, value));
            this.GetDeque(pri).AddLast(node);
            this.keyMap.Add(key, new PriorityAndNode<TPri, TKey, TValue>(pri, node));
            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            PriorityAndNode<TPri, TKey, TValue> node;
            if (!this.keyMap.TryGetValue(key, out node))
            {
                value = default(TValue);
                return false;
            }
            value = node.Node.Value.Value;
            return true;
        }

        public bool TryRemove(TKey key, out TValue value)
        {
            PriorityAndNode<TPri, TKey, TValue> node;
            if (!this.keyMap.TryGetValue(key, out node))
            {
                value = default(TValue);
                return false;
            }
            value = node.Node.Value.Value;
            LinkedList<KeyValuePair<TKey, TValue>> deque = this.GetDeque(node.Pri);
            deque.Remove(node.Node);
            this.keyMap.Remove(key);
            this.RecycleNode(node.Node);
            if (!deque.Any<KeyValuePair<TKey, TValue>>())
            {
                this.deques.Remove(node.Pri);
                this.RecycleDeque(deque);
            }
            return true;
        }

        public bool TryUpdatePriority(TKey key, TPri newPri)
        {
            TValue local;
            return (this.TryRemove(key, out local) && this.TryEnqueue(newPri, key, local));
        }

        public bool TryUpdateValue(TKey key, TValue newValue)
        {
            PriorityAndNode<TPri, TKey, TValue> node;
            if (!this.keyMap.TryGetValue(key, out node))
            {
                return false;
            }
            node.Node.Value = new KeyValuePair<TKey, TValue>(key, newValue);
            return true;
        }

        public int Count =>
            this.keyMap.Count;

        [StructLayout(LayoutKind.Sequential)]
        private struct PriorityAndNode
        {
            private TPri pri;
            private LinkedListNode<KeyValuePair<TKey, TValue>> node;
            public TPri Pri =>
                this.pri;
            public LinkedListNode<KeyValuePair<TKey, TValue>> Node =>
                this.node;
            public PriorityAndNode(TPri pri, LinkedListNode<KeyValuePair<TKey, TValue>> node)
            {
                this.pri = pri;
                this.node = node;
            }
        }
    }
}

