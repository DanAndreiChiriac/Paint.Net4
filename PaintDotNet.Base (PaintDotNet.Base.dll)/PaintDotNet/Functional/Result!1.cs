namespace PaintDotNet.Functional
{
    using System;

    [Serializable]
    public abstract class Result<T> : Result
    {
        internal Result()
        {
        }

        public T GetValueOrDefault()
        {
            if (!this.IsError)
            {
                return this.Value;
            }
            return default(T);
        }

        public bool IsValue =>
            !this.IsError;

        public abstract T Value { get; }

        public sealed override Type ValueType =>
            typeof(T);
    }
}

