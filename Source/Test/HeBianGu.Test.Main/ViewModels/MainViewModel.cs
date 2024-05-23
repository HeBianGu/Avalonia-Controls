using Avalonia;
using Avalonia.Controls;
using Avalonia.Modules.Messages.Dialog;
using Avalonia.Styles;
using HeBianGu.Avalonia.Core.Ioc;
using HeBianGu.Avalonia.Core.Mvvm;
using HeBianGu.Test.Main.Views;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows.Input;

namespace HeBianGu.Test.Main.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
    public MainViewModel()
    {
        this.Collection = new ObservableCollection<string>(Enumerable.Range(1, 30).Select(x => x.ToString()));

        BehaviorCommand = new RelayCommand(x =>
        {
            AdornerDialogPresenter adornerDialogPresenter = new AdornerDialogPresenter(new Student());
            adornerDialogPresenter.ShowDialog();
        });
    }

    private ObservableCollection<string> _collection = new ObservableCollection<string>();
    /// <summary> 说明  </summary>
    public ObservableCollection<string> Collection
    {
        get { return _collection; }
        set { this.RaiseAndSetIfChanged(ref _collection, value); }
    }

    public ICommand BehaviorCommand { get; }


    public RelayCommand ShowMessageCommand => new RelayCommand((s, e) =>
    {
        IocMessage.Dialog.Show("111111");
    });
    public RelayCommand ShowFormMessageCommand => new RelayCommand((s, e) =>
    {
        IocMessage.Form.ShowEdit(Student.Random());
    });
    public RelayCommand ShowNoticeMessageCommand => new RelayCommand((s, e) =>
    {
        IocMessage.Notify.ShowInfo("11111");
    });

    public RelayCommand ShowSnackMessageCommand => new RelayCommand((s, e) =>
    {
        IocMessage.Snack.ShowSuccess("11111");
    });

    public RelayCommand SetFontSizeCommand => new RelayCommand((s, e) =>
    {
        var ss= Application.Current;
    });
}
