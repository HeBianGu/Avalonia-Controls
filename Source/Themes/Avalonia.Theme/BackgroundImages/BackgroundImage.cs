using Avalonia.Extensions.ResourceKey;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Theme
{
    public static class BackgroundImageKeys
    {
        public static StringResourceKey BackgroundImage => new StringResourceKey(typeof(BackgroundImageKeys), "S.BackgroundImage.BackgroundImage");

        public static StringResourceKey Opacity => new StringResourceKey(typeof(BackgroundImageKeys), "S.BackgroundImage.Opacity");

        public static StringResourceKey Stretch => new StringResourceKey(typeof(BackgroundImageKeys), "S.BackgroundImage.Stretch");
    }

    public interface IBackgroundImageResource : IResource
    {

    }
}
