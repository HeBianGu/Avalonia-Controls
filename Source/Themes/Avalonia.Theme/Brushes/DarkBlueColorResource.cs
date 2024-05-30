﻿using Avalonia.Theme.Provider;
using System;

namespace Avalonia.Theme
{
    public class DarkBlueColorResource : ResourceBase, IColorResource
    {
        public override string Name => "深蓝色";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Brushes/Dark.Blue.axaml");
        }
    }
}
