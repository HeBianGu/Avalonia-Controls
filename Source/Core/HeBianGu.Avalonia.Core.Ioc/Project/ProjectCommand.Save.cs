﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

namespace HeBianGu.Avalonia.Core.Ioc
{
    public class ProjectSaveCommand : IocMarkupCommandBase
    {
        public override void Execute(object parameter)
        {
            IocProject.Instance.Save(out string message);
        }
        public override bool CanExecute(object parameter)
        {
            return IocProject.Instance != null;
        }
    }

}