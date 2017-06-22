namespace PaintDotNet.Animation.Proxies
{
    using PaintDotNet;
    using PaintDotNet.Animation;
    using PaintDotNet.ComponentModel;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class AnimationInterpolatorProxy : ObjectRefProxy<IAnimationInterpolator>, IAnimationInterpolator, IAnimationObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AnimationInterpolatorProxy(IAnimationInterpolator objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double InterpolateValue(AnimationSeconds offset) => 
            base.innerRefT.InterpolateValue(offset);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double InterpolateVelocity(AnimationSeconds offset) => 
            base.innerRefT.InterpolateVelocity(offset);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetInitialValueAndVelocity(double initialValue, double initialVelocity)
        {
            base.innerRefT.SetInitialValueAndVelocity(initialValue, initialVelocity);
        }

        public AnimationSeconds Duration
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.Duration;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.Duration = value;
            }
        }

        public AnimationDependencies DurationDependencies =>
            base.innerRefT.DurationDependencies;

        public double FinalValue =>
            base.innerRefT.FinalValue;

        public AnimationDependencies InitialValueDependencies =>
            base.innerRefT.InitialValueDependencies;

        public AnimationDependencies InitialVelocityDependencies =>
            base.innerRefT.InitialVelocityDependencies;
    }
}

