namespace PaintDotNet.Runtime
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.InteropServices;

    public class PartitioningRef : Disposable
    {
        private object target;
        private GCHandle targetHandle;

        public PartitioningRef(object target)
        {
            Validate.IsNotNull<object>(target, "target");
            this.target = target;
            this.targetHandle = GCHandle.Alloc(target, GCHandleType.Normal);
        }

        public static PartitioningRef<T> Create<T>(T target) where T: class => 
            new PartitioningRef<T>(target);

        protected override void Dispose(bool disposing)
        {
            object target = this.target;
            this.target = null;
            this.targetHandle.Free();
            base.Dispose(disposing);
        }

        public object Target =>
            this.target;
    }
}

