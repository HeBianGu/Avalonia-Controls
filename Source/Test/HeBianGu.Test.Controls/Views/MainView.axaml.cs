using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Styling;
using Avalonia.VisualTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HeBianGu.Test.Controls.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        animals.ItemsSource = new string[]
              {"cat", "camel", "cow", "chameleon", "mouse", "lion", "zebra" }
          .OrderBy(x => x);
    }
    public void Next(object source, RoutedEventArgs args)
    {
        slides.Next();
    }
    public void Previous(object source, RoutedEventArgs args)
    {
        slides.Previous();
    }
}

public class CustomTransition : IPageTransition
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomTransition"/> class.
    /// </summary>
    public CustomTransition()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomTransition"/> class.
    /// </summary>
    /// <param name="duration">The duration of the animation.</param>
    public CustomTransition(TimeSpan duration)
    {
        Duration = duration;
    }

    /// <summary>
    /// Gets the duration of the animation.
    /// </summary>
    public TimeSpan Duration { get; set; }

    public async Task Start(Visual? from, Visual? to, bool forward, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }

        var tasks = new List<Task>();
        var parent = GetVisualParent(from, to);
        var scaleProperty = ScaleTransform.ScaleYProperty;

        if (from != null)
        {
            var animation = new Animation
            {
                Children =
                    {
                        new KeyFrame
                        {
                            Setters = { new Setter { Property = scaleProperty, Value = 1d } },
                            Cue = new Cue(0d)
                        },
                        new KeyFrame
                        {
                            Setters =
                            {
                                new Setter
                                {
                                    Property = scaleProperty,
                                    Value = 0d
                                }
                            },
                            Cue = new Cue(1d)
                        }
                    },
                Duration = Duration
            };
            tasks.Add(animation.RunAsync(from, cancellationToken));
        }

        if (to != null)
        {
            to.IsVisible = true;
            var animation = new Animation
            {
                Children =
                    {
                        new KeyFrame
                        {
                            Setters =
                            {
                                new Setter
                                {
                                    Property = scaleProperty,
                                    Value = 0d
                                }
                            },
                            Cue = new Cue(0d)
                        },
                        new KeyFrame
                        {
                            Setters = { new Setter { Property = scaleProperty, Value = 1d } },
                            Cue = new Cue(1d)
                        }
                    },
                Duration = Duration
            };
            tasks.Add(animation.RunAsync(to, cancellationToken));
        }

        await Task.WhenAll(tasks);

        if (from != null && !cancellationToken.IsCancellationRequested)
        {
            from.IsVisible = false;
        }
    }

    /// <summary>
    /// Gets the common visual parent of the two control.
    /// </summary>
    /// <param name="from">The from control.</param>
    /// <param name="to">The to control.</param>
    /// <returns>The common parent.</returns>
    /// <exception cref="ArgumentException">
    /// The two controls do not share a common parent.
    /// </exception>
    /// <remarks>
    /// Any one of the parameters may be null, but not both.
    /// </remarks>
    private static Visual GetVisualParent(Visual? from, Visual? to)
    {
        var p1 = (from ?? to)!.GetVisualParent();
        var p2 = (to ?? from)!.GetVisualParent();

        if (p1 != null && p2 != null && p1 != p2)
        {
            throw new ArgumentException("Controls for PageSlide must have same parent.");
        }

        return p1 ?? throw new InvalidOperationException("Cannot determine visual parent.");
    }
}
