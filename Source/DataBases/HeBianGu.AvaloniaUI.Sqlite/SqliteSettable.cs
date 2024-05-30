


#if NETFRAMEWORK
using System.Data.Entity;
#endif

#if NETCOREAPP
#endif
using HeBianGu.AvaloniaUI.DataBase.Share;
using HeBianGu.AvaloniaUI.Ioc;
using System.ComponentModel.DataAnnotations;

namespace HeBianGu.AvaloniaUI.Sqlite
{
    [Display(Name = "数据库配置", GroupName = SettingGroupNames.GroupApp)]
    public class SqliteSettable : SqliteSettableBase<SqliteSettable>, ISqliteOption, IDbSettable
    {

    }
}
