using HeBianGu.AvaloniaUI.Mvvm;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Avalonia.App.QQ.ViewModels;

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


    private ObservableCollection<TabItemBindableBase> _collection = new ObservableCollection<TabItemBindableBase>();
    /// <summary> 说明  </summary>
    public ObservableCollection<TabItemBindableBase> Collection
    {
        get { return _collection; }
        set
        {
            _collection = value;
            RaisePropertyChanged();
        }
    }


    private TabItemBindableBase _selecteItem;
    /// <summary> 说明  </summary>
    public TabItemBindableBase SelecteItem
    {
        get { return _selecteItem; }
        set
        {
            _selecteItem = value;
            RaisePropertyChanged();
        }
    }


}

public abstract class TabItemBindableBase : DisplayBindableBase
{

}

[Display(Name = "微信")]
public class MessageItem : TabItemBindableBase
{

}
[Display(Name = "通讯录")]
public class AdressItem : TabItemBindableBase
{

}

[Display(Name = "发现")]
public class FindItem : TabItemBindableBase
{

}

[Display(Name = "我")]
public class MyItem : TabItemBindableBase
{

}

