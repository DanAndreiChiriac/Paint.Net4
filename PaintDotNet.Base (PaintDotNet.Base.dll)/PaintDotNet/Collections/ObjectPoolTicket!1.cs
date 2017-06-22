namespace PaintDotNet.Collections
{
    using System;

    public abstract class ObjectPoolTicket<TValue> : IDisposable
    {
        private TValue value;

        protected ObjectPoolTicket(TValue value)
        {
            this.value = value;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.value = default(TValue);
        }

        public static implicit operator TValue(ObjectPoolTicket<TValue> ticket) => 
            ticket.value;

        public TValue Value =>
            this.value;
    }
}

