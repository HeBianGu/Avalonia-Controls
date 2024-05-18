using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using Avalonia.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace HeBianGu.Avalonia.Extensions.Behvaiors
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