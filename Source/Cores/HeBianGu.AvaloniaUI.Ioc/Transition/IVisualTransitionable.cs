using Avalonia;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.Ioc
{
    public interface IVisualTransitionable
    {
        Task Show(Visual visual);

        Task Close(Visual visual);
    }
}
