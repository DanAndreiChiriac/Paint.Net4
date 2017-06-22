namespace PaintDotNet.Animation.Proxies
{
    using PaintDotNet;
    using PaintDotNet.Animation;
    using PaintDotNet.ComponentModel;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class AnimationTransitionFactoryProxy : ObjectRefProxy<IAnimationTransitionFactory>, IAnimationTransitionFactory, IAnimationObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AnimationTransitionFactoryProxy(IAnimationTransitionFactory objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IAnimationTransition CreateTransition(IAnimationInterpolator interpolation) => 
            base.innerRefT.CreateTransition(interpolation);
    }
}

