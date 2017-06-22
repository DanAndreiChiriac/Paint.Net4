namespace PaintDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct TupleStruct<T1, T2, T3> : IEquatable<TupleStruct<T1, T2, T3>>
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
        private T1 item1;
        private T2 item2;
        private T3 item3;
        public static implicit operator Tuple<T1, T2, T3>(TupleStruct<T1, T2, T3> from) => 
            new Tuple<T1, T2, T3>(from.Item1, from.Item2, from.Item3);

        public static implicit operator TupleStruct<T1, T2, T3>(Tuple<T1, T2, T3> from) => 
            new TupleStruct<T1, T2, T3>(from.Item1, from.Item2, from.Item3);

        public T1 Item1 =>
            this.item1;
        public T2 Item2 =>
            this.item2;
        public T3 Item3 =>
            this.item3;
        public TupleStruct(T1 item1, T2 item2, T3 item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }

        public bool Equals(TupleStruct<T1, T2, T3> other)
        {
            bool flag;
            bool flag2;
            bool flag3;
            if ((!TupleStruct<T1, T2, T3>.item1IsValueType && (this.item1 == null)) && (other.item1 == null))
            {
                flag = true;
            }
            else if (!TupleStruct<T1, T2, T3>.item1IsValueType && ((this.item1 == null) || (other.item1 == null)))
            {
                flag = false;
            }
            else
            {
                flag = TupleStruct<T1, T2, T3>.item1Comparer.Equals(this.item1, other.item1);
            }
            if (!flag)
            {
                return false;
            }
            if ((!TupleStruct<T1, T2, T3>.item2IsValueType && (this.item2 == null)) && (other.item2 == null))
            {
                flag2 = true;
            }
            else if (!TupleStruct<T1, T2, T3>.item2IsValueType && ((this.item2 == null) || (other.item2 == null)))
            {
                flag2 = false;
            }
            else
            {
                flag2 = TupleStruct<T1, T2, T3>.item2Comparer.Equals(this.item2, other.item2);
            }
            if (!flag2)
            {
                return false;
            }
            if ((!TupleStruct<T1, T2, T3>.item3IsValueType && (this.item3 == null)) && (other.item3 == null))
            {
                flag3 = true;
            }
            else if (!TupleStruct<T1, T2, T3>.item3IsValueType && ((this.item3 == null) || (other.item3 == null)))
            {
                flag3 = false;
            }
            else
            {
                flag3 = TupleStruct<T1, T2, T3>.item3Comparer.Equals(this.item3, other.item3);
            }
            return ((flag & flag2) & flag3);
        }

        public override unsafe bool Equals(object obj) => 
            EquatableUtil.Equals<TupleStruct<T1, T2, T3>, object>(*((TupleStruct<T1, T2, T3>*) this), obj);

        public static bool operator ==(TupleStruct<T1, T2, T3> lhs, TupleStruct<T1, T2, T3> rhs) => 
            lhs.Equals(rhs);

        public static bool operator !=(TupleStruct<T1, T2, T3> lhs, TupleStruct<T1, T2, T3> rhs) => 
            !lhs.Equals(rhs);

        public override int GetHashCode()
        {
            int hashCode;
            int num2;
            int num3;
            if (!TupleStruct<T1, T2, T3>.item1IsValueType && (this.item1 == null))
            {
                hashCode = 0;
            }
            else
            {
                hashCode = TupleStruct<T1, T2, T3>.item1Comparer.GetHashCode(this.item1);
            }
            if (!TupleStruct<T1, T2, T3>.item2IsValueType && (this.item2 == null))
            {
                num2 = 0;
            }
            else
            {
                num2 = TupleStruct<T1, T2, T3>.item2Comparer.GetHashCode(this.item2);
            }
            if (!TupleStruct<T1, T2, T3>.item3IsValueType && (this.item3 == null))
            {
                num3 = 0;
            }
            else
            {
                num3 = TupleStruct<T1, T2, T3>.item3Comparer.GetHashCode(this.item3);
            }
            return HashCodeUtil.CombineHashCodes(hashCode, num2, num3);
        }

        static TupleStruct()
        {
            TupleStruct<T1, T2, T3>.item1Type = typeof(T1);
            TupleStruct<T1, T2, T3>.item1IsValueType = TupleStruct<T1, T2, T3>.item1Type.IsValueType;
            TupleStruct<T1, T2, T3>.item1Comparer = EqualityComparer<T1>.Default;
            TupleStruct<T1, T2, T3>.item2Type = typeof(T2);
            TupleStruct<T1, T2, T3>.item2IsValueType = TupleStruct<T1, T2, T3>.item2Type.IsValueType;
            TupleStruct<T1, T2, T3>.item2Comparer = EqualityComparer<T2>.Default;
            TupleStruct<T1, T2, T3>.item3Type = typeof(T3);
            TupleStruct<T1, T2, T3>.item3IsValueType = TupleStruct<T1, T2, T3>.item3Type.IsValueType;
            TupleStruct<T1, T2, T3>.item3Comparer = EqualityComparer<T3>.Default;
        }
    }
}

