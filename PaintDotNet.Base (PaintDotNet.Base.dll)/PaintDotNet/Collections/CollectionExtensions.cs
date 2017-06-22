namespace PaintDotNet.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static class CollectionExtensions
    {
        public static void AddIfNotNull<T>(this ICollection<T> collection, T item) where T: class
        {
            if (item != null)
            {
                collection.Add(item);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            collection.AddRangeCore<T>(items);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddRange<T>(this ICollection<T> collection, params T[] items)
        {
            collection.AddRangeCore<T>(items);
        }

        private static void AddRangeCore<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            IAddRange<T> range = collection as IAddRange<T>;
            if (range != null)
            {
                range.AddRange(items);
            }
            else
            {
                List<T> list = collection as List<T>;
                if (list != null)
                {
                    list.AddRange(items);
                }
                else
                {
                    foreach (T local in items)
                    {
                        collection.Add(local);
                    }
                }
            }
        }

        public static bool Any<T>(this ICollection<T> collection) => 
            (collection.Count > 0);

        public static bool RemoveRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            bool flag = true;
            foreach (T local in items)
            {
                flag &= collection.Remove(local);
            }
            return flag;
        }

        public static bool RemoveRange<T>(this ICollection<T> collection, params T[] items)
        {
            bool flag = true;
            foreach (T local in items)
            {
                flag &= collection.Remove(local);
            }
            return flag;
        }

        public static bool TryTrimExcess<T>(this ICollection<T> collection)
        {
            ITrimExcess excess = collection as ITrimExcess;
            if (excess != null)
            {
                excess.TrimExcess();
                return true;
            }
            List<T> list = collection as List<T>;
            if (list != null)
            {
                list.TrimExcess();
                return true;
            }
            Queue<T> queue = collection as Queue<T>;
            if (queue != null)
            {
                queue.TrimExcess();
                return true;
            }
            Stack<T> stack = collection as Stack<T>;
            if (stack != null)
            {
                stack.TrimExcess();
                return true;
            }
            HashSet<T> set = collection as HashSet<T>;
            if (set != null)
            {
                set.TrimExcess();
                return true;
            }
            return false;
        }
    }
}

