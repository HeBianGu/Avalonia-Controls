// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control


using Avalonia.Extensions.Geometry;
using HeBianGu.AvaloniaUI.NoticeMessage;

namespace HeBianGu.AvaloniaUI.NoticeMessage
{
    public class FatalMessagePresenter : MessagePresenterBase
    {
        public FatalMessagePresenter()
        {
            Geometry = GeometryFactory.Create(Geometrys.Fatal);
            Level = 5;
        }
    }
}
