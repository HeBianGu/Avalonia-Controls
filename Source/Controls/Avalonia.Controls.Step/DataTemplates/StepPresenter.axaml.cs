
using Avalonia.Layout;
using Avalonia.Mvvm;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Avalonia.Controls.Step
{
    [Display(Name = "步骤")]
    public class StepPresenter : DisplayBindableBase
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
