using Avalonia.Controls;
using LibVLCSharp.Shared;
using System;

namespace Avalonia.Test.ThirdNuget.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    private readonly LibVLC _libVlc = new LibVLC();

    public MediaPlayer MediaPlayer { get; }

    public MainViewModel()
    {
        MediaPlayer = new MediaPlayer(_libVlc);
    }

    public void Play()
    {
        if (Design.IsDesignMode)
        {
            return;
        }

        ////using var media = new LibVLCSharp.Shared.Media(_libVlc, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"));
        ////MediaPlayer.Play(media);
    }

    public void Stop()
    {
        MediaPlayer.Stop();
    }

    public void Dispose()
    {
        MediaPlayer?.Dispose();
        _libVlc?.Dispose();
    }

}
