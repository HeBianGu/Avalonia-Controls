using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Threading;
using HeBianGu.AvaloniaUI.Mvvm;
using LibVLCSharp.Avalonia;
using LibVLCSharp.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HeBianGu.AvaloniaUI.VlcPlayer
{
    [TemplatePart(Name = "PART_VideoView")]
    [TemplatePart(Name = "PART_Position")]
    [TemplatePart(Name = "PART_Message")]
    public class VlcPlayer : TemplatedControl
    {
        protected override Type StyleKeyOverride => typeof(VlcPlayer);

        private readonly LibVLC _libVlc = new LibVLC();
        private MediaPlayer _mediaPlayer;
        private VideoView _videoView;
        private Slider _posiontionSlider;
        private ContentControl _message;
        public VlcPlayer()
        {
            this.Loaded += (l, k) =>
            {
                this.InitVlcPlayer();
            };
        }


        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);

            if (change.Property == SourceProperty)
            {
                this.OnSourceChanged(change.NewValue?.ToString());
            }
            if (change.Property == VolumeProperty)
            {
                if (this._mediaPlayer != null)
                {
                    if (this.Volume < 0)
                        return;
                    this._mediaPlayer.VolumeChanged -= MediaPlayer_VolumeChanged;
                    this._mediaPlayer.Volume = (int)this.Volume;
                    this._mediaPlayer.VolumeChanged += MediaPlayer_VolumeChanged;
                }
            }
        }

        private void MediaPlayer_TimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                this._posiontionSlider.ValueChanged -= this.PosiontionSlider_ValueChanged;
                this._posiontionSlider.Value = e.Time;
                this._posiontionSlider.ValueChanged += this.PosiontionSlider_ValueChanged;
            });
        }

        private void MediaPlayer_VolumeChanged(object sender, MediaPlayerVolumeChangedEventArgs e)
        {
            if (this._mediaPlayer.Media.State == VLCState.Stopped)
                return;
            if (this._mediaPlayer.Volume < 0)
                return;
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                this.Volume = this._mediaPlayer.Volume;
            });
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            this._videoView = e.NameScope.Find<VideoView>("PART_VideoView");

            this._posiontionSlider = e.NameScope.Find<Slider>("PART_Position");
            this._posiontionSlider.ValueChanged += this.PosiontionSlider_ValueChanged;
            this._posiontionSlider.Loaded += (l, k) =>
            {
                this.InitVlcPlayer();
            };
            this._message = e.NameScope.Find<ContentControl>("PART_Message");
            this.PointerPressed += this.VlcPlayer_PointerPressed;
        }

        private void VlcPlayer_PointerPressed(object sender, PointerPressedEventArgs e)
        {
            this.SwitchPlay();
        }

        private void PosiontionSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            this._mediaPlayer.Time = (long)e.NewValue;

        }

        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly StyledProperty<string> SourceProperty =
            AvaloniaProperty.Register<VlcPlayer, string>("Source");

        public static readonly RoutedEvent<RoutedEventArgs> SourceChangedEvent = RoutedEvent.Register<VlcPlayer, RoutedEventArgs>(nameof(SourceChanged), RoutingStrategies.Bubble);

        public event EventHandler<RoutedEventArgs> SourceChanged
        {
            add => AddHandler(SourceChangedEvent, value);
            remove => RemoveHandler(SourceChangedEvent, value);
        }

        private bool CanPlay()
        {
            return !string.IsNullOrEmpty(this.Source);
        }

        protected void OnSourceChanged(string source)
        {
            if (!this.CanPlay())
                return;

            this.InitVlcPlayer();
            RoutedEventArgs args = new RoutedEventArgs(SourceChangedEvent, this);
            this.RaiseEvent(args);
        }

        public double Volume
        {
            get { return (double)GetValue(VolumeProperty); }
            set { SetValue(VolumeProperty, value); }
        }

        public static readonly StyledProperty<double> VolumeProperty =
            AvaloniaProperty.Register<VlcPlayer, double>("Volume", 100.0);

        public VLCState State
        {
            get { return (VLCState)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly StyledProperty<VLCState> StateProperty =
            AvaloniaProperty.Register<VlcPlayer, VLCState>("State");

        private void InitVlcPlayer()
        {
            if (this._posiontionSlider == null)
                return;
            if (this._posiontionSlider.IsLoaded == false)
                return;
            if (this._mediaPlayer != null)
            {
                this._mediaPlayer.VolumeChanged -= this.MediaPlayer_VolumeChanged;
                this._mediaPlayer.TimeChanged -= this.MediaPlayer_TimeChanged;
                this._mediaPlayer.Dispose();
            }
            using var media = new LibVLCSharp.Shared.Media(_libVlc, new Uri(this.Source));
            this._mediaPlayer = new MediaPlayer(media);
            this._videoView.MediaPlayer = this._mediaPlayer;
            this._mediaPlayer.Media.StateChanged += this.Media_StateChanged;
            this._mediaPlayer.VolumeChanged += this.MediaPlayer_VolumeChanged;
            this._mediaPlayer.TimeChanged += this.MediaPlayer_TimeChanged;
            this._mediaPlayer.Play();
            this._mediaPlayer.Pause();
            Dispatcher.UIThread.InvokeAsync(() =>
                {
                    this._posiontionSlider.Maximum = this._mediaPlayer.Length;
                    this.Volume = this._mediaPlayer.Volume;
                }, DispatcherPriority.Input);
        }

        private void Media_StateChanged(object sender, MediaStateChangedEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                this.State = e.State;

                if (this.State == VLCState.Paused)
                {
                    StreamGeometry streamGeometry = new StreamGeometry();
                    var play = new PathIcon()
                    {
                        Data = StreamGeometry.Parse("M13.7501344,8.41212026 L38.1671892,21.1169293 C39.7594652,21.9454306 40.3786269,23.9078584 39.5501255,25.5001344 C39.2420737,26.0921715 38.7592263,26.5750189 38.1671892,26.8830707 L13.7501344,39.5878797 C12.1578584,40.4163811 10.1954306,39.7972194 9.36692926,38.2049434 C9.12586301,37.7416442 9,37.2270724 9,36.704809 L9,11.295191 C9,9.50026556 10.4550746,8.045191 12.25,8.045191 C12.6976544,8.045191 13.1396577,8.13766178 13.5485655,8.31589049 L13.7501344,8.41212026 Z M12.5961849,10.629867 L12.4856981,10.5831892 C12.4099075,10.5581 12.3303482,10.545191 12.25,10.545191 C11.8357864,10.545191 11.5,10.8809774 11.5,11.295191 L11.5,36.704809 C11.5,36.8253313 11.5290453,36.9440787 11.584676,37.0509939 C11.7758686,37.4184422 12.2287365,37.5613256 12.5961849,37.370133 L37.0132397,24.665324 C37.1498636,24.5942351 37.2612899,24.4828088 37.3323788,24.3461849 C37.5235714,23.9787365 37.380688,23.5258686 37.0132397,23.334676 L12.5961849,10.629867 Z"),
                        Height = 100,
                        Width = 100,
                        Foreground = Brushes.Gray
                    };
                    this._message.Content = play;
                }
                else
                {
                    this._message.Content = null;
                }
            });

        }

        private void _mediaPlayer_Stopped(object sender, EventArgs e)
        {
            this.Stop();
        }

        public void Play()
        {
            if (Design.IsDesignMode)
                return;
            string source = this.Source;
            Task.Run(() =>
            {
                this._mediaPlayer.Play();
            });
        }

        public void Stop()
        {
            this._mediaPlayer.Stop();
        }

        public void Pause()
        {
            this._mediaPlayer.Pause();
        }

        public void Dispose()
        {
            this._mediaPlayer?.Dispose();
            this._libVlc?.Dispose();
        }

        internal void SwitchPlay()
        {
            if (this._mediaPlayer.IsPlaying)
            {
                this.Pause();
            }
            else if (this._mediaPlayer.Media.State == VLCState.Ended)
            {
                this.Stop();
                this.Play();
            }
            else
                this.Play();
        }

    }

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
        //        return string.IsNullOrEmpty(player.Source);
        //    return false;
        //}
    }
}
