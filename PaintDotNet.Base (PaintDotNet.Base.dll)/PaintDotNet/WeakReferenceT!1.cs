namespace PaintDotNet
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class WeakReferenceT<T> : WeakReference where T: class
    {
        public WeakReferenceT(T target) : base(target)
        {
        }

        public WeakReferenceT(T target, bool trackResurrection) : base(target, trackResurrection)
        {
        }

        protected WeakReferenceT(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        [Obsolete("This method is unsafe to use")]
        public static implicit operator WeakReferenceT<T>(T theObject) => 
            new WeakReferenceT<T>(theObject);

        public T Target
        {
            get => 
                ((T) base.Target);
            set
            {
                base.Target = value;
            }
        }
    }
}

