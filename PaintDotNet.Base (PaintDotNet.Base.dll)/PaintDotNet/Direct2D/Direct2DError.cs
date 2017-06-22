namespace PaintDotNet.Direct2D
{
    using PaintDotNet.Interop;
    using System;

    public enum Direct2DError
    {
        [ExceptionMapping(typeof(BadNumberException))]
        BadNumber = -2003238895,
        [ExceptionMapping(typeof(DisplayFormatNotSupportedException))]
        DisplayFormatNotSupported = -2003238903,
        [ExceptionMapping(typeof(DisplayStateInvalidException))]
        DisplayStateInvalid = -2003238906,
        [ExceptionMapping(typeof(ExceedsMaxBitmapSizeException))]
        ExceedsMaxBitmapSize = -2003238883,
        [ExceptionMapping(typeof(IncompatibleBrushTypesException))]
        IncompatibleBrushTypes = -2003238888,
        [ExceptionMapping(typeof(InternalErrorException))]
        InternalError = -2003238904,
        [ExceptionMapping(typeof(InvalidCallException))]
        InvalidCall = -2003238902,
        [ExceptionMapping(typeof(LayerAlreadyInUseException))]
        LayerAlreadyInUse = -2003238893,
        [ExceptionMapping(typeof(MaxTextureSizeExceededException))]
        MaxTextureSizeExceeded = -2003238897,
        [ExceptionMapping(typeof(NoHardwareDeviceException))]
        NoHardwareDevice = -2003238901,
        [ExceptionMapping(typeof(NotInitializedException))]
        NotInitialized = -2003238910,
        [ExceptionMapping(typeof(PopCallDidNotMatchPushException))]
        PopCallDidNotMatchPush = -2003238892,
        [ExceptionMapping(typeof(PushPopUnbalancedException))]
        PushPopUnbalanced = -2003238890,
        [ExceptionMapping(typeof(RecreateTargetException))]
        RecreateTarget = -2003238900,
        [ExceptionMapping(typeof(RenderTargetHasLayerOrClipRectException))]
        RenderTargetHasLayerOrClipRect = -2003238889,
        [ExceptionMapping(typeof(ScannerFailedException))]
        ScannerFailed = -2003238908,
        [ExceptionMapping(typeof(ScreenAccessDeniedException))]
        ScreenAccessDenied = -2003238907,
        [ExceptionMapping(typeof(ShaderCompileFailedException))]
        ShaderCompileFailed = -2003238898,
        [ExceptionMapping(typeof(TargetNotGdiCompatibleException))]
        TargetNotGdiCompatible = -2003238886,
        [ExceptionMapping(typeof(TextEffectIsWrongTypeException))]
        TextEffectIsWrongType = -2003238885,
        [ExceptionMapping(typeof(TextRendererNotReleasedException))]
        TextRendererNotReleased = -2003238884,
        [ExceptionMapping(typeof(TooManyShaderElementsException))]
        TooManyShaderElements = -2003238899,
        [ExceptionMapping(typeof(UnsupportedOperationException))]
        UnsupportedOperation = -2003238909,
        [ExceptionMapping(typeof(UnsupportedVersionException))]
        UnsupportedVersion = -2003238896,
        [ExceptionMapping(typeof(Win32ErrorException))]
        Win32Error = -2003238887,
        [ExceptionMapping(typeof(WrongFactoryException))]
        WrongFactory = -2003238894,
        [ExceptionMapping(typeof(WrongResourceDomainException))]
        WrongResourceDomain = -2003238891,
        [ExceptionMapping(typeof(WrongStateException))]
        WrongState = -2003238911,
        [ExceptionMapping(typeof(ZeroVectorException))]
        ZeroVector = -2003238905
    }
}

