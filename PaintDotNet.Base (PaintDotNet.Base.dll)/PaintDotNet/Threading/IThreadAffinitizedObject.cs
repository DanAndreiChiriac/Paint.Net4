namespace PaintDotNet.Threading
{
    using System;

    public interface IThreadAffinitizedObject
    {
        bool CheckAccess();
        void VerifyAccess();
    }
}

