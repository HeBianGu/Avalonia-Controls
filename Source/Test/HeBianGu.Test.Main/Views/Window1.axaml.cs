using Avalonia.Controls;
using System;

namespace HeBianGu.Test.Main.Views
{
    //ReactiveWindow<MainViewModel>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        public event Action Logined;
    }
}
