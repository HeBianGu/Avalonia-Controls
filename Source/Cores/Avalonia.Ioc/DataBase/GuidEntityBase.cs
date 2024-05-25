using System;

namespace Avalonia.Ioc
{
    public abstract class GuidEntityBase : EntityBase<Guid>
    {
        public GuidEntityBase()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
