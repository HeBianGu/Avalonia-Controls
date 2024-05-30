#if NETFRAMEWORK
using System.Data.Entity;
#endif

#if NETCOREAPP
#endif
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HeBianGu.AvaloniaUI.DataBase.Share
{
    public interface IDbSettable
    {
        string GetConnect();
    }
}
