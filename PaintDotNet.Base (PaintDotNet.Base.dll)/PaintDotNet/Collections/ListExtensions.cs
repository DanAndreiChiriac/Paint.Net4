namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Functional;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class ListExtensions
    {
        public static void AddDefaults<T>(this IList<T> list, int count)
        {
            Validate.Begin().IsNotNull<IList<T>>(list, "list").IsNotNegative(count, "count").Check();
            list.AddRange<T>(Enumerable.Repeat<T>(default(T), count));
        }

        public static T[] AsArrayOrToArray<T>(this IList<T> source, int startIndex, int length)
        {
            Validate.IsNotNull<IList<T>>(source, "source");
            if (startIndex == 0)
            {
                T[] localArray = source as T[];
                if ((localArray != null) && (length == localArray.Length))
                {
                    return localArray;
                }
            }
            return source.ToArrayEx<T>(startIndex, length);
        }

        public static IList<T> AsReadOnly<T>(this IList<T> list)
        {
            if (list.IsReadOnly)
            {
                return list;
            }
            return new ReadOnlyCollection<T>(list);
        }

        public static SegmentedListStruct<T> AsStruct<T>(this SegmentedList<T> source) => 
            new SegmentedListStruct<T>(source);

        public static UnsafeListStruct<T> AsStruct<T>(this UnsafeList<T> source) => 
            new UnsafeListStruct<T>(source);

        public static ListStruct<T, IList<T>> AsStruct<T>(this IList<T> source) => 
            new ListStruct<T, IList<T>>(source);

        public static ListStruct<T> AsStruct<T>(this List<T> source) => 
            new ListStruct<T>(source);

        public static ReadOnlyCollectionStruct<T> AsStruct<T>(this ReadOnlyCollection<T> source) => 
            new ReadOnlyCollectionStruct<T>(source);

        public static ListCastQuery<T> Cast<T>(this IList<T> items) => 
            new ListCastQuery<T>(items);

        public static IList<float> CastToFloat(this IList<double> items) => 
            new ReadOnlyListSelector<double, float, CastDoubleToFloatFunc>(items, new CastDoubleToFloatFunc());

        public static List<T[]> Clone2D<T>(this IList<T[]> list2D)
        {
            Validate.IsNotNull<IList<T[]>>(list2D, "list2D");
            int count = list2D.Count;
            List<T[]> list = new List<T[]>(count);
            for (int i = 0; i < count; i++)
            {
                list.Add(list2D[i].CloneT<T>());
            }
            return list;
        }

        public static SegmentedList<T[]> Clone2DSegmented<T>(this IList<T[]> list2D)
        {
            Validate.IsNotNull<IList<T[]>>(list2D, "list2D");
            int count = list2D.Count;
            SegmentedList<T[]> list = new SegmentedList<T[]>();
            list.EnsureCapacity(count);
            for (int i = 0; i < count; i++)
            {
                list.Add(list2D[i].CloneT<T>());
            }
            return list;
        }

        public static void EnsureCount<T>(this IList<T> list, int count)
        {
            Validate.Begin().IsNotNull<IList<T>>(list, "list").IsNotNegative(count, "count").Check();
            for (int i = count - list.Count; i > 0; i--)
            {
                T item = default(T);
                list.Add(item);
            }
        }

        public static T Last<T>(this IList<T> list) => 
            list[list.Count - 1];

        public static T LastOrDefault<T>(this IList<T> list)
        {
            if (list.Count != 0)
            {
                return list.Last<T>();
            }
            return default(T);
        }

        public static void RemoveRange<T>(this IList<T> list, int startIndex, int count)
        {
            Validate.Begin().IsNotNull<IList<T>>(list, "list").IsNotNegative(startIndex, "startIndex").IsNotNegative(count, "count").Check().IsRangeValid(list.Count, startIndex, count, "list").Check();
            List<T> list2 = list as List<T>;
            if (list2 != null)
            {
                list2.RemoveRange(startIndex, count);
            }
            else
            {
                IRemoveRange range = list as IRemoveRange;
                if (range != null)
                {
                    range.RemoveRange(startIndex, count);
                }
                else
                {
                    for (int i = (startIndex + count) - 1; i >= startIndex; i--)
                    {
                        list.RemoveAt(i);
                    }
                }
            }
        }

        public static void Resize<T>(this IList<T> list, int newCount)
        {
            Validate.IsNotNull<IList<T>>(list, "list");
            int count = list.Count;
            if (count != newCount)
            {
                List<T> list2 = list as List<T>;
                if (list2 != null)
                {
                    if (newCount > count)
                    {
                        list2.AddRange(Enumerable.Repeat<T>(default(T), newCount - count));
                    }
                    else
                    {
                        list2.RemoveRange(newCount, count - newCount);
                    }
                }
                else
                {
                    SegmentedList<T> list3 = list as SegmentedList<T>;
                    if (list3 != null)
                    {
                        list3.Resize(newCount, true, true);
                    }
                    else
                    {
                        SegmentedListStruct<T>? nullable = list as SegmentedListStruct<T>?;
                        if (nullable.HasValue)
                        {
                            nullable.Value.Source.Resize(newCount, true, true);
                        }
                        else
                        {
                            UncheckedSegmentedListStruct<T>? nullable2 = list as UncheckedSegmentedListStruct<T>?;
                            if (nullable2.HasValue)
                            {
                                nullable2.Value.Source.Resize(newCount, true, true);
                            }
                            else if (newCount > count)
                            {
                                list.AddDefaults<T>(newCount - count);
                            }
                            else
                            {
                                list.RemoveRange<T>(newCount, count - newCount);
                            }
                        }
                    }
                }
            }
        }

        public static IList<T> Reverse<T>(this IList<T> items) => 
            new FuncList<T, ListCountProvider<T, IList<T>>, ReverseValueProvider<T, IList<T>>>(new ListCountProvider<T, IList<T>>(items), new ReverseValueProvider<T, IList<T>>(items));

        public static IList<TResult> Select<T, TResult>(this IList<T> items, Func<T, TResult> selector) => 
            new ReadOnlyListSelector<T, TResult>(items, selector);

        public static void SwapElements<T>(this IList<T> items, int index1, int index2)
        {
            T local = items[index1];
            items[index1] = items[index2];
            items[index2] = local;
        }

        public static T[] ToArrayEx<T>(this IList<T> source, int startIndex, int length)
        {
            if (((length == 0) && (source != null)) && ((startIndex >= 0) && (startIndex <= source.Count)))
            {
                return Array.Empty<T>();
            }
            if ((startIndex == 0) && (length == source.Count))
            {
                return source.ToArrayEx<T>();
            }
            return new ListSegment<T>(source, startIndex, length).ToArrayEx<T>();
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct ListCountProvider<T, TList> : IFunc<int> where TList: IList<T>
        {
            private TList list;
            public ListCountProvider(TList list)
            {
                this.list = list;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Invoke() => 
                this.list.Count;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct ReverseValueProvider<T, TList> : IFunc<int, T> where TList: IList<T>
        {
            private TList source;
            public ReverseValueProvider(TList source)
            {
                this.source = source;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public T Invoke(int index) => 
                this.source[(this.source.Count - index) - 1];
        }
    }
}

