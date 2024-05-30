using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml.Templates;

namespace HeBianGu.AvaloniaUI.Attach
{
    public partial class Attach
    {
        public static readonly AttachedProperty<ControlTemplate> LeftTemplateProperty =
      AvaloniaProperty.RegisterAttached<Attach, Control, ControlTemplate>("LeftTemplate");

        public static ControlTemplate GetLeftTemplate(Control element)
        {
            return element.GetValue(LeftTemplateProperty);
        }

        public static void SetLeftTemplate(Control element, ControlTemplate value)
        {
            element.SetValue(LeftTemplateProperty, value);
        }

        public static readonly AttachedProperty<ControlTemplate> RightTemplateProperty =
AvaloniaProperty.RegisterAttached<Attach, Control, ControlTemplate>("RightTemplate");

        public static ControlTemplate GetRightTemplate(Control element)
        {
            return element.GetValue(RightTemplateProperty);
        }

        public static void SetRightTemplate(Control element, ControlTemplate value)
        {
            element.SetValue(RightTemplateProperty, value);
        }

        public static readonly AttachedProperty<ControlTemplate> CenterTemplateProperty =
AvaloniaProperty.RegisterAttached<Attach, Control, ControlTemplate>("CenterTemplate");

        public static ControlTemplate GetCenterTemplate(Control element)
        {
            return element.GetValue(CenterTemplateProperty);
        }

        public static void SetCenterTemplate(Control element, ControlTemplate value)
        {
            element.SetValue(CenterTemplateProperty, value);
        }

        public static readonly AttachedProperty<ControlTemplate> TopTemplateProperty =
AvaloniaProperty.RegisterAttached<Attach, Control, ControlTemplate>("TopTemplate");

        public static ControlTemplate GetTopTemplate(Control element)
        {
            return element.GetValue(TopTemplateProperty);
        }

        public static void SetTopTemplate(Control element, ControlTemplate value)
        {
            element.SetValue(TopTemplateProperty, value);
        }

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