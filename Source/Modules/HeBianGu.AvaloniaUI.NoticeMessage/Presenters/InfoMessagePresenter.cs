// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control



using Avalonia.Extensions.Geometry;
using HeBianGu.AvaloniaUI.NoticeMessage;

namespace HeBianGu.AvaloniaUI.NoticeMessage
{
    public class InfoMessagePresenter : MessagePresenterBase
    {
        public InfoMessagePresenter()
        {
            this.Geometry = GeometryFactory.Create(Geometrys.Info);
            this.Level = 2;
        }
    }
}
