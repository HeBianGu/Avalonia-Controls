// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control



using Avalonia.Extensions.Geometry;
using HeBianGu.AvaloniaUI.NoticeMessage;

namespace HeBianGu.AvaloniaUI.NoticeMessage
{
    public class ErrorMessagePresenter : MessagePresenterBase
    {
        public ErrorMessagePresenter()
        {
            this.Geometry = GeometryFactory.Create(Geometrys.Error);
            this.Level = 4;
        }
    }
}
