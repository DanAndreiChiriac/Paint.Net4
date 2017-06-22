namespace PaintDotNet.Threading
{
    using PaintDotNet;
    using System;

    public abstract class CriticalSection : Disposable
    {
        protected CriticalSection()
        {
        }

        public abstract void Enter();
        public abstract void Exit();
    }
}

