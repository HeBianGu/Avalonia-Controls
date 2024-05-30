using HeBianGu.AvaloniaUI.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeBianGu.AvaloniaUI.Ioc;

namespace HeBianGu.AvaloniaUI.NoticeMessage
{
    public class ProgressMessagePresenter : MessagePresenterBase, IPercentNoticeItem
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
