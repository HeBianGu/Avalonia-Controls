
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Layout;
using HeBianGu.AvaloniaUI.Animations;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace HeBianGu.AvaloniaUI.DialogMessage
{
    public abstract class AdornerDialogPresenterBase : DesignPresenterBase, IDialog, ICancelable, IAdornerDialogPresenter
    {
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


        public RelayCommand CancelCommand => new RelayCommand((s, e) =>
        {
            if (e is RoutedEventArgs project && project.Source is Grid grid && grid.Name == "g_all")
            {
                if (this.DialogButton == DialogButton.None)
                    this.Close();
            }
        });

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
        public IVisualTransitionable VisualTransitionable { get; set; } = new OpacityTransitionable();
        #endregion
    }

    public partial class AdornerDialogPresenter : AdornerDialogPresenterBase
    {
        public AdornerDialogPresenter()
        {

        }
        public AdornerDialogPresenter(object presenter)
        {
            Presenter = presenter;
        }
    }

}
