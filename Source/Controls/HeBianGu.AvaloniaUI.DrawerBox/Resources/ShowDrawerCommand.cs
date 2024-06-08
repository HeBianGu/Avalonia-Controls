using HeBianGu.AvaloniaUI.Ioc;

namespace HeBianGu.AvaloniaUI.DrawerBox
{
    public class ShowDrawerCommand : IocMarkupCommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is DrawerBox drawer)
                drawer.Show();
        }
    }
}
