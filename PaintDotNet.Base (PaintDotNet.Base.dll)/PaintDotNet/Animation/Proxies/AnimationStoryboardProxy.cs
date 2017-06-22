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
    public class AnimationStoryboardProxy : ObjectRefProxyWithEvents<IAnimationStoryboard>, IAnimationStoryboard, IAnimationObject, IObjectRef, IDisposable, IIsDisposed
    {
        private static readonly Action<IAnimationStoryboard, Delegate> removeStatusChangedHandler = new Action<IAnimationStoryboard, Delegate>(<>c.<>9.<.cctor>b__27_0);
        private static readonly Action<IAnimationStoryboard, Delegate> removeUpdatedHandler = new Action<IAnimationStoryboard, Delegate>(<>c.<>9.<.cctor>b__27_1);

        public event ValueChangedEventHandler<AnimationStoryboardStatus> StatusChanged
        {
            add
            {
                ValueChangedEventHandler<AnimationStoryboardStatus> proxyHandler = (s, e) => value(this, e);
                base.AddEventHandler(value, proxyHandler, removeStatusChangedHandler);
                base.innerRefT.StatusChanged += proxyHandler;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)] remove
            {
                base.RemoveEventHandler(value, removeStatusChangedHandler);
            }
        }

        public event EventHandler Updated
        {
            add
            {
                EventHandler proxyHandler = (s, e) => value(this, e);
                base.AddEventHandler(value, proxyHandler, removeUpdatedHandler);
                base.innerRefT.Updated += proxyHandler;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)] remove
            {
                base.RemoveEventHandler(value, removeUpdatedHandler);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AnimationStoryboardProxy(IAnimationStoryboard objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AnimationKeyFrame AddKeyFrameAfterTransition(IAnimationTransition transition) => 
            base.innerRefT.AddKeyFrameAfterTransition(transition);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AnimationKeyFrame AddKeyFrameAtOffset(AnimationKeyFrame existingKeyFrame, AnimationSeconds offset) => 
            base.innerRefT.AddKeyFrameAtOffset(existingKeyFrame, offset);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddTransition(IAnimationVariable variable, IAnimationTransition transition)
        {
            base.innerRefT.AddTransition(variable, transition);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddTransitionAtKeyFrame(IAnimationVariable variable, IAnimationTransition animationTransition, AnimationKeyFrame startKeyFrame)
        {
            base.innerRefT.AddTransitionAtKeyFrame(variable, animationTransition, startKeyFrame);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddTransitionBetweenKeyFrames(IAnimationVariable variable, IAnimationTransition transition, AnimationKeyFrame startKeyFrame, AnimationKeyFrame endKeyFrame)
        {
            base.innerRefT.AddTransitionBetweenKeyFrames(variable, transition, startKeyFrame, endKeyFrame);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void HoldVariable(IAnimationVariable variable)
        {
            base.innerRefT.HoldVariable(variable);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RepeatBetweenKeyFrames(AnimationKeyFrame startKeyFrame, AnimationKeyFrame endKeyFrame, int repetitionCount)
        {
            base.innerRefT.RepeatBetweenKeyFrames(startKeyFrame, endKeyFrame, repetitionCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InteropErrorInfo TryAbandon() => 
            base.innerRefT.TryAbandon();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InteropErrorInfo TryConclude() => 
            base.innerRefT.TryConclude();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InteropErrorInfo TryFinish(AnimationSeconds completionDeadline) => 
            base.innerRefT.TryFinish(completionDeadline);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InteropErrorInfo TrySchedule(AnimationSeconds timeNow, out AnimationSchedulingResult result) => 
            base.innerRefT.TrySchedule(timeNow, out result);

        public AnimationSeconds ElapsedTime =>
            base.innerRefT.ElapsedTime;

        public AnimationStoryboardStatus Status =>
            base.innerRefT.Status;

        public object Tag
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.Tag;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.Tag = value;
            }
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly AnimationStoryboardProxy.<>c <>9 = new AnimationStoryboardProxy.<>c();

            internal void <.cctor>b__27_0(IAnimationStoryboard innerRefT, Delegate handler)
            {
                innerRefT.StatusChanged -= ((ValueChangedEventHandler<AnimationStoryboardStatus>) handler);
            }

            internal void <.cctor>b__27_1(IAnimationStoryboard innerRefT, Delegate handler)
            {
                innerRefT.Updated -= ((EventHandler) handler);
            }
        }
    }
}

