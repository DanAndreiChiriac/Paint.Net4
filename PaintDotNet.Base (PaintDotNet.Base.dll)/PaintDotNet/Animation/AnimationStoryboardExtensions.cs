namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.CompilerServices;

    public static class AnimationStoryboardExtensions
    {
        public static void Abandon(this IAnimationStoryboard storyboard)
        {
            storyboard.TryAbandon().ThrowIfError();
        }

        public static void Conclude(this IAnimationStoryboard storyboard)
        {
            storyboard.TryConclude().ThrowIfError();
        }

        public static void Finish(this IAnimationStoryboard storyboard, AnimationSeconds completionDeadline)
        {
            storyboard.TryFinish(completionDeadline).ThrowIfError();
        }

        public static AnimationSchedulingResult Schedule(this IAnimationStoryboard storyboard, AnimationSeconds timeNow)
        {
            AnimationSchedulingResult result;
            storyboard.TrySchedule(timeNow, out result).ThrowIfError();
            return result;
        }
    }
}

