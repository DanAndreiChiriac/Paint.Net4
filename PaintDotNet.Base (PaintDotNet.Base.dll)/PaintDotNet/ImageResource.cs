namespace PaintDotNet
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Drawing;
    using System.Threading;

    public abstract class ImageResource
    {
        private long id;
        private Image image;
        private static long nextID;

        internal ImageResource() : this(null)
        {
        }

        internal ImageResource(Image image)
        {
            this.id = Interlocked.Increment(ref nextID);
            this.image = image;
        }

        public static ImageResource FromImage(Image image)
        {
            Validate.IsNotNull<Image>(image, "image");
            return new FromImageResource(image);
        }

        public Image GetCopy() => 
            this.Load();

        protected abstract Image Load();

        public long ID =>
            this.id;

        public Image Reference
        {
            get
            {
                if (this.image == null)
                {
                    ImageResource resource = this;
                    lock (resource)
                    {
                        if (this.image == null)
                        {
                            this.image = this.Load();
                        }
                    }
                }
                return this.image;
            }
        }

        private sealed class FromImageResource : ImageResource
        {
            public FromImageResource(Image image) : base(image)
            {
            }

            protected override Image Load() => 
                ((Image) base.Reference.Clone());
        }
    }
}

