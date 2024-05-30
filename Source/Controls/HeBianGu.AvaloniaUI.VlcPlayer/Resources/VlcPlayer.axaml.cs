using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Interactivity;
using LibVLCSharp.Avalonia;
using LibVLCSharp.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.VlcPlayer
{
    [TemplatePart(Name = "PART_VideoView")]
    public class VlcPlayer : TemplatedControl
    {
        protected override Type StyleKeyOverride => typeof(VlcPlayer);

        private readonly LibVLC _libVlc = new LibVLC();
        private MediaPlayer _mediaPlayer;
        private VideoView _videoView;
        public VlcPlayer()
        {
            this._mediaPlayer = new MediaPlayer(this._libVlc);
        }
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            this._videoView = e.NameScope.Find<VideoView>("PART_VideoView");
            this._videoView.MediaPlayer = this._mediaPlayer;
            this.PointerPressed += this.VideoView_PointerPressed;

            this.AddHandler(VlcPlayer.PointerPressedEvent, VideoView_PointerPressed, RoutingStrategies.Bubble, true);
        }

        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly StyledProperty<string> SourceProperty =
            AvaloniaProperty.Register<VlcPlayer, string>("Source", "C:\\Users\\LENOVO\\Videos\\2024-05-28-17-18-54.mp4", false, BindingMode.Default, x =>
            {
                return true;
            }, (x, y) =>
            {

                return y;
            });

        private void VideoView_PointerPressed(object sender, global::Avalonia.Input.PointerPressedEventArgs e)
        {
            if (this._mediaPlayer.IsPlaying)
                this.Pause();
            else
                this.Play();
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
                using var media = new LibVLCSharp.Shared.Media(_libVlc, new Uri(source));
                this._mediaPlayer.Play(media);
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

    }
}
