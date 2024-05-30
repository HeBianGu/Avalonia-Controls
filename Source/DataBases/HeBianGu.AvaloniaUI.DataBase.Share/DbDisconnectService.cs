



using Avalonia.Ioc;
using System;

#if NETFRAMEWORK
using System.Data.Entity;
#endif

#if NETCOREAPP
using Microsoft.EntityFrameworkCore;
#endif
namespace HeBianGu.AvaloniaUI.DataBase.Share
{
    public class DbDisconnectService : IDbDisconnectService
    {
        public string Name => "数据库数据";
        public bool Save(out string message)
        {
            message = null;
            DbContext db = System.Ioc.GetService<DbContext>();
            db?.SaveChanges();
            //db.Dispose();
            return true;
        }
    }

    public class DbDisconnectService<TDbContext> : IDbDisconnectService where TDbContext : DbContext
    {
        public string Name => "数据库数据";
        public bool Save(out string message)
        {
            message = null;
            TDbContext db = System.Ioc.GetService<TDbContext>();
            db?.SaveChanges();
            //db.Dispose();
            return true;
        }
    }

}
