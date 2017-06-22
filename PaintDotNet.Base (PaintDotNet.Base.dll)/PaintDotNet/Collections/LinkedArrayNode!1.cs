namespace PaintDotNet.Collections
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct LinkedArrayNode<T>
    {
        private T value;
        private int index;
        private int? previousIndex;
        private int? nextIndex;
        public T Value =>
            this.value;
        public int Index =>
            this.index;
        public int? PreviousIndex =>
            this.previousIndex;
        public int? NextIndex =>
            this.nextIndex;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LinkedArrayNode(T value, int index, int? previousIndex, int? nextIndex)
        {
            this.value = value;
            this.index = index;
            this.previousIndex = previousIndex;
            this.nextIndex = nextIndex;
        }
    }
}

