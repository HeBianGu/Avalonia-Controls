// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.Ioc
{
    public interface ISnackMessageService
    {
        Task<bool?> ShowDialog(string message);
        void ShowError(string message);
        void ShowFatal(string message);
        void ShowInfo(string message);
        void Show(ISnackItemPresenter message);
        Task<T> ShowProgress<T>(Func<IPercentSnackItemPresenter, T> action);
        Task<T> ShowString<T>(Func<ISnackItemPresenter, T> action);
        void ShowSuccess(string message);
        void ShowWarn(string message);
    }
}
