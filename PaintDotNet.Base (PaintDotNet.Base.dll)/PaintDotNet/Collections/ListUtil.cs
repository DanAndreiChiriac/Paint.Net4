namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static class ListUtil
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch<T>(IList<T> array, T item) => 
            AlgorithmsWithComparer<T, IList<T>, Comparer<T>>.InternalBinarySearch(array, 0, array.Count, item, Comparer<T>.Default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch<T, TList>(TList array, T item) where TList: IList<T> => 
            AlgorithmsWithComparer<T, TList, Comparer<T>>.InternalBinarySearch(array, 0, array.Count, item, Comparer<T>.Default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch<T>(IList<T> array, T item, IComparer<T> comparer) => 
            AlgorithmsWithComparer<T, IList<T>, IComparer<T>>.InternalBinarySearch(array, 0, array.Count, item, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch<T>(IList<T> array, T item, Comparison<T> comparer) => 
            AlgorithmsWithComparer<T, IList<T>, ComparisonWrapper<T>>.InternalBinarySearch(array, 0, array.Count, item, new ComparisonWrapper<T>(comparer));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch<T, TList, TComparer>(TList array, T item, TComparer comparer) where TList: IList<T> where TComparer: IComparer<T> => 
            AlgorithmsWithComparer<T, TList, TComparer>.InternalBinarySearch(array, 0, array.Count, item, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch<T>(IList<T> array, int index, int count, T item, IComparer<T> comparer) => 
            AlgorithmsWithComparer<T, IList<T>, IComparer<T>>.InternalBinarySearch(array, index, count, item, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch<T>(IList<T> array, int index, int count, T item, Comparison<T> comparer) => 
            AlgorithmsWithComparer<T, IList<T>, ComparisonWrapper<T>>.InternalBinarySearch(array, index, count, item, new ComparisonWrapper<T>(comparer));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch<T, TList, TComparer>(TList array, int index, int count, T item, TComparer comparer) where TList: IList<T> where TComparer: IComparer<T> => 
            AlgorithmsWithComparer<T, TList, TComparer>.InternalBinarySearch(array, index, count, item, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FisherYatesShuffle<T>(IList<T> list)
        {
            FisherYatesShuffle<T>(list, RandomUtil.ThreadInstance);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FisherYatesShuffle<T, TList>(TList list) where TList: IList<T>
        {
            FisherYatesShuffle<T, TList>(list, RandomUtil.ThreadInstance);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FisherYatesShuffle<T>(IList<T> list, Random random)
        {
            FisherYatesShuffle<T>(list, 0, list.Count, random);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FisherYatesShuffle<T, TList>(TList list, Random random) where TList: IList<T>
        {
            FisherYatesShuffle<T, TList>(list, 0, list.Count, random);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FisherYatesShuffle<T>(IList<T> list, int startIndex, int length, Random random)
        {
            FisherYatesShuffle<T, IList<T>>(list, startIndex, length, random);
        }

        public static void FisherYatesShuffle<T, TList>(TList list, int startIndex, int length, Random random) where TList: IList<T>
        {
            Validate.Begin().IsNotNull<Random>(random, "random").Check().IsRangeValid(list.Count, startIndex, length, "list").Check();
            if (length != 0)
            {
                for (int i = (startIndex + length) - 1; i >= (startIndex + 1); i--)
                {
                    int num2 = startIndex + random.Next((i - startIndex) + 1);
                    list.SwapElements<T>(i, num2);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void QuickSort<T>(IList<T> list)
        {
            QuickSort<T, IList<T>>(list);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void QuickSort<T, TList>(TList list) where TList: IList<T>
        {
            QuickSort<T, TList, Comparer<T>>(list, 0, list.Count, Comparer<T>.Default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void QuickSort<T>(IList<T> list, IComparer<T> comparer)
        {
            QuickSort<T, IList<T>, IComparer<T>>(list, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void QuickSort<T>(IList<T> list, Comparison<T> comparer)
        {
            QuickSort<T, IList<T>, ComparisonWrapper<T>>(list, new ComparisonWrapper<T>(comparer));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void QuickSort<T, TList, TComparer>(TList list, TComparer comparer) where TList: IList<T> where TComparer: IComparer<T>
        {
            QuickSort<T, TList, TComparer>(list, 0, list.Count, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void QuickSort<T>(IList<T> list, int startIndex, int length, IComparer<T> comparer)
        {
            QuickSort<T, IList<T>, IComparer<T>>(list, startIndex, length, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void QuickSort<T>(IList<T> list, int startIndex, int length, Comparison<T> comparer)
        {
            QuickSort<T, IList<T>, ComparisonWrapper<T>>(list, startIndex, length, new ComparisonWrapper<T>(comparer));
        }

        public static void QuickSort<T, TList, TComparer>(TList list, int startIndex, int length, TComparer comparer) where TList: IList<T> where TComparer: IComparer<T>
        {
            Validate.Begin().IsNotNullIfRefType<TList>(ref list, "list").IsNotNullIfRefType<TComparer>(ref comparer, "comparer").Check().IsNotNegative(startIndex, "startIndex").IsNotNegative(length, "length").IsRangeValid(list.Count, startIndex, length, "list").Check();
            if ((length != 0) && (length != 1))
            {
                AlgorithmsWithComparer<T, TList, TComparer>.QuickSortImpl(list, startIndex, (startIndex + length) - 1, comparer);
            }
        }

        public static void RemoveWhere<T>(IList<T> list, Func<T, bool> selector)
        {
            Validate.IsNotNull<IList<T>>(list, "list");
            int count = list.Count;
            int newCount = 0;
            for (int i = 0; i < count; i++)
            {
                T arg = list[i];
                if (!selector(arg))
                {
                    list[newCount] = arg;
                    newCount++;
                }
            }
            if (newCount != count)
            {
                Resize<T>(list, newCount);
            }
        }

        public static void Resize<T>(IList<T> list, int newCount)
        {
            Validate.Begin().IsNotNull<IList<T>>(list, "list").IsNotNegative(newCount, "newCount").Check();
            SegmentedList<T> list2 = list as SegmentedList<T>;
            if (list2 != null)
            {
                list2.Resize(newCount, false, true);
            }
            else
            {
                int count = list.Count;
                if (newCount != count)
                {
                    if (newCount == 0)
                    {
                        list.Clear();
                    }
                    else if (newCount < count)
                    {
                        int num2 = list.Count - newCount;
                        list.RemoveRange<T>(list.Count - num2, num2);
                    }
                    else if (newCount > count)
                    {
                        int num3 = newCount - list.Count;
                        list.AddDefaults<T>(num3);
                    }
                }
            }
        }

        public static void RotateElementRange<T, TList>(TList list, int firstInclusiveIndex, int middleIndex, int endExclusiveIndex) where TList: IList<T>
        {
            if (((firstInclusiveIndex > middleIndex) || (middleIndex > endExclusiveIndex)) || ((firstInclusiveIndex < 0) || (endExclusiveIndex > list.Count)))
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException();
            }
            int i = firstInclusiveIndex;
            int j = middleIndex;
            while (i != j)
            {
                SwapElements<T, TList>(list, i, j);
                i++;
                j++;
                if (j == endExclusiveIndex)
                {
                    j = middleIndex;
                }
                else if (i == middleIndex)
                {
                    middleIndex = j;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sort<T>(IList<T> list)
        {
            Sort<T, IList<T>>(list);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sort<T, TList>(TList list) where TList: IList<T>
        {
            Sort<T, TList, Comparer<T>>(list, 0, list.Count, Comparer<T>.Default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sort<T>(IList<T> list, IComparer<T> comparer)
        {
            Sort<T, IList<T>, IComparer<T>>(list, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sort<T>(IList<T> list, Comparison<T> comparer)
        {
            Sort<T, IList<T>, ComparisonWrapper<T>>(list, new ComparisonWrapper<T>(comparer));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sort<T, TList, TComparer>(TList list, TComparer comparer) where TList: IList<T> where TComparer: IComparer<T>
        {
            Sort<T, TList, TComparer>(list, 0, list.Count, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sort<T>(IList<T> list, int startIndex, int length, IComparer<T> comparer)
        {
            Sort<T, IList<T>, IComparer<T>>(list, startIndex, length, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sort<T>(IList<T> list, int startIndex, int length, Comparison<T> comparison)
        {
            Sort<T, IList<T>, ComparisonWrapper<T>>(list, startIndex, length, new ComparisonWrapper<T>(comparison));
        }

        public static void Sort<T, TList, TComparer>(TList list, int startIndex, int length, TComparer comparer) where TList: IList<T> where TComparer: IComparer<T>
        {
            Validate.Begin().IsNotNullIfRefType<TList>(ref list, "list").IsNotNullIfRefType<TComparer>(ref comparer, "comparer").Check().IsNotNegative(startIndex, "startIndex").IsNotNegative(length, "length").IsRangeValid(list.Count, startIndex, length, "list").Check();
            if ((length != 0) && (length != 1))
            {
                AlgorithmsWithComparer<T, TList, TComparer>.IntrospectiveSort(list, startIndex, length, comparer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SwapElements<T, TList>(TList a, int i, int j) where TList: IList<T>
        {
            if (i != j)
            {
                T local = a[i];
                a[i] = a[j];
                a[j] = local;
            }
        }

        private static class AlgorithmsWithComparer<T, TList, TComparer> where TList: IList<T> where TComparer: IComparer<T>
        {
            public static void DownHeap(TList keys, int i, int n, int lo, TComparer comparer)
            {
                T x = keys[(lo + i) - 1];
                while (i <= (n >> 1))
                {
                    int num = 2 * i;
                    if ((num < n) && (comparer.Compare(keys[(lo + num) - 1], keys[lo + num]) < 0))
                    {
                        num++;
                    }
                    if (comparer.Compare(x, keys[(lo + num) - 1]) >= 0)
                    {
                        break;
                    }
                    keys[(lo + i) - 1] = keys[(lo + num) - 1];
                    i = num;
                }
                keys[(lo + i) - 1] = x;
            }

            public static void Heapsort(TList keys, int lo, int hi, TComparer comparer)
            {
                int n = (hi - lo) + 1;
                for (int i = n >> 1; i >= 1; i--)
                {
                    ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.DownHeap(keys, i, n, lo, comparer);
                }
                for (int j = n; j > 1; j--)
                {
                    ListUtil.SwapElements<T, TList>(keys, lo, (lo + j) - 1);
                    ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.DownHeap(keys, 1, j - 1, lo, comparer);
                }
            }

            public static void InsertionSort(TList keys, int lo, int hi, TComparer comparer)
            {
                for (int i = lo; i < hi; i++)
                {
                    int num2 = i;
                    T x = keys[i + 1];
                    while ((num2 >= lo) && (comparer.Compare(x, keys[num2]) < 0))
                    {
                        keys[num2 + 1] = keys[num2];
                        num2--;
                    }
                    keys[num2 + 1] = x;
                }
            }

            public static int InternalBinarySearch(TList array, int lowIndex, int length, T value, TComparer comparer)
            {
                int num = lowIndex;
                int num2 = (lowIndex + length) - 1;
                while (num <= num2)
                {
                    int num3 = num + ((num2 - num) >> 1);
                    int num4 = comparer.Compare(array[num3], value);
                    if (num4 == 0)
                    {
                        return num3;
                    }
                    if (num4 < 0)
                    {
                        num = num3 + 1;
                    }
                    else
                    {
                        num2 = num3 - 1;
                    }
                }
                return ~num;
            }

            public static void IntrospectiveSort(TList keys, int startIndex, int length, TComparer comparer)
            {
                int depthLimit = 2 * Int32Util.Log2Floor(keys.Count);
                ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.IntrospectiveSort(keys, startIndex, (startIndex + length) - 1, depthLimit, comparer);
            }

            public static void IntrospectiveSort(TList keys, int lo, int hi, int depthLimit, TComparer comparer)
            {
                while (hi > lo)
                {
                    int num = (hi - lo) + 1;
                    if (num <= 0x10)
                    {
                        switch (num)
                        {
                            case 1:
                                return;

                            case 2:
                                ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.SwapIfGreater(keys, comparer, lo, hi);
                                return;

                            case 3:
                                ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.SwapIfGreater(keys, comparer, lo, hi - 1);
                                ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.SwapIfGreater(keys, comparer, lo, hi);
                                ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.SwapIfGreater(keys, comparer, hi - 1, hi);
                                return;
                        }
                        ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.InsertionSort(keys, lo, hi, comparer);
                        return;
                    }
                    if (depthLimit == 0)
                    {
                        ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.Heapsort(keys, lo, hi, comparer);
                        return;
                    }
                    depthLimit--;
                    int num2 = ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.PickPivotAndPartition(keys, lo, hi, comparer);
                    ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.IntrospectiveSort(keys, num2 + 1, hi, depthLimit, comparer);
                    hi = num2 - 1;
                }
            }

            public static int PickPivotAndPartition(TList keys, int lo, int hi, TComparer comparer)
            {
                int j = lo + ((hi - lo) >> 1);
                ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.SwapIfGreater(keys, comparer, lo, j);
                ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.SwapIfGreater(keys, comparer, lo, hi);
                ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.SwapIfGreater(keys, comparer, j, hi);
                T y = keys[j];
                ListUtil.SwapElements<T, TList>(keys, j, hi - 1);
                int i = lo;
                int num3 = hi - 1;
                while (i < num3)
                {
                    while (comparer.Compare(keys[++i], y) < 0)
                    {
                    }
                    while (comparer.Compare(y, keys[--num3]) < 0)
                    {
                    }
                    if (i >= num3)
                    {
                        break;
                    }
                    ListUtil.SwapElements<T, TList>(keys, i, num3);
                }
                ListUtil.SwapElements<T, TList>(keys, i, hi - 1);
                return i;
            }

            public static void QuickSortImpl(TList keys, int left, int right, TComparer comparer)
            {
                do
                {
                    int a = left;
                    int b = right;
                    int num3 = a + ((b - a) >> 1);
                    ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.SwapIfGreaterWithItems(keys, comparer, a, num3);
                    ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.SwapIfGreaterWithItems(keys, comparer, a, b);
                    ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.SwapIfGreaterWithItems(keys, comparer, num3, b);
                    T y = keys[num3];
                    do
                    {
                        while (comparer.Compare(keys[a], y) < 0)
                        {
                            a++;
                        }
                        while (comparer.Compare(y, keys[b]) < 0)
                        {
                            b--;
                        }
                        if (a > b)
                        {
                            break;
                        }
                        if (a < b)
                        {
                            T local2 = keys[a];
                            keys[a] = keys[b];
                            keys[b] = local2;
                        }
                        a++;
                        b--;
                    }
                    while (a <= b);
                    if ((b - left) <= (right - a))
                    {
                        if (left < b)
                        {
                            ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.QuickSortImpl(keys, left, b, comparer);
                        }
                        left = a;
                    }
                    else
                    {
                        if (a < right)
                        {
                            ListUtil.AlgorithmsWithComparer<T, TList, TComparer>.QuickSortImpl(keys, a, right, comparer);
                        }
                        right = b;
                    }
                }
                while (left < right);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void SwapIfGreater(TList keys, TComparer comparer, int i, int j)
            {
                if ((i != j) && (comparer.Compare(keys[i], keys[j]) > 0))
                {
                    T local = keys[i];
                    keys[i] = keys[j];
                    keys[j] = local;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void SwapIfGreaterWithItems(TList keys, TComparer comparer, int a, int b)
            {
                if ((a != b) && (comparer.Compare(keys[a], keys[b]) > 0))
                {
                    T local = keys[a];
                    keys[a] = keys[b];
                    keys[b] = local;
                }
            }
        }
    }
}

