
using Avalonia.Layout;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace HeBianGu.AvaloniaUI.Step
{
    [Display(Name = "步骤")]
    public class StepPresenter : DisplayBindableBase, IPresenter
    {
        private Orientation _orientation = Orientation.Horizontal;
        public Orientation Orientation
        {
            get { return _orientation; }
            set
            {
                _orientation = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<IStepItemPresenter> _collection = new ObservableCollection<IStepItemPresenter>();
        public ObservableCollection<IStepItemPresenter> Collection
        {
            get { return _collection; }
            set
            {
                _collection = value;
                RaisePropertyChanged();
            }
        }
    }
}
