namespace PaintDotNet.Dxgi
{
    using PaintDotNet.Interop;
    using System;

    public enum DxgiError
    {
        [ExceptionMapping(typeof(DeviceHungException))]
        DeviceHung = -2005270522,
        [ExceptionMapping(typeof(DeviceRemovedException))]
        DeviceRemoved = -2005270523,
        [ExceptionMapping(typeof(DeviceResetException))]
        DeviceReset = -2005270521,
        [ExceptionMapping(typeof(DriverInternalErrorException))]
        DriverInternalError = -2005270496,
        [ExceptionMapping(typeof(FrameStatisticsDisjointException))]
        FrameStatisticsDisjoint = -2005270517,
        [ExceptionMapping(typeof(GraphicsVidpnSourceInUseException))]
        GraphicsVidpnSourceInUse = -2005270516,
        [ExceptionMapping(typeof(InvalidCallException))]
        InvalidCall = -2005270527,
        [ExceptionMapping(typeof(ModeChangedException))]
        ModeChanged = 0x87a0007,
        [ExceptionMapping(typeof(ModeChangeInProgressException))]
        ModeChangeInProgress = 0x87a0008,
        [ExceptionMapping(typeof(MoreDataException))]
        MoreData = -2005270525,
        [ExceptionMapping(typeof(NonExclusiveException))]
        NonExclusive = -2005270495,
        [ExceptionMapping(typeof(NotCurrentlyAvailableException))]
        NotCurrentlyAvailable = -2005270494,
        [ExceptionMapping(typeof(NotFoundException))]
        NotFound = -2005270526,
        [ExceptionMapping((Type) null)]
        Occluded = 0x87a0001,
        [ExceptionMapping((Type) null)]
        Ok = 0,
        [ExceptionMapping(typeof(RemoteClientDisconnectedException))]
        RemoteClientDisconnected = -2005270493,
        [ExceptionMapping(typeof(RemoteOutOfMemoryException))]
        RemoteOutOfMemory = -2005270492,
        [ExceptionMapping(typeof(UnsupportedException))]
        Unsupported = -2005270524,
        [ExceptionMapping(typeof(WasStillDrawingException))]
        WasStillDrawing = -2005270518
    }
}

