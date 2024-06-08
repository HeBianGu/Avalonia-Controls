using HeBianGu.AvaloniaUI.Ioc;

namespace HeBianGu.AvaloniaUI.DrawerBox
{
    public class CloseDrawerCommand : IocMarkupCommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is DrawerBox drawer)
                drawer.Close();
        }
    }
}
