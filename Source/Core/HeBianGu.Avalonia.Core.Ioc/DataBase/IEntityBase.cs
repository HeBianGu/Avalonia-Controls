namespace HeBianGu.Avalonia.Core.Ioc
{
    public interface IEntityBase<TPrimaryKey>
    {
        TPrimaryKey ID { get; set; }
    }
}