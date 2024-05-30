// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Controls;
using Avalonia.LogicalTree;
using Avalonia.VisualTree;
using System.Collections;
using System.Linq;

namespace HeBianGu.AvaloniaUI.Command
{
    public class DeleteItemCommand : MarkupCommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is Control control && control.DataContext != null)
            {
                var items = control.GetVisualAncestors().OfType<ItemsControl>()?.FirstOrDefault();
                if (items == null)
                    return;
                if (items.ItemsSource is IList list)
                {
                    list.Remove(control.DataContext);
                }
            }
        }
    }
}
