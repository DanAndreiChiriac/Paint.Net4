namespace PaintDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8> : IEquatable<TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>>
    {
        private static readonly Type item1Type;
        private static readonly bool item1IsValueType;
        private static readonly EqualityComparer<T1> item1Comparer;
        private static readonly Type item2Type;
        private static readonly bool item2IsValueType;
        private static readonly EqualityComparer<T2> item2Comparer;
        private static readonly Type item3Type;
        private static readonly bool item3IsValueType;
        private static readonly EqualityComparer<T3> item3Comparer;
        private static readonly Type item4Type;
        private static readonly bool item4IsValueType;
        private static readonly EqualityComparer<T4> item4Comparer;
        private static readonly Type item5Type;
        private static readonly bool item5IsValueType;
        private static readonly EqualityComparer<T5> item5Comparer;
        private static readonly Type item6Type;
        private static readonly bool item6IsValueType;
        private static readonly EqualityComparer<T6> item6Comparer;
        private static readonly Type item7Type;
        private static readonly bool item7IsValueType;
        private static readonly EqualityComparer<T7> item7Comparer;
        private static readonly Type item8Type;
        private static readonly bool item8IsValueType;
        private static readonly EqualityComparer<T8> item8Comparer;
        private T1 item1;
        private T2 item2;
        private T3 item3;
        private T4 item4;
        private T5 item5;
        private T6 item6;
        private T7 item7;
        private T8 item8;
        public static implicit operator Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8>>(TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8> from) => 
            new Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8>>(from.Item1, from.Item2, from.Item3, from.Item4, from.Item5, from.Item6, from.Item7, new Tuple<T8>(from.Item8));

        public static implicit operator TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>(Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8>> from) => 
            new TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>(from.Item1, from.Item2, from.Item3, from.Item4, from.Item5, from.Item6, from.Item7, from.Rest.Item1);

        public T1 Item1 =>
            this.item1;
        public T2 Item2 =>
            this.item2;
        public T3 Item3 =>
            this.item3;
        public T4 Item4 =>
            this.item4;
        public T5 Item5 =>
            this.item5;
        public T6 Item6 =>
            this.item6;
        public T7 Item7 =>
            this.item7;
        public T8 Item8 =>
            this.item8;
        public TupleStruct(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;
            this.item5 = item5;
            this.item6 = item6;
            this.item7 = item7;
            this.item8 = item8;
        }

        public bool Equals(TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8> other)
        {
            bool flag;
            bool flag2;
            bool flag3;
            bool flag4;
            bool flag5;
            bool flag6;
            bool flag7;
            bool flag8;
            if ((!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item1IsValueType && (this.item1 == null)) && (other.item1 == null))
            {
                flag = true;
            }
            else if (!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item1IsValueType && ((this.item1 == null) || (other.item1 == null)))
            {
                flag = false;
            }
            else
            {
                flag = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item1Comparer.Equals(this.item1, other.item1);
            }
            if (!flag)
            {
                return false;
            }
            if ((!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item2IsValueType && (this.item2 == null)) && (other.item2 == null))
            {
                flag2 = true;
            }
            else if (!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item2IsValueType && ((this.item2 == null) || (other.item2 == null)))
            {
                flag2 = false;
            }
            else
            {
                flag2 = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item2Comparer.Equals(this.item2, other.item2);
            }
            if (!flag2)
            {
                return false;
            }
            if ((!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item3IsValueType && (this.item3 == null)) && (other.item3 == null))
            {
                flag3 = true;
            }
            else if (!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item3IsValueType && ((this.item3 == null) || (other.item3 == null)))
            {
                flag3 = false;
            }
            else
            {
                flag3 = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item3Comparer.Equals(this.item3, other.item3);
            }
            if (!flag3)
            {
                return false;
            }
            if ((!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item4IsValueType && (this.item4 == null)) && (other.item4 == null))
            {
                flag4 = true;
            }
            else if (!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item4IsValueType && ((this.item4 == null) || (other.item4 == null)))
            {
                flag4 = false;
            }
            else
            {
                flag4 = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item4Comparer.Equals(this.item4, other.item4);
            }
            if (!flag4)
            {
                return false;
            }
            if ((!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item5IsValueType && (this.item5 == null)) && (other.item5 == null))
            {
                flag5 = true;
            }
            else if (!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item5IsValueType && ((this.item5 == null) || (other.item5 == null)))
            {
                flag5 = false;
            }
            else
            {
                flag5 = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item5Comparer.Equals(this.item5, other.item5);
            }
            if (!flag5)
            {
                return false;
            }
            if ((!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item6IsValueType && (this.item6 == null)) && (other.item6 == null))
            {
                flag6 = true;
            }
            else if (!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item6IsValueType && ((this.item6 == null) || (other.item6 == null)))
            {
                flag6 = false;
            }
            else
            {
                flag6 = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item6Comparer.Equals(this.item6, other.item6);
            }
            if (!flag6)
            {
                return false;
            }
            if ((!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item7IsValueType && (this.item7 == null)) && (other.item7 == null))
            {
                flag7 = true;
            }
            else if (!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item7IsValueType && ((this.item7 == null) || (other.item7 == null)))
            {
                flag7 = false;
            }
            else
            {
                flag7 = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item7Comparer.Equals(this.item7, other.item7);
            }
            if (!flag7)
            {
                return false;
            }
            if ((!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item8IsValueType && (this.item8 == null)) && (other.item8 == null))
            {
                flag8 = true;
            }
            else if (!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item8IsValueType && ((this.item8 == null) || (other.item8 == null)))
            {
                flag8 = false;
            }
            else
            {
                flag8 = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item8Comparer.Equals(this.item8, other.item8);
            }
            return (((((((flag & flag2) & flag3) & flag4) & flag5) & flag6) & flag7) & flag8);
        }

        public override unsafe bool Equals(object obj) => 
            EquatableUtil.Equals<TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>, object>(*((TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>*) this), obj);

        public static bool operator ==(TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8> lhs, TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8> rhs) => 
            lhs.Equals(rhs);

        public static bool operator !=(TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8> lhs, TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8> rhs) => 
            !lhs.Equals(rhs);

        public override int GetHashCode()
        {
            int hashCode;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            if (!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item1IsValueType && (this.item1 == null))
            {
                hashCode = 0;
            }
            else
            {
                hashCode = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item1Comparer.GetHashCode(this.item1);
            }
            if (!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item2IsValueType && (this.item2 == null))
            {
                num2 = 0;
            }
            else
            {
                num2 = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item2Comparer.GetHashCode(this.item2);
            }
            if (!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item3IsValueType && (this.item3 == null))
            {
                num3 = 0;
            }
            else
            {
                num3 = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item3Comparer.GetHashCode(this.item3);
            }
            if (!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item4IsValueType && (this.item4 == null))
            {
                num4 = 0;
            }
            else
            {
                num4 = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item4Comparer.GetHashCode(this.item4);
            }
            if (!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item5IsValueType && (this.item5 == null))
            {
                num5 = 0;
            }
            else
            {
                num5 = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item5Comparer.GetHashCode(this.item5);
            }
            if (!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item6IsValueType && (this.item6 == null))
            {
                num6 = 0;
            }
            else
            {
                num6 = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item6Comparer.GetHashCode(this.item6);
            }
            if (!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item7IsValueType && (this.item7 == null))
            {
                num7 = 0;
            }
            else
            {
                num7 = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item7Comparer.GetHashCode(this.item7);
            }
            if (!TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item8IsValueType && (this.item8 == null))
            {
                num8 = 0;
            }
            else
            {
                num8 = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item8Comparer.GetHashCode(this.item8);
            }
            return HashCodeUtil.CombineHashCodes(hashCode, num2, num3, num4, num5, num6, num7, num8);
        }

        static TupleStruct()
        {
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item1Type = typeof(T1);
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item1IsValueType = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item1Type.IsValueType;
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item1Comparer = EqualityComparer<T1>.Default;
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item2Type = typeof(T2);
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item2IsValueType = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item2Type.IsValueType;
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item2Comparer = EqualityComparer<T2>.Default;
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item3Type = typeof(T3);
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item3IsValueType = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item3Type.IsValueType;
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item3Comparer = EqualityComparer<T3>.Default;
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item4Type = typeof(T4);
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item4IsValueType = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item4Type.IsValueType;
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item4Comparer = EqualityComparer<T4>.Default;
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item5Type = typeof(T5);
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item5IsValueType = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item5Type.IsValueType;
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item5Comparer = EqualityComparer<T5>.Default;
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item6Type = typeof(T6);
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item6IsValueType = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item6Type.IsValueType;
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item6Comparer = EqualityComparer<T6>.Default;
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item7Type = typeof(T7);
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item7IsValueType = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item7Type.IsValueType;
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item7Comparer = EqualityComparer<T7>.Default;
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item8Type = typeof(T8);
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item8IsValueType = TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item8Type.IsValueType;
            TupleStruct<T1, T2, T3, T4, T5, T6, T7, T8>.item8Comparer = EqualityComparer<T8>.Default;
        }
    }
}

