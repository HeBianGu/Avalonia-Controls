using HeBianGu.AvaloniaUI.Mvvm;
using LibVLCSharp.Shared;
using System;
using System.IO;

namespace HeBianGu.AvaloniaUI.VlcPlayer
{
    public class TakeSnapshotCommand : MarkupCommandBase
    {
        public override async void Execute(object parameter)
        {
            if (parameter is IVlcPlayer player)
            {

                var r = await player.TakeSnapshot();
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
