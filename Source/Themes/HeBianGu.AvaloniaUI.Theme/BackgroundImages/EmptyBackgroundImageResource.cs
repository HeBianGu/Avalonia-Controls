﻿using HeBianGu.AvaloniaUI.Theme.Provider;
using System;

namespace HeBianGu.AvaloniaUI.Theme
{
    public class EmptyBackgroundImageResource : ResourceBase, IBackgroundImageResource
    {
        public override string Name => "无";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/BackgroundImages/Empty.axaml");
        }
    }

    public class StarBackgroundImageResource : ResourceBase, IBackgroundImageResource
    {
        public override string Name => "星空";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/BackgroundImages/Star.axaml");
        }
    }

    public class GridBackgroundImageResource : ResourceBase, IBackgroundImageResource
    {
        public override string Name => "网格";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/BackgroundImages/Grid.axaml");
        }
    }

    public class CoverBackgroundImageResource : ResourceBase, IBackgroundImageResource
    {
        public override string Name => "蒙砂";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/BackgroundImages/Cover.axaml");
        }
    }

    public class ArrowBackgroundImageResource : ResourceBase, IBackgroundImageResource
    {
        public override string Name => "箭头";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/BackgroundImages/Arrow.axaml");
        }
    }

    public class MountainBackgroundImageResource : ResourceBase, IBackgroundImageResource
    {
        public override string Name => "景观";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/BackgroundImages/Mountain.axaml");
        }
    }

    public class WaveBackgroundImageResource : ResourceBase, IBackgroundImageResource
    {
        public override string Name => "波浪";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/BackgroundImages/Wave.axaml");
        }
    }
}
