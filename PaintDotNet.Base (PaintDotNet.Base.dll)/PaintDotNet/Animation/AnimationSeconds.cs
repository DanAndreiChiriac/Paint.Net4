namespace PaintDotNet.Animation
{
    using PaintDotNet;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct AnimationSeconds : IEquatable<AnimationSeconds>
    {
        private readonly double seconds;
        public static AnimationSeconds Eventually =>
            -1.0;
        public double Seconds =>
            this.seconds;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double(AnimationSeconds animationSeconds) => 
            animationSeconds.seconds;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AnimationSeconds(int seconds) => 
            new AnimationSeconds((double) seconds);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AnimationSeconds(double seconds) => 
            new AnimationSeconds(seconds);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AnimationSeconds operator +(AnimationSeconds animationSeconds, double deltaSeconds) => 
            new AnimationSeconds(animationSeconds.seconds + deltaSeconds);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AnimationSeconds(double seconds)
        {
            this.seconds = seconds;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(AnimationSeconds other) => 
            (this.seconds == other.seconds);

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<AnimationSeconds, object>(this, obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(AnimationSeconds a, AnimationSeconds b) => 
            a.Equals(b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(AnimationSeconds a, AnimationSeconds b) => 
            !(a == b);

        public override int GetHashCode() => 
            this.seconds.GetHashCode();
    }
}

