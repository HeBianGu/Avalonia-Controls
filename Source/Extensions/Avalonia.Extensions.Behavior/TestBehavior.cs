using Avalonia.Controls;
using Avalonia.Xaml.Interactivity;
using System;

namespace Avalonia.Extensions.Behavior
{
    public class TestBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.TextChanged += this.AssociatedObject_TextChanged;
        }

        private void AssociatedObject_TextChanged(object? sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.TextChanged -= this.AssociatedObject_TextChanged;
        }
    }
}