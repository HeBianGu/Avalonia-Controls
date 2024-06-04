using Avalonia.Controls;
using HeBianGu.AvaloniaUI.DemoData;
using HeBianGu.AvaloniaUI.DialogMessage;
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
    public RelayCommand ShowCommand => new RelayCommand(async l =>
    {
        await AdornerDialog.ShowPresenter<MobileAdornerDialogPresenter>(new ShowMessage(this), x => x.Title = this.Name);
    });
}

public class ShowMessage : ModelBindable<Message>
{
    public ShowMessage(Message model) : base(model)
    {

    }
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
    public RelayCommand ShowCommand => new RelayCommand(async l =>
    {
        await AdornerDialog.ShowPresenter<MobileAdornerDialogPresenter>(new ShowAdress(this), x => x.Title = this.Name);
    });
}

public class Function : Student
{
    public RelayCommand ShowCommand => new RelayCommand(async l =>
    {
        await AdornerDialog.ShowPresenter<MobileAdornerDialogPresenter>(new ShowMy(this), x => x.Title = this.Name);
    });
}

public class ShowAdress : ModelBindable<Adress>
{
    public ShowAdress(Adress model) : base(model)
    {

    }
}


[Display(Name = "发现")]
public class FindItem : TabItemBindableBase<Function>
{

}

public class ShowFindItem : ModelBindable<Function>
{
    public ShowFindItem(Function model) : base(model)
    {

    }
}

[Display(Name = "我")]
public class MyItem : TabItemBindableBase<Adress>
{

}
public class ShowMy : ModelBindable<Function>
{
    public ShowMy(Function model) : base(model)
    {

    }
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