namespace Avalonia.Ioc
{
    public interface IEntityBase<TPrimaryKey>
    {
        TPrimaryKey ID { get; set; }
    }
}