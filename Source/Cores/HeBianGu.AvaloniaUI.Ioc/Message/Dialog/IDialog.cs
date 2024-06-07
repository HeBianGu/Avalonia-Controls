using Avalonia.Controls;
using System;
using System.Windows;

namespace HeBianGu.AvaloniaUI.Ioc
{
    public interface IDialog : ILayoutable, ICancelable, IVisualTransitionableHost
    {
        Func<bool> CanSumit { get; set; }
        void Sumit();
        void Close();
        string? Title { get; set; }
        bool? DialogResult { get; set; }
        DialogButton DialogButton { get; set; }
        WindowBase? Owner { get; }
    }
}
