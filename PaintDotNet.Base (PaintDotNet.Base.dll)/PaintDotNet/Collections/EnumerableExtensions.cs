namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class EnumerableExtensions
    {
        public static bool AllDefaultOrEmpty<T>(this IEnumerable<T> list)
        {
            DefaultValueComparer<T> instance = DefaultValueComparer<T>.Instance;
            foreach (T local in list)
            {
                if (!instance.IsDefaultValue(ref local))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AllNonDefaultOrEmpty<T>(this IEnumerable<T> list)
        {
            DefaultValueComparer<T> instance = DefaultValueComparer<T>.Instance;
            foreach (T local in list)
            {
                if (instance.IsDefaultValue(ref local))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AnyNull<T>(this IEnumerable<T> list) where T: class
        {
            using (IEnumerator<T> enumerator = list.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current == null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static T[] AsArrayOrToArray<T>(this IEnumerable<T> source)
        {
            Validate.IsNotNull<IEnumerable<T>>(source, "source");
            T[] localArray = source as T[];
            if (localArray != null)
            {
                return localArray;
            }
            return source.ToArrayEx<T>();
        }

        public static IEnumerable<T> AsItemsOrEmpty<T>(this IEnumerable<T> source) => 
            (source ?? Array.Empty<T>());

        [IteratorStateMachine(typeof(<Concat>d__9))]
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> head, T tail)
        {
            using (this.<>7__wrap1 = head.GetEnumerator())
            {
                while (this.<>7__wrap1.MoveNext())
                {
                    T current = this.<>7__wrap1.Current;
                    yield return current;
                }
            }
            this.<>7__wrap1 = null;
            yield return tail;
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<T> head, params T[] tails)
        {
            Validate.Begin().IsNotNull<IEnumerable<T>>(head, "head").IsNotNull<T[]>(tails, "tails").Check();
            return head.Concat<T>(tails);
        }

        public static EnumerableConvertQuery<T> Convert<T>(this IEnumerable<T> items) => 
            new EnumerableConvertQuery<T>(items);

        [IteratorStateMachine(typeof(<Convert>d__24))]
        public static IEnumerable<TResult> Convert<T, TResult>(this IEnumerable<T> items) where T: IConvertibleTo<TResult> => 
            new <Convert>d__24<T, TResult>(-2) { <>3__items = items };

        public static IEnumerable<T> Except<T>(this IEnumerable<T> items, params T[] excluded) => 
            items.Except<T>(excluded);

        public static int FirstIndexWhere<T>(this IEnumerable<T> items, Func<T, bool> selector)
        {
            int num = 0;
            foreach (T local in items)
            {
                if (selector(local))
                {
                    return num;
                }
                num++;
            }
            return -1;
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (T local in items)
            {
                action(local);
            }
        }

        public static int IndexOf<T>(this IEnumerable<T> items, Predicate<T> match)
        {
            int num = 0;
            foreach (T local in items)
            {
                if (match(local))
                {
                    return num;
                }
                num++;
            }
            return -1;
        }

        public static int IndexOf<T>(this IEnumerable<T> items, T value)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            return items.IndexOf<T>(value, comparer);
        }

        public static int IndexOf<T>(this IEnumerable<T> items, T value, IEqualityComparer<T> comparer)
        {
            Validate.Begin().IsNotNull<IEnumerable<T>>(items, "items").IsNotNull<IEqualityComparer<T>>(comparer, "comparer").Check();
            int num = 0;
            foreach (T local in items)
            {
                if (comparer.Equals(local, value))
                {
                    return num;
                }
                num++;
            }
            return -1;
        }

        public static bool InductiveAllWeak<T>(this IEnumerable<T> list, Func<T, T, bool> prevNextPredicate)
        {
            using (IEnumerator<T> enumerator = list.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    T current;
                    for (T local = enumerator.Current; enumerator.MoveNext(); local = current)
                    {
                        current = enumerator.Current;
                        if (!prevNextPredicate(local, current))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        [IteratorStateMachine(typeof(<NotOfType>d__19))]
        public static IEnumerable<TInput> NotOfType<TInput, TNotResult>(this IEnumerable<TInput> items) => 
            new <NotOfType>d__19<TInput, TNotResult>(-2) { <>3__items = items };

        public static IEnumerable<T> OrderBySelf<T>(this IEnumerable<T> items) => 
            (from x in items
                orderby x
                select x);

        [IteratorStateMachine(typeof(<Select>d__23))]
        public static IEnumerable<TResult> Select<T, TResult, TSelector>(this IEnumerable<T> items, TSelector selector) where TSelector: IFunc<T, TResult> => 
            new <Select>d__23<T, TResult, TSelector>(-2) { 
                <>3__items = items,
                <>3__selector = selector
            };

        [IteratorStateMachine(typeof(<SelectMany>d__16))]
        public static IEnumerable<T> SelectMany<T>(this IEnumerable<IEnumerable<T>> items2D) => 
            new <SelectMany>d__16<T>(-2) { <>3__items2D = items2D };

        public static IEnumerable<T> SequentialDistinct<T>(this IEnumerable<T> items) => 
            items.SequentialDistinct<T>(EqualityComparer<T>.Default);

        [IteratorStateMachine(typeof(<SequentialDistinct>d__30))]
        public static IEnumerable<T> SequentialDistinct<T>(this IEnumerable<T> items, IEqualityComparer<T> comparer) => 
            new <SequentialDistinct>d__30<T>(-2) { 
                <>3__items = items,
                <>3__comparer = comparer
            };

        public static T[] ToArrayEx<T>(this IEnumerable<T> items) => 
            ArrayUtil.GetArrayOrEmptySingleton<T>(items.TryToArrayEfficiently<T>() ?? items.ToArray<T>());

        public static void ToArrayNonTrimmed<T>(this IEnumerable<T> items, out T[] array, out int count)
        {
            array = items.TryToArrayEfficiently<T>();
            if (array != null)
            {
                count = array.Length;
            }
            else
            {
                array = Array.Empty<T>();
                count = 0;
                using (IEnumerator<T> enumerator = items.GetEnumerator())
                {
                    if (!enumerator.MoveNext())
                    {
                        return;
                    }
                    bool flag = true;
                    goto Label_0074;
                Label_0030:
                    array[count] = enumerator.Current;
                    count++;
                    flag = enumerator.MoveNext();
                Label_004C:
                    if (flag && (count < array.Length))
                    {
                        goto Label_0030;
                    }
                    if (flag)
                    {
                        Array.Resize<T>(ref array, MathUtil.Max(4, array.Length + 1, (array.Length * 3) / 2));
                    }
                Label_0074:
                    if (flag)
                    {
                        goto Label_004C;
                    }
                }
            }
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> items) => 
            items.ToDictionary<KeyValuePair<TKey, TValue>, TKey, TValue>(kv => kv.Key, kv => kv.Value);

        public static SegmentedList<T> ToSegmentedList<T>(this IEnumerable<T> items) => 
            items.ToSegmentedList<T>(7);

        public static SegmentedList<T> ToSegmentedList<T>(this IEnumerable<T> items, int segmentLengthLog2) => 
            new SegmentedList<T>(items, segmentLengthLog2);

        public static T[] TryToArrayEfficiently<T>(this IEnumerable<T> items)
        {
            ICollection<T> is2 = items as ICollection<T>;
            if ((is2 != null) && (is2.Count == 0))
            {
                return Array.Empty<T>();
            }
            IToArray<T> array = items as IToArray<T>;
            if (array != null)
            {
                return array.ToArray();
            }
            T[] localArray = items as T[];
            if (localArray != null)
            {
                T[] localArray2 = new T[localArray.Length];
                localArray.CopyTo(localArray2, 0);
                return localArray2;
            }
            ConcurrentBag<T> bag = items as ConcurrentBag<T>;
            if (bag != null)
            {
                return bag.ToArray();
            }
            ConcurrentQueue<T> queue = items as ConcurrentQueue<T>;
            if (queue != null)
            {
                return queue.ToArray();
            }
            ConcurrentStack<T> stack = items as ConcurrentStack<T>;
            if (stack != null)
            {
                return stack.ToArray();
            }
            Queue<T> queue2 = items as Queue<T>;
            if (queue2 != null)
            {
                return queue2.ToArray();
            }
            List<T> list = items as List<T>;
            if (list != null)
            {
                return list.ToArray();
            }
            Stack<T> stack2 = items as Stack<T>;
            if (stack2 != null)
            {
                return stack2.ToArray();
            }
            if (is2 != null)
            {
                T[] localArray3 = new T[is2.Count];
                is2.CopyTo(localArray3, 0);
                return localArray3;
            }
            return null;
        }

        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            Validate.Begin().IsNotNull<IEnumerable<T>>(items, "items").IsNotNull<Func<T, bool>>(predicate, "predicate").Check();
            return items.WhereNotImpl<T>(predicate);
        }

        [IteratorStateMachine(typeof(<WhereNotImpl>d__21))]
        private static IEnumerable<T> WhereNotImpl<T>(this IEnumerable<T> items, Func<T, bool> predicate) => 
            new <WhereNotImpl>d__21<T>(-2) { 
                <>3__items = items,
                <>3__predicate = predicate
            };

        [IteratorStateMachine(typeof(<WhereNotNull>d__22))]
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> items) where T: class => 
            new <WhereNotNull>d__22<T>(-2) { <>3__items = items };

        [Serializable, CompilerGenerated]
        private sealed class <>c__26<TKey, TValue>
        {
            public static readonly EnumerableExtensions.<>c__26<TKey, TValue> <>9;
            public static Func<KeyValuePair<TKey, TValue>, TKey> <>9__26_0;
            public static Func<KeyValuePair<TKey, TValue>, TValue> <>9__26_1;

            static <>c__26()
            {
                EnumerableExtensions.<>c__26<TKey, TValue>.<>9 = new EnumerableExtensions.<>c__26<TKey, TValue>();
            }

            internal TKey <ToDictionary>b__26_0(KeyValuePair<TKey, TValue> kv) => 
                kv.Key;

            internal TValue <ToDictionary>b__26_1(KeyValuePair<TKey, TValue> kv) => 
                kv.Value;
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c__28<T>
        {
            public static readonly EnumerableExtensions.<>c__28<T> <>9;
            public static Func<T, T> <>9__28_0;

            static <>c__28()
            {
                EnumerableExtensions.<>c__28<T>.<>9 = new EnumerableExtensions.<>c__28<T>();
            }

            internal T <OrderBySelf>b__28_0(T x) => 
                x;
        }

        [CompilerGenerated]
        private sealed class <Concat>d__9<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
        {
            private int <>1__state;
            private T <>2__current;
            public IEnumerable<T> <>3__head;
            public T <>3__tail;
            private IEnumerator<T> <>7__wrap1;
            private int <>l__initialThreadId;
            private IEnumerable<T> head;
            private T tail;

            [DebuggerHidden]
            public <Concat>d__9(int <>1__state)
            {
                this.<>1__state = <>1__state;
                this.<>l__initialThreadId = Environment.CurrentManagedThreadId;
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
                    T local;
                    switch (this.<>1__state)
                    {
                        case 0:
                            this.<>1__state = -1;
                            this.<>7__wrap1 = this.head.GetEnumerator();
                            this.<>1__state = -3;
                            goto Label_0068;

                        case 1:
                            this.<>1__state = -3;
                            goto Label_0068;

                        case 2:
                            this.<>1__state = -1;
                            return false;

                        default:
                            return false;
                    }
                Label_0042:
                    local = this.<>7__wrap1.Current;
                    this.<>2__current = local;
                    this.<>1__state = 1;
                    return true;
                Label_0068:
                    if (this.<>7__wrap1.MoveNext())
                    {
                        goto Label_0042;
                    }
                    this.<>m__Finally1();
                    this.<>7__wrap1 = null;
                    this.<>2__current = this.tail;
                    this.<>1__state = 2;
                    return true;
                }
                fault
                {
                    this.System.IDisposable.Dispose();
                }
            }

            [DebuggerHidden]
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                EnumerableExtensions.<Concat>d__9<T> d__;
                if ((this.<>1__state == -2) && (this.<>l__initialThreadId == Environment.CurrentManagedThreadId))
                {
                    this.<>1__state = 0;
                    d__ = (EnumerableExtensions.<Concat>d__9<T>) this;
                }
                else
                {
                    d__ = new EnumerableExtensions.<Concat>d__9<T>(0);
                }
                d__.head = this.<>3__head;
                d__.tail = this.<>3__tail;
                return d__;
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator() => 
                this.System.Collections.Generic.IEnumerable<T>.GetEnumerator();

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

        [CompilerGenerated]
        private sealed class <Convert>d__24<T, TResult> : IEnumerable<TResult>, IEnumerable, IEnumerator<TResult>, IDisposable, IEnumerator where T: IConvertibleTo<TResult>
        {
            private int <>1__state;
            private TResult <>2__current;
            public IEnumerable<T> <>3__items;
            private IEnumerator<T> <>7__wrap1;
            private int <>l__initialThreadId;
            private IEnumerable<T> items;

            [DebuggerHidden]
            public <Convert>d__24(int <>1__state)
            {
                this.<>1__state = <>1__state;
                this.<>l__initialThreadId = Environment.CurrentManagedThreadId;
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
                        this.<>7__wrap1 = this.items.GetEnumerator();
                        this.<>1__state = -3;
                        while (this.<>7__wrap1.MoveNext())
                        {
                            this.<>2__current = this.<>7__wrap1.Current.Convert();
                            this.<>1__state = 1;
                            return true;
                        Label_005E:
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
                    goto Label_005E;
                }
                fault
                {
                    this.System.IDisposable.Dispose();
                }
            }

            [DebuggerHidden]
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator()
            {
                EnumerableExtensions.<Convert>d__24<T, TResult> d__;
                if ((this.<>1__state == -2) && (this.<>l__initialThreadId == Environment.CurrentManagedThreadId))
                {
                    this.<>1__state = 0;
                    d__ = (EnumerableExtensions.<Convert>d__24<T, TResult>) this;
                }
                else
                {
                    d__ = new EnumerableExtensions.<Convert>d__24<T, TResult>(0);
                }
                d__.items = this.<>3__items;
                return d__;
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator() => 
                this.System.Collections.Generic.IEnumerable<TResult>.GetEnumerator();

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

            TResult IEnumerator<TResult>.Current =>
                this.<>2__current;

            object IEnumerator.Current =>
                this.<>2__current;
        }

        [CompilerGenerated]
        private sealed class <NotOfType>d__19<TInput, TNotResult> : IEnumerable<TInput>, IEnumerable, IEnumerator<TInput>, IDisposable, IEnumerator
        {
            private int <>1__state;
            private TInput <>2__current;
            public IEnumerable<TInput> <>3__items;
            private IEnumerator<TInput> <>7__wrap1;
            private int <>l__initialThreadId;
            private IEnumerable<TInput> items;

            [DebuggerHidden]
            public <NotOfType>d__19(int <>1__state)
            {
                this.<>1__state = <>1__state;
                this.<>l__initialThreadId = Environment.CurrentManagedThreadId;
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
                        this.<>7__wrap1 = this.items.GetEnumerator();
                        this.<>1__state = -3;
                        while (this.<>7__wrap1.MoveNext())
                        {
                            TInput current = this.<>7__wrap1.Current;
                            if (current is TNotResult)
                            {
                                continue;
                            }
                            this.<>2__current = current;
                            this.<>1__state = 1;
                            return true;
                        Label_005F:
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
                    goto Label_005F;
                }
                fault
                {
                    this.System.IDisposable.Dispose();
                }
            }

            [DebuggerHidden]
            IEnumerator<TInput> IEnumerable<TInput>.GetEnumerator()
            {
                EnumerableExtensions.<NotOfType>d__19<TInput, TNotResult> d__;
                if ((this.<>1__state == -2) && (this.<>l__initialThreadId == Environment.CurrentManagedThreadId))
                {
                    this.<>1__state = 0;
                    d__ = (EnumerableExtensions.<NotOfType>d__19<TInput, TNotResult>) this;
                }
                else
                {
                    d__ = new EnumerableExtensions.<NotOfType>d__19<TInput, TNotResult>(0);
                }
                d__.items = this.<>3__items;
                return d__;
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator() => 
                this.System.Collections.Generic.IEnumerable<TInput>.GetEnumerator();

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

            TInput IEnumerator<TInput>.Current =>
                this.<>2__current;

            object IEnumerator.Current =>
                this.<>2__current;
        }

        [CompilerGenerated]
        private sealed class <Select>d__23<T, TResult, TSelector> : IEnumerable<TResult>, IEnumerable, IEnumerator<TResult>, IDisposable, IEnumerator where TSelector: IFunc<T, TResult>
        {
            private int <>1__state;
            private TResult <>2__current;
            public IEnumerable<T> <>3__items;
            public TSelector <>3__selector;
            private IEnumerator<T> <>7__wrap1;
            private int <>l__initialThreadId;
            private IEnumerable<T> items;
            private TSelector selector;

            [DebuggerHidden]
            public <Select>d__23(int <>1__state)
            {
                this.<>1__state = <>1__state;
                this.<>l__initialThreadId = Environment.CurrentManagedThreadId;
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
                        this.<>7__wrap1 = this.items.GetEnumerator();
                        this.<>1__state = -3;
                        while (this.<>7__wrap1.MoveNext())
                        {
                            T current = this.<>7__wrap1.Current;
                            this.<>2__current = this.selector.Invoke(current);
                            this.<>1__state = 1;
                            return true;
                        Label_0063:
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
                    goto Label_0063;
                }
                fault
                {
                    this.System.IDisposable.Dispose();
                }
            }

            [DebuggerHidden]
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator()
            {
                EnumerableExtensions.<Select>d__23<T, TResult, TSelector> d__;
                if ((this.<>1__state == -2) && (this.<>l__initialThreadId == Environment.CurrentManagedThreadId))
                {
                    this.<>1__state = 0;
                    d__ = (EnumerableExtensions.<Select>d__23<T, TResult, TSelector>) this;
                }
                else
                {
                    d__ = new EnumerableExtensions.<Select>d__23<T, TResult, TSelector>(0);
                }
                d__.items = this.<>3__items;
                d__.selector = this.<>3__selector;
                return d__;
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator() => 
                this.System.Collections.Generic.IEnumerable<TResult>.GetEnumerator();

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

            TResult IEnumerator<TResult>.Current =>
                this.<>2__current;

            object IEnumerator.Current =>
                this.<>2__current;
        }

        [CompilerGenerated]
        private sealed class <SelectMany>d__16<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
        {
            private int <>1__state;
            private T <>2__current;
            public IEnumerable<IEnumerable<T>> <>3__items2D;
            private IEnumerator<IEnumerable<T>> <>7__wrap1;
            private IEnumerator<T> <>7__wrap2;
            private int <>l__initialThreadId;
            private IEnumerable<IEnumerable<T>> items2D;

            [DebuggerHidden]
            public <SelectMany>d__16(int <>1__state)
            {
                this.<>1__state = <>1__state;
                this.<>l__initialThreadId = Environment.CurrentManagedThreadId;
            }

            private void <>m__Finally1()
            {
                this.<>1__state = -1;
                if (this.<>7__wrap1 != null)
                {
                    this.<>7__wrap1.Dispose();
                }
            }

            private void <>m__Finally2()
            {
                this.<>1__state = -3;
                if (this.<>7__wrap2 != null)
                {
                    this.<>7__wrap2.Dispose();
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
                        this.<>7__wrap1 = this.items2D.GetEnumerator();
                        this.<>1__state = -3;
                        while (this.<>7__wrap1.MoveNext())
                        {
                            this.<>7__wrap2 = this.<>7__wrap1.Current.GetEnumerator();
                            this.<>1__state = -4;
                            while (this.<>7__wrap2.MoveNext())
                            {
                                T current = this.<>7__wrap2.Current;
                                this.<>2__current = current;
                                this.<>1__state = 1;
                                return true;
                            Label_0077:
                                this.<>1__state = -4;
                            }
                            this.<>m__Finally2();
                            this.<>7__wrap2 = null;
                        }
                        this.<>m__Finally1();
                        this.<>7__wrap1 = null;
                        return false;
                    }
                    if (num != 1)
                    {
                        return false;
                    }
                    goto Label_0077;
                }
                fault
                {
                    this.System.IDisposable.Dispose();
                }
            }

            [DebuggerHidden]
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                EnumerableExtensions.<SelectMany>d__16<T> d__;
                if ((this.<>1__state == -2) && (this.<>l__initialThreadId == Environment.CurrentManagedThreadId))
                {
                    this.<>1__state = 0;
                    d__ = (EnumerableExtensions.<SelectMany>d__16<T>) this;
                }
                else
                {
                    d__ = new EnumerableExtensions.<SelectMany>d__16<T>(0);
                }
                d__.items2D = this.<>3__items2D;
                return d__;
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator() => 
                this.System.Collections.Generic.IEnumerable<T>.GetEnumerator();

            [DebuggerHidden]
            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            [DebuggerHidden]
            void IDisposable.Dispose()
            {
                int num = this.<>1__state;
                switch (num)
                {
                    case -4:
                    case -3:
                    case 1:
                        try
                        {
                            switch (num)
                            {
                                case -4:
                                case 1:
                                    try
                                    {
                                    }
                                    finally
                                    {
                                        this.<>m__Finally2();
                                    }
                                    break;
                            }
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

        [CompilerGenerated]
        private sealed class <SequentialDistinct>d__30<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
        {
            private int <>1__state;
            private T <>2__current;
            public IEqualityComparer<T> <>3__comparer;
            public IEnumerable<T> <>3__items;
            private int <>l__initialThreadId;
            private T <item>5__3;
            private IEnumerator<T> <itemsEnum>5__1;
            private T <lastItem>5__2;
            private IEqualityComparer<T> comparer;
            private IEnumerable<T> items;

            [DebuggerHidden]
            public <SequentialDistinct>d__30(int <>1__state)
            {
                this.<>1__state = <>1__state;
                this.<>l__initialThreadId = Environment.CurrentManagedThreadId;
            }

            private void <>m__Finally1()
            {
                this.<>1__state = -1;
                if (this.<itemsEnum>5__1 != null)
                {
                    this.<itemsEnum>5__1.Dispose();
                }
            }

            private bool MoveNext()
            {
                try
                {
                    bool flag;
                    switch (this.<>1__state)
                    {
                        case 0:
                            this.<>1__state = -1;
                            this.<itemsEnum>5__1 = this.items.GetEnumerator();
                            this.<>1__state = -3;
                            if (this.<itemsEnum>5__1.MoveNext())
                            {
                                break;
                            }
                            flag = false;
                            goto Label_010B;

                        case 1:
                            this.<>1__state = -3;
                            goto Label_00EA;

                        case 2:
                            goto Label_00CA;

                        default:
                            return false;
                    }
                    this.<lastItem>5__2 = this.<itemsEnum>5__1.Current;
                    this.<>2__current = this.<lastItem>5__2;
                    this.<>1__state = 1;
                    return true;
                Label_0089:
                    this.<item>5__3 = this.<itemsEnum>5__1.Current;
                    if (this.comparer.Equals(this.<lastItem>5__2, this.<item>5__3))
                    {
                        goto Label_00D2;
                    }
                    this.<>2__current = this.<item>5__3;
                    this.<>1__state = 2;
                    return true;
                Label_00CA:
                    this.<>1__state = -3;
                Label_00D2:
                    this.<lastItem>5__2 = this.<item>5__3;
                    this.<item>5__3 = default(T);
                Label_00EA:
                    if (this.<itemsEnum>5__1.MoveNext())
                    {
                        goto Label_0089;
                    }
                    this.<lastItem>5__2 = default(T);
                    this.<>m__Finally1();
                    goto Label_0113;
                Label_010B:
                    this.<>m__Finally1();
                    return flag;
                Label_0113:
                    this.<itemsEnum>5__1 = null;
                    return false;
                }
                fault
                {
                    this.System.IDisposable.Dispose();
                }
            }

            [DebuggerHidden]
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                EnumerableExtensions.<SequentialDistinct>d__30<T> d__;
                if ((this.<>1__state == -2) && (this.<>l__initialThreadId == Environment.CurrentManagedThreadId))
                {
                    this.<>1__state = 0;
                    d__ = (EnumerableExtensions.<SequentialDistinct>d__30<T>) this;
                }
                else
                {
                    d__ = new EnumerableExtensions.<SequentialDistinct>d__30<T>(0);
                }
                d__.items = this.<>3__items;
                d__.comparer = this.<>3__comparer;
                return d__;
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator() => 
                this.System.Collections.Generic.IEnumerable<T>.GetEnumerator();

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
                    case 2:
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

        [CompilerGenerated]
        private sealed class <WhereNotImpl>d__21<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
        {
            private int <>1__state;
            private T <>2__current;
            public IEnumerable<T> <>3__items;
            public Func<T, bool> <>3__predicate;
            private IEnumerator<T> <>7__wrap1;
            private int <>l__initialThreadId;
            private IEnumerable<T> items;
            private Func<T, bool> predicate;

            [DebuggerHidden]
            public <WhereNotImpl>d__21(int <>1__state)
            {
                this.<>1__state = <>1__state;
                this.<>l__initialThreadId = Environment.CurrentManagedThreadId;
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
                        this.<>7__wrap1 = this.items.GetEnumerator();
                        this.<>1__state = -3;
                        while (this.<>7__wrap1.MoveNext())
                        {
                            T current = this.<>7__wrap1.Current;
                            if (this.predicate(current))
                            {
                                continue;
                            }
                            this.<>2__current = current;
                            this.<>1__state = 1;
                            return true;
                        Label_0060:
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
                    goto Label_0060;
                }
                fault
                {
                    this.System.IDisposable.Dispose();
                }
            }

            [DebuggerHidden]
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                EnumerableExtensions.<WhereNotImpl>d__21<T> d__;
                if ((this.<>1__state == -2) && (this.<>l__initialThreadId == Environment.CurrentManagedThreadId))
                {
                    this.<>1__state = 0;
                    d__ = (EnumerableExtensions.<WhereNotImpl>d__21<T>) this;
                }
                else
                {
                    d__ = new EnumerableExtensions.<WhereNotImpl>d__21<T>(0);
                }
                d__.items = this.<>3__items;
                d__.predicate = this.<>3__predicate;
                return d__;
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator() => 
                this.System.Collections.Generic.IEnumerable<T>.GetEnumerator();

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

        [CompilerGenerated]
        private sealed class <WhereNotNull>d__22<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator where T: class
        {
            private int <>1__state;
            private T <>2__current;
            public IEnumerable<T> <>3__items;
            private IEnumerator<T> <>7__wrap1;
            private int <>l__initialThreadId;
            private IEnumerable<T> items;

            [DebuggerHidden]
            public <WhereNotNull>d__22(int <>1__state)
            {
                this.<>1__state = <>1__state;
                this.<>l__initialThreadId = Environment.CurrentManagedThreadId;
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
                        Validate.IsNotNull<IEnumerable<T>>(this.items, "items");
                        this.<>7__wrap1 = this.items.GetEnumerator();
                        this.<>1__state = -3;
                        while (this.<>7__wrap1.MoveNext())
                        {
                            T current = this.<>7__wrap1.Current;
                            if (current.IsNullReference<T>())
                            {
                                continue;
                            }
                            this.<>2__current = current;
                            this.<>1__state = 1;
                            return true;
                        Label_006E:
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
                    goto Label_006E;
                }
                fault
                {
                    this.System.IDisposable.Dispose();
                }
            }

            [DebuggerHidden]
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                EnumerableExtensions.<WhereNotNull>d__22<T> d__;
                if ((this.<>1__state == -2) && (this.<>l__initialThreadId == Environment.CurrentManagedThreadId))
                {
                    this.<>1__state = 0;
                    d__ = (EnumerableExtensions.<WhereNotNull>d__22<T>) this;
                }
                else
                {
                    d__ = new EnumerableExtensions.<WhereNotNull>d__22<T>(0);
                }
                d__.items = this.<>3__items;
                return d__;
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator() => 
                this.System.Collections.Generic.IEnumerable<T>.GetEnumerator();

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

