using System.Collections;

namespace HeBianGu.Avalonia.Core.Ioc
{
    public interface IWhereable
    {
        IEnumerable Where(IEnumerable from);
    }
}
