using Avalonia;
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
            if (host.VisualTransitionable == null)
                return;
            await host.VisualTransitionable.Show(visual);
        }

        public static async Task Close(this IVisualTransitionableHost host, Visual visual)
        {
            if (host.VisualTransitionable == null)
                return;
            await host.VisualTransitionable.Close(visual);
        }
    }
}
