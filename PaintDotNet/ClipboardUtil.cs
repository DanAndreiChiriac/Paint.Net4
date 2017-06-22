namespace PaintDotNet
{
    using PaintDotNet.Rendering;
    using PaintDotNet.Runtime;
    using PaintDotNet.SystemLayer;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    internal static class ClipboardUtil
    {
        private static readonly ClipboardRetriever[] retrievers = new ClipboardRetriever[] { new MaskedSurfaceClipboardRetriever(), new FileDropClipboardRetriever(), new DibClipboardRetriever(), new BitmapClipboardRetriever(), new EmfClipboardRetriever(), new PngClipboardRetriever() };

        [Conditional("DEBUG")]
        private static void ClipDataDebugging(IPdnDataObject clipData)
        {
        }

        private static MaskedSurface GetClipboardImageImpl(IWin32Window currentWindow, IPdnDataObject clipData)
        {
            List<Exception> source = null;
            for (int i = 0; i < retrievers.Length; i++)
            {
                ClipboardRetriever retriever = retrievers[i];
                for (int j = 1; j <= 2; j++)
                {
                    try
                    {
                        if (retriever.IsDataMaybeAvailable(currentWindow, clipData))
                        {
                            MaskedSurface surface = retriever.TryGetMaskedSurface(currentWindow, clipData);
                            if ((surface != null) && !surface.IsDisposed)
                            {
                                return surface;
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        if (exception is OutOfMemoryException)
                        {
                            CleanupManager.RequestCleanup();
                            CleanupManager.WaitForPendingCleanup();
                        }
                        else
                        {
                            j = 2;
                        }
                        source = source ?? new List<Exception>();
                        source.Add(exception);
                    }
                }
            }
            if (source == null)
            {
                return null;
            }
            if (source.Count == 1)
            {
                if (source[0] is OutOfMemoryException)
                {
                    throw new OutOfMemoryException(source[0].Message, source[0]);
                }
                throw new Exception(source[0].Message, source[0]);
            }
            if (source.All<Exception>(ex => ex is OutOfMemoryException))
            {
                throw new OutOfMemoryException(new OutOfMemoryException().Message, new AggregateException(source));
            }
            throw new AggregateException(source);
        }

        public static bool IsClipboardImageMaybeAvailable(IWin32Window currentWindow, IPdnDataObject clipData)
        {
            try
            {
                bool flag = false;
                foreach (ClipboardRetriever retriever in retrievers)
                {
                    if (retriever.IsDataMaybeAvailable(currentWindow, clipData))
                    {
                        flag = true;
                    }
                }
                return flag;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static MaskedSurface TryGetClipboardImage(IWin32Window currentWindow, IPdnDataObject clipData)
        {
            try
            {
                return GetClipboardImageImpl(currentWindow, clipData);
            }
            finally
            {
            }
        }

        public static SizeInt32? TryGetClipboardImageSize(IWin32Window currentWindow, IPdnDataObject clipData)
        {
            try
            {
                return TryGetClipboardImageSizeImpl(currentWindow, clipData);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static SizeInt32? TryGetClipboardImageSizeImpl(IWin32Window currentWindow, IPdnDataObject clipData)
        {
            using (MaskedSurface surface = TryGetClipboardImage(currentWindow, clipData))
            {
                if (surface != null)
                {
                    return new SizeInt32?(surface.GetCachedGeometryMaskScansBounds().Size);
                }
            }
            return null;
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly ClipboardUtil.<>c <>9 = new ClipboardUtil.<>c();
            public static Func<Exception, bool> <>9__5_0;

            internal bool <GetClipboardImageImpl>b__5_0(Exception ex) => 
                (ex is OutOfMemoryException);
        }

        private sealed class BitmapClipboardRetriever : ClipboardUtil.ClipboardRetriever
        {
            public override bool IsDataMaybeAvailable(IWin32Window window, IPdnDataObject clipData)
            {
                if (!clipData.GetDataPresent(PdnDataObjectFormats.Bitmap, true))
                {
                    return clipData.GetDataPresent(PdnDataObjectFormats.EnhancedMetafile, true);
                }
                return true;
            }

            public override MaskedSurface TryGetMaskedSurface(IWin32Window window, IPdnDataObject clipData)
            {
                Image data = clipData.GetData(PdnDataObjectFormats.Bitmap, true) as Image;
                return ClipboardUtil.ClipboardRetriever.ConvertToMaskedSurface(ref data, true);
            }
        }

        private abstract class ClipboardRetriever
        {
            protected ClipboardRetriever()
            {
            }

            protected static MaskedSurface ConvertToMaskedSurface(ref Surface surface)
            {
                if (surface == null)
                {
                    return null;
                }
                return new MaskedSurface(ref surface, true);
            }

            protected static MaskedSurface ConvertToMaskedSurface(ref Image image, bool detectDishonestAlpha)
            {
                if (image == null)
                {
                    return null;
                }
                Surface surface = Surface.CopyFromGdipImage(image, detectDishonestAlpha);
                DisposableUtil.Free<Image>(ref image);
                return ConvertToMaskedSurface(ref surface);
            }

            public abstract bool IsDataMaybeAvailable(IWin32Window window, IPdnDataObject clipData);
            public abstract MaskedSurface TryGetMaskedSurface(IWin32Window window, IPdnDataObject clipData);
        }

        private sealed class DibClipboardRetriever : ClipboardUtil.ClipboardRetriever
        {
            public override bool IsDataMaybeAvailable(IWin32Window window, IPdnDataObject clipData) => 
                clipData.GetDataPresent(PdnDataObjectFormats.Dib, true);

            public override unsafe MaskedSurface TryGetMaskedSurface(IWin32Window window, IPdnDataObject clipData)
            {
                Surface result = null;
                using (PaintDotNet.SystemLayer.Clipboard.Transaction transaction = PaintDotNet.SystemLayer.Clipboard.Open(window))
                {
                    bool flag = transaction.TryGetRawNativeData(8, delegate (UnsafeBufferLock buffer) {
                        Size size;
                        byte* pBitmapInfo = (byte*) buffer.Address;
                        int ncbBitmapInfo = (int) buffer.Size;
                        if (PdnGraphics.TryGetBitmapInfoSize(pBitmapInfo, ncbBitmapInfo, out size))
                        {
                            Surface disposeMe = new Surface(size.Width, size.Height);
                            bool flag = false;
                            try
                            {
                                using (Bitmap bitmap = disposeMe.CreateAliasedBitmap(true))
                                {
                                    flag = PdnGraphics.TryCopyFromBitmapInfo(bitmap, pBitmapInfo, ncbBitmapInfo);
                                }
                                disposeMe.DetectAndFixDishonestAlpha();
                            }
                            finally
                            {
                                if (flag)
                                {
                                    result = disposeMe;
                                }
                                else
                                {
                                    DisposableUtil.Free<Surface>(ref disposeMe);
                                }
                            }
                        }
                    });
                }
                return ClipboardUtil.ClipboardRetriever.ConvertToMaskedSurface(ref result);
            }
        }

        private sealed class EmfClipboardRetriever : ClipboardUtil.ClipboardRetriever
        {
            public override bool IsDataMaybeAvailable(IWin32Window window, IPdnDataObject clipData)
            {
                if (!clipData.GetDataPresent(PdnDataObjectFormats.Bitmap, true))
                {
                    return clipData.GetDataPresent(PdnDataObjectFormats.EnhancedMetafile, true);
                }
                return true;
            }

            public override MaskedSurface TryGetMaskedSurface(IWin32Window window, IPdnDataObject clipData)
            {
                using (PaintDotNet.SystemLayer.Clipboard.Transaction transaction = PaintDotNet.SystemLayer.Clipboard.Open(window))
                {
                    return ClipboardUtil.ClipboardRetriever.ConvertToMaskedSurface(ref transaction.TryGetEmf(), true);
                }
            }
        }

        private sealed class FileDropClipboardRetriever : ClipboardUtil.ClipboardRetriever
        {
            private static readonly string[] fileDropImageExtensions = new string[] { ".bmp", ".png", ".jpg", ".jpe", ".jpeg", ".jfif", ".gif" };

            public override bool IsDataMaybeAvailable(IWin32Window window, IPdnDataObject clipData)
            {
                string[] strArray;
                if (!clipData.GetDataPresent(PdnDataObjectFormats.FileDrop))
                {
                    return false;
                }
                using (PaintDotNet.SystemLayer.Clipboard.Transaction transaction = PaintDotNet.SystemLayer.Clipboard.Open(window))
                {
                    strArray = transaction.TryGetFileDropData();
                }
                return (((strArray != null) && (strArray.Length == 1)) && (IsImageFileName(strArray[0]) && File.Exists(strArray[0])));
            }

            private static bool IsImageFileName(string fileName)
            {
                try
                {
                    foreach (string str in fileDropImageExtensions)
                    {
                        if (Path.HasExtension(str))
                        {
                            return true;
                        }
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                return false;
            }

            public override MaskedSurface TryGetMaskedSurface(IWin32Window window, IPdnDataObject clipData)
            {
                string[] strArray;
                using (PaintDotNet.SystemLayer.Clipboard.Transaction transaction = PaintDotNet.SystemLayer.Clipboard.Open(window))
                {
                    strArray = transaction.TryGetFileDropData();
                }
                if (strArray == null)
                {
                    return null;
                }
                if (strArray.Length != 1)
                {
                    return null;
                }
                string fileName = strArray[0];
                if (!IsImageFileName(fileName))
                {
                    return null;
                }
                File.Exists(fileName);
                return ClipboardUtil.ClipboardRetriever.ConvertToMaskedSurface(ref Image.FromFile(fileName), false);
            }
        }

        private sealed class MaskedSurfaceClipboardRetriever : ClipboardUtil.ClipboardRetriever
        {
            public override bool IsDataMaybeAvailable(IWin32Window window, IPdnDataObject clipData)
            {
                using (PaintDotNet.SystemLayer.Clipboard.Transaction transaction = PaintDotNet.SystemLayer.Clipboard.Open(window))
                {
                    if (transaction.IsManagedDataPresent(typeof(MaskedSurface)))
                    {
                        return clipData.GetDataPresent(typeof(MaskedSurface));
                    }
                }
                return false;
            }

            public override MaskedSurface TryGetMaskedSurface(IWin32Window window, IPdnDataObject clipData)
            {
                using (PaintDotNet.SystemLayer.Clipboard.Transaction transaction = PaintDotNet.SystemLayer.Clipboard.Open(window))
                {
                    MaskedSurface surface = transaction.TryGetManagedData(typeof(MaskedSurface)) as MaskedSurface;
                    if (surface == null)
                    {
                        return null;
                    }
                    if (surface.IsDisposed)
                    {
                        return null;
                    }
                    return surface;
                }
            }
        }

        private sealed class PngClipboardRetriever : ClipboardUtil.ClipboardRetriever
        {
            public override bool IsDataMaybeAvailable(IWin32Window window, IPdnDataObject clipData) => 
                clipData.GetDataPresent("PNG", false);

            public override MaskedSurface TryGetMaskedSurface(IWin32Window window, IPdnDataObject clipData)
            {
                using (PaintDotNet.SystemLayer.Clipboard.Transaction transaction = PaintDotNet.SystemLayer.Clipboard.Open(window))
                {
                    uint formatID = PaintDotNet.SystemLayer.Clipboard.RegisterFormat("PNG");
                    Image image = null;
                    if (!transaction.TryGetRawNativeData(formatID, delegate (Stream stream) {
                        image = Image.FromStream(stream, false, true);
                    }))
                    {
                        return null;
                    }
                    if (image != null)
                    {
                        return ClipboardUtil.ClipboardRetriever.ConvertToMaskedSurface(ref image, false);
                    }
                }
                return null;
            }
        }
    }
}

