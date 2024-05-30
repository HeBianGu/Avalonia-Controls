// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control


using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;

namespace HeBianGu.AvaloniaUI.Setting
{
    public class ClearCacheDataCommand : MarkupCommandBase
    {
        public override void Execute(object parameter)
        {
            AppPaths.Instance.ClearCache();
        }
    }
}
