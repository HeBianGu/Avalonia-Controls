namespace HeBianGu.Avalonia.Core.Ioc
{
    public interface IStringRepository<TEntity> : IRepository<TEntity, string> where TEntity : StringEntityBase
    {

    }
}
