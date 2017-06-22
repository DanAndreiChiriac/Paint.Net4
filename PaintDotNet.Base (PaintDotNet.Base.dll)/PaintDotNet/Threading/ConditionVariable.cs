namespace PaintDotNet.Threading
{
    using PaintDotNet;
    using System;

    public abstract class ConditionVariable : Disposable
    {
        protected ConditionVariable()
        {
        }

        public abstract void Enter();
        public abstract void Exit();
        public abstract void Pulse();
        public abstract void PulseAll();
        public abstract void Wait();
    }
}

