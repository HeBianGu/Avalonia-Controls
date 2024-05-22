using Avalonia.Controls;
using Avalonia.Markup.Xaml.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Extensions.Attach
{
    internal class Class1
    {
        public static readonly AttachedProperty<ControlTemplate> BottomTemplateProperty =
   AvaloniaProperty.RegisterAttached<Attach, Control, ControlTemplate>("BottomTemplate");

        public static ControlTemplate GetBottomTemplate(Control element)
        {
            return element.GetValue(BottomTemplateProperty);
        }

        public static void SetBottomTemplate(Control element, ControlTemplate value)
        {
            element.SetValue(BottomTemplateProperty, value);
        }
    }
}
