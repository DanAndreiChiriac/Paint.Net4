namespace PaintDotNet.Functional
{
    using System;

    [Serializable]
    internal sealed class ResultValueImpl<T> : ResultValue<T>
    {
        private static readonly ResultValueImpl<T> defaultInstance;
        private T value;

        static ResultValueImpl()
        {
            ResultValueImpl<T>.defaultInstance = new ResultValueImpl<T>(default(T));
        }

        internal ResultValueImpl(T value)
        {
            this.value = value;
        }

        public override void Observe()
        {
        }

        public static ResultValue<T> Default =>
            ResultValueImpl<T>.defaultInstance;

        public override T Value =>
            this.value;
    }
}

