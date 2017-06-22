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

    internal sealed class ReadOnlyListFromSource<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>
    {
        private IListSource<T> source;

        public ReadOnlyListFromSource(IListSource<T> source)
        {
            Validate.IsNotNull<IListSource<T>>(source, "source");
            this.source = source;
        }

        public void Add(T item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(T item)
        {
            using (this.source.UseVersionScope<T>())
            {
                return this.source.List.Contains(item);
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            using (this.source.UseVersionScope<T>())
            {
                this.source.List.CopyTo(array, arrayIndex);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int version = this.source.Version;
            return this.GetEnumerator(this.source.List, version);
        }

        [IteratorStateMachine(typeof(<GetEnumerator>d__18))]
        private IEnumerator<T> GetEnumerator(IList<T> items, int version) => 
            new <GetEnumerator>d__18<T>(0) { 
                <>4__this = (ReadOnlyListFromSource<T>) this,
                version = version
            };

        public int IndexOf(T item)
        {
            using (this.source.UseVersionScope<T>())
            {
                return this.source.List.IndexOf(item);
            }
        }

        public void Insert(int index, T item)
        {
            throw new NotSupportedException();
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        public int Count =>
            this.source.List.Count;

        public bool IsReadOnly =>
            true;

        public T this[int index]
        {
            get
            {
                using (this.source.UseVersionScope<T>())
                {
                    return this.source.List[index];
                }
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        [CompilerGenerated]
        private sealed class <GetEnumerator>d__18 : IEnumerator<T>, IDisposable, IEnumerator
        {
            private int <>1__state;
            private T <>2__current;
            public ReadOnlyListFromSource<T> <>4__this;
            private IEnumerator<T> <>7__wrap1;
            public int version;

            [DebuggerHidden]
            public <GetEnumerator>d__18(int <>1__state)
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
                        this.<>7__wrap1 = this.<>4__this.source.List.GetEnumerator();
                        this.<>1__state = -3;
                        while (this.<>7__wrap1.MoveNext())
                        {
                            T current = this.<>7__wrap1.Current;
                            if (this.<>4__this.source.Version != this.version)
                            {
                                ExceptionUtil.ThrowInvalidOperationException("The collection changed during enumeration");
                            }
                            this.<>2__current = current;
                            this.<>1__state = 1;
                            return true;
                        Label_0081:
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
                    goto Label_0081;
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

