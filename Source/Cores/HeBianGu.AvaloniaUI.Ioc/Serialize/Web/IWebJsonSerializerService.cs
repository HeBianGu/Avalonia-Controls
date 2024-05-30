﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

namespace HeBianGu.AvaloniaUI.Ioc
{
    public interface IWebJsonSerializerService
    {
        T Load<T>(string uri, out string message);
    }
}