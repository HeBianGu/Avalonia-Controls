namespace Avalonia.Ioc
{
    public interface IStringRepository<TEntity> : IRepository<TEntity, string> where TEntity : StringEntityBase
    {

    }
}
