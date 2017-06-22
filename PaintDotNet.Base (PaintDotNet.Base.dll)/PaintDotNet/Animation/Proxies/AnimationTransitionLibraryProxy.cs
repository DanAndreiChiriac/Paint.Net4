namespace PaintDotNet.Animation.Proxies
{
    using PaintDotNet;
    using PaintDotNet.Animation;
    using PaintDotNet.ComponentModel;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class AnimationTransitionLibraryProxy : ObjectRefProxy<IAnimationTransitionLibrary>, IAnimationTransitionLibrary, IAnimationObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AnimationTransitionLibraryProxy(IAnimationTransitionLibrary objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IAnimationTransition CreateAccelerateDecelerateTransition(AnimationSeconds duration, double finalValue, double accelerationRatio, double decelerationRatio) => 
            base.innerRefT.CreateAccelerateDecelerateTransition(duration, finalValue, accelerationRatio, decelerationRatio);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IAnimationTransition CreateConstantTransition(AnimationSeconds duration) => 
            base.innerRefT.CreateConstantTransition(duration);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IAnimationTransition CreateCubicTransition(AnimationSeconds duration, double finalValue, double finalVelocity) => 
            base.innerRefT.CreateCubicTransition(duration, finalValue, finalVelocity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IAnimationTransition CreateDiscreteTransition(AnimationSeconds delay, double finalValue, AnimationSeconds hold) => 
            base.innerRefT.CreateDiscreteTransition(delay, finalValue, hold);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IAnimationTransition CreateInstantaneousTransition(double finalValue) => 
            base.innerRefT.CreateInstantaneousTransition(finalValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IAnimationTransition CreateLinearTransition(AnimationSeconds duration, double finalValue) => 
            base.innerRefT.CreateLinearTransition(duration, finalValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IAnimationTransition CreateLinearTransitionFromSpeed(double speed, double finalValue) => 
            base.innerRefT.CreateLinearTransitionFromSpeed(speed, finalValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IAnimationTransition CreateParabolicTransitionFromAcceleration(double finalValue, double finalVelocity, double acceleration) => 
            base.innerRefT.CreateParabolicTransitionFromAcceleration(finalValue, finalVelocity, acceleration);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IAnimationTransition CreateReversalTransition(AnimationSeconds duration) => 
            base.innerRefT.CreateReversalTransition(duration);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IAnimationTransition CreateSinusoidalTransitionFromRange(AnimationSeconds duration, double minimumValue, double maximumValue, AnimationSeconds period, AnimationSlope slope) => 
            base.innerRefT.CreateSinusoidalTransitionFromRange(duration, minimumValue, maximumValue, period, slope);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IAnimationTransition CreateSinusoidalTransitionFromVelocity(AnimationSeconds duration, AnimationSeconds period) => 
            base.innerRefT.CreateSinusoidalTransitionFromVelocity(duration, period);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IAnimationTransition CreateSmoothStopTransition(AnimationSeconds maximumDuration, double finalValue) => 
            base.innerRefT.CreateSmoothStopTransition(maximumDuration, finalValue);
    }
}

