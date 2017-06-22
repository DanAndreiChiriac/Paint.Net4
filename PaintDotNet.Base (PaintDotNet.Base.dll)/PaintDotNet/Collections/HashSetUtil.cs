namespace PaintDotNet.Collections
{
    using System;
    using System.Collections.Generic;

    public static class HashSetUtil
    {
        public static HashSet<T> Create<T>(IEnumerable<T> items) => 
            new HashSet<T>(items);

        public static HashSet<T> Create<T>(params T[] items) => 
            new HashSet<T>(items);

        public static HashSet<T> Intersect<T>(HashSet<T> items1, HashSet<T> items2)
        {
            HashSet<T> set = new HashSet<T>();
            foreach (T local in items1)
            {
                if (items2.Contains(local))
                {
                    set.Add(local);
                }
            }
            return set;
        }
    }
}

