
using Avalonia.DataBases.Share;
using Avalonia.Ioc;
using Microsoft.EntityFrameworkCore;

namespace HeBianGu.AvaloniaUI.Sqlite
{
    public class SqliteDbConnectService<TDbContext> : DbConnectServiceBase<TDbContext> where TDbContext : DbContext
    {
        protected override IDbSettable GetSetting()
        {
            return SqliteSettable.Instance;
        }
    }
}
