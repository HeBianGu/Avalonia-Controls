
using System;

namespace HeBianGu.Avalonia.Core.Ioc
{
    public class ShowGuideCommand : IocMarkupCommandBase
    {
        public override void Execute(object parameter)
        {
            Ioc<IGuideService>.Instance.Show();
        }
    }

}
