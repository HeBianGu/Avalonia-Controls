using Android.App;
using Android.Content.PM;

using Avalonia;
using Avalonia.Android;
using Avalonia.ReactiveUI;

namespace HeBianGu.Test.Main.Android;

[Activity(
    Label = "HeBianGu.Test.Main.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity<App>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder)
            .WithInterFont()
            .UseReactiveUI();
    }
}
