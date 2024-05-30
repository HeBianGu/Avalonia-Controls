﻿using System;

namespace HeBianGu.AvaloniaUI.Ioc
{
    /// <summary>
    /// 定义默认主键类型为Guid的实体基类
    /// </summary>
    public abstract class StringEntityBase : EntityBase<string>
    {
        public StringEntityBase()
        {
            this.ID = Guid.NewGuid().ToString();
        }
    }
}
