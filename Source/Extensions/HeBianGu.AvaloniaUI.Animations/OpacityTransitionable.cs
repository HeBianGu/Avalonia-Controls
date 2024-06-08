// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia;
using Avalonia.Animation;
using Avalonia.Styling;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.Animations
{
    public class OpacityTransitionable : TransitionableBase
    {
        public OpacityTransitionable()
        {
            this.From = 0;
            this.To = 0;
        }
        public override async Task Show(Visual visual)
        {
            var animation = new Animation
            {
                FillMode = FillMode.Forward,
                Children =
                {
                    new KeyFrame
                    {
                        Setters =
                        {
                            new Setter
                            {
                                Property = Visual.OpacityProperty,
                                Value = this.From
                            }
                        },
                        Cue = new Cue(0d)
                    },
                    new KeyFrame
                    {
                        Setters =
                        {
                            new Setter
                            {
                                Property = Visual.OpacityProperty,
                                Value = 1.0d
                            }
                        },
                        Cue = new Cue(1d)
                    }
                },
                Duration = this.ShowDuration
            };
            await animation.RunAsync(visual);
        }
        public override async Task Close(Visual visual)
        {
            var animation = new Animation
            {
                FillMode = FillMode.Forward,
                Children =
                {
                    new KeyFrame
                    {
                        Setters =
                        {
                            new Setter
                            {
                                Property = Visual.OpacityProperty,
                                Value = 1.0d
                            }
                        },
                        Cue = new Cue(0d)
                    },
                    new KeyFrame
                    {
                        Setters =
                        {
                            new Setter
                            {
                                Property = Visual.OpacityProperty,
                                Value = this.To
                            }
                        },
                        Cue = new Cue(1d)
                    }
                },
                Duration = this.CloseDuration
            };
            await animation.RunAsync(visual);
        }
    }
}
