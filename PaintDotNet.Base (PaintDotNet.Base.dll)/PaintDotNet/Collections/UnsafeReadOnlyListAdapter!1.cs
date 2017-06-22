namespace PaintDotNet.Collections
{
    using System;

    internal static class UnsafeReadOnlyListAdapter<T> where T: struct
    {
        public static unsafe UnsafeReadOnlyListAdapter<T, TAccessor> Create<TAccessor>(void* pList, int count, TAccessor accessor) where TAccessor: IUnsafeElementAccessor<T> => 
            new UnsafeReadOnlyListAdapter<T, TAccessor>(pList, count, accessor);
    }
}

