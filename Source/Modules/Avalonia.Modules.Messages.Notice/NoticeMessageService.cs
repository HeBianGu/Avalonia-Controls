﻿
using Avalonia.Controls;
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

namespace Avalonia.Modules.Messages.Notice
{
    public class NoticeMessageService : INoticeMessageService
    {
        private NoticeBoxPresenter _noticeBox = new NoticeBoxPresenter();

        private void CheckValid()
        {
            var control = Application.Current.GetMainAdornerControl();
            if (control == null)
                return;
            //AdornerLayer layer = AdornerLayer.GetAdornerLayer(control);
            ContentPresenter contentPresenter = new ContentPresenter();
            contentPresenter.Content = this._noticeBox;
            contentPresenter.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch;
            contentPresenter.VerticalAlignment = VerticalAlignment.Stretch;
            AdornerLayer.SetAdorner(control, contentPresenter);

            //System.Collections.Generic.IEnumerable<PresenterAdorner> adorners = layer.GetAdorners(child)?.OfType<PresenterAdorner>().Where(x => x.Presenter == this._noticeBox);
            //if (adorners == null || adorners.Count() == 0)
            //{
            //    PresenterAdorner adorner = new PresenterAdorner(child, this._noticeBox);
            //    layer.Add(adorner);
            //}
        }

        public async void ShowInfo(string message)
        {
            this.CheckValid();
            InfoMessagePresenter presenter = new InfoMessagePresenter() { Message = message };
            this._noticeBox.Collection.Add(presenter);
            await Task.Run(() =>
            {
                Thread.Sleep(3000);
            });
            this._noticeBox.Collection.Remove(presenter);
        }

        public void ShowError(string message)
        {
            this.CheckValid();
            this._noticeBox.Collection.Add(new ErrorMessagePresenter() { Message = message });
        }
        public void Show(INoticeItem message)
        {
            this.CheckValid();
            this._noticeBox.Collection.Add(message);
        }

        public void ShowFatal(string message)
        {
            this.CheckValid();
            this._noticeBox.Collection.Add(new FatalMessagePresenter() { Message = message });
        }

        public async Task<bool?> ShowDialog(string message)
        {
            this.CheckValid();
            DialogMessagePresenter dialog = new DialogMessagePresenter() { Message = message };
            this._noticeBox.Collection.Add(dialog);
            bool? r = await dialog.ShowDialog();
            this._noticeBox.Collection.Remove(dialog);
            return r;
        }

        public async Task<T> ShowProgress<T>(Func<IPercentNoticeItem, T> action)
        {
            this.CheckValid();
            ProgressMessagePresenter progress = new ProgressMessagePresenter();
            this._noticeBox.Collection.Add(progress);
            T r = await Task.Run(() => action.Invoke(progress));
            this._noticeBox.Collection.Remove(progress);
            return r;
        }

        public async Task<T> ShowString<T>(Func<INoticeItem, T> action)
        {
            this.CheckValid();
            StringMessagePresenter progress = new StringMessagePresenter();
            this._noticeBox.Collection.Add(progress);
            T r = await Task.Run(() => action.Invoke(progress));
            this._noticeBox.Collection.Remove(progress);
            return r;
        }

        public async void ShowSuccess(string message)
        {
            this.CheckValid();
            SuccessMessagePresenter presenter = new SuccessMessagePresenter() { Message = message };
            this._noticeBox.Collection.Add(presenter);
            await Task.Run(() =>
             {
                 Thread.Sleep(3000);
             });
            this._noticeBox.Collection.Remove(presenter);
        }

        public void ShowWarn(string message)
        {
            this.CheckValid();
            this._noticeBox.Collection.Add(new WarnMessagePresenter() { Message = message });

        }
    }
}
