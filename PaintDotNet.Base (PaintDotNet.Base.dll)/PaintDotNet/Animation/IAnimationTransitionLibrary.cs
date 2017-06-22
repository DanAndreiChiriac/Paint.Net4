namespace PaintDotNet.Animation
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("ca5a14b1-d24f-48b8-8fe4-c78169ba954e")]
    public interface IAnimationTransitionLibrary : IAnimationObject, IObjectRef, IDisposable, IIsDisposed
    {
        IAnimationTransition CreateAccelerateDecelerateTransition(AnimationSeconds duration, double finalValue, double accelerationRatio, double decelerationRatio);
        IAnimationTransition CreateConstantTransition(AnimationSeconds duration);
        IAnimationTransition CreateCubicTransition(AnimationSeconds duration, double finalValue, double finalVelocity);
        IAnimationTransition CreateDiscreteTransition(AnimationSeconds delay, double finalValue, AnimationSeconds hold);
        IAnimationTransition CreateInstantaneousTransition(double finalValue);
        IAnimationTransition CreateLinearTransition(AnimationSeconds duration, double finalValue);
        IAnimationTransition CreateLinearTransitionFromSpeed(double speed, double finalValue);
        IAnimationTransition CreateParabolicTransitionFromAcceleration(double finalValue, double finalVelocity, double acceleration);
        IAnimationTransition CreateReversalTransition(AnimationSeconds duration);
        IAnimationTransition CreateSinusoidalTransitionFromRange(AnimationSeconds duration, double minimumValue, double maximumValue, AnimationSeconds period, AnimationSlope slope);
        IAnimationTransition CreateSinusoidalTransitionFromVelocity(AnimationSeconds duration, AnimationSeconds period);
        IAnimationTransition CreateSmoothStopTransition(AnimationSeconds maximumDuration, double finalValue);
    }
}

