namespace PaintDotNet
{
    using System;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential), Obsolete("Use Tuple<T1, T2, T3> or TupleStruct<T1, T2, T3> instead")]
    public struct Triple<T1, T2, T3> : IEquatable<Triple<T1, T2, T3>>
    {
        private static readonly Type t1Type;
        private static readonly bool t1IsValueType;
        private static readonly Type t2Type;
        private static readonly bool t2IsValueType;
        private static readonly Type t3Type;
        private static readonly bool t3IsValueType;
        private T1 first;
        private T2 second;
        private T3 third;
        public static implicit operator Tuple<T1, T2, T3>(Triple<T1, T2, T3> from) => 
            new Tuple<T1, T2, T3>(from.First, from.Second, from.Third);

        public static implicit operator TupleStruct<T1, T2, T3>(Triple<T1, T2, T3> from) => 
            new TupleStruct<T1, T2, T3>(from.First, from.Second, from.Third);

        public static implicit operator Triple<T1, T2, T3>(Tuple<T1, T2, T3> from) => 
            new Triple<T1, T2, T3>(from.Item1, from.Item2, from.Item3);

        public static bool operator ==(Triple<T1, T2, T3> lhs, Triple<T1, T2, T3> rhs) => 
            lhs.Equals(rhs);

        public static bool operator !=(Triple<T1, T2, T3> lhs, Triple<T1, T2, T3> rhs) => 
            !lhs.Equals(rhs);

        public T1 First =>
            this.first;
        public T2 Second =>
            this.second;
        public T3 Third =>
            this.third;
        public override int GetHashCode()
        {
            int hashCode;
            int num2;
            int num3;
            if (!Triple<T1, T2, T3>.t1IsValueType && (this.first == null))
            {
                hashCode = 0;
            }
            else
            {
                hashCode = this.first.GetHashCode();
            }
            if (!Triple<T1, T2, T3>.t2IsValueType && (this.second == null))
            {
                num2 = 0;
            }
            else
            {
                num2 = this.second.GetHashCode();
            }
            if (!Triple<T1, T2, T3>.t3IsValueType && (this.third == null))
            {
                num3 = 0;
            }
            else
            {
                num3 = this.third.GetHashCode();
            }
            return HashCodeUtil.CombineHashCodes(hashCode, num2, num3);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Triple<T1, T2, T3>))
            {
                return false;
            }
            Triple<T1, T2, T3> other = (Triple<T1, T2, T3>) obj;
            return this.Equals(other);
        }

        public bool Equals(Triple<T1, T2, T3> other)
        {
            bool flag;
            bool flag2;
            bool flag3;
            if ((!Triple<T1, T2, T3>.t1IsValueType && (this.first == null)) && (other.first == null))
            {
                flag = true;
            }
            else if (!Triple<T1, T2, T3>.t1IsValueType && ((this.first == null) || (other.first == null)))
            {
                flag = false;
            }
            else
            {
                flag = this.first.Equals(other.first);
            }
            if (!flag)
            {
                return false;
            }
            if ((!Triple<T1, T2, T3>.t2IsValueType && (this.second == null)) && (other.second == null))
            {
                flag2 = true;
            }
            else if (!Triple<T1, T2, T3>.t2IsValueType && ((this.second == null) || (other.second == null)))
            {
                flag2 = false;
            }
            else
            {
                flag2 = this.second.Equals(other.second);
            }
            if (!flag2)
            {
                return false;
            }
            if ((!Triple<T1, T2, T3>.t3IsValueType && (this.third == null)) && (other.third == null))
            {
                flag3 = true;
            }
            else if (!Triple<T1, T2, T3>.t3IsValueType && ((this.third == null) || (other.third == null)))
            {
                flag3 = false;
            }
            else
            {
                flag3 = this.third.Equals(other.third);
            }
            return ((flag & flag2) & flag3);
        }

        public Triple(T1 first, T2 second, T3 third)
        {
            this.first = first;
            this.second = second;
            this.third = third;
        }

        static Triple()
        {
            Triple<T1, T2, T3>.t1Type = typeof(T1);
            Triple<T1, T2, T3>.t1IsValueType = Triple<T1, T2, T3>.t1Type.IsValueType;
            Triple<T1, T2, T3>.t2Type = typeof(T2);
            Triple<T1, T2, T3>.t2IsValueType = Triple<T1, T2, T3>.t2Type.IsValueType;
            Triple<T1, T2, T3>.t3Type = typeof(T3);
            Triple<T1, T2, T3>.t3IsValueType = Triple<T1, T2, T3>.t3Type.IsValueType;
        }
    }
}

