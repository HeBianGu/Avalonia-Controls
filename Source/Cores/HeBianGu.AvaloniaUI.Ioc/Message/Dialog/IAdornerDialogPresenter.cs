// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Controls;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.Ioc
{
    public interface IAdornerDialogPresenter : IDialog, IPresenter
    {
        object Presenter { get; set; }

        void Cancel();
        Task<bool?> ShowDialog(Window owner = null);
    }

}
