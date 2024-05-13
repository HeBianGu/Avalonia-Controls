using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace HeBianGu.Controls.TemplateControl
{
    public class MyButton : Button
    {
        // `MyButton` will be styled as a standard `Button` control.
        protected override Type StyleKeyOverride => typeof(Button);
    }
}
