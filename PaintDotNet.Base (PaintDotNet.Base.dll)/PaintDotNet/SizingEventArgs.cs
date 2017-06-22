namespace PaintDotNet
{
    using System;
    using System.Drawing;

    public sealed class SizingEventArgs : EventArgs
    {
        private Rectangle screenWindowRectangle;
        private FormSizingEdge sizingEdge;

        public SizingEventArgs(FormSizingEdge sizingEdge, Rectangle screenWindowRect)
        {
            this.sizingEdge = sizingEdge;
            this.screenWindowRectangle = screenWindowRect;
        }

        public Rectangle ScreenWindowRectangle
        {
            get => 
                this.screenWindowRectangle;
            set
            {
                this.screenWindowRectangle = value;
            }
        }

        public FormSizingEdge SizingEdge =>
            this.sizingEdge;
    }
}

