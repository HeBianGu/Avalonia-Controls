﻿

using Avalonia.Ioc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HeBianGu.AvaloniaUI.Modules.Operation
{
    [Display(Name = "操作日志")]
    public class hi_dd_operation : DbModelBase
    {
        [Browsable(false)]
        public string? UserID { get; set; }

        [Display(Name = "操作账号")]
        public string? UserName { get; set; }

        [Display(Name = "操作")]
        public string? Method { get; set; }

        [Display(Name = "信息")]
        public string? Title { get; set; }

        [Display(Name = "详情")]
        public string? Message { get; set; }

        [Display(Name = "类型")]
        public string? Type { get; set; }

        [Display(Name = "操作类型")]
        public OperationType OperationType { get; set; }

        [Display(Name = "结果")]
        public bool Result { get; set; }

        [Display(Name = "操作时间")]
        public DateTime Time { get; set; } = DateTime.Now;
    }
}
