namespace PaintDotNet
{
    using System;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct Pair<T1, T2> : IEquatable<Pair<T1, T2>>
    {
        private static readonly Type t1Type;
        private static readonly bool t1IsValueType;
        private static readonly Type t2Type;
        private static readonly bool t2IsValueType;
        private T1 first;
        private T2 second;
        public static implicit operator Tuple<T1, T2>(Pair<T1, T2> from) => 
            new Tuple<T1, T2>(from.First, from.Second);

        public static explicit operator TupleStruct<T1, T2>(Pair<T1, T2> from) => 
            new TupleStruct<T1, T2>(from.First, from.Second);

        public static implicit operator Pair<T1, T2>(TupleStruct<T1, T2> from) => 
            new Pair<T1, T2>(from.Item1, from.Item2);

        public static implicit operator Pair<T1, T2>(Tuple<T1, T2> from) => 
            new Pair<T1, T2>(from.Item1, from.Item2);

        public static bool operator ==(Pair<T1, T2> lhs, Pair<T1, T2> rhs) => 
            lhs.Equals(rhs);

        public static bool operator !=(Pair<T1, T2> lhs, Pair<T1, T2> rhs) => 
            !lhs.Equals(rhs);

        public T1 First =>
            this.first;
        public T2 Second =>
            this.second;
        public override int GetHashCode()
        {
            int hashCode;
            int num2;
            if (!Pair<T1, T2>.t1IsValueType && (this.first == null))
            {
                hashCode = 0;
            }
            else
            {
                hashCode = this.first.GetHashCode();
            }
            if (!Pair<T1, T2>.t2IsValueType && (this.second == null))
            {
                num2 = 0;
            }
            else
            {
                num2 = this.second.GetHashCode();
            }
            return HashCodeUtil.CombineHashCodes(hashCode, num2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Pair<T1, T2>))
            {
                return false;
            }
            Pair<T1, T2> other = (Pair<T1, T2>) obj;
            return this.Equals(other);
        }

        public bool Equals(Pair<T1, T2> other)
        {
            bool flag;
            bool flag2;
            if ((!Pair<T1, T2>.t1IsValueType && (this.first == null)) && (other.first == null))
            {
                flag = true;
            }
            else if (!Pair<T1, T2>.t1IsValueType && ((this.first == null) || (other.first == null)))
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
            if ((!Pair<T1, T2>.t2IsValueType && (this.second == null)) && (other.second == null))
            {
                flag2 = true;
            }
            else if (!Pair<T1, T2>.t2IsValueType && ((this.second == null) || (other.second == null)))
            {
                flag2 = false;
            }
            else
            {
                flag2 = this.second.Equals(other.second);
            }
            return (flag & flag2);
        }

        public Pair(T1 first, T2 second)
        {
            this.first = first;
            this.second = second;
        }

        static Pair()
        {
            Pair<T1, T2>.t1Type = typeof(T1);
            Pair<T1, T2>.t1IsValueType = Pair<T1, T2>.t1Type.IsValueType;
            Pair<T1, T2>.t2Type = typeof(T2);
            Pair<T1, T2>.t2IsValueType = Pair<T1, T2>.t2Type.IsValueType;
        }
    }
}

