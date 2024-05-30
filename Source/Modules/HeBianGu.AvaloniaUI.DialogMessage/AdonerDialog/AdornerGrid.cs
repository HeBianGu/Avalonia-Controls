using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Threading;
using HeBianGu.AvaloniaUI.Application;
using System.Linq;

namespace HeBianGu.AvaloniaUI.DialogMessage
{
    public class AdornerGrid : Grid
    {
        //public AdornerGrid()
        //{
        //    this.Background = Brushes.Orange;
        //}
        public static void AddPresenter(object presenter)
        {
            var visual = Avalonia.Application.Current.GetMainAdornerControl();
            if (visual == null)
                return;
            var control = AdornerLayer.GetAdorner(visual);
            if (control is AdornerGrid grid)
            {
                ContentPresenter contentPresenter = grid.ToContentPresenter(presenter);
                grid.Children.Add(contentPresenter);
            }
            else
            {
                AdornerGrid adornerGrid = new AdornerGrid();
                ContentPresenter contentPresenter = adornerGrid.ToContentPresenter(presenter);
                adornerGrid.Children.Add(contentPresenter);
                AdornerLayer.SetAdorner(visual, adornerGrid);
            }
        }

        private ContentPresenter ToContentPresenter(object presenter)
        {
            ContentPresenter contentPresenter = new ContentPresenter();
            contentPresenter.Content = presenter;
            contentPresenter.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch;
            contentPresenter.VerticalAlignment = VerticalAlignment.Stretch;
            return contentPresenter;
        }

        public static void RemovePresenter(object presenter)
        {
            Dispatcher.UIThread.Invoke(() =>
            {
                var visual =Avalonia. Application.Current.GetMainAdornerControl();
                if (visual == null)
                    return;
                var control = AdornerLayer.GetAdorner(visual);
                if (control is AdornerGrid grid)
                {
                    var finds = grid.Children.OfType<ContentPresenter>().Where(x => x.Content == presenter).ToList();
                    grid.Children.RemoveAll(finds);
                    if (grid.Children.Count == 0)
                        AdornerLayer.SetAdorner(visual, null);
                }
            });
        }

        public static bool HasPresenter(object presenter)
        {
            var visual = Avalonia.Application.Current.GetMainAdornerControl();
            if (visual == null)
                return false;
            var control = AdornerLayer.GetAdorner(visual);
            if (control is AdornerGrid grid)
            {
                return grid.Children.OfType<ContentPresenter>().Any(x => x.Content == presenter);
            }
            return false;
        }
    }
}
