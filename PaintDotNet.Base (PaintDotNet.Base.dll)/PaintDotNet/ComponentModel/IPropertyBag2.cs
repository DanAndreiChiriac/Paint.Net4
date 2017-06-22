namespace PaintDotNet.ComponentModel
{
    using PaintDotNet;
    using System;

    public interface IPropertyBag2 : IObjectRef, IDisposable, IIsDisposed
    {
        string GetPropertyName(int propertyIndex);
        Type GetPropertyType(int propertyIndex);
        object GetPropertyValue(int propertyIndex);
        object GetPropertyValue(string propertyName);
        void SetPropertyValue(string propertyName, object value);

        int PropertyCount { get; }
    }
}

