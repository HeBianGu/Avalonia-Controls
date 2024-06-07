// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia;
using Avalonia.Animation;
using Avalonia.Media;
using Avalonia.Styling;
using System;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.Animations
{
    public static class AnimationExtension
    {
        public static async Task BeginScaleTest(this Visual visual, Action<Visual> complated = null)
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
                                Value = 0.7d
                            } ,
                            new Setter
                            {
                                Property = ScaleTransform.ScaleXProperty,
                                Value = 0.7d
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
                                Value = 1d
                            },
                                  new Setter
                            {
                                Property = ScaleTransform.ScaleXProperty,
                                Value = 1d
                            }
                        },
                        Cue = new Cue(1d)
                    }
                },
                Duration = TimeSpan.FromMilliseconds(100)
            };

            await animation.RunAsync(visual);
            complated?.Invoke(visual);
        }

        public static async Task EndScaleTest(this Visual visual, Action<Visual> complated = null)
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
                                Value = 1d
                            } ,
                            new Setter
                            {
                                Property = ScaleTransform.ScaleXProperty,
                                Value = 1d
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
                                Value = 0.5d
                            },
                                  new Setter
                            {
                                Property = ScaleTransform.ScaleXProperty,
                                Value = 0.5d
                            }
                        },
                        Cue = new Cue(1d)
                    }
                },
                Duration = TimeSpan.FromMilliseconds(100)
            };

            await animation.RunAsync(visual);
            complated?.Invoke(visual);
        }

    }
}
