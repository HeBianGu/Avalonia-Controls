// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Data;
using Avalonia.Extensions.Repository;
using Avalonia.Ioc;
using Avalonia.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.Modules.Identity
{
    public class RoleRepositoryViewModel : RepositoryBindable<hi_dd_role>
    {
        public override async Task Add(object obj)
        {
            hi_dd_role m = new hi_dd_role();
            RoleEditPresenter roleViewModel = new RoleEditPresenter(m);
            bool? dialog = await IocMessage.Dialog.Show(roleViewModel, x =>
            {
                x.DialogButton = DialogButton.Sumit;
                x.Title = "新增";
            });
            if (dialog != true)
            {
                IocMessage.Snack?.ShowInfo("取消操作");
                return;
            }
            await this.Add(m);
            this.OnCollectionChanged(obj);
        }

        public override async Task Edit(object obj)
        {
            hi_dd_role entity = this.GetEntity(obj);
            if (entity == null)
                return;
            RoleEditPresenter roleViewModel = new RoleEditPresenter(entity);
            bool? r = await IocMessage.Dialog.Show(roleViewModel, x =>
            {
                x.DialogButton = DialogButton.Sumit;
                x.Title = "编辑";
            });
            if (r != true)
            {
                IocMessage.Snack?.ShowInfo("取消操作");
                return;
            }

            int rs = this.Repository == null ? 1 : await this.Repository.SaveAsync();

            if (rs > 0)
            {
                if (this.UseMessage)
                    IocMessage.Snack?.ShowInfo("保存成功");
            }
            else
            {
                IocMessage.Snack?.ShowInfo("保存失败，数据库保存错误");
            }
        }
    }

    [Display(Name = "角色管理", GroupName = SettingGroupNames.GroupAuthority, Description = "应用此功能进行角色管理")]
    public class RoleViewPresenter : RepositoryViewPresenterBase<hi_dd_role>, IRoleViewPresenter
    {


    }
}
