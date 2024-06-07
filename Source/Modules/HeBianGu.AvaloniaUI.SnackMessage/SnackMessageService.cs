// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;
using Avalonia.Threading;
using HeBianGu.AvaloniaUI.DialogMessage;
using HeBianGu.AvaloniaUI.Ioc;
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
            else
            {
                AdornerGrid.RemovePresenter(_snackBox);
                AdornerGrid.AddPresenter(_snackBox);
            }
            return true;
        }

        public async void ShowInfo(string message)
        {
            if (this.CheckValid() == false)
                return;
            InfoMessagePresenter presenter = new InfoMessagePresenter() { Message = message };
            Dispatcher.UIThread.Invoke(() =>
             {
                 this.Add(presenter);
             });

            await Task.Run(() =>
            {
                Thread.Sleep(3000);
            });
            Dispatcher.UIThread.Invoke(() =>
            {
                this.Remove(presenter);
            });
        }

        private void Add(ISnackItemPresenter presenter)
        {
            this._snackBox.Collection.Add(presenter);
        }

        private void Remove(ISnackItemPresenter presenter)
        {
            this._snackBox.Collection.Remove(presenter);
        }

        public void ShowError(string message)
        {
            if (this.CheckValid() == false)
                return;
            this.Add(new ErrorMessagePresenter() { Message = message });
        }
        public void Show(ISnackItemPresenter message)
        {
            if (this.CheckValid() == false)
                return;
            this.Add(message);
        }

        public void ShowFatal(string message)
        {
            if (this.CheckValid() == false)
                return;
            this.Add(new FatalMessagePresenter() { Message = message });
        }

        public async Task<bool?> ShowDialog(string message)
        {
            if (this.CheckValid() == false)
                return false;
            DialogMessagePresenter dialog = new DialogMessagePresenter() { Message = message };
            this.Add(dialog);
            bool? r = await dialog.ShowDialog();
            this.Remove(dialog);
            return r;
        }

        public async Task<T> ShowProgress<T>(Func<IPercentSnackItemPresenter, T> action)
        {
            if (this.CheckValid() == false)
                return default(T);
            ProgressMessagePresenter progress = new ProgressMessagePresenter();
            this.Add(progress);
            T r = await Task.Run(() => action.Invoke(progress));
            this.Remove(progress);
            return r;
        }

        public async Task<T> ShowString<T>(Func<ISnackItemPresenter, T> action)
        {
            if (this.CheckValid() == false)
                return default(T);
            StringMessagePresenter progress = new StringMessagePresenter();
            this.Add(progress);
            T r = await Task.Run(() => action.Invoke(progress));
            this.Remove(progress);
            return r;
        }

        public async void ShowSuccess(string message)
        {
            if (this.CheckValid() == false)
                return;
            SuccessMessagePresenter presenter = new SuccessMessagePresenter() { Message = message };
            this.Add(presenter);
            await Task.Run(() =>
             {
                 Thread.Sleep(3000);
             });
            this.Remove(presenter);
        }

        public void ShowWarn(string message)
        {
            if (this.CheckValid() == false)
                return;
            this.Add(new WarnMessagePresenter() { Message = message });

        }
    }
}
