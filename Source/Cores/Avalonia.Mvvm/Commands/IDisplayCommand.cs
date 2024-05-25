// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

namespace Avalonia.Mvvm
{
    public interface IDisplayCommand
    {
        string Name { get; set; }
        string Description { get; set; }
        string GroupName { get; set; }
        int Order { get; set; }
    }
}
