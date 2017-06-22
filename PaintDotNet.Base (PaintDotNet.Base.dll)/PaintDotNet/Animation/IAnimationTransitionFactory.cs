namespace PaintDotNet.Animation
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("fcd91e03-3e3b-45ad-bbb1-6dfc8153743d")]
    public interface IAnimationTransitionFactory : IAnimationObject, IObjectRef, IDisposable, IIsDisposed
    {
        IAnimationTransition CreateTransition(IAnimationInterpolator interpolation);
    }
}

