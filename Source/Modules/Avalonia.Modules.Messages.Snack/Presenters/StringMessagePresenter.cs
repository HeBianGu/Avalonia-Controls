// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control



using Avalonia.Extensions.Geometry;

namespace Avalonia.Modules.Messages.Snack
{
    public class StringMessagePresenter : SnackMessagePresenterBase
    {
        public StringMessagePresenter()
        {
            Geometry = GeometryFactory.Create(Geometrys.Wait);
        }
    }
}
