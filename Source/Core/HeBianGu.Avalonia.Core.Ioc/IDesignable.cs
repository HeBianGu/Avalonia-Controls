﻿namespace HeBianGu.Avalonia.Core.Ioc
{
    public interface IDesignable : ILayoutable
    {
        int Column { get; set; }
        int ColumnSpan { get; set; }
        bool IsMouseOver { get; set; }
        bool IsSelected { get; set; }
        bool IsVisible { get; set; }
        int Row { get; set; }
        int RowSpan { get; set; }
        object Clone();
    }
}
