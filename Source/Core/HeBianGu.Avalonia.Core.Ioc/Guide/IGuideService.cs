using Avalonia.Controls;
using System.Windows;

namespace HeBianGu.Avalonia.Core.Ioc
{
    public interface IGuideService
    {
        void Show(Control owner = null);
    }

}
