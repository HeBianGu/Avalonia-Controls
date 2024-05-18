﻿using System;

namespace HeBianGu.Avalonia.Core.Ioc
{
    public class RevertibleDisposer : IDisposable
    {
        private IRevertibleService _service;
        public RevertibleDisposer()
        {

        }
        public RevertibleDisposer(IRevertibleService service)
        {
            _service = service;
        }

        public void Dispose()
        {
            if (_service == null)
                return;
            _service.Commit();
        }
    }
}
