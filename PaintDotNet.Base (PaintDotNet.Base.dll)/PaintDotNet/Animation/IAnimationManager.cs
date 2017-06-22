namespace PaintDotNet.Animation
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [NativeInterfaceID("9169896c-ac8d-4e7d-94e5-67fa4dc2f2e8")]
    public interface IAnimationManager : IAnimationObject, IObjectRef, IDisposable, IIsDisposed
    {
        event ValueChangedEventHandler<AnimationManagerStatus> StatusChanged;

        InteropErrorInfo TryAbandonAllStoryboards();
        InteropErrorInfo TryCreateAnimationVariable(double initialValue, out IAnimationVariable result);
        InteropErrorInfo TryCreateStoryboard(out IAnimationStoryboard result);
        InteropErrorInfo TryFinishAllStoryboards(AnimationSeconds completionDeadline);
        InteropErrorInfo TryGetStoryboardFromTag(object tag, out IAnimationStoryboard result);
        InteropErrorInfo TryGetVariableFromTag(object tag, out IAnimationVariable result);
        InteropErrorInfo TryPause();
        InteropErrorInfo TryResume();
        InteropErrorInfo TryScheduleTransition(IAnimationVariable variable, IAnimationTransition transition, AnimationSeconds timeNow);
        InteropErrorInfo TrySetAnimationMode(AnimationMode mode);
        InteropErrorInfo TryShutdown();
        InteropErrorInfo TryUpdate(AnimationSeconds timeNow, out AnimationUpdateResult result);

        AnimationManagerStatus Status { get; }
    }
}

