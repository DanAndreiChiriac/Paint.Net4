namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct BitVector8 : IEquatable<BitVector8>
    {
        private byte bits;
        public byte Bits
        {
            get => 
                this.bits;
            set
            {
                this.bits = value;
            }
        }
        public bool GetBool(int bitIndex)
        {
            Validate.Begin().IsValueInRange(bitIndex, 0, 7, "bitIndex").Check();
            return (((this.bits & (1 << (bitIndex & 0x1f))) >> bitIndex) > 0);
        }

        public void SetBool(int bitIndex, bool value)
        {
            byte num;
            Validate.Begin().IsValueInRange(bitIndex, 0, 7, "bitIndex").Check();
            if (value)
            {
                num = (byte) (this.bits | (((int) 1) << bitIndex));
            }
            else
            {
                num = (byte) (this.bits & ~(((int) 1) << bitIndex));
            }
            this.bits = num;
        }

        public int GetSection(int bitsMask, int shift) => 
            ((this.bits & bitsMask) >> shift);

        public void SetSection(int bitsMask, int shift, int value)
        {
            Validate.Begin().IsValueInRange(bitsMask, 0, 0xff, "bitsMask").IsValueInRange(shift, 0, 7, "shift").Check();
            if ((value & ~(bitsMask >> shift)) != 0)
            {
                throw new ArgumentOutOfRangeException("value has bits set that are not accounted for with bitsMask");
            }
            this.bits = (byte) ((this.bits & ~bitsMask) | ((value << shift) & bitsMask));
        }

        public int GetSection(Section section) => 
            this.GetSection(section.Mask, section.Shift);

        public void SetSection(Section section, int value)
        {
            this.SetSection(section.Mask, section.Shift, value);
        }

        public BitVector8(byte bits)
        {
            this.bits = bits;
        }

        public bool Equals(BitVector8 other) => 
            (this.bits == other.bits);

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<BitVector8, object>(this, obj);

        public static bool operator ==(BitVector8 a, BitVector8 b) => 
            a.Equals(b);

        public static bool operator !=(BitVector8 a, BitVector8 b) => 
            !(a == b);

        public override int GetHashCode() => 
            this.bits.GetHashCode();
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct Section : IEquatable<BitVector8.Section>
        {
            private byte mask;
            private byte shift;
            public byte Mask =>
                this.mask;
            public byte Shift =>
                this.shift;
            public static BitVector8.Section FromRange(int startBit, int length)
            {
                Validate.Begin().IsValueInRange(startBit, 0, 7, "startBit").IsValueInRange(length, startBit, (8 - startBit), "length").Check();
                return new BitVector8.Section((byte) (((((int) 1) << (startBit + length)) - 1) & ~((((int) 1) << startBit) - 1)), (byte) startBit);
            }

            public Section(byte mask, byte shift)
            {
                this.mask = mask;
                this.shift = shift;
            }

            public bool Equals(BitVector8.Section other) => 
                ((this.mask == other.mask) && (this.shift == other.shift));

            public override bool Equals(object obj) => 
                EquatableUtil.Equals<BitVector8.Section, object>(this, obj);

            public static bool operator ==(BitVector8.Section a, BitVector8.Section b) => 
                a.Equals(b);

            public static bool operator !=(BitVector8.Section a, BitVector8.Section b) => 
                !(a == b);

            public override int GetHashCode() => 
                HashCodeUtil.CombineHashCodes(this.mask.GetHashCode(), this.shift.GetHashCode());
        }
    }
}

