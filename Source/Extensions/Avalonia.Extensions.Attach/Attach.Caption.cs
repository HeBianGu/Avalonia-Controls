using Avalonia.Controls;
using Avalonia.Markup.Xaml.Templates;

namespace Avalonia.Extensions.Attach
{
    public partial class Attach
    {
        public static readonly AttachedProperty<ControlTemplate> HeaderLeftTemplateProperty =
      AvaloniaProperty.RegisterAttached<Attach, Control, ControlTemplate>("HeaderLeftTemplate");

        public static ControlTemplate GetHeaderLeftTemplate(Control element)
        {
            return element.GetValue(HeaderLeftTemplateProperty);
        }

        public static void SetHeaderLeftTemplate(Control element, ControlTemplate value)
        {
            element.SetValue(HeaderLeftTemplateProperty, value);
        }

        public static readonly AttachedProperty<ControlTemplate> HeaderRightTemplateProperty =
AvaloniaProperty.RegisterAttached<Attach, Control, ControlTemplate>("HeaderRightTemplate");

        public static ControlTemplate GetHeaderRightTemplate(Control element)
        {
            return element.GetValue(HeaderRightTemplateProperty);
        }

        public static void SetHeaderRightTemplate(Control element, ControlTemplate value)
        {
            element.SetValue(HeaderRightTemplateProperty, value);
        }

        public static readonly AttachedProperty<ControlTemplate> HeaderCenterTemplateProperty =
AvaloniaProperty.RegisterAttached<Attach, Control, ControlTemplate>("HeaderCenterTemplate");

        public static ControlTemplate GetHeaderCenterTemplate(Control element)
        {
            return element.GetValue(HeaderCenterTemplateProperty);
        }

        public static void SetHeaderCenterTemplate(Control element, ControlTemplate value)
        {
            element.SetValue(HeaderCenterTemplateProperty, value);
        }
    }

}