﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control


using HeBianGu.AvaloniaUI.Geometry;
using HeBianGu.AvaloniaUI.SnackMessage;

namespace HeBianGu.AvaloniaUI.SnackMessage
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
