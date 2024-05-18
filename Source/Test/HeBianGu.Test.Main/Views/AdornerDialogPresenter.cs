using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System.Linq;
using System;
using Avalonia.Controls.Presenters;
using Avalonia;
using System.Threading.Tasks;
using System.Threading;
using Avalonia.Controls.ApplicationLifetimes;
using HeBianGu.Test.Main.ViewModels;
using ReactiveUI;
using Avalonia.Layout;

namespace HeBianGu.Test.Main.Views;

public partial class AdornerDialogPresenter:ViewModelBase
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


    private ManualResetEvent _waitHandle = new ManualResetEvent(false);
    public async Task<bool?> ShowDialog(Window owner = null)
    {
        if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            Window window = owner ?? desktop.MainWindow;
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(window.Content as Visual);
            //PresenterAdorner adorner = new PresenterAdorner(child, this);
            //layer.Add(adorner);
            ContentPresenter contentPresenter = new ContentPresenter();
            contentPresenter.Content = this;
            contentPresenter.HorizontalAlignment = HorizontalAlignment.Stretch;
            contentPresenter.VerticalAlignment=VerticalAlignment.Stretch;
            //AdornerLayer.SetAdornedElement(contentPresenter, layer);
            AdornerLayer.SetAdorner(window.Content as Visual, contentPresenter);
            //layer.Children.Add(contentPresenter);
            _waitHandle.Reset();
            return await Task.Run(() =>
            {
                _waitHandle.WaitOne();
                return this.DialogResult;
            });
        }
        return false;
        
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
        if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            Window window = desktop.MainWindow;
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(window);
            //PresenterAdorner adorner = new PresenterAdorner(child, this);
            //layer.Add(adorner);

            AdornerLayer.SetAdorner(window.Content as Visual, null);

            //ContentPresenter contentPresenter = layer.Children.OfType<ContentPresenter>().FirstOrDefault(x=>x.Content==this);
            //layer.Children.Remove(contentPresenter);
            _waitHandle.Set();
        }

        //Application.Current.Dispatcher.Invoke(() =>
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
    public Window Owner { get; set; }
    #endregion
}
