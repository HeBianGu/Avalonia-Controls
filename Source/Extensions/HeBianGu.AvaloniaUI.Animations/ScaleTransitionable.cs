// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia;
using Avalonia.Animation;
using Avalonia.Media;
using Avalonia.Styling;
using System;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.Animations
{
    public class ScaleTransitionable : TransitionableBase
    {
        public ScaleTransitionable()
        {
            this.From = 0.5;
            this.To = 0.8;
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
                                Property = ScaleTransform.ScaleYProperty,
                                Value = this.From
                            } ,
                            new Setter
                            {
                                Property = ScaleTransform.ScaleXProperty,
                                Value =this.From
                            }
                            ,
                            new Setter
                            {
                                Property = Visual.OpacityProperty,
                                Value =1d
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
                                Property = ScaleTransform.ScaleYProperty,
                                Value = 1.0d
                            },
                                  new Setter
                            {
                                Property = ScaleTransform.ScaleXProperty,
                                Value =  1.0d
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
                                Property = ScaleTransform.ScaleYProperty,
                                Value =  1.0d
                            } ,
                            new Setter
                            {
                                Property = ScaleTransform.ScaleXProperty,
                                Value =  1.0d
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
                                Property = ScaleTransform.ScaleYProperty,
                                Value = this.To
                            },
                                  new Setter
                            {
                                Property = ScaleTransform.ScaleXProperty,
                                Value =this.To
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
