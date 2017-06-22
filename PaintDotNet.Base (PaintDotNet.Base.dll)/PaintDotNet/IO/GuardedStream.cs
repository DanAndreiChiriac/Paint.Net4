namespace PaintDotNet.IO
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Runtime.InteropServices;

    public sealed class GuardedStream : Stream, IIsDisposed, IDisposable
    {
        private SegmentedList<Exception> exceptions;
        private ReadOnlyCollection<Exception> exceptionsRO;
        private int maxExceptions;
        private bool ownsStream;
        private Stream source;
        private object sync = new object();
        private bool tooManyExceptions;

        public GuardedStream(Stream source, bool takeOwnership = false, int maxExceptions = 0x400)
        {
            Validate.IsNotNull<Stream>(source, "source");
            this.source = source;
            this.ownsStream = takeOwnership;
            this.maxExceptions = maxExceptions;
        }

        private void AddException(Exception ex)
        {
            object sync = this.sync;
            lock (sync)
            {
                if (this.exceptions == null)
                {
                    this.exceptions = new SegmentedList<Exception>();
                }
                if (this.exceptions.Count < this.maxExceptions)
                {
                    this.exceptions.Add(ex);
                }
                else
                {
                    this.tooManyExceptions = true;
                }
            }
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            IAsyncResult result;
            this.VerifyNotDisposed();
            try
            {
                result = this.source.BeginRead(buffer, offset, count, callback, state);
            }
            catch (Exception exception)
            {
                this.AddException(exception);
                throw;
            }
            return result;
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            IAsyncResult result;
            this.VerifyNotDisposed();
            try
            {
                result = this.source.BeginWrite(buffer, offset, count, callback, state);
            }
            catch (Exception exception)
            {
                this.AddException(exception);
                throw;
            }
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.ownsStream)
                {
                    DisposableUtil.Free<Stream>(ref this.source);
                }
                this.source = null;
            }
            base.Dispose(disposing);
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            int num;
            this.VerifyNotDisposed();
            try
            {
                num = this.source.EndRead(asyncResult);
            }
            catch (Exception exception)
            {
                this.AddException(exception);
                throw;
            }
            return num;
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            this.VerifyNotDisposed();
            try
            {
                this.source.EndWrite(asyncResult);
            }
            catch (Exception exception)
            {
                this.AddException(exception);
                throw;
            }
        }

        public override void Flush()
        {
            this.VerifyNotDisposed();
            try
            {
                this.source.Flush();
            }
            catch (Exception exception)
            {
                this.AddException(exception);
                throw;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int num;
            this.VerifyNotDisposed();
            try
            {
                num = this.source.Read(buffer, offset, count);
            }
            catch (Exception exception)
            {
                this.AddException(exception);
                throw;
            }
            return num;
        }

        public override int ReadByte()
        {
            int num;
            this.VerifyNotDisposed();
            try
            {
                num = this.source.ReadByte();
            }
            catch (Exception exception)
            {
                this.AddException(exception);
                throw;
            }
            return num;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            long num;
            this.VerifyNotDisposed();
            try
            {
                num = this.source.Seek(offset, origin);
            }
            catch (Exception exception)
            {
                this.AddException(exception);
                throw;
            }
            return num;
        }

        public override void SetLength(long value)
        {
            this.VerifyNotDisposed();
            try
            {
                this.source.SetLength(value);
            }
            catch (Exception exception)
            {
                this.AddException(exception);
                throw;
            }
        }

        private void VerifyNotDisposed()
        {
            if (this.IsDisposed)
            {
                throw new ObjectDisposedException("GuardedStream");
            }
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            this.VerifyNotDisposed();
            try
            {
                this.source.Write(buffer, offset, count);
            }
            catch (Exception exception)
            {
                this.AddException(exception);
                throw;
            }
        }

        public override void WriteByte(byte value)
        {
            this.VerifyNotDisposed();
            try
            {
                this.source.WriteByte(value);
            }
            catch (Exception exception)
            {
                this.AddException(exception);
                throw;
            }
        }

        public override bool CanRead
        {
            get
            {
                bool canRead;
                this.VerifyNotDisposed();
                try
                {
                    canRead = this.source.CanRead;
                }
                catch (Exception exception)
                {
                    this.AddException(exception);
                    throw;
                }
                return canRead;
            }
        }

        public override bool CanSeek
        {
            get
            {
                bool canSeek;
                this.VerifyNotDisposed();
                try
                {
                    canSeek = this.source.CanSeek;
                }
                catch (Exception exception)
                {
                    this.AddException(exception);
                    throw;
                }
                return canSeek;
            }
        }

        public override bool CanTimeout
        {
            get
            {
                bool canTimeout;
                this.VerifyNotDisposed();
                try
                {
                    canTimeout = this.source.CanTimeout;
                }
                catch (Exception exception)
                {
                    this.AddException(exception);
                    throw;
                }
                return canTimeout;
            }
        }

        public override bool CanWrite
        {
            get
            {
                bool canWrite;
                this.VerifyNotDisposed();
                try
                {
                    canWrite = this.source.CanWrite;
                }
                catch (Exception exception)
                {
                    this.AddException(exception);
                    throw;
                }
                return canWrite;
            }
        }

        public IList<Exception> Exceptions
        {
            get
            {
                object sync = this.sync;
                lock (sync)
                {
                    if (this.exceptions == null)
                    {
                        this.exceptions = new SegmentedList<Exception>();
                    }
                    if (this.exceptionsRO == null)
                    {
                        this.exceptionsRO = new ReadOnlyCollection<Exception>(this.exceptions);
                    }
                    return this.exceptionsRO;
                }
            }
        }

        public bool IsDisposed =>
            (this.source == null);

        public override long Length
        {
            get
            {
                long length;
                this.VerifyNotDisposed();
                try
                {
                    length = this.source.Length;
                }
                catch (Exception exception)
                {
                    this.AddException(exception);
                    throw;
                }
                return length;
            }
        }

        public override long Position
        {
            get
            {
                long position;
                this.VerifyNotDisposed();
                try
                {
                    position = this.source.Position;
                }
                catch (Exception exception)
                {
                    this.AddException(exception);
                    throw;
                }
                return position;
            }
            set
            {
                this.VerifyNotDisposed();
                try
                {
                    this.source.Position = value;
                }
                catch (Exception exception)
                {
                    this.AddException(exception);
                    throw;
                }
            }
        }

        public override int ReadTimeout
        {
            get
            {
                int readTimeout;
                this.VerifyNotDisposed();
                try
                {
                    readTimeout = this.source.ReadTimeout;
                }
                catch (Exception exception)
                {
                    this.AddException(exception);
                    throw;
                }
                return readTimeout;
            }
            set
            {
                this.VerifyNotDisposed();
                try
                {
                    this.source.ReadTimeout = value;
                }
                catch (Exception exception)
                {
                    this.AddException(exception);
                    throw;
                }
            }
        }

        public bool TooManyExceptions =>
            this.tooManyExceptions;

        public override int WriteTimeout
        {
            get
            {
                int writeTimeout;
                this.VerifyNotDisposed();
                try
                {
                    writeTimeout = this.source.WriteTimeout;
                }
                catch (Exception exception)
                {
                    this.AddException(exception);
                    throw;
                }
                return writeTimeout;
            }
            set
            {
                this.VerifyNotDisposed();
                try
                {
                    this.source.WriteTimeout = value;
                }
                catch (Exception exception)
                {
                    this.AddException(exception);
                    throw;
                }
            }
        }
    }
}

