using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Avalonia.Test.Sqlite;

public class MyDataContextFactory : IDesignTimeDbContextFactory<MyDataContext>
{
    public MyDataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyDataContext>();
        optionsBuilder.UseLazyLoadingProxies().UseSqlite("Data Source=Migration.db");
        return new MyDataContext(optionsBuilder.Options);
    }
}
