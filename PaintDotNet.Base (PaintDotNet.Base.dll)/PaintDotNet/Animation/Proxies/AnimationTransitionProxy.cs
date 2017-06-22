namespace PaintDotNet.Animation.Proxies
{
    using PaintDotNet;
    using PaintDotNet.Animation;
    using PaintDotNet.ComponentModel;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class AnimationTransitionProxy : ObjectRefProxy<IAnimationTransition>, IAnimationTransition, IAnimationObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AnimationTransitionProxy(IAnimationTransition objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetInitialValue(double value)
        {
            base.innerRefT.SetInitialValue(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetInitialVelocity(double velocity)
        {
            base.innerRefT.SetInitialVelocity(velocity);
        }

        public AnimationSeconds Duration =>
            base.innerRefT.Duration;

        public bool IsDurationKnown =>
            base.innerRefT.IsDurationKnown;

        public bool IsStoryboardActive =>
            base.innerRefT.IsStoryboardActive;
    }
}

