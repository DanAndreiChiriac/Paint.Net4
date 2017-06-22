namespace PaintDotNet.Animation
{
    using PaintDotNet.Interop;
    using System;

    public enum AnimationError
    {
        [ExceptionMapping(typeof(AmbiguousMatchException))]
        AmbiguousMatch = -2144731126,
        [ExceptionMapping(typeof(BooleanExpectedException))]
        BooleanExpected = -2144731128,
        [ExceptionMapping(typeof(CreateFailedException))]
        CreateFailed = -2144731135,
        [ExceptionMapping(typeof(DifferentOwnerException))]
        DifferentOwner = -2144731127,
        [ExceptionMapping(typeof(EndKeyFrameNotDeterminedException))]
        EndKeyFrameNotDetermined = -2144730876,
        [ExceptionMapping(typeof(FloatingPointOverflowException))]
        FloatingPointOverflow = -2144731125,
        [ExceptionMapping(typeof(IllegalReentrancyException))]
        IllegalReentrancy = -2144731133,
        [ExceptionMapping(typeof(InvalidOutputException))]
        InvalidOutput = -2144731129,
        [ExceptionMapping(typeof(LoopsOverlapException))]
        LoopsOverlap = -2144730875,
        [ExceptionMapping(typeof(ObjectSealedException))]
        ObjectSealed = -2144731132,
        [ExceptionMapping(typeof(ShutdownCalledException))]
        ShutdownCalled = -2144731134,
        [ExceptionMapping(typeof(StartKeyFrameAfterEndException))]
        StartKeyFrameAfterEnd = -2144730877,
        [ExceptionMapping(typeof(StoryboardActiveException))]
        StoryboardActive = -2144730879,
        [ExceptionMapping(typeof(StoryboardNotPlayingException))]
        StoryboardNotPlaying = -2144730878,
        [ExceptionMapping(typeof(TimeBeforeLastUpdateException))]
        TimeBeforeLastUpdate = -2144730871,
        [ExceptionMapping(typeof(TimerClientAlreadyConnectedException))]
        TimerClientAlreadyConnected = -2144730870,
        [ExceptionMapping(typeof(TransitionAlreadyUsedException))]
        TransitionAlreadyUsed = -2144730874,
        [ExceptionMapping(typeof(TransitionEclipsedException))]
        TransitionEclipsed = -2144730872,
        [ExceptionMapping(typeof(TransitionNotInStoryboardException))]
        TransitionNotInStoryboard = -2144730873,
        [ExceptionMapping(typeof(ValueNotDeterminedException))]
        ValueNotDetermined = -2144731130,
        [ExceptionMapping(typeof(ValueNotSetException))]
        ValueNotSet = -2144731131,
        [ExceptionMapping(typeof(WrongThreadException))]
        WrongThread = -2144731124
    }
}

