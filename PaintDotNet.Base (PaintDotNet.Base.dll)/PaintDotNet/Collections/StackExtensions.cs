namespace PaintDotNet.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static class StackExtensions
    {
        public static bool Any<T>(this Stack<T> stack) => 
            (stack.Count > 0);

        public static void PushRange<T>(this Stack<T> stack, IEnumerable<T> items)
        {
            foreach (T local in items)
            {
                stack.Push(local);
            }
        }
    }
}

