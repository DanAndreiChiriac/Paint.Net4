namespace PaintDotNet.DirectWrite
{
    using PaintDotNet.Interop;
    using System;

    public enum DirectWriteError
    {
        [ExceptionMapping(typeof(AlreadyRegisteredException))]
        AlreadyRegistered = -2003283962,
        [ExceptionMapping(typeof(FontCollectionObsoleteException))]
        FontCollectionObsolete = -2003283963,
        [ExceptionMapping(typeof(FontFileAccessException))]
        FontFileAccess = -2003283964,
        [ExceptionMapping(typeof(FontFileFormatException))]
        FontFileFormat = -2003283968,
        [ExceptionMapping(typeof(FontFileNotFoundException))]
        FontFileNotFound = -2003283965,
        [ExceptionMapping(typeof(NoFontException))]
        NoFont = -2003283966,
        [ExceptionMapping(typeof(UnexpectedDirectWriteException))]
        UnexpectedDirectWrite = -2003283967
    }
}

