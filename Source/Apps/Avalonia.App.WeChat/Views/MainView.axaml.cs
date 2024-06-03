using Avalonia.Controls;
using HeBianGu.AvaloniaUI.DemoData;
using HeBianGu.AvaloniaUI.Mvvm;
using HeBianGu.AvaloniaUI.ValueConverter;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace Avalonia.App.WeChat.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }
}

public interface ITabItem
{

}

public abstract class TabItemBindableBase<T> : DisplayBindableBase, ITabItem
{
    private ObservableCollection<T> _collection = new ObservableCollection<T>();
    /// <summary> 说明  </summary>
    public ObservableCollection<T> Collection
    {
        get { return _collection; }
        set
        {
            _collection = value;
            RaisePropertyChanged();
        }
    }
}

[Display(Name = "微信")]
public class MessageItem : TabItemBindableBase<Message>
{
    public MessageItem()
    {
        this.Collection = Enumerable.Range(0, 20).Select(x => new Message() { }).ToObservable();
    }
}

public class Message : Student
{


}


[Display(Name = "通讯录")]
public class AdressItem : TabItemBindableBase<Adress>
{
    public AdressItem()
    {
        this.Collection = Enumerable.Range(0, 20).Select(x => new Adress()).ToObservable();
    }
}

public class Adress : Student
{

}

[Display(Name = "发现")]
public class FindItem : TabItemBindableBase<Adress>
{

}

[Display(Name = "我")]
public class MyItem : TabItemBindableBase<Adress>
{

}

public class TimeValueConverter : MarkupValueConverterBase
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DateTime time)
            return time.ToString("MM月dd日");
        return value;
    }
}