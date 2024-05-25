using Avalonia.Controls;
using System.Windows;

namespace Avalonia.Ioc
{
    public interface IGuideService
    {
        void Show(Control owner = null);
    }

}
