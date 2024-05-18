namespace HeBianGu.Avalonia.Core.Ioc
{
    public interface ISettable
    {
        int Order { get; }
        string Name { get; }
        string GroupName { get; }
    }
}
