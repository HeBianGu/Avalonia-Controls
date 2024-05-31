using HeBianGu.AvaloniaUI.Mvvm;
using LibVLCSharp.Shared;

namespace HeBianGu.AvaloniaUI.VlcPlayer
{
    public class AddFrameCommand : MarkupCommandBase
    {
        public int Frame { get; set; } = 10 * 1000;
        public override void Execute(object parameter)
        {
            if (parameter is IVlcPlayer player)
            {
                player.AddFrame(this.Frame);
            }
        }

        //public override bool CanExecute(object parameter)
        //{
        //    if (parameter is VlcPlayer player)
        //    {
        //        return player.State == VLCState.Playing || player.State == VLCState.Paused;
        //    }
        //    return false;
        //}
    }

}
