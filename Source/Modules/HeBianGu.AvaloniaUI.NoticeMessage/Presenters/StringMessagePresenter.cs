// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

//using H.Extensions.Geometry;

using Avalonia.Extensions.Geometry;
using HeBianGu.AvaloniaUI.NoticeMessage;

namespace HeBianGu.AvaloniaUI.NoticeMessage
{
    public class StringMessagePresenter : MessagePresenterBase
    {
        public StringMessagePresenter()
        {
            Geometry = GeometryFactory.Create(Geometrys.Wait);
        }
    }
}
