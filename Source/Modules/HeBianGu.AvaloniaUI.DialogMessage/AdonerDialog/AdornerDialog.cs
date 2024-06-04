
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Layout;
using Avalonia;
using HeBianGu.AvaloniaUI.Ioc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace HeBianGu.AvaloniaUI.DialogMessage
{
    public static class AdornerDialog
    {
        public static async Task<bool?> ShowPresenter<Dialog>(object presenter, Action<IDialog> action = null, Func<bool> canSumit = null) where Dialog : IAdornerDialogPresenter, new()
        {
            IAdornerDialogPresenter dialog = new Dialog();
            if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime)
            {
                dialog.MinWidth = 400;
            }
            else
            {
                dialog.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                dialog.HorizontalAlignment = HorizontalAlignment.Stretch;
            }
            dialog.Presenter = presenter;
            dialog.CanSumit = canSumit;
            action?.Invoke(dialog);
            dialog.Title = dialog.Title ?? presenter.GetType().GetCustomAttribute<DisplayAttribute>()?.Name ?? "提示";
            return await dialog.ShowDialog();
        }

        public static async Task<bool?> ShowPresenter(object presenter, Action<IDialog> action = null, Func<bool> canSumit = null)
        {
            return await ShowPresenter<AdornerDialogPresenter>(presenter, action, canSumit);
        }

        public static async Task<T> ShowAction<P, T>(P presenter, Func<IDialog, P, T> func = null, Action<IDialog> action = null)
        {
            AdornerDialogPresenter dialog = new AdornerDialogPresenter(presenter);
            if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime)
            {
                dialog.MinWidth = 400;
                dialog.MinHeight = 150;
            }
            else
            {
                dialog.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                dialog.HorizontalAlignment = HorizontalAlignment.Stretch;
            }
            action?.Invoke(dialog);
            dialog.Title = dialog.Title ?? presenter.GetType().GetCustomAttribute<DisplayAttribute>()?.Name ?? "提示";
            T result = default;
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
            Task.Run(() =>
            {
                result = func.Invoke(dialog, presenter);
                dialog.DialogResult = true;
                dialog.Close();
            });
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
            await dialog.ShowDialog();
            return result;
        }

    }
}
