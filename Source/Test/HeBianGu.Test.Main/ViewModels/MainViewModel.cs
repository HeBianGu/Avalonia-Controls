using CommunityToolkit.Mvvm.Input;
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

        BehaviorCommand = new RelayCommand(() =>
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
}
