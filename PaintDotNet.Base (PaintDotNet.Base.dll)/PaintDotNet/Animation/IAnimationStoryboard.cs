namespace PaintDotNet.Animation
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [NativeInterfaceID("a8ff128f-9bf9-4af1-9e67-e5e410defb84")]
    public interface IAnimationStoryboard : IAnimationObject, IObjectRef, IDisposable, IIsDisposed
    {
        event ValueChangedEventHandler<AnimationStoryboardStatus> StatusChanged;

        event EventHandler Updated;

        AnimationKeyFrame AddKeyFrameAfterTransition(IAnimationTransition transition);
        AnimationKeyFrame AddKeyFrameAtOffset(AnimationKeyFrame existingKeyFrame, AnimationSeconds offset);
        void AddTransition(IAnimationVariable variable, IAnimationTransition transition);
        void AddTransitionAtKeyFrame(IAnimationVariable variable, IAnimationTransition animationTransition, AnimationKeyFrame startKeyFrame);
        void AddTransitionBetweenKeyFrames(IAnimationVariable variable, IAnimationTransition transition, AnimationKeyFrame startKeyFrame, AnimationKeyFrame endKeyFrame);
        void HoldVariable(IAnimationVariable variable);
        void RepeatBetweenKeyFrames(AnimationKeyFrame startKeyFrame, AnimationKeyFrame endKeyFrame, int repetitionCount);
        InteropErrorInfo TryAbandon();
        InteropErrorInfo TryConclude();
        InteropErrorInfo TryFinish(AnimationSeconds completionDeadline);
        InteropErrorInfo TrySchedule(AnimationSeconds timeNow, out AnimationSchedulingResult result);

        AnimationSeconds ElapsedTime { get; }

        AnimationStoryboardStatus Status { get; }

        object Tag { get; set; }
    }
}

