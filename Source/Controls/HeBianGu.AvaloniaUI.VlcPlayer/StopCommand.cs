using HeBianGu.AvaloniaUI.Mvvm;
using LibVLCSharp.Shared;

namespace HeBianGu.AvaloniaUI.VlcPlayer
{
    public class StopCommand : MarkupCommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is IVlcPlayer player)
            {
                player.Stop();
            }
        }

        //public override bool CanExecute(object parameter)
        //{
        //    if (parameter is VlcPlayer player)
        //    {
        //        return player.State != VLCState.Stopped;
        //    }
        //    return false;
        //}
    }

}
