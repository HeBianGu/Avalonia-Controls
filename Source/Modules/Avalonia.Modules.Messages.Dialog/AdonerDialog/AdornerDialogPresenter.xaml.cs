
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
            AdornerGrid.AddPresenter(this);
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
            AdornerGrid.RemovePresenter(this);
            _waitHandle.Set();
        }

        public Func<bool> CanSumit { get; set; }
        public bool IsCancel => this.DialogResult == false;
        //public DialogButton DialogButton { get; set; } = DialogButton.Sumit;
        public WindowBase? Owner { get; set; }
        #endregion
    }
}
