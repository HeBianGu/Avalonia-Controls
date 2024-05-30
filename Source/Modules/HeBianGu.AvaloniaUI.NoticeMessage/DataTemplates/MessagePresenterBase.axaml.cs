// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control


using Avalonia.Media;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;
using System;

namespace HeBianGu.AvaloniaUI.NoticeMessage
{
    public abstract class MessagePresenterBase : BindableBase, INoticeItem
    {
        public string Time { get; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        public Avalonia.Media.Geometry Geometry { get; set; }
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                RaisePropertyChanged();
            }
        }
        public int Level { get; set; }

        private Brush _iconBrush;
        public Brush IconBrush
        {
            get { return _iconBrush; }
            set
            {
                _iconBrush = value;
                RaisePropertyChanged();
            }
        }
    }
}
