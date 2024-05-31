using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml.Styling;
using HeBianGu.Test.Main.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Windows.Input;
using ReactiveUI;
using HeBianGu.AvaloniaUI.Mvvm;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.DialogMessage;
using HeBianGu.AvaloniaUI.DemoData;
using System.Threading.Tasks;

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


    private ObservableCollection<string> _selectedcollection = new ObservableCollection<string>();
    /// <summary> 说明  </summary>
    public ObservableCollection<string> SelectedCollection
    {
        get { return _selectedcollection; }
        set { this.RaiseAndSetIfChanged(ref _selectedcollection, value); }
    }

    public ICommand BehaviorCommand { get; }


    public RelayCommand ShowMessageCommand => new RelayCommand((s, e) =>
    {
        IocMessage.Dialog.Show("数据保存完成");
    });
    public RelayCommand ShowFormMessageCommand => new RelayCommand((s, e) =>
    {
        IocMessage.Form.ShowEdit(Student.Random());
    });
    public RelayCommand ShowTaskException => new RelayCommand((s, e) =>
    {
        Task.Run(() =>
        {
            throw new AggregateException("ShowTaskException");
        });
    });

    public RelayCommand ShowException => new RelayCommand((s, e) =>
    {
        throw new Exception("ShowException");
    });

    public RelayCommand SetFontSizeCommand => new RelayCommand((s, e) =>
    {
        var find = Application.Current.Resources.MergedDictionaries.OfType<ResourceInclude>().FirstOrDefault(x => x.Source.AbsoluteUri.Contains("FontSize"));
        int index = Application.Current.Resources.MergedDictionaries.IndexOf(find);
        Uri uri = new Uri("avares://HeBianGu.AvaloniaUI.Theme/FontSizes/Large.axaml");
        ResourceInclude include = new ResourceInclude(uri) { Source = uri };
        Application.Current.Resources.MergedDictionaries[index] = include;
    });
}
