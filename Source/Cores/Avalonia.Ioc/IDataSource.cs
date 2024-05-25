﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;
using System.Collections.Generic;

namespace Avalonia.Ioc
{
    public interface IDataSource<T>
    {
        IEnumerable<T> Collection { get; }
        void Add(params T[] ts);
        void Delete(params T[] ts);
        event EventHandler CollectionChanged;
    }
}