namespace PaintDotNet.IO
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;

    public sealed class SegmentedMemoryStream : Stream, IIsDisposed, IDisposable
    {
        private SegmentedList<byte> buffer;
        private const int defaultSectorSizeLog2 = 12;
        private int position;
        private int sectorSizeLog2;

        public SegmentedMemoryStream() : this(12)
        {
        }

        public SegmentedMemoryStream(int sectorSizeLog2)
        {
            Validate.IsNotNegative(sectorSizeLog2, "sectorSizeLog2");
            this.sectorSizeLog2 = sectorSizeLog2;
            this.buffer = new SegmentedList<byte>(0, sectorSizeLog2);
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            ExceptionUtil.ThrowNotSupportedException();
            return null;
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            ExceptionUtil.ThrowNotSupportedException();
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            this.buffer = null;
            base.Dispose(disposing);
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            ExceptionUtil.ThrowNotSupportedException();
            return -1;
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            ExceptionUtil.ThrowNotSupportedException();
        }

        public override void Flush()
        {
        }

        public IList<byte> GetData() => 
            new ReadOnlyCollection<byte>(this.buffer);

        internal IList<byte[]> GetSectors() => 
            this.buffer.GetSegments();

        public override int Read(byte[] buffer, int offset, int count)
        {
            Validate.IsNotNull<byte[]>(buffer, "buffer");
            Validate.IsNotNegative(offset, "offset");
            Validate.IsNotNegative(count, "count");
            Validate.IsLessThanOrEqualTo(offset + count, (long) buffer.Length, "offset, count, buffer.Length");
            int num = this.buffer.Count - this.position;
            int num2 = Math.Min(count, num);
            if (num2 <= 0)
            {
                return 0;
            }
            this.buffer.Copy(this.position, count, buffer, offset);
            this.position += num2;
            return num2;
        }

        public override int ReadByte()
        {
            if (this.position == this.Length)
            {
                return -1;
            }
            this.position++;
            return this.buffer[this.position - 1];
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            Validate.IsLessThan(offset, 0x7fffffffL, "offset");
            switch (origin)
            {
                case SeekOrigin.Begin:
                    Validate.IsClamped(offset, 0L, this.Length, "offset");
                    this.position = (int) offset;
                    break;

                case SeekOrigin.Current:
                {
                    long num = this.position + offset;
                    Validate.IsClamped(num, 0L, this.Length, "offset");
                    this.position = (int) num;
                    break;
                }
                case SeekOrigin.End:
                {
                    long num2 = this.Length + offset;
                    Validate.IsClamped(num2, 0L, this.Length, "offset");
                    this.position = (int) num2;
                    break;
                }
                default:
                    throw ExceptionUtil.InvalidEnumArgumentException<SeekOrigin>(origin, "origin");
            }
            return (long) this.position;
        }

        public override void SetLength(long value)
        {
            Validate.IsClamped(value, 0L, 0x7fffffffL, "value");
            this.buffer.Resize((int) value, true, false);
            this.position = Math.Min(this.position, this.buffer.Count);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            Validate.IsNotNull<byte[]>(buffer, "buffer");
            Validate.IsNotNegative(offset, "offset");
            Validate.IsNotNegative(count, "count");
            Validate.IsLessThanOrEqualTo(offset + count, (long) buffer.Length, "offset, count, buffer.Length");
            int newCount = this.position + count;
            if (newCount > this.buffer.Count)
            {
                this.buffer.Resize(newCount);
            }
            this.buffer.SetRange(this.position, buffer, offset, count);
            this.position += count;
        }

        public override void WriteByte(byte value)
        {
            if (this.position == this.buffer.Count)
            {
                this.buffer.Resize(this.buffer.Count + 1);
            }
            this.buffer[this.position] = value;
            this.position++;
        }

        public void WriteTo(int startPosition, int count, Stream outputStream)
        {
            Validate.IsNotNull<Stream>(outputStream, "outputStream");
            if (!outputStream.CanWrite)
            {
                throw new ReadOnlyException("outputStream");
            }
            Validate.IsClamped((long) startPosition, 0L, this.Length, "startPosition");
            Validate.IsNotNegative(count, "count");
            if (count != 0)
            {
                Validate.IsClamped((long) (startPosition + count), 0L, this.Length, "startPosition + count");
                int listIndex = startPosition;
                int num2 = startPosition + count;
                int segmentIndex = this.buffer.GetSegmentIndex(listIndex);
                int segmentSubIndex = this.buffer.GetSegmentSubIndex(listIndex);
                byte[] segment = null;
                while (listIndex < num2)
                {
                    segment = this.buffer.GetSegment(segmentIndex);
                    int num1 = Math.Min(listIndex + (segment.Length - segmentSubIndex), num2);
                    int num5 = num1 - listIndex;
                    outputStream.Write(segment, segmentSubIndex, num5);
                    listIndex = num1;
                    segmentSubIndex = 0;
                    segmentIndex++;
                }
            }
        }

        public override bool CanRead =>
            true;

        public override bool CanSeek =>
            true;

        public override bool CanTimeout =>
            false;

        public override bool CanWrite =>
            true;

        public long Capacity =>
            ((long) this.buffer.Capacity);

        public bool IsDisposed =>
            (this.buffer == null);

        public override long Length =>
            ((long) this.buffer.Count);

        public override long Position
        {
            get => 
                ((long) this.position);
            set
            {
                Validate.IsClamped(value, 0L, 0x7fffffffL, "value");
                this.position = (int) value;
            }
        }

        public override int ReadTimeout
        {
            get
            {
                throw new InvalidOperationException();
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        public int SectorSize =>
            (((int) 1) << this.sectorSizeLog2);

        public int SectorSizeLog2 =>
            this.sectorSizeLog2;

        public override int WriteTimeout
        {
            get
            {
                throw new InvalidOperationException();
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
    }
}

