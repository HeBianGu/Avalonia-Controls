using System;

namespace HeBianGu.AvaloniaUI.Ioc
{
    public abstract class GuidEntityBase : EntityBase<Guid>
    {
        public GuidEntityBase()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
