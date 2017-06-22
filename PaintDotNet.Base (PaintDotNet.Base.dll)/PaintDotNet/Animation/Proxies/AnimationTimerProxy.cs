namespace PaintDotNet.Animation.Proxies
{
    using PaintDotNet;
    using PaintDotNet.Animation;
    using PaintDotNet.ComponentModel;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class AnimationTimerProxy : ObjectRefProxyWithEvents<IAnimationTimer>, IAnimationTimer, IAnimationObject, IObjectRef, IDisposable, IIsDisposed
    {
        private static readonly Action<IAnimationTimer, Delegate> removePostUpdateHandler = new Action<IAnimationTimer, Delegate>(<>c.<>9.<.cctor>b__18_0);
        private static readonly Action<IAnimationTimer, Delegate> removePreUpdateHandler = new Action<IAnimationTimer, Delegate>(<>c.<>9.<.cctor>b__18_1);
        private static readonly Action<IAnimationTimer, Delegate> removeRenderingTooSlowHandler = new Action<IAnimationTimer, Delegate>(<>c.<>9.<.cctor>b__18_2);

        public event EventHandler PostUpdate
        {
            add
            {
                EventHandler proxyHandler = (s, e) => value(this, e);
                base.AddEventHandler(value, proxyHandler, removePostUpdateHandler);
                base.innerRefT.PostUpdate += proxyHandler;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)] remove
            {
                base.RemoveEventHandler(value, removePostUpdateHandler);
            }
        }

        public event EventHandler PreUpdate
        {
            add
            {
                EventHandler proxyHandler = (s, e) => value(this, e);
                base.AddEventHandler(value, proxyHandler, removePreUpdateHandler);
                base.innerRefT.PreUpdate += proxyHandler;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)] remove
            {
                base.RemoveEventHandler(value, removePreUpdateHandler);
            }
        }

        public event RenderingTooSlowEventHandler RenderingTooSlow
        {
            add
            {
                RenderingTooSlowEventHandler proxyHandler = (s, e) => value(this, e);
                base.AddEventHandler(value, proxyHandler, removeRenderingTooSlowHandler);
                base.innerRefT.RenderingTooSlow += proxyHandler;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)] remove
            {
                base.RemoveEventHandler(value, removeRenderingTooSlowHandler);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AnimationTimerProxy(IAnimationTimer objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public bool IsEnabled
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.IsEnabled;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.IsEnabled = value;
            }
        }

        public AnimationSeconds Time =>
            base.innerRefT.Time;

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly AnimationTimerProxy.<>c <>9 = new AnimationTimerProxy.<>c();

            internal void <.cctor>b__18_0(IAnimationTimer innerRefT, Delegate handler)
            {
                innerRefT.PostUpdate -= ((EventHandler) handler);
            }

            internal void <.cctor>b__18_1(IAnimationTimer innerRefT, Delegate handler)
            {
                innerRefT.PreUpdate -= ((EventHandler) handler);
            }

            internal void <.cctor>b__18_2(IAnimationTimer innerRefT, Delegate handler)
            {
                innerRefT.RenderingTooSlow -= ((RenderingTooSlowEventHandler) handler);
            }
        }
    }
}

