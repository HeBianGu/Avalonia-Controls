
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;
using System.Collections.ObjectModel;

namespace HeBianGu.AvaloniaUI.Form
{
    public class FormPresenter : DisplayBindableBase, IPresenter
    {
        public FormPresenter(object value)
        {
            this._value = value;
        }

        private object _value;
        public object Value
        {
            get { return _value; }
            set
            {
                _value = value;
                RaisePropertyChanged();
            }
        }

        private bool _usePropertyView;
        public bool UsePropertyView
        {
            get { return _usePropertyView; }
            set
            {
                _usePropertyView = value;
                RaisePropertyChanged();
            }
        }
    }

    public class ItemsFormPresenter : DisplayBindableBase
    {
        private ObservableCollection<object> _objs = new ObservableCollection<object>();

        public ObservableCollection<object> Objs
        {
            get { return _objs; }
            set
            {
                _objs = value;
                RaisePropertyChanged("Objs");
            }
        }
    }
}
