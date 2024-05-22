// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control



using Avalonia.Extensions.Geometry;
using Avalonia.Modules.Messages.Notice;

namespace Avalonia.Modules.Messages.Notice
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
