using Avalonia.Ioc;
using Avalonia.Mvvm;

namespace Avalonia.Modules.Messages.Dialog
{
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
}
