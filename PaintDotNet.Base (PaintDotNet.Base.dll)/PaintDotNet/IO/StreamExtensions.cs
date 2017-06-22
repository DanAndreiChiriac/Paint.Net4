namespace PaintDotNet.IO
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;

    public static class StreamExtensions
    {
        public static void CopyTo(this Stream stream, Stream destination, byte[] buffer)
        {
            int num;
            while ((num = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                destination.Write(buffer, 0, num);
            }
        }

        public static int ProperRead(this Stream input, byte[] buffer, int offset, int count)
        {
            int num = 0;
            while (num < count)
            {
                int num2 = input.Read(buffer, offset + num, count - num);
                if (num2 == 0)
                {
                    throw new EndOfStreamException();
                }
                num += num2;
            }
            return num;
        }

        public static int ReadInt16(this Stream stream)
        {
            int num = stream.ReadUInt16();
            if (num == -1)
            {
                return -1;
            }
            return (ushort) (num & 0xffffffffL);
        }

        public static long ReadInt32(this Stream stream)
        {
            long num = stream.ReadUInt32();
            if (num == -1L)
            {
                return -1L;
            }
            uint num2 = (uint) (((ulong) num) & 0xffffffffL);
            return (long) num2;
        }

        public static int ReadUInt16(this Stream stream)
        {
            int num = stream.ReadByte();
            if (num == -1)
            {
                return -1;
            }
            int num2 = stream.ReadByte();
            if (num2 == -1)
            {
                return -1;
            }
            return (num + (num2 << 8));
        }

        public static int ReadUInt24(this Stream stream)
        {
            int num = stream.ReadByte();
            if (num == -1)
            {
                return -1;
            }
            int num2 = stream.ReadByte();
            if (num2 == -1)
            {
                return -1;
            }
            int num3 = stream.ReadByte();
            if (num3 == -1)
            {
                return -1;
            }
            return ((num + (num2 << 8)) + (num3 << 0x10));
        }

        public static long ReadUInt32(this Stream stream)
        {
            int num = stream.ReadByte();
            if (num == -1)
            {
                return -1L;
            }
            int num2 = stream.ReadByte();
            if (num2 == -1)
            {
                return -1L;
            }
            int num3 = stream.ReadByte();
            if (num3 == -1)
            {
                return -1L;
            }
            int num4 = stream.ReadByte();
            if (num4 == -1)
            {
                return -1L;
            }
            return (long) ((ulong) (((num + (num2 << 8)) + (num3 << 0x10)) + (num4 << 0x18)));
        }

        public static unsafe void WriteInt16(this Stream stream, short value)
        {
            stream.WriteUInt16(*((ushort*) &value));
        }

        public static unsafe void WriteInt32(this Stream stream, int value)
        {
            stream.WriteUInt32(*((uint*) &value));
        }

        public static unsafe void WriteInt64(this Stream stream, long value)
        {
            stream.WriteUInt64(*((ulong*) &value));
        }

        public static void WriteUInt16(this Stream stream, ushort value)
        {
            stream.WriteByte((byte) (value & 0xff));
            stream.WriteByte((byte) (value >> 8));
        }

        public static void WriteUInt24(this Stream stream, int value)
        {
            Validate.IsClamped(value, 0, 0xffffff, "value");
            stream.WriteByte((byte) (value & 0xff));
            stream.WriteByte((byte) ((value >> 8) & 0xff));
            stream.WriteByte((byte) ((value >> 0x10) & 0xff));
        }

        public static void WriteUInt32(this Stream stream, uint value)
        {
            stream.WriteByte((byte) (value & 0xff));
            stream.WriteByte((byte) ((value >> 8) & 0xff));
            stream.WriteByte((byte) ((value >> 0x10) & 0xff));
            stream.WriteByte((byte) ((value >> 0x18) & 0xff));
        }

        public static void WriteUInt64(this Stream stream, ulong value)
        {
            stream.WriteByte((byte) (value & ((ulong) 0xffL)));
            stream.WriteByte((byte) ((value >> 8) & ((ulong) 0xffL)));
            stream.WriteByte((byte) ((value >> 0x10) & ((ulong) 0xffL)));
            stream.WriteByte((byte) ((value >> 0x18) & ((ulong) 0xffL)));
            stream.WriteByte((byte) ((value >> 0x20) & ((ulong) 0xffL)));
            stream.WriteByte((byte) ((value >> 40) & ((ulong) 0xffL)));
            stream.WriteByte((byte) ((value >> 0x30) & ((ulong) 0xffL)));
            stream.WriteByte((byte) ((value >> 0x38) & ((ulong) 0xffL)));
        }
    }
}

