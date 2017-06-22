namespace PaintDotNet.Collections
{
    using System;

    public interface IModifyElementByRef<T>
    {
        void ModifyByRef<TActionByRef>(int index, TActionByRef modifyAction) where TActionByRef: struct, IActionByRef<T>;
    }
}

