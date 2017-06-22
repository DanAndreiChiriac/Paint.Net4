namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.CompilerServices;

    public static class AnimationManagerExtensions
    {
        public static void AbandonAllStoryboards(this IAnimationManager manager)
        {
            manager.TryAbandonAllStoryboards().ThrowIfError();
        }

        public static IAnimationVariable CreateAnimationVariable(this IAnimationManager manager, double initialValue)
        {
            IAnimationVariable variable;
            manager.TryCreateAnimationVariable(initialValue, out variable).ThrowIfError();
            return variable;
        }

        public static IAnimationStoryboard CreateStoryboard(this IAnimationManager manager)
        {
            IAnimationStoryboard storyboard;
            manager.TryCreateStoryboard(out storyboard).ThrowIfError();
            return storyboard;
        }

        public static void FinishAllStoryboards(this IAnimationManager manager, AnimationSeconds completionDeadline)
        {
            manager.TryFinishAllStoryboards(completionDeadline).ThrowIfError();
        }

        public static IAnimationStoryboard GetStoryboardFromTag(this IAnimationManager manager, object tag)
        {
            IAnimationStoryboard storyboard;
            manager.TryGetStoryboardFromTag(tag, out storyboard).ThrowIfError();
            return storyboard;
        }

        public static IAnimationVariable GetVariableFromTag(this IAnimationManager manager, object tag)
        {
            IAnimationVariable variable;
            manager.TryGetVariableFromTag(tag, out variable).ThrowIfError();
            return variable;
        }

        public static void Pause(this IAnimationManager manager)
        {
            manager.TryPause().ThrowIfError();
        }

        public static void Resume(this IAnimationManager manager)
        {
            manager.TryResume().ThrowIfError();
        }

        public static void ScheduleTransition(this IAnimationManager manager, IAnimationVariable variable, IAnimationTransition transition, AnimationSeconds timeNow)
        {
            manager.TryScheduleTransition(variable, transition, timeNow).ThrowIfError();
        }

        public static void SetAnimationMode(this IAnimationManager manager, AnimationMode mode)
        {
            manager.TrySetAnimationMode(mode).ThrowIfError();
        }

        public static void Shutdown(this IAnimationManager manager)
        {
            manager.TryShutdown().ThrowIfError();
        }

        public static AnimationUpdateResult Update(this IAnimationManager manager, AnimationSeconds timeNow)
        {
            AnimationUpdateResult result;
            manager.TryUpdate(timeNow, out result).ThrowIfError();
            return result;
        }
    }
}

