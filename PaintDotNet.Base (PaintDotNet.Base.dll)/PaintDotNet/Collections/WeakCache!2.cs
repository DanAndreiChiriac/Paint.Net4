namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Functional;
    using System;
    using System.Collections.Concurrent;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;

    public sealed class WeakCache<TKey, TValue> : IFunc<TKey, TValue> where TValue: class
    {
        private readonly ConcurrentSet<TKey> alwaysPinnedKeys;
        private readonly Action<TKey, TValue> cleanKeyValueCallback;
        private const LazyThreadSafetyMode defaultMode = LazyThreadSafetyMode.None;
        private readonly ConcurrentDictionary<TKey, Entry<TKey, TValue>> entries;
        private static readonly Func<TKey, Entry<TKey, TValue>> entryFactory;
        private readonly Func<TKey, TValue> valueFactory;

        static WeakCache()
        {
            WeakCache<TKey, TValue>.entryFactory = new Func<TKey, Entry<TKey, TValue>>(<>c<TKey, TValue>.<>9.<.cctor>b__21_0);
        }

        public WeakCache(Func<TKey, TValue> valueFactory) : this(valueFactory, null)
        {
        }

        public WeakCache(Func<TKey, TValue> valueFactory, Action<TKey, TValue> cleanKeyValueCallback)
        {
            Validate.IsNotNull<Func<TKey, TValue>>(valueFactory, "valueFactory");
            this.valueFactory = valueFactory;
            this.cleanKeyValueCallback = cleanKeyValueCallback;
            this.entries = new ConcurrentDictionary<TKey, Entry<TKey, TValue>>();
            this.alwaysPinnedKeys = new ConcurrentSet<TKey>();
        }

        public void AddAlwaysPinnedKey(TKey key)
        {
            lock (cache)
            {
                this.alwaysPinnedKeys.Add(key);
                if (this.ContainsKey(key))
                {
                    this.TryPin(key);
                }
            }
        }

        private void CleanEntryAfterRemoval(Entry<TKey, TValue> entry)
        {
            TValue local;
            if ((this.cleanKeyValueCallback != null) && entry.TryGet(out local))
            {
                this.cleanKeyValueCallback(entry.Key, local);
            }
        }

        public void Clear()
        {
            Entry<TKey, TValue>[] entryArray = null;
            lock (cache)
            {
                if (this.cleanKeyValueCallback != null)
                {
                    entryArray = this.entries.Values.ToArrayEx<Entry<TKey, TValue>>();
                }
                this.entries.Clear();
            }
            if (entryArray != null)
            {
                foreach (Entry<TKey, TValue> entry in entryArray)
                {
                    this.CleanEntryAfterRemoval(entry);
                }
            }
        }

        public bool ClearValue(TKey key)
        {
            bool flag;
            Entry<TKey, TValue> entry;
            lock (cache)
            {
                flag = this.entries.TryRemove(key, out entry);
            }
            if (flag)
            {
                this.CleanEntryAfterRemoval(entry);
            }
            return flag;
        }

        public bool ContainsKey(TKey key)
        {
            lock (cache)
            {
                return this.entries.ContainsKey(key);
            }
        }

        public TValue Get(TKey key)
        {
            lock (cache)
            {
                return this.entries.GetOrAdd(key, WeakCache<TKey, TValue>.entryFactory).GetOrCreate(this.valueFactory);
            }
        }

        TValue IFunc<TKey, TValue>.Invoke(TKey key) => 
            this[key];

        public void RemoveAlwaysPinnedKey(TKey key)
        {
            lock (cache)
            {
                this.alwaysPinnedKeys.Remove(key);
                if (this.ContainsKey(key))
                {
                    this.Unpin(key);
                }
            }
        }

        public bool TryPin(TKey key)
        {
            lock (cache)
            {
                Entry<TKey, TValue> entry;
                if (!this.entries.TryGetValue(key, out entry))
                {
                    return false;
                }
                return entry.TryPin();
            }
        }

        public void Unpin(TKey key)
        {
            lock (cache)
            {
                Entry<TKey, TValue> entry;
                if (this.entries.TryGetValue(key, out entry))
                {
                    entry.Unpin();
                }
            }
        }

        public TValue this[TKey key] =>
            this.Get(key);

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly WeakCache<TKey, TValue>.<>c <>9;

            static <>c()
            {
                WeakCache<TKey, TValue>.<>c.<>9 = new WeakCache<TKey, TValue>.<>c();
            }

            internal WeakCache<TKey, TValue>.Entry <.cctor>b__21_0(TKey key) => 
                new WeakCache<TKey, TValue>.Entry(key);
        }

        private sealed class Entry : IEquatable<WeakCache<TKey, TValue>.Entry>
        {
            private readonly TKey key;
            private TValue strongRef;
            private WeakReferenceT<TValue> weakRef;

            public Entry(TKey key)
            {
                this.key = key;
            }

            public bool Equals(WeakCache<TKey, TValue>.Entry other) => 
                ((other != null) && this.key.Equals(other.key));

            public override bool Equals(object obj) => 
                EquatableUtil.Equals<WeakCache<TKey, TValue>.Entry, object>((WeakCache<TKey, TValue>.Entry) this, obj);

            public override int GetHashCode() => 
                this.key.GetHashCode();

            public TValue GetOrCreate(Func<TKey, TValue> valueFactory)
            {
                TValue local;
                if (!this.TryGet(out local))
                {
                    local = valueFactory(this.key);
                    if (this.weakRef == null)
                    {
                        this.weakRef = new WeakReferenceT<TValue>(local);
                        return local;
                    }
                    this.weakRef.Target = local;
                }
                return local;
            }

            public bool TryGet(out TValue value)
            {
                value = this.strongRef;
                if (((TValue) value) != null)
                {
                    return true;
                }
                if (this.weakRef != null)
                {
                    value = this.weakRef.Target;
                    if ((((TValue) value) != null) && this.weakRef.IsAlive)
                    {
                        return true;
                    }
                    value = default(TValue);
                }
                return false;
            }

            public bool TryPin()
            {
                if (this.strongRef != null)
                {
                    return true;
                }
                if (this.weakRef != null)
                {
                    TValue target = this.weakRef.Target;
                    if ((target != null) && this.weakRef.IsAlive)
                    {
                        this.strongRef = target;
                        return true;
                    }
                }
                return false;
            }

            public void Unpin()
            {
                this.strongRef = default(TValue);
            }

            public TKey Key =>
                this.key;
        }
    }
}

