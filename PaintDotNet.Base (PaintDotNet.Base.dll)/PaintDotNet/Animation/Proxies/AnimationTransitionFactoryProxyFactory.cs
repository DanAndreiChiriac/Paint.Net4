namespace PaintDotNet.Animation.Proxies
{
    using PaintDotNet.Animation;
    using PaintDotNet.ComponentModel;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    internal sealed class AnimationTransitionFactoryProxyFactory : ObjectRefProxyFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override ObjectRefProxy CreateProxy(IObjectRef objectRef, ObjectRefProxyOptions proxyOptions) => 
            new AnimationTransitionFactoryProxy((IAnimationTransitionFactory) objectRef, proxyOptions);
    }
}

