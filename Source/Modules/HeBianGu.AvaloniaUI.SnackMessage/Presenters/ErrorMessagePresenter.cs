﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control



using HeBianGu.AvaloniaUI.Geometry;
using HeBianGu.AvaloniaUI.SnackMessage;

namespace HeBianGu.AvaloniaUI.SnackMessage
{
    public class ErrorMessagePresenter : SnackMessagePresenterBase
    {
        public ErrorMessagePresenter()
        {
            this.Geometry = GeometryFactory.Create(Geometrys.Error);
            this.Level = 4;
        }
    }
}
