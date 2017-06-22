namespace PaintDotNet
{
    using System;

    [Obsolete]
    public class NewValueEventArgs<T> : EventArgs
    {
        private readonly T newValue;

        public NewValueEventArgs(T newValue)
        {
            this.newValue = newValue;
        }

        public T NewValue =>
            this.newValue;
    }
}

