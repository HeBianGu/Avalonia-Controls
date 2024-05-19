// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;
using HeBianGu.Avalonia.Core.Ioc;
using HeBianGu.Avalonia.Extensions.ApplicationBase;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Avalonia.Modules.Messages.Snack
{
    public class SnackMessageService : ISnackMessageService
    {
        private SnackBoxPresenter _snackBox = new SnackBoxPresenter();

        private bool CheckValid()
        {
            var control = Application.Current.GetMainAdornerControl();
            if (control == null)
                return false;
            //AdornerLayer layer = AdornerLayer.GetAdornerLayer(control);
            ContentPresenter contentPresenter = new ContentPresenter();
            contentPresenter.Content = this._snackBox;
            contentPresenter.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch;
            contentPresenter.VerticalAlignment = VerticalAlignment.Stretch;
            AdornerLayer.SetAdorner(control, contentPresenter);
            return true;
            //return Application.Current.Invoke(() =>
            //  {
            //      UIElement child = Application.Current.MainWindow?.Content as UIElement;

            //      if (child == null)
            //          return false;
            //      AdornerLayer layer = AdornerLayer.GetAdornerLayer(child);
            //      if (layer == null)
            //          return false;
            //      System.Collections.Generic.IEnumerable<PresenterAdorner> adorners = layer.GetAdorners(child)?.OfType<PresenterAdorner>().Where(x => x.Presenter == this._snackBox);
            //      if (adorners == null || adorners.Count() == 0)
            //      {
            //          PresenterAdorner adorner = new PresenterAdorner(child, this._snackBox);
            //          layer.Add(adorner);
            //      }
            //      return true;
            //  });
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
