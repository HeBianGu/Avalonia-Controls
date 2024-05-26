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

                //���ڲ���ť���¼��У�ִ���ⲿע��� OnSearch �¼�

                //RoutedEventArgs args = new RoutedEventArgs(OnSearchEvent);

                //RaiseEvent(args);

            };
        }
    }
}
