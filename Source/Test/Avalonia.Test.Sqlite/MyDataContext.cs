using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Avalonia.Test.Sqlite;

public class MyDataContext : DbContext
{
    public MyDataContext(DbContextOptions<MyDataContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<mbc_dv_image> mbc_dv_images { get; set; }

}
