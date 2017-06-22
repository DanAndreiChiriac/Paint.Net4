namespace PaintDotNet.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static class QueueExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<T>(this Queue<T> queue) => 
            (queue.Count > 0);

        public static int EnqueueRange<T>(this Queue<T> queue, IEnumerable<T> items)
        {
            int num = 0;
            foreach (T local in items)
            {
                queue.Enqueue(local);
                num++;
            }
            return num;
        }
    }
}

