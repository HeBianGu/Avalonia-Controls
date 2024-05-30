
using System;

namespace HeBianGu.AvaloniaUI.Ioc
{
    public class ShowGuideCommand : IocMarkupCommandBase
    {
        public override void Execute(object parameter)
        {
            Ioc<IGuideService>.Instance.Show();
        }
    }

}
