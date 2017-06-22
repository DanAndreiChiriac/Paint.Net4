namespace PaintDotNet.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public sealed class ConcurrentSet<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, IToArray<T>
    {
        private ConcurrentDictionary<T, object> items;

        public ConcurrentSet()
        {
            this.items = new ConcurrentDictionary<T, object>();
        }

        public ConcurrentSet(IEqualityComparer<T> comparer)
        {
            this.items = new ConcurrentDictionary<T, object>(comparer);
        }

        public bool Add(T item) => 
            this.items.TryAdd(item, null);

        public void Clear()
        {
            this.items.Clear();
        }

        public bool Contains(T item) => 
            this.items.ContainsKey(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.items.Keys.CopyTo(array, arrayIndex);
        }

        [IteratorStateMachine(typeof(<GetEnumerator>d__16))]
        public IEnumerator<T> GetEnumerator() => 
            new <GetEnumerator>d__16<T>(0) { <>4__this = (ConcurrentSet<T>) this };

        public bool Remove(T item) => 
            this.TryRemove(item);

        void ICollection<T>.Add(T item)
        {
            this.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator() => 
            this.items.Keys.GetEnumerator();

        public T[] ToArray() => 
            this.items.ToArray().Select<KeyValuePair<T, object>, T>(kvp => kvp.Key).ToArrayEx<T>();

        public bool TryAdd(T item) => 
            this.items.TryAdd(item, null);

        public bool TryRemove(T item)
        {
            object obj2;
            return this.items.TryRemove(item, out obj2);
        }

        public int Count =>
            this.items.Count;

        public bool IsReadOnly =>
            false;

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly ConcurrentSet<T>.<>c <>9;
            public static Func<KeyValuePair<T, object>, T> <>9__15_0;

            static <>c()
            {
                ConcurrentSet<T>.<>c.<>9 = new ConcurrentSet<T>.<>c();
            }

            internal T <ToArray>b__15_0(KeyValuePair<T, object> kvp) => 
                kvp.Key;
        }

        [CompilerGenerated]
        private sealed class <GetEnumerator>d__16 : IEnumerator<T>, IDisposable, IEnumerator
        {
            private int <>1__state;
            private T <>2__current;
            public ConcurrentSet<T> <>4__this;
            private IEnumerator<T> <>7__wrap1;

            [DebuggerHidden]
            public <GetEnumerator>d__16(int <>1__state)
            {
                this.<>1__state = <>1__state;
            }

            private void <>m__Finally1()
            {
                this.<>1__state = -1;
                if (this.<>7__wrap1 != null)
                {
                    this.<>7__wrap1.Dispose();
                }
            }

            private bool MoveNext()
            {
                try
                {
                    int num = this.<>1__state;
                    if (num == 0)
                    {
                        this.<>1__state = -1;
                        this.<>7__wrap1 = this.<>4__this.items.Keys.GetEnumerator();
                        this.<>1__state = -3;
                        while (this.<>7__wrap1.MoveNext())
                        {
                            T current = this.<>7__wrap1.Current;
                            this.<>2__current = current;
                            this.<>1__state = 1;
                            return true;
                        Label_005C:
                            this.<>1__state = -3;
                        }
                        this.<>m__Finally1();
                        this.<>7__wrap1 = null;
                        return false;
                    }
                    if (num != 1)
                    {
                        return false;
                    }
                    goto Label_005C;
                }
                fault
                {
                    this.System.IDisposable.Dispose();
                }
            }

            [DebuggerHidden]
            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            [DebuggerHidden]
            void IDisposable.Dispose()
            {
                switch (this.<>1__state)
                {
                    case -3:
                    case 1:
                        try
                        {
                        }
                        finally
                        {
                            this.<>m__Finally1();
                        }
                        break;
                }
            }

            T IEnumerator<T>.Current =>
                this.<>2__current;

            object IEnumerator.Current =>
                this.<>2__current;
        }
    }
}

