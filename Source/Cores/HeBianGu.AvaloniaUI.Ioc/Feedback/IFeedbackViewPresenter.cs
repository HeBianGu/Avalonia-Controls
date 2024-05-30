﻿using System.Collections.ObjectModel;

namespace HeBianGu.AvaloniaUI.Ioc
{
    public interface IFeedbackViewPresenter
    {
        string Contact { get; set; }
        string Text { get; set; }
        string Title { get; set; }
        string MailAccount { get; }
        ObservableCollection<string> Files { get; set; }
    }
}
