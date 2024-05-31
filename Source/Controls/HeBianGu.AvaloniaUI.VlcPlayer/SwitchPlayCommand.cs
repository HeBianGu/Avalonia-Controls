using HeBianGu.AvaloniaUI.Mvvm;
using LibVLCSharp.Shared;
using System.Xml.Linq;
using System;

namespace HeBianGu.AvaloniaUI.VlcPlayer
{
    public class SwitchPlayCommand : MarkupCommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is VlcPlayer player)
            {
                player.SwitchPlay();
            }
        }

        //public override bool CanExecute(object parameter)
        //{
        //    if (parameter is VlcPlayer player)
        //    {
        //        return player.MediaPlayer.CanPause || player.MediaPlayer.WillPlay;
        //        //return player.State == VLCState.Playing || player.State == VLCState.Paused || player.State == VLCState.Ended || player.State == VLCState.Stopped || player.State == VLCState.NothingSpecial;
        //    }
        //    return false;
        //}
    }
}
