���ݿ�Ǩ������
����һ��������´��룬�������ʱ DbContext ����
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlite("Data Source=Migration.db");

            return new DataContext(optionsBuilder.Options);
        }
    }
���������֤��������������ɳɹ�

��������DbContext������ڵ�ǰ��������

�����������������
Avalonia.Modules.Identity

��������ִ��Ǩ���������Ǩ���ļ�
add-migration init -project Avalonia.Modules.Identity

�����ģ�ִ�и������ݿ����ͬ�������ݿ���
Update-Database -project Avalonia.Modules.Identity

���������Զ�ִ��Ǩ�ƣ��滻�������ݿⷽ��
db.Database.Migrate();�滻�� db.Database.EnsureCreated();

�����ӳټ��أ��Ȳ�����ʾ����include������Ĭ�ϼ���������
��װ��
Microsoft.EntityFrameworkCore.Proxies

����UseLazyLoadingProxies
optionsBuilder.UseLazyLoadingProxies().UseSqlite(connect);

�������
modelBuilder.Entity<im_dd_music>().HasMany(x => x.Images).WithOne(x => x.Music).HasForeignKey(x => x.MusicID).OnDelete(DeleteBehavior.Cascade);

����virtual
public virtual ObservableCollection<im_dd_image> Images { get; set; } = new ObservableCollection<im_dd_image>();

