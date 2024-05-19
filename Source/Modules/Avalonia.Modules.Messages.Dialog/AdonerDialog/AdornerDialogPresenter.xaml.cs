
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Controls;
using HeBianGu.Avalonia.Core.Ioc;
using HeBianGu.Avalonia.Core.Mvvm;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Avalonia.Layout;
using HeBianGu.Avalonia.Extensions.ApplicationBase;

namespace Avalonia.Modules.Messages.Dialog
{
    public partial class AdornerDialogPresenter : DesignPresenterBase, IDialog, ICancelable
    {
        public AdornerDialogPresenter(object presenter)
        {
            this.Presenter = presenter;
        }
        //public string Title { get; set; } = "提示";
        public object Presenter { get; set; }


        private string _title = "提示";
        /// <summary> 说明  </summary>
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                //RaisePropertyChanged();
                this.RaisePropertyChanged();
            }
        }
        public DialogButton DialogButton { get; set; }

        private ManualResetEvent _waitHandle = new ManualResetEvent(false);
        public async Task<bool?> ShowDialog(Window owner = null)
        {
           var control= Application.Current.GetMainAdornerControl();
            if(control==null)
                return false;
            //AdornerLayer layer = AdornerLayer.GetAdornerLayer(control);
            ContentPresenter contentPresenter = new ContentPresenter();
            contentPresenter.Content = this;
            contentPresenter.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch;
            contentPresenter.VerticalAlignment = VerticalAlignment.Stretch;
            AdornerLayer.SetAdorner(control, contentPresenter);
            _waitHandle.Reset();
            return await Task.Run(() =>
            {
                _waitHandle.WaitOne();
                return this.DialogResult;
            });

        }
        #region - IDialogWindow -
        public bool? DialogResult { get; set; }
        public void Sumit()
        {
            this.DialogResult = true;
            this.Close();
        }

        public void Cancel()
        {
            this.DialogResult = false;
            this.Close();
        }

        public void Close()
        {
            var control = Application.Current.GetMainAdornerControl();
            if (control == null)
                return;

            AdornerLayer.SetAdorner(control, null);
            //ContentPresenter contentPresenter = layer.Children.OfType<ContentPresenter>().FirstOrDefault(x=>x.Content==this);
            //layer.Children.Remove(contentPresenter);
            _waitHandle.Set();

            //Dispatcher.UIThread.Invoke(() =>
            //{
            //    UIElement child = Application.Current.MainWindow.Content as UIElement;
            //    AdornerLayer layer = AdornerLayer.GetAdornerLayer(child);
            //    System.Collections.Generic.IEnumerable<PresenterAdorner> adorners = layer.GetAdorners(child)?.OfType<PresenterAdorner>().Where(x => x.Presenter == this);
            //    if (adorners == null)
            //        return;
            //    foreach (PresenterAdorner adorner in adorners)
            //    {
            //        layer.Remove(adorner);
            //    }
            //    _waitHandle.Set();
            //});
        }

        public Func<bool> CanSumit { get; set; }
        public bool IsCancel => this.DialogResult == false;
        //public DialogButton DialogButton { get; set; } = DialogButton.Sumit;
        public WindowBase? Owner { get; set; }
        #endregion
    }
}
