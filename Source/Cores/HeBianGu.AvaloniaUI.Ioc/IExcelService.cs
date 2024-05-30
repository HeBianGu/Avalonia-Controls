﻿using System;
using System.Collections.Generic;

namespace HeBianGu.AvaloniaUI.Ioc
{
    public interface IExcelService
    {
        bool Export(IEnumerable<object> collection, string path, string sheetName, out string message);
        IEnumerable<T> Read<T>(string filePath, Func<object, T> convert, out string message);
    }
}
