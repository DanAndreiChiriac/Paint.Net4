namespace PaintDotNet.HistoryMementos
{
    using PaintDotNet;
    using System;

    internal sealed class NullHistoryMemento : HistoryMemento
    {
        public NullHistoryMemento(string name, ImageResource image) : base(name, image)
        {
        }

        protected override HistoryMemento OnUndo(ProgressEventHandler progressCallback)
        {
            throw new InvalidOperationException("NullHistoryMementos are not undoable");
        }
    }
}

