namespace PaintDotNet.ObjectModel
{
    public interface IResourceSource<TResource> : IResourceSource where TResource: IObjectRef
    {
    }
}

