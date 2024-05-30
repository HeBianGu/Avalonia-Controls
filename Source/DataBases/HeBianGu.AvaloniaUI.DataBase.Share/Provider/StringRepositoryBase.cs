

#if NETFRAMEWORK
using System.Data.Entity;
#endif

#if NETCOREAPP

using Avalonia.Ioc;
using Microsoft.EntityFrameworkCore;
#endif

namespace HeBianGu.AvaloniaUI.DataBase.Share
{
    /// <summary>
    /// 主键为Guid类型的仓储基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class StringRepositoryBase<TEntity> : RepositoryBase<DbContext, TEntity, string> where TEntity : StringEntityBase
    {
        public StringRepositoryBase(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
