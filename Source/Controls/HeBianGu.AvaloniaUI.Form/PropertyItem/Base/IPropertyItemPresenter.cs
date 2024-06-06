// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using HeBianGu.AvaloniaUI.Ioc;
using System.Reflection;

namespace HeBianGu.AvaloniaUI.Form
{
    public interface IPropertyItemPresenter : IPresenter
    {
        string Name { get; set; }
        int Order { get; set; }
        string TabGroup { get; set; }
        string GroupName { get; set; }
        PropertyInfo PropertyInfo { get; set; }
        object Obj { get; set; }
    }
}