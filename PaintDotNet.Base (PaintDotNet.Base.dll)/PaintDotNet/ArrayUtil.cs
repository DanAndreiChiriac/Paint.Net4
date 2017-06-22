namespace PaintDotNet
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class ArrayUtil
    {
        public static unsafe bool AreAllZero<T>(T[] array, int startIndex, int length)
        {
            bool flag;
            Validate.Begin().IsNotNull<T[]>(array, "array").Check().IsPositive(array.Length, "array.Length").IsNotNegative(startIndex, "startIndex").IsPositive(length, "length").Check().IsRangeValid(array.Length, startIndex, length, "array").Check();
            long num = Marshal.SizeOf(typeof(T));
            long num2 = startIndex * num;
            long num3 = length * num;
            GCHandle handle = GCHandle.Alloc(array, GCHandleType.Pinned);
            try
            {
                byte* numPtr = (byte*) handle.AddrOfPinnedObject();
                byte* numPtr2 = numPtr + ((byte*) num2);
                long num4 = num3;
                goto Label_00A9;
            Label_008F:
                if (numPtr2[0] != 0)
                {
                    return false;
                }
                numPtr2++;
                num4 -= 1L;
            Label_00A9:
                if (num4 > 0L)
                {
                    UIntPtr ptr = (UIntPtr) numPtr2;
                    if ((ptr.ToUInt64() & ((ulong) 7L)) != 0)
                    {
                        goto Label_008F;
                    }
                }
                while (num4 >= 0x40L)
                {
                    if ((((((((*(((long*) numPtr2)) | *(((long*) (numPtr2 + 8)))) | *(((long*) (numPtr2 + (2 * 8))))) | *(((long*) (numPtr2 + (3 * 8))))) | *(((long*) (numPtr2 + (4 * 8))))) | *(((long*) (numPtr2 + (5 * 8))))) | *(((long*) (numPtr2 + (6 * 8))))) | *(((long*) (numPtr2 + (7 * 8))))) != 0)
                    {
                        return false;
                    }
                    numPtr2 += 0x40;
                    num4 -= 0x40L;
                }
                while (num4 >= 8L)
                {
                    if (*(((long*) numPtr2)) != 0)
                    {
                        return false;
                    }
                    numPtr2++;
                    num4 -= 1L;
                }
                while (num4 > 0L)
                {
                    if (numPtr2[0] != 0)
                    {
                        return false;
                    }
                    numPtr2++;
                    num4 -= 1L;
                }
                flag = true;
            }
            finally
            {
                handle.Free();
            }
            return flag;
        }

        public static void Clear2D<T>(T[][] array2D)
        {
            for (int i = 0; i < array2D.Length; i++)
            {
                Array.Clear(array2D[i], 0, array2D[i].Length);
            }
        }

        public static T[][] Create2D<T>(int rows, int columns)
        {
            T[][] localArray = new T[rows][];
            for (int i = 0; i < rows; i++)
            {
                localArray[i] = new T[columns];
            }
            return localArray;
        }

        [Obsolete]
        public static T[][][] Create3D<T>(int z, int y, int x)
        {
            T[][][] localArray = new T[z][][];
            int index = 0;
            while (index < z)
            {
                localArray[index] = Create2D<T>(y, x);
                z++;
            }
            return localArray;
        }

        public static T[] CreateAndFill<T>(int count) where T: class, new()
        {
            T[] localArray = new T[count];
            for (int i = 0; i < localArray.Length; i++)
            {
                localArray[i] = Activator.CreateInstance<T>();
            }
            return localArray;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining), Obsolete("Use System.Array.Empty<T>() instead", true)]
        public static T[] Empty<T>() => 
            Array.Empty<T>();

        public static bool Equals(byte[] a, byte[] b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            if (b == null)
            {
                throw new ArgumentNullException("b");
            }
            return ((a.Length == b.Length) && Equals(a, b, 0, a.Length));
        }

        public static bool Equals<T>(T[] a, T[] b) where T: struct, IEquatable<T>
        {
            if (a != b)
            {
                if ((a == null) || (b == null))
                {
                    return false;
                }
                if (a.Length != b.Length)
                {
                    return false;
                }
                for (int i = 0; i < a.Length; i++)
                {
                    if (!a[i].Equals(b[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals<T>(T[] a, T[] b, IEqualityComparer<T> comparer) => 
            Equals<T, IEqualityComparer<T>>(a, b, comparer);

        public static bool Equals<T, TComparer>(T[] a, T[] b, TComparer comparer) where TComparer: IEqualityComparer<T>
        {
            if (a != b)
            {
                if ((a == null) || (b == null))
                {
                    return false;
                }
                if (a.Length != b.Length)
                {
                    return false;
                }
                for (int i = 0; i < a.Length; i++)
                {
                    if (!comparer.Equals(a[i], b[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static unsafe bool Equals(byte[] a, byte[] b, int startIndex, int length)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            if (b == null)
            {
                throw new ArgumentNullException("b");
            }
            if (a != b)
            {
                int num = length;
                fixed (byte* numRef = a)
                {
                    fixed (byte* numRef2 = b)
                    {
                        byte* numPtr = numRef;
                        byte* numPtr2 = numRef2;
                        while (num >= 8)
                        {
                            if (*(((long*) numPtr)) != *(((long*) numPtr2)))
                            {
                                return false;
                            }
                            numPtr += 8;
                            numPtr2 += 8;
                            num -= 8;
                        }
                        while (num > 0)
                        {
                            if (numPtr[0] != numPtr2[0])
                            {
                                return false;
                            }
                            numPtr++;
                            numPtr2++;
                            num--;
                        }
                    }
                }
            }
            return true;
        }

        internal static T[] GetArrayOrEmptySingleton<T>(T[] array)
        {
            if ((array != null) && (array.Length == 0))
            {
                return Array.Empty<T>();
            }
            return array;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] Infer<T>(params T[] items) => 
            items;

        public static void SetAll<T>(T[] array, T value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }

        public static void SetAll2D<T>(T[][] array2D, T value)
        {
            for (int i = 0; i < array2D.Length; i++)
            {
                SetAll<T>(array2D[i], value);
            }
        }
    }
}

