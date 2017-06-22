namespace PaintDotNet.Dynamic
{
    using System;

    public interface IDynamicInvoke
    {
        object InvokeDynamicMethod(string name, object[] args);
    }
}

