namespace PaintDotNet.Animation
{
    using PaintDotNet;

    public sealed class AnimationVariableValueChangedEventArgs<T> : PooledEventArgs<AnimationVariableValueChangedEventArgs<T>, IAnimationStoryboard, T, T>
    {
        public T NewValue =>
            base.Value3;

        public T OldValue =>
            base.Value2;

        public IAnimationStoryboard Storyboard =>
            base.Value1;
    }
}

