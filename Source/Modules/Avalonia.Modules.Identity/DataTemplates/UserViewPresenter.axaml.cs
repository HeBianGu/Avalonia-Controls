// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Data;
using Avalonia.Extensions.Repository;
using Avalonia.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Avalonia.Modules.Identity
{
    public class Filter : IFilterable
    {
        public bool IsMatch(object obj)
        {
            return true;
        }
    }
    [Display(Name = "用户管理", GroupName = SettingGroupNames.GroupAuthority, Description = "应用此功能进行用户管理")]
    public class UserViewPresenter : RepositoryViewPresenterBase<hi_dd_user>, IUserViewPresenter
    {

    }
}
