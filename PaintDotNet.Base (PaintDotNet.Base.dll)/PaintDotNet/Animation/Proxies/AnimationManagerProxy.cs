namespace PaintDotNet.Animation.Proxies
{
    using PaintDotNet;
    using PaintDotNet.Animation;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class AnimationManagerProxy : ObjectRefProxyWithEvents<IAnimationManager>, IAnimationManager, IAnimationObject, IObjectRef, IDisposable, IIsDisposed
    {
        private static readonly Action<IAnimationManager, Delegate> removeStatusChangedHandler = new Action<IAnimationManager, Delegate>(<>c.<>9.<.cctor>b__19_0);

        public event ValueChangedEventHandler<AnimationManagerStatus> StatusChanged
        {
            add
            {
                ValueChangedEventHandler<AnimationManagerStatus> proxyHandler = (s, e) => value(this, e);
                base.AddEventHandler(value, proxyHandler, removeStatusChangedHandler);
                base.innerRefT.StatusChanged += proxyHandler;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)] remove
            {
                base.RemoveEventHandler(value, removeStatusChangedHandler);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AnimationManagerProxy(IAnimationManager objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InteropErrorInfo TryAbandonAllStoryboards() => 
            base.innerRefT.TryAbandonAllStoryboards();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InteropErrorInfo TryCreateAnimationVariable(double initialValue, out IAnimationVariable result) => 
            base.innerRefT.TryCreateAnimationVariable(initialValue, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InteropErrorInfo TryCreateStoryboard(out IAnimationStoryboard result) => 
            base.innerRefT.TryCreateStoryboard(out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InteropErrorInfo TryFinishAllStoryboards(AnimationSeconds completionDeadline) => 
            base.innerRefT.TryFinishAllStoryboards(completionDeadline);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InteropErrorInfo TryGetStoryboardFromTag(object tag, out IAnimationStoryboard result) => 
            base.innerRefT.TryGetStoryboardFromTag(tag, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InteropErrorInfo TryGetVariableFromTag(object tag, out IAnimationVariable result) => 
            base.innerRefT.TryGetVariableFromTag(tag, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InteropErrorInfo TryPause() => 
            base.innerRefT.TryPause();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InteropErrorInfo TryResume() => 
            base.innerRefT.TryResume();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InteropErrorInfo TryScheduleTransition(IAnimationVariable variable, IAnimationTransition transition, AnimationSeconds timeNow) => 
            base.innerRefT.TryScheduleTransition(variable, transition, timeNow);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InteropErrorInfo TrySetAnimationMode(AnimationMode mode) => 
            base.innerRefT.TrySetAnimationMode(mode);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InteropErrorInfo TryShutdown() => 
            base.innerRefT.TryShutdown();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InteropErrorInfo TryUpdate(AnimationSeconds timeNow, out AnimationUpdateResult result) => 
            base.innerRefT.TryUpdate(timeNow, out result);

        public AnimationManagerStatus Status =>
            base.innerRefT.Status;

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly AnimationManagerProxy.<>c <>9 = new AnimationManagerProxy.<>c();

            internal void <.cctor>b__19_0(IAnimationManager innerRefT, Delegate handler)
            {
                innerRefT.StatusChanged -= ((ValueChangedEventHandler<AnimationManagerStatus>) handler);
            }
        }
    }
}

