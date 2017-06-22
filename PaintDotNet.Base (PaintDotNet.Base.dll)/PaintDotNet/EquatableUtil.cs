namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class EquatableUtil
    {
        public static bool Equals(object a, object b)
        {
            if (a == b)
            {
                return true;
            }
            bool flag = a == null;
            bool flag2 = b == null;
            if (flag & flag2)
            {
                return true;
            }
            if (flag | flag2)
            {
                return false;
            }
            if (a.GetType() != b.GetType())
            {
                return false;
            }
            if (a.GetHashCode() != b.GetHashCode())
            {
                return false;
            }
            return a.Equals(b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool Equals<T>(void* a, void* b) where T: struct => 
            Equals(a, b, ObjectUtil.SizeOf<T>());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals<TThis, TOther>(TThis @this, TOther obj) where TThis: TOther, IEquatable<TThis> => 
            (((obj is TThis) && (@this.GetHashCode() == obj.GetHashCode())) && @this.Equals((TThis) obj));

        public static unsafe bool Equals(void* a, void* b, int bytes)
        {
            while (bytes >= 8)
            {
                if (*(((long*) a)) != *(((long*) b)))
                {
                    return false;
                }
                a += 8;
                b += 8;
                bytes -= 8;
            }
            while (bytes > 0)
            {
                if (*(((byte*) a)) != *(((byte*) b)))
                {
                    return false;
                }
                a++;
                b++;
                bytes--;
            }
            return true;
        }

        public static bool OperatorEquals<T>(T a, T b) where T: class, IEquatable<T>
        {
            if (a == b)
            {
                return true;
            }
            if ((a == null) || (b == null))
            {
                return false;
            }
            if (a.GetHashCode() != b.GetHashCode())
            {
                return false;
            }
            return a.Equals(b);
        }
    }
}

