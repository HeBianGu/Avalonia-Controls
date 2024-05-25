﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Ioc;
using Avalonia.Extensions.Setting;
using System.ComponentModel.DataAnnotations;

namespace HeBianGu.Avalonia.Modules.Setting
{
    /// <summary> 文件管理 </summary>
    [Display(Name = "文件管理", GroupName = SettingGroupNames.GroupBase)]
    public class FileSetting : Settable<FileSetting>
    {
    }

    [Display(Name = "密码", GroupName = SettingGroupNames.GroupSecurity)]
    public class PasswordSetting : Settable<PasswordSetting>
    {

    }

    [Display(Name = "消息记录", GroupName = SettingGroupNames.GroupMessage)]
    public class MessageSetting : Settable<MessageSetting>
    {

    }


    [Display(Name = "个人资料", GroupName = SettingGroupNames.GroupSecurity)]
    public class PersonalSetting : Settable<PersonalSetting>
    {

    }
}
