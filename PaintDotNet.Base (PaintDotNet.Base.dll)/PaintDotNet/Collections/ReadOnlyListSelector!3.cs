namespace PaintDotNet.Collections
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public class ReadOnlyListSelector<TIn, TOut, TSelector> : IList<TOut>, ICollection<TOut>, IEnumerable<TOut>, IEnumerable, IReadOnlyList<TOut>, IReadOnlyCollection<TOut> where TSelector: IFunc<TIn, TOut>
    {
        private TSelector selector;
        private IList<TIn> source;

        public ReadOnlyListSelector(IList<TIn> source, TSelector selector)
        {
            Validate.Begin().IsNotNull<IList<TIn>>(source, "source").IsNotNullIfRefType<TSelector>(ref selector, "selector").Check();
            this.source = source;
            this.selector = selector;
        }

        public void Add(TOut item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(TOut item) => 
            (this.IndexOf(item) != -1);

        [IteratorStateMachine(typeof(<GetEnumerator>d__18))]
        public IEnumerator<TOut> GetEnumerator() => 
            new <GetEnumerator>d__18<TIn, TOut, TSelector>(0) { <>4__this = (ReadOnlyListSelector<TIn, TOut, TSelector>) this };

        public int IndexOf(TOut item) => 
            this.IndexOf<TOut>(item);

        public void Insert(int index, TOut item)
        {
            throw new NotSupportedException();
        }

        public bool Remove(TOut item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TOut>.CopyTo(TOut[] array, int arrayIndex)
        {
            int count = this.Count;
            for (int i = 0; i < count; i++)
            {
                array[i + arrayIndex] = this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        public int Count =>
            this.source.Count;

        public bool IsReadOnly =>
            true;

        public TOut this[int index]
        {
            get => 
                this.selector.Invoke(this.source[index]);
            set
            {
                throw new NotSupportedException();
            }
        }

        [CompilerGenerated]
        private sealed class <GetEnumerator>d__18 : IEnumerator<TOut>, IDisposable, IEnumerator
        {
            private int <>1__state;
            private TOut <>2__current;
            public ReadOnlyListSelector<TIn, TOut, TSelector> <>4__this;
            private IEnumerator<TIn> <enumerator>5__1;

            [DebuggerHidden]
            public <GetEnumerator>d__18(int <>1__state)
            {
                this.<>1__state = <>1__state;
            }

            private void <>m__Finally1()
            {
                this.<>1__state = -1;
                if (this.<enumerator>5__1 != null)
                {
                    this.<enumerator>5__1.Dispose();
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
                        this.<enumerator>5__1 = this.<>4__this.source.GetEnumerator();
                        this.<>1__state = -3;
                        while (this.<enumerator>5__1.MoveNext())
                        {
                            TIn current = this.<enumerator>5__1.Current;
                            TOut local2 = this.<>4__this.selector.Invoke(current);
                            this.<>2__current = local2;
                            this.<>1__state = 1;
                            return true;
                        Label_0072:
                            this.<>1__state = -3;
                        }
                        this.<>m__Finally1();
                        this.<enumerator>5__1 = null;
                        return false;
                    }
                    if (num != 1)
                    {
                        return false;
                    }
                    goto Label_0072;
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

            TOut IEnumerator<TOut>.Current =>
                this.<>2__current;

            object IEnumerator.Current =>
                this.<>2__current;
        }
    }
}

