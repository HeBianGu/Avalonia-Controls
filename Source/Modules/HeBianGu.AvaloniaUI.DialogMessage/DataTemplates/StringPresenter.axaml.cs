using Avalonia.Ioc;
using Avalonia.Mvvm;

namespace HeBianGu.AvaloniaUI.DialogMessage
{
    public class StringPresenter : DisplayBindableBase, IStringPresenter
    {
        private string _value;
        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                RaisePropertyChanged();
            }
        }
    }
}
