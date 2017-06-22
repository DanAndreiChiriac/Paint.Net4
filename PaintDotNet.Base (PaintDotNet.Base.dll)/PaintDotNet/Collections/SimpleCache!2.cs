namespace PaintDotNet.Collections
{
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Functional;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading;

    public sealed class SimpleCache<TKey, TValue> : IFunc<TKey, TValue>
    {
        private const LazyThreadSafetyMode defaultMode = LazyThreadSafetyMode.None;
        private readonly ConcurrentDictionary<TKey, Lazy<TValue>> lazyCache;
        private readonly Func<TKey, Lazy<TValue>> lazyValueFactory;
        private readonly LazyThreadSafetyMode mode;
        private readonly Func<TKey, TValue> valueFactory;

        public SimpleCache(Func<TKey, TValue> valueFactory) : this(valueFactory, null, LazyThreadSafetyMode.None)
        {
        }

        public SimpleCache(Func<TKey, TValue> valueFactory, IEqualityComparer<TKey> keyComparer) : this(valueFactory, keyComparer, LazyThreadSafetyMode.None)
        {
        }

        public SimpleCache(Func<TKey, TValue> valueFactory, LazyThreadSafetyMode mode) : this(valueFactory, null, mode)
        {
        }

        public SimpleCache(Func<TKey, TValue> valueFactory, IEqualityComparer<TKey> keyComparer, LazyThreadSafetyMode mode)
        {
            Validate.IsNotNull<Func<TKey, TValue>>(valueFactory, "valueFactory");
            this.mode = mode;
            this.valueFactory = valueFactory;
            this.lazyValueFactory = key => new Lazy<TValue>(() => this.CreateValue(key), base.mode);
            if (keyComparer == null)
            {
                this.lazyCache = new ConcurrentDictionary<TKey, Lazy<TValue>>();
            }
            else
            {
                this.lazyCache = new ConcurrentDictionary<TKey, Lazy<TValue>>(keyComparer);
            }
        }

        public void Clear()
        {
            this.lazyCache.Clear();
        }

        public bool ClearValue(TKey key)
        {
            Lazy<TValue> lazy;
            return this.lazyCache.TryRemove(key, out lazy);
        }

        private TValue CreateValue(TKey key)
        {
            if (this.mode == LazyThreadSafetyMode.ExecutionAndPublication)
            {
                Func<TKey, Lazy<TValue>> lazyValueFactory = this.lazyValueFactory;
                lock (lazyValueFactory)
                {
                    return this.valueFactory(key);
                }
            }
            return this.valueFactory(key);
        }

        public TValue Get(TKey key) => 
            this.lazyCache.GetOrAdd(key, this.lazyValueFactory).Value;

        TValue IFunc<TKey, TValue>.Invoke(TKey key) => 
            this[key];

        public TValue this[TKey key] =>
            this.Get(key);
    }
}

