﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;
using System.Threading;

namespace HeBianGu.AvaloniaUI.Ioc
{
    public class ShowStringCommand : MessageCommandBase
    {
        public string Format { get; set; } = "正在加载数据第{0}/100条";
        public override void Execute(object parameter)
        {
            Func<ICancelable, IStringPresenter, bool> func = (c, p) =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    if (c.IsCancel)
                        break;
                    p.Value = string.Format(Format, i);
                    Thread.Sleep(20);
                }
                p.Value = c.IsCancel ? "取消操作" : "加载完成";
                Thread.Sleep(1000);
                return true;
            };
            IocMessage.Dialog.ShowString(func);
        }
    }
}
