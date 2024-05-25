﻿using System;

namespace Avalonia.Ioc
{
    public interface IRevertible
    {
        string Name { get; }
        void AddAction(Action redo, Action undo);
        void Undo();
        void Redo();
    }
}