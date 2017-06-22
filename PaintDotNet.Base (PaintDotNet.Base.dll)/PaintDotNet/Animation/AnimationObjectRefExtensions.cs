namespace PaintDotNet.Animation
{
    using PaintDotNet.ComponentModel;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    public static class AnimationObjectRefExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IAnimationInterpolator CreateRef(this IAnimationInterpolator objectRef) => 
            ((IAnimationInterpolator) objectRef.CreateRef(typeof(IAnimationInterpolator)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IAnimationManager CreateRef(this IAnimationManager objectRef) => 
            ((IAnimationManager) objectRef.CreateRef(typeof(IAnimationManager)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IAnimationObject CreateRef(this IAnimationObject objectRef) => 
            ((IAnimationObject) objectRef.CreateRef(typeof(IAnimationObject)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IAnimationStoryboard CreateRef(this IAnimationStoryboard objectRef) => 
            ((IAnimationStoryboard) objectRef.CreateRef(typeof(IAnimationStoryboard)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IAnimationTimer CreateRef(this IAnimationTimer objectRef) => 
            ((IAnimationTimer) objectRef.CreateRef(typeof(IAnimationTimer)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IAnimationTransition CreateRef(this IAnimationTransition objectRef) => 
            ((IAnimationTransition) objectRef.CreateRef(typeof(IAnimationTransition)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IAnimationTransitionFactory CreateRef(this IAnimationTransitionFactory objectRef) => 
            ((IAnimationTransitionFactory) objectRef.CreateRef(typeof(IAnimationTransitionFactory)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IAnimationTransitionLibrary CreateRef(this IAnimationTransitionLibrary objectRef) => 
            ((IAnimationTransitionLibrary) objectRef.CreateRef(typeof(IAnimationTransitionLibrary)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IAnimationVariable CreateRef(this IAnimationVariable objectRef) => 
            ((IAnimationVariable) objectRef.CreateRef(typeof(IAnimationVariable)));
    }
}

