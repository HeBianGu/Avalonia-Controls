﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

//using H.Extensions.Geometry;

using Avalonia.Extensions.Geometry;

namespace Avalonia.Modules.Messages.Notice
{
    public class WarnMessagePresenter : MessagePresenterBase
    {
        public WarnMessagePresenter()
        {
            Geometry = GeometryFactory.Create("M947.2 810.666667L571.733333 128C554.666667 100.266667 533.333333 85.333333 509.866667 85.333333c-23.466667 0-44.8 14.933333-59.733334 42.666667L74.666667 810.666667c-14.933333 25.6-14.933333 53.333333-4.266667 74.666666 12.8 21.333333 36.266667 32 66.133333 32h746.666667c29.866667 0 53.333333-12.8 66.133333-32 12.8-21.333333 12.8-49.066667-2.133333-74.666666z m-34.133333 51.2c-4.266667 6.4-14.933333 10.666667-29.866667 10.666666h-746.666667c-14.933333 0-25.6-4.266667-29.866666-10.666666-4.266667-6.4-2.133333-19.2 4.266666-32l375.466667-682.666667c8.533333-12.8 17.066667-19.2 23.466667-19.2 6.4 0 14.933333 6.4 23.466666 19.2l375.466667 682.666667c8.533333 12.8 8.533333 25.6 4.266667 32z M512 640c12.8 0 21.333333-8.533333 21.333333-21.333333V322.133333c0-12.8-8.533333-21.333333-21.333333-21.333333s-21.333333 8.533333-21.333333 21.333333V618.666667c0 10.666667 10.666667 21.333333 21.333333 21.333333z M509.866667 744.533333m-42.666667 0a42.666667 42.666667 0 1 0 85.333333 0 42.666667 42.666667 0 1 0-85.333333 0Z");
            Level = 3;
        }
    }
}
