using System.Collections;

namespace HeBianGu.AvaloniaUI.Ioc
{
    public interface IWhereable
    {
        IEnumerable Where(IEnumerable from);
    }
}
