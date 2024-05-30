using Avalonia.Controls;
using System.Windows;

namespace HeBianGu.AvaloniaUI.Ioc
{
    public interface IGuideService
    {
        void Show(Control owner = null);
    }

}
