using HeBianGu.AvaloniaUI.Extension;
using HeBianGu.AvaloniaUI.Mvvm;

namespace HeBianGu.AvaloniaUI.VlcPlayer
{
    public class OpenFilePlayerCommand : MarkupCommandBase
    {
        public override async void Execute(object parameter)
        {
            if (parameter is VlcPlayer player)
            {
                var r = await player.OpenFilePickerAsync();
                if (r == null)
                    return;
                player.Source = r;
            }
        }
    }
}
