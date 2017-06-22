namespace PaintDotNet.Animation
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct AnimationKeyFrame : IEquatable<AnimationKeyFrame>
    {
        private IntPtr value;
        public static AnimationKeyFrame StoryboardStart =>
            new AnimationKeyFrame((IntPtr) (-1));
        private AnimationKeyFrame(IntPtr value)
        {
            this.value = value;
        }

        public bool Equals(AnimationKeyFrame other) => 
            (this.value == other.value);

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<AnimationKeyFrame, object>(this, obj);

        public static bool operator ==(AnimationKeyFrame a, AnimationKeyFrame b) => 
            a.Equals(b);

        public static bool operator !=(AnimationKeyFrame a, AnimationKeyFrame b) => 
            !(a == b);

        public override int GetHashCode() => 
            this.value.GetHashCode();
    }
}

