namespace PaintDotNet.IO
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using PaintDotNet.MemoryManagement;
    using System;
    using System.IO;

    public sealed class NativeMemoryStream : Stream, IIsDisposed, IDisposable
    {
        private IAllocator allocator;
        private unsafe byte* buffer;
        private IBufferLock bufferLockRef;
        private IBuffer bufferRef;
        private long bufferSize;
        private long length;
        private long position;

        public NativeMemoryStream(IAllocator allocator) : this(allocator, 0)
        {
        }

        public unsafe NativeMemoryStream(IAllocator allocator, int capacity)
        {
            Validate.Begin().IsNotNull<IAllocator>(allocator, "allocator").IsNotNegative(capacity, "capacity").Check();
            this.allocator = allocator.CreateRef();
            this.bufferRef = null;
            this.bufferLockRef = null;
            this.buffer = null;
            this.bufferSize = 0L;
            this.length = 0L;
            this.position = 0L;
            if (capacity > 0)
            {
                this.EnsureCapacity((long) capacity);
            }
        }

        protected override unsafe void Dispose(bool disposing)
        {
            DisposableUtil.Free<IBufferLock>(ref this.bufferLockRef, disposing);
            DisposableUtil.Free<IBuffer>(ref this.bufferRef, disposing);
            DisposableUtil.Free<IAllocator>(ref this.allocator, disposing);
            this.buffer = null;
            this.bufferSize = 0L;
            this.length = 0L;
            this.position = 0L;
            base.Dispose(disposing);
        }

        private bool EnsureCapacity(long desiredCapacity)
        {
            Validate.IsNotNegative(desiredCapacity, "desiredCapacity");
            long capacity = this.Capacity;
            if (desiredCapacity <= capacity)
            {
                return false;
            }
            long num2 = desiredCapacity;
            if (num2 < 0x100L)
            {
                num2 = 0x100L;
            }
            if (num2 < (capacity * 2L))
            {
                num2 = capacity * 2L;
            }
            this.Capacity = num2;
            return true;
        }

        public override void Flush()
        {
        }

        public unsafe long Read(byte* pBuffer, long count)
        {
            Validate.Begin().IsNotNull(((void*) pBuffer), "pBuffer").IsNotNegative(count, "count").Check();
            long num = this.length - this.position;
            if (num > count)
            {
                num = count;
            }
            if (num <= 0L)
            {
                return 0L;
            }
            Buffer.MemoryCopy((void*) (this.buffer + this.position), (void*) pBuffer, count, count);
            this.position += num;
            return num;
        }

        public override int Read(byte[] buffer, int offset, int count) => 
            ((int) this.Read(buffer, (long) offset, (long) count));

        public unsafe long Read(byte[] buffer, long offset, long count)
        {
            byte[] buffer2;
            Validate.Begin().IsNotNull<byte[]>(buffer, "buffer").IsNotNegative(offset, "offset").IsNotNegative(count, "count").Check().IsRangeValid(((long) buffer.Length), offset, count, "buffer").Check();
            if (((buffer2 = buffer) == null) || (buffer2.Length == 0))
            {
                fixed (byte* numRef = null)
                {
                }
            }
            return this.Read(numRef + ((byte*) offset), count);
        }

        public override unsafe int ReadByte()
        {
            if (this.position >= this.length)
            {
                return -1;
            }
            this.position += 1L;
            return *(((int*) (this.buffer + this.position)));
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            long num;
            switch (origin)
            {
                case SeekOrigin.Begin:
                    num = offset;
                    break;

                case SeekOrigin.Current:
                    num = this.position + offset;
                    break;

                case SeekOrigin.End:
                    num = this.length + offset;
                    break;

                default:
                    throw ExceptionUtil.InvalidEnumArgumentException<SeekOrigin>(origin, "origin");
            }
            if (num < 0L)
            {
                throw new IOException($"cannot seek to a negative position. offset = {offset}, origin = {origin}, this.position = {this.position}, newPosition = {num}");
            }
            this.position = num;
            return num;
        }

        public override unsafe void SetLength(long value)
        {
            Validate.IsNotNegative(value, "value");
            if (!this.EnsureCapacity(value) && (value > this.length))
            {
                BufferUtil.ZeroMemory(this.buffer + ((byte*) this.length), value - this.length);
            }
            this.length = value;
            if (this.position > value)
            {
                this.position = value;
            }
        }

        public unsafe void Write(byte* pBuffer, long count)
        {
            Validate.Begin().IsNotNull(((void*) pBuffer), "pBuffer").IsNotNegative(count, "count").Check();
            long num = this.position + count;
            if (num < 0L)
            {
                throw new IOException($"stream too long, this.position + count = {this.position} + {count} = {num}");
            }
            if (num > this.length)
            {
                bool flag = this.position > this.length;
                if ((num > this.Capacity) && this.EnsureCapacity(num))
                {
                    flag = false;
                }
                if (flag)
                {
                    BufferUtil.ZeroMemory(this.buffer + ((byte*) this.length), num - this.length);
                }
                this.length = num;
            }
            byte* numPtr = this.buffer + ((byte*) this.position);
            Buffer.MemoryCopy((void*) pBuffer, (void*) numPtr, this.bufferSize, count);
            this.position += count;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            this.Write(buffer, (long) offset, (long) count);
        }

        public unsafe void Write(byte[] buffer, long offset, long count)
        {
            Validate.Begin().IsNotNull<byte[]>(buffer, "buffer").IsNotNegative(offset, "offset").IsNotNegative(count, "count").Check().IsRangeValid(((long) buffer.Length), offset, count, "buffer").Check();
            fixed (byte* numRef = buffer)
            {
                this.Write(numRef + ((byte*) offset), count);
            }
        }

        public override unsafe void WriteByte(byte value)
        {
            if (this.position >= this.length)
            {
                long desiredCapacity = this.position + 1L;
                bool flag = this.position > this.length;
                if ((desiredCapacity >= this.Capacity) && this.EnsureCapacity(desiredCapacity))
                {
                    flag = false;
                }
                if (flag)
                {
                    BufferUtil.ZeroMemory(this.buffer + ((byte*) this.length), this.position - this.length);
                }
                this.length = desiredCapacity;
            }
            this.buffer[(int) this.position] = value;
            this.position += 1L;
        }

        public override bool CanRead =>
            true;

        public override bool CanSeek =>
            true;

        public override bool CanTimeout =>
            false;

        public override bool CanWrite =>
            true;

        public long Capacity
        {
            get => 
                this.bufferSize;
            set
            {
                Validate.Begin().IsNotNegative(value, "value").IsGreaterThanOrEqualTo(value, this.length, "value").Check();
                if (value == 0)
                {
                    DisposableUtil.Free<IBuffer>(ref this.bufferRef);
                    DisposableUtil.Free<IBufferLock>(ref this.bufferLockRef);
                    this.buffer = null;
                    this.bufferSize = 0L;
                }
                else
                {
                    IBuffer buffer = this.allocator.Allocate(value, AllocationOptions.Default);
                    IBufferLock @lock = buffer.Lock(0L, value, BufferAccess.ReadWrite);
                    if (this.length > 0L)
                    {
                        Buffer.MemoryCopy((void*) this.buffer, (void*) @lock.Address, this.bufferSize, this.length);
                    }
                    DisposableUtil.Free<IBufferLock>(ref this.bufferLockRef);
                    DisposableUtil.Free<IBuffer>(ref this.bufferRef);
                    this.bufferRef = buffer;
                    this.bufferLockRef = @lock;
                    this.buffer = (byte*) this.bufferLockRef.Address;
                    this.bufferSize = this.bufferLockRef.Size;
                }
            }
        }

        public bool IsDisposed =>
            (this.allocator == null);

        public override long Length =>
            this.length;

        public override long Position
        {
            get => 
                this.position;
            set
            {
                Validate.IsNotNegative(value, "value");
                this.position = value;
            }
        }
    }
}

