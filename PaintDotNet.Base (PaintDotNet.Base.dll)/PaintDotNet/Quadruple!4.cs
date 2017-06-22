namespace PaintDotNet
{
    using System;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential), Obsolete("Use Tuple<T1, T2, T3, T4> or TupleStruct<T1, T2, T3, T4> instead")]
    public struct Quadruple<T1, T2, T3, T4> : IEquatable<Quadruple<T1, T2, T3, T4>>
    {
        private static readonly Type t1Type;
        private static readonly bool t1IsValueType;
        private static readonly Type t2Type;
        private static readonly bool t2IsValueType;
        private static readonly Type t3Type;
        private static readonly bool t3IsValueType;
        private static readonly Type t4Type;
        private static readonly bool t4IsValueType;
        private readonly T1 first;
        private readonly T2 second;
        private readonly T3 third;
        private readonly T4 fourth;
        public static implicit operator Tuple<T1, T2, T3, T4>(Quadruple<T1, T2, T3, T4> from) => 
            new Tuple<T1, T2, T3, T4>(from.First, from.Second, from.Third, from.Fourth);

        public static implicit operator Quadruple<T1, T2, T3, T4>(Tuple<T1, T2, T3, T4> from) => 
            new Quadruple<T1, T2, T3, T4>(from.Item1, from.Item2, from.Item3, from.Item4);

        public static bool operator ==(Quadruple<T1, T2, T3, T4> lhs, Quadruple<T1, T2, T3, T4> rhs) => 
            lhs.Equals(rhs);

        public static bool operator !=(Quadruple<T1, T2, T3, T4> lhs, Quadruple<T1, T2, T3, T4> rhs) => 
            !lhs.Equals(rhs);

        public T1 First =>
            this.first;
        public T2 Second =>
            this.second;
        public T3 Third =>
            this.third;
        public T4 Fourth =>
            this.fourth;
        public override int GetHashCode()
        {
            int hashCode;
            int num2;
            int num3;
            int num4;
            if (!Quadruple<T1, T2, T3, T4>.t1IsValueType && (this.first == null))
            {
                hashCode = 0;
            }
            else
            {
                hashCode = this.first.GetHashCode();
            }
            if (!Quadruple<T1, T2, T3, T4>.t2IsValueType && (this.second == null))
            {
                num2 = 0;
            }
            else
            {
                num2 = this.second.GetHashCode();
            }
            if (!Quadruple<T1, T2, T3, T4>.t3IsValueType && (this.third == null))
            {
                num3 = 0;
            }
            else
            {
                num3 = this.third.GetHashCode();
            }
            if (!Quadruple<T1, T2, T3, T4>.t4IsValueType && (this.fourth == null))
            {
                num4 = 0;
            }
            else
            {
                num4 = this.fourth.GetHashCode();
            }
            return HashCodeUtil.CombineHashCodes(hashCode, num2, num3, num4);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Quadruple<T1, T2, T3, T4>))
            {
                return false;
            }
            Quadruple<T1, T2, T3, T4> other = (Quadruple<T1, T2, T3, T4>) obj;
            return this.Equals(other);
        }

        public bool Equals(Quadruple<T1, T2, T3, T4> other)
        {
            bool flag;
            bool flag2;
            bool flag3;
            bool flag4;
            if ((!Quadruple<T1, T2, T3, T4>.t1IsValueType && (this.first == null)) && (other.first == null))
            {
                flag = true;
            }
            else if (!Quadruple<T1, T2, T3, T4>.t1IsValueType && ((this.first == null) || (other.first == null)))
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
            if ((!Quadruple<T1, T2, T3, T4>.t2IsValueType && (this.second == null)) && (other.second == null))
            {
                flag2 = true;
            }
            else if (!Quadruple<T1, T2, T3, T4>.t2IsValueType && ((this.second == null) || (other.second == null)))
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
            if ((!Quadruple<T1, T2, T3, T4>.t3IsValueType && (this.third == null)) && (other.third == null))
            {
                flag3 = true;
            }
            else if (!Quadruple<T1, T2, T3, T4>.t3IsValueType && ((this.third == null) || (other.third == null)))
            {
                flag3 = false;
            }
            else
            {
                flag3 = this.third.Equals(other.third);
            }
            if (!flag3)
            {
                return false;
            }
            if ((!Quadruple<T1, T2, T3, T4>.t4IsValueType && (this.fourth == null)) && (other.fourth == null))
            {
                flag4 = true;
            }
            else if (!Quadruple<T1, T2, T3, T4>.t4IsValueType && ((this.fourth == null) || (other.fourth == null)))
            {
                flag4 = false;
            }
            else
            {
                flag4 = this.fourth.Equals(other.fourth);
            }
            return (((flag & flag2) & flag3) & flag4);
        }

        public Triple<T1, T2, T3> GetTriple123() => 
            Triple.Create<T1, T2, T3>(this.first, this.second, this.third);

        public Triple<T2, T3, T4> GetTriple234() => 
            Triple.Create<T2, T3, T4>(this.second, this.third, this.fourth);

        public Quadruple(T1 first, T2 second, T3 third, T4 fourth)
        {
            this.first = first;
            this.second = second;
            this.third = third;
            this.fourth = fourth;
        }

        static Quadruple()
        {
            Quadruple<T1, T2, T3, T4>.t1Type = typeof(T1);
            Quadruple<T1, T2, T3, T4>.t1IsValueType = Quadruple<T1, T2, T3, T4>.t1Type.IsValueType;
            Quadruple<T1, T2, T3, T4>.t2Type = typeof(T2);
            Quadruple<T1, T2, T3, T4>.t2IsValueType = Quadruple<T1, T2, T3, T4>.t2Type.IsValueType;
            Quadruple<T1, T2, T3, T4>.t3Type = typeof(T3);
            Quadruple<T1, T2, T3, T4>.t3IsValueType = Quadruple<T1, T2, T3, T4>.t3Type.IsValueType;
            Quadruple<T1, T2, T3, T4>.t4Type = typeof(T4);
            Quadruple<T1, T2, T3, T4>.t4IsValueType = Quadruple<T1, T2, T3, T4>.t4Type.IsValueType;
        }
    }
}

