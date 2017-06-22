namespace PaintDotNet.Imaging
{
    using PaintDotNet.Interop;
    using System;

    public enum ImagingError
    {
        [ExceptionMapping(typeof(AlreadyLockedException))]
        AlreadyLocked = -2003292403,
        [ExceptionMapping(typeof(BadHeaderException))]
        BadHeader = -2003292319,
        [ExceptionMapping(typeof(BadImageException))]
        BadImage = -2003292320,
        [ExceptionMapping(typeof(BadMetadataHeaderException))]
        BadMetadataHeader = -2003292317,
        [ExceptionMapping(typeof(BadStreamDataException))]
        BadStreamData = -2003292304,
        [ExceptionMapping(typeof(CodecNoThumbnailException))]
        CodecNoThumbnail = -2003292348,
        [ExceptionMapping(typeof(CodecPresentException))]
        CodecPresent = -2003292349,
        [ExceptionMapping(typeof(CodecTooManyScanlinesException))]
        CodecTooManyScanlines = -2003292346,
        [ExceptionMapping(typeof(ComponentInitializeFailureException))]
        ComponentInitializeFailure = -2003292277,
        [ExceptionMapping(typeof(ComponentNotFoundException))]
        ComponentNotFound = -2003292336,
        [ExceptionMapping(typeof(DuplicateMetadataPresentException))]
        DuplicateMetadataPresent = -2003292275,
        [ExceptionMapping(typeof(FrameMissingException))]
        FrameMissing = -2003292318,
        [ExceptionMapping(typeof(ImageSizeOutOfRangeException))]
        ImageSizeOutOfRange = -2003292335,
        [ExceptionMapping(typeof(InsufficientBufferException))]
        InsufficientBuffer = -2003292276,
        [ExceptionMapping(typeof(InternalErrorException))]
        InternalError = -2003292344,
        [ExceptionMapping(typeof(InvalidQueryCharacterException))]
        InvalidQueryCharacter = -2003292269,
        [ExceptionMapping(typeof(InvalidQueryRequestException))]
        InvalidQueryRequest = -2003292272,
        [ExceptionMapping(typeof(InvalidRegistrationException))]
        InvalidRegistration = -2003292278,
        [ExceptionMapping(typeof(NotInitializedException))]
        NotInitialized = -2003292404,
        [ExceptionMapping(typeof(PaletteUnavailableException))]
        PaletteUnavailable = -2003292347,
        [ExceptionMapping(typeof(PropertyNotFoundException))]
        PropertyNotFound = -2003292352,
        [ExceptionMapping(typeof(PropertyNotSupportedException))]
        PropertyNotSupported = -2003292351,
        [ExceptionMapping(typeof(PropertySizeException))]
        PropertySize = -2003292350,
        [ExceptionMapping(typeof(PropertyUnexpectedTypeException))]
        PropertyUnexpectedType = -2003292274,
        [ExceptionMapping(typeof(RequestOnlyValidAtMetadataRootException))]
        RequestOnlyValidAtMetadataRoot = -2003292270,
        [ExceptionMapping(typeof(SourceRectDoesNotMatchDimensionsException))]
        SourceRectDoesNotMatchDimensions = -2003292343,
        [ExceptionMapping(typeof(StreamNotAvailableException))]
        StreamNotAvailable = -2003292301,
        [ExceptionMapping(typeof(StreamReadException))]
        StreamRead = -2003292302,
        [ExceptionMapping(typeof(StreamWriteException))]
        StreamWrite = -2003292303,
        [ExceptionMapping(typeof(TooMuchMetadataException))]
        TooMuchMetadata = -2003292334,
        [ExceptionMapping(typeof(UnexpectedMetadataTypeException))]
        UnexpectedMetadataType = -2003292271,
        [ExceptionMapping(typeof(UnexpectedSizeException))]
        UnexpectedSize = -2003292273,
        [ExceptionMapping(typeof(UnknownImageFormatException))]
        UnknownImageFormat = -2003292409,
        [ExceptionMapping(typeof(UnsupportedOperationException))]
        UnsupportedOperation = -2003292287,
        [ExceptionMapping(typeof(UnsupportedPixelFormatException))]
        UnsupportedPixelFormat = -2003292288,
        [ExceptionMapping(typeof(UnsupportedVersionException))]
        UnsupportedVersion = -2003292405,
        [ExceptionMapping(typeof(ValueOutOfRangeException))]
        ValueOutOfRange = -2003292411,
        [ExceptionMapping(typeof(WrongStateException))]
        WrongState = -2003292412
    }
}

