using System;

namespace HeBianGu.Avalonia.Core.Ioc
{
    public abstract class GuidEntityBase : EntityBase<Guid>
    {
        public GuidEntityBase()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
