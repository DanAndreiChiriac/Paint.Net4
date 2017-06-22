namespace PaintDotNet.HistoryFunctions
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using PaintDotNet.Functional;
    using PaintDotNet.HistoryMementos;
    using PaintDotNet.Rendering;
    using PaintDotNet.Resources;
    using PaintDotNet.Runtime;
    using PaintDotNet.SystemLayer.Threading;
    using PaintDotNet.Threading.Tasks;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class CropToSelectionFunction : HistoryFunction
    {
        public CropToSelectionFunction() : base(ActionFlags.None)
        {
        }

        public override HistoryMemento OnExecute(IHistoryWorkspace historyWorkspace)
        {
            GeometryList cachedClippingMask = historyWorkspace.Selection.GetCachedClippingMask();
            if (historyWorkspace.Selection.IsEmpty || (cachedClippingMask.Bounds.Area < 1.0))
            {
                return null;
            }
            Document oldDocument = historyWorkspace.Document;
            RectInt32 b = cachedClippingMask.Bounds.GetInt32Bound(1E-05);
            RectInt32 oldClipBounds = RectInt32.Intersect(oldDocument.Bounds(), b);
            Document document = new Document(oldClipBounds.Width, oldClipBounds.Height);
            document.ReplaceMetadataFrom(oldDocument);
            RectInt32 newClipBounds = new RectInt32(0, 0, oldClipBounds.Width, oldClipBounds.Height);
            SelectionRenderingQuality quality = historyWorkspace.ToolSettings.Selection.RenderingQuality.Value;
            Result<IRenderer<ColorAlpha8>> oldClipMaskRendererLazy = historyWorkspace.Selection.GetCachedLazyClippingMaskRenderer(quality);
            LazyResult<ClippedRenderer<ColorAlpha8>> newClipMaskRendererLazy = LazyResult.New<ClippedRenderer<ColorAlpha8>>(() => new ClippedRenderer<ColorAlpha8>(oldClipMaskRendererLazy.Value, oldClipBounds), LazyThreadSafetyMode.ExecutionAndPublication, new VistaCriticalSection(0));
            SelectionData selectionData = historyWorkspace.Selection.Save();
            System.Threading.Tasks.Task<SelectionHistoryMemento> task = System.Threading.Tasks.Task.Factory.StartNew<SelectionHistoryMemento>(() => new SelectionHistoryMemento(null, null, historyWorkspace, selectionData));
            System.Threading.Tasks.Task<ReplaceDocumentHistoryMemento> task2 = System.Threading.Tasks.Task.Factory.StartNew<ReplaceDocumentHistoryMemento>(() => new ReplaceDocumentHistoryMemento(null, null, historyWorkspace, oldDocument), TaskCreationOptions.LongRunning);
            int count = oldDocument.Layers.Count;
            System.Threading.Tasks.Task<BitmapLayer>[] items = new System.Threading.Tasks.Task<BitmapLayer>[count];
            for (int i = 0; i < count; i++)
            {
                int iP = i;
                items[iP] = System.Threading.Tasks.Task.Factory.StartNew<BitmapLayer>(delegate {
                    if (iP == 0)
                    {
                        newClipMaskRendererLazy.EnsureEvaluated();
                    }
                    BitmapLayer layer = (BitmapLayer) oldDocument.Layers[iP];
                    Surface croppedSurface = layer.Surface.CreateWindow(oldClipBounds);
                    BitmapLayer newLayer = RetryManager.RunMemorySensitiveOperation<BitmapLayer>(() => new BitmapLayer(croppedSurface));
                    newLayer.LoadProperties(layer.SaveProperties());
                    Parallel.ForEach<RectInt32>(newClipBounds.GetTiles(TilingStrategy.Tiles, 7), delegate (RectInt32 newTileRect) {
                        ISurface<ColorBgra> surface = newLayer.Surface.CreateWindow(newTileRect);
                        IRenderer<ColorAlpha8> mask = new ClippedRenderer<ColorAlpha8>(newClipMaskRendererLazy.Value, newTileRect);
                        surface.MultiplyAlphaChannel(mask);
                    });
                    return newLayer;
                });
            }
            List<TupleStruct<System.Threading.Tasks.Task, double>> collection = new List<TupleStruct<System.Threading.Tasks.Task, double>>();
            collection.AddTuple<System.Threading.Tasks.Task, double>(task, 0.1);
            collection.AddTuple<System.Threading.Tasks.Task, double>(task2, 1.0);
            for (int j = 0; j < items.Length; j++)
            {
                collection.AddTuple<System.Threading.Tasks.Task, double>(items[j], 0.1);
            }
            PaintDotNet.Threading.Tasks.Task<Unit> task3 = historyWorkspace.TaskManager.CreateFrameworkTasksWrapper(collection);
            historyWorkspace.WaitWithProgress(task3, HistoryMementoImage, HistoryMementoName, PdnResources.GetString("Effects.ApplyingDialog.Description"));
            document.Layers.AddRange<Layer>(items.Select<System.Threading.Tasks.Task<BitmapLayer>, BitmapLayer>(t => t.Result));
            SelectionHistoryMemento result = task.Result;
            ReplaceDocumentHistoryMemento memento2 = task2.Result;
            base.EnterCriticalRegion();
            historyWorkspace.Document = document;
            HistoryMemento[] mementos = new HistoryMemento[] { result, memento2 };
            return HistoryMemento.Combine(HistoryMementoName, HistoryMementoImage, mementos);
        }

        public static ImageResource HistoryMementoImage =>
            PdnResources.GetImageResource("Icons.MenuImageCropIcon.png");

        public static string HistoryMementoName =>
            PdnResources.GetString("CropAction.Name");

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly CropToSelectionFunction.<>c <>9 = new CropToSelectionFunction.<>c();
            public static Func<System.Threading.Tasks.Task<BitmapLayer>, BitmapLayer> <>9__4_6;

            internal BitmapLayer <OnExecute>b__4_6(System.Threading.Tasks.Task<BitmapLayer> t) => 
                t.Result;
        }
    }
}

