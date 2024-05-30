// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System.Windows;

namespace HeBianGu.AvaloniaUI.Mvvm
{
    public interface ITreeNode
    {
        bool IsExpanded { get; set; }
        bool? IsChecked { get; set; }
        bool Visibility { get; set; }
    }
}
