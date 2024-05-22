using HeBianGu.Avalonia.Core.Ioc;
using HeBianGu.Avalonia.Core.Mvvm;

namespace Avalonia.Modules.Messages.Dialog
{
    public class WaitPresenter : DisplayBindableBase
    {

    }
    public class PercentPresenter : DisplayBindableBase, IPercentPresenter
    {
        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                RaisePropertyChanged();
            }
        }
    }
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
