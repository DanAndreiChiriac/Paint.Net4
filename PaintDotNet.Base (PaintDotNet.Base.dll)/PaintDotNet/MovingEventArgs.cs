namespace PaintDotNet
{
    using System;
    using System.Drawing;

    public sealed class MovingEventArgs : EventArgs
    {
        private System.Drawing.Rectangle rectangle;

        public MovingEventArgs(System.Drawing.Rectangle rect)
        {
            this.rectangle = rect;
        }

        public System.Drawing.Rectangle Rectangle
        {
            get => 
                this.rectangle;
            set
            {
                this.rectangle = value;
            }
        }
    }
}

