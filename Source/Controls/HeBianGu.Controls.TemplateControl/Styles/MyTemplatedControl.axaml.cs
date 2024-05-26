using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;

namespace HeBianGu.Controls.TemplateControl
{
    public class MyTemplatedControl : TemplatedControl
    {
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            Button btnSearch = e.NameScope.Find<Button>("btnSearch");

            btnSearch.Click += (s, e) =>

            {

                //在内部按钮的事件中，执行外部注册的 OnSearch 事件

                //RoutedEventArgs args = new RoutedEventArgs(OnSearchEvent);

                //RaiseEvent(args);

            };
        }
    }
}
