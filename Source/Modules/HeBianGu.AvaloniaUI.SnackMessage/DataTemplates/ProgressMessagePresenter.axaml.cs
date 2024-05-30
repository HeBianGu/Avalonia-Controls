
using HeBianGu.AvaloniaUI.Geometry;
using HeBianGu.AvaloniaUI.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.SnackMessage
{
    public class ProgressMessagePresenter : SnackMessagePresenterBase, IPercentSnackItem
    {
        public ProgressMessagePresenter()
        {
            this.Geometry = GeometryFactory.Create(Geometrys.Wait);
        }
        private double _value;
        public double Value
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
