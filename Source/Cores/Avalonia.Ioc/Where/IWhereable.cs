using System.Collections;

namespace Avalonia.Ioc
{
    public interface IWhereable
    {
        IEnumerable Where(IEnumerable from);
    }
}
