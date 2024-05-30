﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Extensions.Setting;
using Avalonia.Ioc;
using System.ComponentModel.DataAnnotations;

namespace HeBianGu.AvaloniaUI.Modules.Setting
{
    /// <summary> 提醒 </summary>
    [Display(Name = "提醒", GroupName = SettingGroupNames.GroupMessage)]
    public class NotifySetting : Settable<NotifySetting>
    {
    }
}
