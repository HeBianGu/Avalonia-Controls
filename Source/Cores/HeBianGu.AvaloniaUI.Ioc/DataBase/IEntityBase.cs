namespace HeBianGu.AvaloniaUI.Ioc
{
    public interface IEntityBase<TPrimaryKey>
    {
        TPrimaryKey ID { get; set; }
    }
}