using Avalonia;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.Ioc
{
    public interface IVisualTransitionableHost
    {
        public IVisualTransitionable VisualTransitionable { get; set; }
    }

    public static class VisualTransitionableHostExtensions
    {

        public static async Task Show(this IVisualTransitionableHost host, Visual visual)
        {
            visual.IsVisible = true;
            if (host.VisualTransitionable == null)
                return;
            if (visual is Control control)
            {
                var disposable = new IsHitTestVisibleDisposable(control);
                await host.VisualTransitionable.Show(visual);
                disposable.Dispose();
            }
            else
            {
                await host.VisualTransitionable.Show(visual);
            }
        }

        public static async Task Close(this IVisualTransitionableHost host, Visual visual)
        {
            if (host.VisualTransitionable == null)
                return;
            if (visual is Control control)
            {
                var disposable = new IsHitTestVisibleDisposable(control);
                await host.VisualTransitionable.Close(visual);
                disposable.Dispose();
            }
            else
            {
                await host.VisualTransitionable.Close(visual);
            }
            visual.IsVisible= false;
        }
    }

    public class IsHitTestVisibleDisposable : IDisposable
    {
        private bool _temp;
        Control _control;
        public IsHitTestVisibleDisposable(Control control)
        {
            _control = control;
            _temp = _control.IsHitTestVisible;
            _control.IsHitTestVisible = false;
        }
        public void Dispose()
        {
            _control.IsHitTestVisible = _temp;
        }
    }
}
