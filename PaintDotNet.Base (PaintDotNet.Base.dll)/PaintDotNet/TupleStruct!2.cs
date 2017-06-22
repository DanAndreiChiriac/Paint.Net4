namespace PaintDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct TupleStruct<T1, T2> : IEquatable<TupleStruct<T1, T2>>
    {
        private static readonly Type item1Type;
        private static readonly bool item1IsValueType;
        private static readonly EqualityComparer<T1> item1Comparer;
        private static readonly Type item2Type;
        private static readonly bool item2IsValueType;
        private static readonly EqualityComparer<T2> item2Comparer;
        private T1 item1;
        private T2 item2;
        public static implicit operator Tuple<T1, T2>(TupleStruct<T1, T2> from) => 
            new Tuple<T1, T2>(from.Item1, from.Item2);

        public static implicit operator TupleStruct<T1, T2>(Tuple<T1, T2> from) => 
            new TupleStruct<T1, T2>(from.Item1, from.Item2);

        public T1 Item1 =>
            this.item1;
        public T2 Item2 =>
            this.item2;
        public TupleStruct(T1 item1, T2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public bool Equals(TupleStruct<T1, T2> other)
        {
            bool flag;
            bool flag2;
            if ((!TupleStruct<T1, T2>.item1IsValueType && (this.item1 == null)) && (other.item1 == null))
            {
                flag = true;
            }
            else if (!TupleStruct<T1, T2>.item1IsValueType && ((this.item1 == null) || (other.item1 == null)))
            {
                flag = false;
            }
            else
            {
                flag = TupleStruct<T1, T2>.item1Comparer.Equals(this.item1, other.item1);
            }
            if (!flag)
            {
                return false;
            }
            if ((!TupleStruct<T1, T2>.item2IsValueType && (this.item2 == null)) && (other.item2 == null))
            {
                flag2 = true;
            }
            else if (!TupleStruct<T1, T2>.item2IsValueType && ((this.item2 == null) || (other.item2 == null)))
            {
                flag2 = false;
            }
            else
            {
                flag2 = TupleStruct<T1, T2>.item2Comparer.Equals(this.item2, other.item2);
            }
            return (flag & flag2);
        }

        public override unsafe bool Equals(object obj) => 
            EquatableUtil.Equals<TupleStruct<T1, T2>, object>(*((TupleStruct<T1, T2>*) this), obj);

        public static bool operator ==(TupleStruct<T1, T2> lhs, TupleStruct<T1, T2> rhs) => 
            lhs.Equals(rhs);

        public static bool operator !=(TupleStruct<T1, T2> lhs, TupleStruct<T1, T2> rhs) => 
            !lhs.Equals(rhs);

        public override int GetHashCode()
        {
            int hashCode;
            int num2;
            if (!TupleStruct<T1, T2>.item1IsValueType && (this.item1 == null))
            {
                hashCode = 0;
            }
            else
            {
                hashCode = TupleStruct<T1, T2>.item1Comparer.GetHashCode(this.item1);
            }
            if (!TupleStruct<T1, T2>.item2IsValueType && (this.item2 == null))
            {
                num2 = 0;
            }
            else
            {
                num2 = TupleStruct<T1, T2>.item2Comparer.GetHashCode(this.item2);
            }
            return HashCodeUtil.CombineHashCodes(hashCode, num2);
        }

        static TupleStruct()
        {
            TupleStruct<T1, T2>.item1Type = typeof(T1);
            TupleStruct<T1, T2>.item1IsValueType = TupleStruct<T1, T2>.item1Type.IsValueType;
            TupleStruct<T1, T2>.item1Comparer = EqualityComparer<T1>.Default;
            TupleStruct<T1, T2>.item2Type = typeof(T2);
            TupleStruct<T1, T2>.item2IsValueType = TupleStruct<T1, T2>.item2Type.IsValueType;
            TupleStruct<T1, T2>.item2Comparer = EqualityComparer<T2>.Default;
        }
    }
}

