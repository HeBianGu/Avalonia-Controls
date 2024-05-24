


#if NETFRAMEWORK
using System.Data.Entity;
#endif

#if NETCOREAPP
#endif
using Avalonia.DataBases.Share;
using HeBianGu.Avalonia.Core.Ioc;
using System.ComponentModel.DataAnnotations;

namespace Avalonia.DataBases.Sqlite
{
    [Display(Name = "数据库配置", GroupName = SettingGroupNames.GroupApp)]
    public class SqliteSettable : SqliteSettableBase<SqliteSettable>, ISqliteOption, IDbSettable
    {

    }
}
