namespace PaintDotNet.Dxgi
{
    using System;

    public enum Residency
    {
        EvictedToDisk = 3,
        FullyResident = 1,
        ResidentInSharedMemory = 2
    }
}

