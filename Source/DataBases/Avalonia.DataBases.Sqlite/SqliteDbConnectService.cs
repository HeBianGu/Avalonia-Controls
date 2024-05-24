
using Avalonia.DataBases.Share;
using HeBianGu.Avalonia.Core.Ioc;
using Microsoft.EntityFrameworkCore;
namespace Avalonia.DataBases.Sqlite
{
    public class SqliteDbConnectService<TDbContext> : DbConnectServiceBase<TDbContext> where TDbContext : DbContext
    {
        protected override IDbSettable GetSetting()
        {
            return SqliteSettable.Instance;
        }
    }
}
