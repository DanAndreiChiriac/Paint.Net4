﻿namespace PaintDotNet.MemoryManagement.Proxies
{
    using PaintDotNet.ComponentModel;
    using PaintDotNet.MemoryManagement;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    internal sealed class MemoryManagerProxyFactory : ObjectRefProxyFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override ObjectRefProxy CreateProxy(IObjectRef objectRef, ObjectRefProxyOptions proxyOptions) => 
            new MemoryManagerProxy((IMemoryManager) objectRef, proxyOptions);
    }
}

