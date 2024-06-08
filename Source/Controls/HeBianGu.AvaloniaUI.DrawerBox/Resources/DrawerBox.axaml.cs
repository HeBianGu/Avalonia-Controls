using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using HeBianGu.AvaloniaUI.Animations;
using HeBianGu.AvaloniaUI.Ioc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.DrawerBox
{
    [TemplatePart(Name = "PART_DrawerTemplate")]
    [TemplatePart(Name = "PART_ToggleTemplate")]
    public class DrawerBox : TemplatedControl, IVisualTransitionableHost
    {
        protected override Type StyleKeyOverride => typeof(DrawerBox);

        private TemplatedControl _drawer;
        private TemplatedControl _toggle;
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            this._drawer = e.NameScope.Find<TemplatedControl>("PART_DrawerTemplate");
            this._toggle = e.NameScope.Find<TemplatedControl>("PART_ToggleTemplate");
            this.Show();
        }

        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }
        public static readonly StyledProperty<bool> IsExpandedProperty = AvaloniaProperty.Register<DrawerBox, bool>("IsExpanded");

        public ControlTemplate ToggleTemplate
        {
            get { return (ControlTemplate)GetValue(ToggleTemplateProperty); }
            set { SetValue(ToggleTemplateProperty, value); }
        }
        public static readonly StyledProperty<ControlTemplate> ToggleTemplateProperty = AvaloniaProperty.Register<DrawerBox, ControlTemplate>("ToggleTemplate");

        public ControlTemplate DrawerTemplate
        {
            get { return (ControlTemplate)GetValue(DrawerTemplateProperty); }
            set { SetValue(DrawerTemplateProperty, value); }
        }

        public IVisualTransitionable VisualTransitionable { get; set; } = new OpacityTransitionable();

        public static readonly StyledProperty<ControlTemplate> DrawerTemplateProperty = AvaloniaProperty.Register<DrawerBox, ControlTemplate>("DrawerTemplate");


        public async void Show()
        {
            await this.Show(this._drawer);
            await this.Close(this._toggle);
            this.IsExpanded = true;
        }

        public async void Close()
        {
            await this.Show(this._toggle);
            await this.Close(this._drawer);
            this.IsExpanded = false;
        }
    }
}
