// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control


using Avalonia.Extensions.Geometry;
using Avalonia.Modules.Messages.Snack;

namespace Avalonia.Modules.Messages.Snack
{
    public class FatalMessagePresenter : SnackMessagePresenterBase
    {
        public FatalMessagePresenter()
        {
            Geometry = GeometryFactory.Create(Geometrys.Fatal);
            Level = 5;
        }
    }
}
