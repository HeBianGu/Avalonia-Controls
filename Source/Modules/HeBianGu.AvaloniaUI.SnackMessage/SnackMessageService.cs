// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Extensions.Application;
using Avalonia.Ioc;
using Avalonia.Layout;
using Avalonia.Modules.Messages.Dialog;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace HeBianGu.AvaloniaUI.SnackMessage
{
    public class SnackMessageService : ISnackMessageService
    {
        private SnackBoxPresenter _snackBox = new SnackBoxPresenter();

        private bool CheckValid()
        {
            if (!AdornerGrid.HasPresenter(_snackBox))
                AdornerGrid.AddPresenter(_snackBox);
            return true;
        }

        public async void ShowInfo(string message)
        {
            if (this.CheckValid() == false)
                return;
            InfoMessagePresenter presenter = new InfoMessagePresenter() { Message = message };
            Application.Current.Invoke(() =>
            {
                this._snackBox.Collection.Add(presenter);
            });

            await Task.Run(() =>
            {
                Thread.Sleep(3000);
            });
            Application.Current.Invoke(() =>
            {
                this._snackBox.Collection.Remove(presenter);
            });
        }

        public void ShowError(string message)
        {
            if (this.CheckValid() == false)
                return;
            this._snackBox.Collection.Add(new ErrorMessagePresenter() { Message = message });
        }
        public void Show(ISnackItem message)
        {
            if (this.CheckValid() == false)
                return;
            this._snackBox.Collection.Add(message);
        }

        public void ShowFatal(string message)
        {
            if (this.CheckValid() == false)
                return;
            this._snackBox.Collection.Add(new FatalMessagePresenter() { Message = message });
        }

        public async Task<bool?> ShowDialog(string message)
        {
            if (this.CheckValid() == false)
                return false;
            DialogMessagePresenter dialog = new DialogMessagePresenter() { Message = message };
            this._snackBox.Collection.Add(dialog);
            bool? r = await dialog.ShowDialog();
            this._snackBox.Collection.Remove(dialog);
            return r;
        }

        public async Task<T> ShowProgress<T>(Func<IPercentSnackItem, T> action)
        {
            if (this.CheckValid() == false)
                return default(T);
            ProgressMessagePresenter progress = new ProgressMessagePresenter();
            this._snackBox.Collection.Add(progress);
            T r = await Task.Run(() => action.Invoke(progress));
            this._snackBox.Collection.Remove(progress);
            return r;
        }

        public async Task<T> ShowString<T>(Func<ISnackItem, T> action)
        {
            if (this.CheckValid() == false)
                return default(T);
            StringMessagePresenter progress = new StringMessagePresenter();
            this._snackBox.Collection.Add(progress);
            T r = await Task.Run(() => action.Invoke(progress));
            this._snackBox.Collection.Remove(progress);
            return r;
        }

        public async void ShowSuccess(string message)
        {
            if (this.CheckValid() == false)
                return;
            SuccessMessagePresenter presenter = new SuccessMessagePresenter() { Message = message };
            this._snackBox.Collection.Add(presenter);
            await Task.Run(() =>
             {
                 Thread.Sleep(3000);
             });
            this._snackBox.Collection.Remove(presenter);
        }

        public void ShowWarn(string message)
        {
            if (this.CheckValid() == false)
                return;
            this._snackBox.Collection.Add(new WarnMessagePresenter() { Message = message });

        }
    }
}
