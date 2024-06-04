using HeBianGu.AvaloniaUI.DemoData;
using HeBianGu.AvaloniaUI.Mvvm;

namespace Avalonia.App.WeChat.Models
{
    public abstract class InfoItemBase : Student
    {
        public RelayCommand ShowCommand => new RelayCommand(l =>
        {
            this.ShowInfo(l);
        });


        public abstract void ShowInfo(object p);

    }
}
