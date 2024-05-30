#if NETFRAMEWORK
using System.Data.Entity;
#endif

#if NETCOREAPP
#endif

namespace HeBianGu.AvaloniaUI.Sqlite
{
    public interface ISqliteOption
    {
        string InitialCatalog { get; set; }
        string FilePath { get; set; }
        string ConfigPath { get; set; }
    }
}
