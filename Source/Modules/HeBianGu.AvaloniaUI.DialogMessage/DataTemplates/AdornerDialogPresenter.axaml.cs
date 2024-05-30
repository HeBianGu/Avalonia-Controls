
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace HeBianGu.AvaloniaUI.DialogMessage
{
    public partial class AdornerDialogPresenter : DesignPresenterBase, IDialog, ICancelable
    {
        public AdornerDialogPresenter(object presenter)
        {
            Presenter = presenter;
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
                RaisePropertyChanged();
            }
        }
        public DialogButton DialogButton { get; set; }

        private ManualResetEvent _waitHandle = new ManualResetEvent(false);
        public async Task<bool?> ShowDialog(Window owner = null)
        {
            AdornerGrid.AddPresenter(this);
            _waitHandle.Reset();
            return await Task.Run(() =>
            {
                _waitHandle.WaitOne();
                return DialogResult;
            });
        }
        #region - IDialogWindow -
        public bool? DialogResult { get; set; }
        public void Sumit()
        {
            DialogResult = true;
            Close();
        }

        public void Cancel()
        {
            DialogResult = false;
            Close();
        }

        public void Close()
        {
            AdornerGrid.RemovePresenter(this);
            _waitHandle.Set();
        }

        public Func<bool> CanSumit { get; set; }
        public bool IsCancel => DialogResult == false;
        //public DialogButton DialogButton { get; set; } = DialogButton.Sumit;
        public WindowBase? Owner { get; set; }
        #endregion
    }
}
