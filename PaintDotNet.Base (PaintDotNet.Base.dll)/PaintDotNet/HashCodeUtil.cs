namespace PaintDotNet
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static class HashCodeUtil
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CombineHashCodes(int hash1, int hash2) => 
            (((hash1 << 5) + hash1) ^ hash2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CombineHashCodes(int hash1, int hash2, int hash3) => 
            CombineHashCodes(CombineHashCodes(hash1, hash2), hash3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CombineHashCodes(int hash1, int hash2, int hash3, int hash4) => 
            CombineHashCodes(CombineHashCodes(hash1, hash2), CombineHashCodes(hash3, hash4));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CombineHashCodes(int hash1, int hash2, int hash3, int hash4, int hash5) => 
            CombineHashCodes(CombineHashCodes(hash1, hash2, hash3, hash4), hash5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CombineHashCodes(int hash1, int hash2, int hash3, int hash4, int hash5, int hash6) => 
            CombineHashCodes(CombineHashCodes(hash1, hash2, hash3, hash4), CombineHashCodes(hash5, hash6));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CombineHashCodes(int hash1, int hash2, int hash3, int hash4, int hash5, int hash6, int hash7) => 
            CombineHashCodes(CombineHashCodes(hash1, hash2, hash3, hash4), CombineHashCodes(hash5, hash6, hash7));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CombineHashCodes(int hash1, int hash2, int hash3, int hash4, int hash5, int hash6, int hash7, int hash8) => 
            CombineHashCodes(CombineHashCodes(hash1, hash2, hash3, hash4), CombineHashCodes(hash5, hash6, hash7, hash8));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CombineHashCodes(int hash1, int hash2, int hash3, int hash4, int hash5, int hash6, int hash7, int hash8, int hash9) => 
            CombineHashCodes(CombineHashCodes(hash1, hash2, hash3, hash4), CombineHashCodes(hash5, hash6, hash7, hash8), hash9);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CombineHashCodes(int hash1, int hash2, int hash3, int hash4, int hash5, int hash6, int hash7, int hash8, int hash9, int hash10) => 
            CombineHashCodes(CombineHashCodes(hash1, hash2, hash3, hash4), CombineHashCodes(hash5, hash6, hash7, hash8), CombineHashCodes(hash9, hash10));

        public static int CreateHashCode<T>(IEnumerable<T> items)
        {
            Validate.IsNotNull<IEnumerable<T>>(items, "items");
            if (items is IList<T>)
            {
                return CreateHashCode<T>((IList<T>) items);
            }
            int num = 0;
            int num2 = 0;
            foreach (T local in items)
            {
                int num3 = (local == null) ? 0 : local.GetHashCode();
                num2 = CombineHashCodes(num2, num3);
                num++;
            }
            return CombineHashCodes(num.GetHashCode(), num2);
        }

        public static int CreateHashCode<T>(IList<T> list)
        {
            Validate.IsNotNull<IList<T>>(list, "list");
            return CreateHashCode<T>(list, 0, list.Count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CreateHashCode<T>(T[] array)
        {
            Validate.IsNotNull<T[]>(array, "array");
            return CreateHashCode<T>(array, 0, array.Length);
        }

        public static int CreateHashCode<T>(IList<T> list, int startIndex, int length)
        {
            Validate.Begin().IsNotNull<IList<T>>(list, "list").Check().IsRangeValid(list.Count, startIndex, length, "list").Check();
            int hashCode = length.GetHashCode();
            for (int i = startIndex; i < (startIndex + length); i++)
            {
                hashCode = CombineHashCodes(hashCode, list[i].GetHashCode());
            }
            return hashCode;
        }

        public static int CreateHashCode<T>(T[] array, int startIndex, int length)
        {
            Validate.Begin().IsNotNull<T[]>(array, "array").Check().IsRangeValid(array.Length, startIndex, length, "array").Check();
            int hashCode = length.GetHashCode();
            for (int i = startIndex; i < (startIndex + length); i++)
            {
                hashCode = CombineHashCodes(hashCode, array[i].GetHashCode());
            }
            return hashCode;
        }

        public static unsafe int CreateHashCodeRaw<T>(void* item) where T: struct => 
            CreateHashCodeRaw(item, ObjectUtil.SizeOf<T>());

        public static unsafe int CreateHashCodeRaw(void* item, int bytes)
        {
            int hashCode = bytes.GetHashCode();
            while (bytes >= 4)
            {
                hashCode = CombineHashCodes(hashCode, *((int*) item));
                item += 4;
                bytes -= 4;
            }
            while (bytes > 0)
            {
                hashCode = CombineHashCodes(hashCode, *((byte*) item));
                item++;
                bytes--;
            }
            return hashCode;
        }
    }
}

