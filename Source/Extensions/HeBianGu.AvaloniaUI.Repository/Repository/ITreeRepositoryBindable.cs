// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control


using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;

namespace HeBianGu.AvaloniaUI.Repository
{
    public interface ITreeRepositoryBindable<TEntity> : IRepositoryBindableBase<TEntity> where TEntity : StringEntityBase, new()
    {
        IObservableSource<TreeNodeBase<TEntity>> Collection { get; set; }
        TreeNodeBase<TEntity> SelectedTreeItem { get; set; }
    }
}
