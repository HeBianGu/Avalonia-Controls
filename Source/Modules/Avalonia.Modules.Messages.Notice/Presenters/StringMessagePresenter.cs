// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

//using H.Extensions.Geometry;

using Avalonia.Extensions.Geometry;
using Avalonia.Modules.Messages.Notice;

namespace Avalonia.Modules.Messages.Notice
{
    public class StringMessagePresenter : MessagePresenterBase
    {
        public StringMessagePresenter()
        {
            Geometry = GeometryFactory.Create(Geometrys.Wait);
        }
    }
}
