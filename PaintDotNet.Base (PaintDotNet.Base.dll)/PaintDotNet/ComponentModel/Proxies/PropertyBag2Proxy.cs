namespace PaintDotNet.ComponentModel.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class PropertyBag2Proxy : ObjectRefProxy<IPropertyBag2>, IPropertyBag2, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PropertyBag2Proxy(IPropertyBag2 objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetPropertyName(int propertyIndex) => 
            base.innerRefT.GetPropertyName(propertyIndex);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Type GetPropertyType(int propertyIndex) => 
            base.innerRefT.GetPropertyType(propertyIndex);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object GetPropertyValue(int propertyIndex) => 
            base.innerRefT.GetPropertyValue(propertyIndex);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object GetPropertyValue(string propertyName) => 
            base.innerRefT.GetPropertyValue(propertyName);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetPropertyValue(string propertyName, object value)
        {
            base.innerRefT.SetPropertyValue(propertyName, value);
        }

        public int PropertyCount =>
            base.innerRefT.PropertyCount;
    }
}

