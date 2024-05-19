// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Media;
using System.Reflection;

namespace HeBianGu.Avalonia.Controls.Form
{
    public class ColorPropertyItem : ObjectPropertyItem<Color>
    {
        public ColorPropertyItem(PropertyInfo property, object obj) : base(property, obj)
        {
        }
    }
}
