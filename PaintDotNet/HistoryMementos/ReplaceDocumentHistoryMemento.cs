namespace PaintDotNet.HistoryMementos
{
    using PaintDotNet;
    using System;

    internal sealed class ReplaceDocumentHistoryMemento : HistoryMemento
    {
        private IHistoryWorkspace historyWorkspace;

        public ReplaceDocumentHistoryMemento(string name, ImageResource image, IHistoryWorkspace historyWorkspace) : this(name, image, historyWorkspace, historyWorkspace.Document)
        {
        }

        public ReplaceDocumentHistoryMemento(string name, ImageResource image, IHistoryWorkspace historyWorkspace, Document document) : base(name, image)
        {
            this.historyWorkspace = historyWorkspace;
            ReplaceDocumentHistoryMementoData data = new ReplaceDocumentHistoryMementoData(document);
            base.Data = data;
        }

        protected override HistoryMemento OnUndo(ProgressEventHandler progressCallback)
        {
            ReplaceDocumentHistoryMemento memento = new ReplaceDocumentHistoryMemento(base.Name, base.Image, this.historyWorkspace);
            this.historyWorkspace.Document = ((ReplaceDocumentHistoryMementoData) base.Data).OldDocument;
            return memento;
        }

        [Serializable]
        private sealed class ReplaceDocumentHistoryMementoData : HistoryMementoData
        {
            private Document oldDocument;

            public ReplaceDocumentHistoryMementoData(Document oldDocument)
            {
                this.oldDocument = oldDocument;
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    DisposableUtil.Free<Document>(ref this.oldDocument);
                }
                base.Dispose(disposing);
            }

            public Document OldDocument =>
                this.oldDocument;
        }
    }
}

