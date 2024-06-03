using Avalonia.App.WeChat.Views;
using HeBianGu.AvaloniaUI.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;
namespace Avalonia.App.WeChat.ViewModels;

public class MainViewModel : BindableBase
{
    public MainViewModel()
    {
        this.Collection.Add(new MessageItem());
        this.Collection.Add(new AdressItem());
        this.Collection.Add(new FindItem());
        this.Collection.Add(new MyItem());
        this.SelecteItem = this.Collection.First();
    }
    public string Greeting => "Welcome to Avalonia!";


    private ObservableCollection<ITabItem> _collection = new ObservableCollection<ITabItem>();
    /// <summary> 说明  </summary>
    public ObservableCollection<ITabItem> Collection
    {
        get { return _collection; }
        set
        {
            _collection = value;
            RaisePropertyChanged();
        }
    }


    private ITabItem _selecteItem;
    /// <summary> 说明  </summary>
    public ITabItem SelecteItem
    {
        get { return _selecteItem; }
        set
        {
            _selecteItem = value;
            RaisePropertyChanged();
        }
    }


}

