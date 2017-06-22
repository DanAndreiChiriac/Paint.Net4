namespace PaintDotNet.Interop
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;
    using System.IO;

    public enum InteropError
    {
        [ExceptionMapping(typeof(OperationCanceledException))]
        Aborted = -2147467260,
        [ExceptionMapping(typeof(UnauthorizedAccessException))]
        AccessDenied = -2147024891,
        [ExceptionMapping(typeof(OverflowException))]
        ArithmeticOverflow = -2147024362,
        [ExceptionMapping(typeof(ElevationRequiredException))]
        ElevationRequired = -2147024156,
        [ExceptionMapping(typeof(Exception))]
        Fail = -2147467259,
        [ExceptionMapping((Type) null)]
        False = 1,
        [ExceptionMapping(typeof(PathTooLongException))]
        FilenameExceedsRange = -2147024690,
        [ExceptionMapping(typeof(FileNotFoundException))]
        FileNotFound = -2147024894,
        [ExceptionMapping(typeof(EndOfStreamException))]
        HandleEndOfFile = -2147024858,
        [ExceptionMapping(typeof(InsufficientBufferException))]
        InsufficientBuffer = -2147024774,
        [ExceptionMapping(typeof(InterfaceNotSupportedException))]
        InterfaceNotSupported = -2147467262,
        [ExceptionMapping(typeof(ArgumentException))]
        InvalidArgument = -2147024809,
        [ExceptionMapping(typeof(InvalidHandleException))]
        InvalidHandle = -2147024890,
        [ExceptionMapping(typeof(NotImplementedException))]
        NotImplemented = -2147467263,
        [ExceptionMapping((Type) null)]
        Ok = 0,
        [ExceptionMapping(typeof(OutOfMemoryException))]
        OutOfMemory = -2147024882,
        [ExceptionMapping(typeof(DirectoryNotFoundException))]
        PathNotFound = -2147024893
    }
}

