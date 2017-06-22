namespace PaintDotNet.IO
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public sealed class SiphonStream : Stream
    {
        private int readAccumulator;
        private readonly int siphonSize;
        private readonly Stream stream;
        private object tag;
        private Exception throwMe;
        private int writeAccumulator;

        [field: CompilerGenerated]
        public event IOEventHandler IOFinished;

        public SiphonStream(Stream underlyingStream) : this(underlyingStream, 0x10000)
        {
        }

        public SiphonStream(Stream underlyingStream, int siphonSize)
        {
            this.stream = underlyingStream;
            this.siphonSize = siphonSize;
        }

        public void Abort(Exception newThrowMe)
        {
            if (newThrowMe == null)
            {
                throw new ArgumentException("throwMe may not be null", "throwMe");
            }
            this.throwMe = newThrowMe;
        }

        public override void Flush()
        {
            this.stream.Flush();
        }

        private void OnIOFinished(IOEventArgs e)
        {
            if (this.IOFinished != null)
            {
                this.IOFinished(this, e);
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (this.throwMe != null)
            {
                throw new IOException("Aborted", this.throwMe);
            }
            int num = count;
            int num2 = offset;
            int num3 = 0;
            while (num2 < (offset + count))
            {
                int num4 = Math.Min(this.siphonSize, num);
                int num5 = this.stream.Read(buffer, num2, num4);
                this.ReadAccumulate(num5);
                num -= num5;
                num2 += num5;
                num3 += num5;
                if (num5 == 0)
                {
                    return num3;
                }
            }
            return num3;
        }

        private void ReadAccumulate(int count)
        {
            if (count == -1)
            {
                if (this.readAccumulator > 0)
                {
                    this.OnIOFinished(new IOEventArgs(IOOperationType.Read, this.Position, this.readAccumulator));
                    this.readAccumulator = 0;
                }
            }
            else
            {
                this.WriteAccumulate(-1);
                this.readAccumulator += count;
                while (this.readAccumulator > this.siphonSize)
                {
                    this.OnIOFinished(new IOEventArgs(IOOperationType.Read, (this.Position - this.readAccumulator) + this.siphonSize, this.siphonSize));
                    this.readAccumulator -= this.siphonSize;
                }
            }
        }

        public override long Seek(long offset, SeekOrigin origin) => 
            this.stream.Seek(offset, origin);

        public override void SetLength(long value)
        {
            this.stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            int num3;
            if (this.throwMe != null)
            {
                throw new IOException("Aborted", this.throwMe);
            }
            int num = count;
            for (int i = offset; i < (offset + count); i += num3)
            {
                num3 = Math.Min(this.siphonSize, num);
                this.stream.Write(buffer, i, num3);
                this.WriteAccumulate(num3);
                num -= num3;
            }
        }

        private void WriteAccumulate(int count)
        {
            if (count == -1)
            {
                if (this.writeAccumulator > 0)
                {
                    this.OnIOFinished(new IOEventArgs(IOOperationType.Write, this.Position, this.writeAccumulator));
                    this.writeAccumulator = 0;
                }
            }
            else
            {
                this.ReadAccumulate(-1);
                this.writeAccumulator += count;
                while (this.writeAccumulator > this.siphonSize)
                {
                    this.OnIOFinished(new IOEventArgs(IOOperationType.Write, (this.Position - this.writeAccumulator) + this.siphonSize, this.siphonSize));
                    this.writeAccumulator -= this.siphonSize;
                }
            }
        }

        public override bool CanRead =>
            this.stream.CanRead;

        public override bool CanSeek =>
            this.stream.CanSeek;

        public override bool CanWrite =>
            this.stream.CanWrite;

        public override long Length =>
            this.stream.Length;

        public override long Position
        {
            get => 
                this.stream.Position;
            set
            {
                this.stream.Position = value;
            }
        }

        public object Tag
        {
            get => 
                this.tag;
            set
            {
                this.tag = value;
            }
        }
    }
}

