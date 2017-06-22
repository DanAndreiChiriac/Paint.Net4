namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public sealed class ConcurrentBitArray
    {
        private readonly int count;
        private readonly int[] segments;

        public ConcurrentBitArray(int count) : this(count, false)
        {
        }

        public ConcurrentBitArray(int count, bool fillValue)
        {
            if (count < 0)
            {
                ExceptionUtil.ThrowArgumentException("count");
            }
            this.count = count;
            int num = (count + 0x1f) / 0x20;
            this.segments = new int[num];
            if (fillValue)
            {
                int num2 = AsInt32(uint.MaxValue);
                for (int i = 0; i < this.segments.Length; i++)
                {
                    this.segments[i] = num2;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe int AsInt32(uint x) => 
            *(((int*) &x));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe uint AsUInt32(int x) => 
            *(((uint*) &x));

        public bool GetUnchecked(int index)
        {
            int num = index >> 5;
            int num2 = index & 0x1f;
            return ((AsUInt32(Volatile.Read(ref this.segments[num])) & (((int) 1) << num2)) > 0);
        }

        public void SetUnchecked(int index, bool value)
        {
            uint num5;
            uint num6;
            int num = index >> 5;
            int num2 = index & 0x1f;
            uint num3 = ((uint) 1) << num2;
            uint num4 = value ? num3 : 0;
            do
            {
                num5 = AsUInt32(Volatile.Read(ref this.segments[num]));
                num6 = (num5 & ~num3) | num4;
            }
            while ((num6 != num5) && (AsUInt32(Interlocked.CompareExchange(ref this.segments[num], AsInt32(num6), AsInt32(num5))) != num5));
        }

        public int Count =>
            this.count;

        public bool this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if ((index < 0) || (index >= this.count))
                {
                    ExceptionUtil.ThrowArgumentOutOfRangeException("index");
                }
                return this.GetUnchecked(index);
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if ((index < 0) || (index >= this.count))
                {
                    ExceptionUtil.ThrowArgumentOutOfRangeException("index");
                }
                this.SetUnchecked(index, value);
            }
        }
    }
}

