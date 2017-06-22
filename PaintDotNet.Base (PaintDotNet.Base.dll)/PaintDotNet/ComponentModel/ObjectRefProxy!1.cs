namespace PaintDotNet.ComponentModel
{
    using System;

    [Serializable]
    public abstract class ObjectRefProxy<T> : ObjectRefProxy where T: class, IObjectRef
    {
        [NonSerialized]
        internal T innerRefT;

        internal ObjectRefProxy(T objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        internal sealed override void OnInnerRefSet(IObjectRef innerRef)
        {
            this.innerRefT = (T) innerRef;
            base.OnInnerRefSet(innerRef);
        }

        public T InnerRef =>
            this.innerRefT;
    }
}

