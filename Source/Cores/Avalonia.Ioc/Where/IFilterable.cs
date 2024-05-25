namespace Avalonia.Ioc
{
    public interface IFilterable
    {
        bool IsMatch(object obj);
    }
}
