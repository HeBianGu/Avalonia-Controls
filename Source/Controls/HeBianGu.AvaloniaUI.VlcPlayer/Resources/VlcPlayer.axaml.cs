using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Interactivity;
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
    //[TemplatePart(Name = "PART_Volume")]
    public class VlcPlayer : TemplatedControl
    {
        protected override Type StyleKeyOverride => typeof(VlcPlayer);

        private readonly LibVLC _libVlc = new LibVLC();
        private MediaPlayer _mediaPlayer;
        private VideoView _videoView;
        private Slider _posiontionSlider;
        //private Slider _volumeSlider;
        public VlcPlayer()
        {
            //this._mediaPlayer = new MediaPlayer(this._libVlc);
            //this._mediaPlayer.VolumeChanged += this._mediaPlayer_VolumeChanged;
            //this._mediaPlayer.TimeChanged += this._mediaPlayer_TimeChanged;

            this.PlayCommand = new RelayCommand(l =>
        {
            if (this._mediaPlayer.IsPlaying)
                this.Pause();
            else
                this.Play();


        });

            this.Loaded += (l, k) =>
            {
                this.InitVlcPlayer();
            };

            //this.VolumeProperty.Changed += l =>
            //{
            //    string
            //};

            //var r = this.GetPropertyChangedObservable(VlcPlayer.SourceProperty).Subscribe(;
            //this.GetObservable(VlcPlayer.SourceProperty, x =>
            //{
            //    this.OnSourceChanged(x);
            //    return true;
            //});

            this.GetObservable(VlcPlayer.VolumeProperty, x =>
            {
                return true;
            });
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
                this._mediaPlayer.Volume = (int)this.Volume;
            }
        }


        //protected override void ObservablePropertyChanged(AvaloniaPropertyChangedEventArgs change)
        //{
        //    //base.ObservablePropertyChanged(change);

        //    //// 当 MyProperty 更改时发出通知
        //    //if (change.Property == MyPropertyProperty)
        //    //{
        //    //    var subject = new Subject<IObservedChange<object, object>>();
        //    //    (this.GetObservable(MyPropertyProperty) as IObservable<IObservedChange<object, object>>)
        //    //        ?.Subscribe(subject);
        //    //    subject.OnNext(change);
        //    //    subject.OnCompleted();
        //    //}
        //}

        private void _mediaPlayer_TimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                this._posiontionSlider.ValueChanged -= this.PosiontionSlider_ValueChanged;
                this._posiontionSlider.Value = e.Time;
                this._posiontionSlider.ValueChanged += this.PosiontionSlider_ValueChanged;
            });
        }

        //private void _mediaPlayer_PositionChanged(object sender, MediaPlayerPositionChangedEventArgs e)
        //{
        //    Dispatcher.UIThread.InvokeAsync(() =>
        //    {
        //        this._posiontionSlider.ValueChanged -= this.PosiontionSlider_ValueChanged;
        //        this._posiontionSlider.Value = e.Position;
        //        this._posiontionSlider.ValueChanged += this.PosiontionSlider_ValueChanged;
        //    });
        //}

        private void _mediaPlayer_VolumeChanged(object sender, MediaPlayerVolumeChangedEventArgs e)
        {
            //this._volumeSlider.Value = e.Volume;
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            this._videoView = e.NameScope.Find<VideoView>("PART_VideoView");
            //this._videoView.MediaPlayer = this._mediaPlayer;

            this._posiontionSlider = e.NameScope.Find<Slider>("PART_Position");
            this._posiontionSlider.ValueChanged += this.PosiontionSlider_ValueChanged;
            //this._volumeSlider = e.NameScope.Find<Slider>("PART_Volume");
            //this._volumeSlider.ValueChanged += this.VolumeSlider_ValueChanged;

            //this.InitVlcPlayer();
        }

        private void VolumeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

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
            AvaloniaProperty.Register<VlcPlayer, double>("Volume", 100.0, false, BindingMode.TwoWay, x =>
            {
                return true;
            }, (x, y) =>
            {
                //if (x is VlcPlayer player)

                return y;
            });

        public void InitVlcPlayer()
        {
            if (this._posiontionSlider == null)
                return;
            this._mediaPlayer?.Dispose();
            using var media = new LibVLCSharp.Shared.Media(_libVlc, new Uri(this.Source));
            this._mediaPlayer = new MediaPlayer(media);
            this._videoView.MediaPlayer = this._mediaPlayer;
            this._mediaPlayer.Play();
            this._mediaPlayer.Pause();
            //this._mediaPlayer = new MediaPlayer(this._libVlc);
            this._mediaPlayer.VolumeChanged += this._mediaPlayer_VolumeChanged;
            this._mediaPlayer.TimeChanged += this._mediaPlayer_TimeChanged;

            this._posiontionSlider.Maximum = this._mediaPlayer.Length;
            //this._volumeSlider.Value = this._mediaPlayer.Volume;
        }


        public void Play()
        {
            if (Design.IsDesignMode)
            {
                return;
            }

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


        public static readonly StyledProperty<ICommand> PlayCommandProperty =
       AvaloniaProperty.Register<VlcPlayer, ICommand>(nameof(PlayCommand));


        public ICommand PlayCommand
        {
            get { return GetValue(PlayCommandProperty); }
            set
            {
                SetValue(PlayCommandProperty, value);
            }
        }



        //public RelayCommand PlayCommand => new RelayCommand(l =>
        //{
        //    if (this._mediaPlayer.IsPlaying)
        //        this.Pause();
        //    else
        //        this.Play();
        //});


        internal void SwitchPlay()
        {
            if (this._mediaPlayer.IsPlaying)
                this.Pause();
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
