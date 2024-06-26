﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.Ioc
{
    public interface INoticeMessageService
    {
        Task<bool?> ShowDialog(string message);
        void ShowError(string message);
        void ShowFatal(string message);
        void ShowInfo(string message);
        void Show(INoticeItemPresenter message);
        Task<T> ShowProgress<T>(Func<IPercentNoticeItemPresenter, T> action);
        Task<T> ShowString<T>(Func<INoticeItemPresenter, T> action);
        void ShowSuccess(string message);
        void ShowWarn(string message);
    }
}
