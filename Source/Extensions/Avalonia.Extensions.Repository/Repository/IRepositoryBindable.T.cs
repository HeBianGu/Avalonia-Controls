// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control
using Avalonia.Ioc;
using Avalonia.Mvvm;
using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.Extensions.Repository
{
    public interface IRepositoryBindable<TEntity> : IRepositoryBindableBase<TEntity>
     where TEntity : StringEntityBase, new()
    {
        IObservableSource<SelectBindable<TEntity>> Collection { get; set; }
    }
}
