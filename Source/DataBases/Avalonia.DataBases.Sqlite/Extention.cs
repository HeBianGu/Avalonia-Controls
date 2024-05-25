﻿using Avalonia.DataBases.Sqlite;



#if NETFRAMEWORK
using System.Data.Entity;
#endif

#if NETCOREAPP
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Avalonia.Ioc;
using Avalonia.DataBases.Share;
#endif

namespace System
{
    public static class SqliteExtention
    {
        ///// 注册
        ///// </summary>
        ///// <param name="service"></param>
        //public static void AddDbConnectService<TDbContext>(this IServiceCollection service) where TDbContext : DbContext
        //{
        //    service.AddSingleton<IDbConnectService, SqliteDbConnectService<TDbContext>>();
        //    service.AddSingleton<IDbDisconnectService, DbDisconnectService<TDbContext>>();
        //}

        public static void AddDbContextBySetting<TDbContext>(this IServiceCollection services, Action<ISqliteOption> action = null) where TDbContext : DbContext
        {
            action?.Invoke(SqliteSettable.Instance);
            SqliteSettable.Instance.Load(out string messge);
            string connect = SqliteSettable.Instance.GetConnect();
            services.AddDbContext<TDbContext>(x => x.UseLazyLoadingProxies().UseSqlite(connect));
            SettingDataManager.Instance.Add(SqliteSettable.Instance);
            services.AddSingleton<IDbConnectService, SqliteDbConnectService<TDbContext>>();
            services.AddSingleton<IDbDisconnectService, DbDisconnectService<TDbContext>>();
        }

        public static void AddDbContextNewSetting<TDbContext>(this IServiceCollection services, Action<ISqliteOption> action = null) where TDbContext : DbContext
        {
            SqliteSettable setting = new SqliteSettable()
            {
                ID = typeof(TDbContext).Name
            };
            setting.FilePath = Path.Combine(setting.FilePath, setting.ID);
            Directory.CreateDirectory(setting.FilePath);
            action?.Invoke(setting);
            setting.Load(out string message);
            string connect = setting.GetConnect();
            services.AddDbContext<TDbContext>(x => x.UseLazyLoadingProxies().UseSqlite(connect));
            SettingDataManager.Instance.Add(setting);
            services.AddSingleton<IDbConnectService, SqliteDbConnectService<TDbContext>>();
            services.AddSingleton<IDbDisconnectService, DbDisconnectService<TDbContext>>();
        }
    }
}
