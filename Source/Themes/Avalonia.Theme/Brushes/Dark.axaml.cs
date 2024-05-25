using Avalonia.Extensions.ResourceKey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Theme
{
    public static class BrushKeys
    {
        #region - Background -
        public static StringResourceKey CaptionBackground => new StringResourceKey(typeof(BrushKeys), "S.Brush.CaptionBackground");

        public static StringResourceKey Background => new StringResourceKey(typeof(BrushKeys), "S.Brush.TextBackground");
        public static StringResourceKey BackgroundDisabled => new StringResourceKey(typeof(BrushKeys), "S.Brush.TextBackground.Disabled");
        public static StringResourceKey AlternatingRowBackground => new StringResourceKey(typeof(BrushKeys), "S.Brush.RowIndex.BackGround");
        #endregion

        public static StringResourceKey CaptionForeground => new StringResourceKey(typeof(BrushKeys), "S.Brush.CaptionForeground");
        public static StringResourceKey Foreground => new StringResourceKey(typeof(BrushKeys), "S.Brush.TextForeground");
        public static StringResourceKey ForegroundTitle => new StringResourceKey(typeof(BrushKeys), "S.Brush.TextForeground.Title");
        public static StringResourceKey ForegroundDisabled => new StringResourceKey(typeof(BrushKeys), "S.Brush.TextForeground.Disabled");

        #region - Foreground -

        public static StringResourceKey MouseOver => new StringResourceKey(typeof(BrushKeys), "S.Brush.TextMouseOver");
        public static StringResourceKey Selected => new StringResourceKey(typeof(BrushKeys), "S.Brush.TextSelected");
        public static StringResourceKey ForegroundAssist => new StringResourceKey(typeof(BrushKeys), "S.Brush.TextForeground.Assist");
        public static StringResourceKey ForegroundLink => new StringResourceKey(typeof(BrushKeys), "S.Brush.TextForeground.Link");
        public static StringResourceKey ForegroundWhite => new StringResourceKey(typeof(BrushKeys), "S.Brush.TextForeground.White");

        #endregion

        #region - BorderBrush -

        public static StringResourceKey BorderBrush => new StringResourceKey(typeof(BrushKeys), "S.Brush.TextBorderBrush");
        public static StringResourceKey BorderBrushTitle => new StringResourceKey(typeof(BrushKeys), "S.Brush.TextBorderBrush.Title");
        public static StringResourceKey BorderBrushAssist => new StringResourceKey(typeof(BrushKeys), "S.Brush.TextBorderBrush.Assist");
        public static StringResourceKey BorderBrushDisabled => new StringResourceKey(typeof(BrushKeys), "S.Brush.TextBorderBrush.Disabled");
        #endregion

        #region - Accent -
        public static StringResourceKey Accent => new StringResourceKey(typeof(BrushKeys), "S.Brush.Accent");
        #endregion 

        #region - Dark - 
        public static StringResourceKey Dark10 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.10");
        public static StringResourceKey Dark9_5 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.9.5");
        public static StringResourceKey Dark9 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.9");
        public static StringResourceKey Dark8_5 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.8.5");
        public static StringResourceKey Dark8 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.8");
        public static StringResourceKey Dark7_5 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.7.5");
        public static StringResourceKey Dark7 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.7");
        public static StringResourceKey Dark6_5 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.6.5");
        public static StringResourceKey Dark6 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.6");
        public static StringResourceKey Dark5_5 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.5.5");
        public static StringResourceKey Dark5 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.5");
        public static StringResourceKey Dark4_5 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.4.5");
        public static StringResourceKey Dark4 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.4");
        public static StringResourceKey Dark3_5 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.3.5");
        public static StringResourceKey Dark3 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.3");
        public static StringResourceKey Dark2_5 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.2.5");
        public static StringResourceKey Dark2 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.2");
        public static StringResourceKey Dark1_5 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.1.5");
        public static StringResourceKey Dark1 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.1");
        public static StringResourceKey Dark0_9 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.0.9");
        public static StringResourceKey Dark0_8 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.0.8");
        public static StringResourceKey Dark0_7 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.0.7");
        public static StringResourceKey Dark0_6 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.0.6");
        public static StringResourceKey Dark0_5 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.0.5");
        public static StringResourceKey Dark0_4 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.0.4");
        public static StringResourceKey Dark0_3 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.0.3");
        public static StringResourceKey Dark0_2 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.0.2");
        public static StringResourceKey Dark0_1 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.0.1");
        public static StringResourceKey Dark0 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dark.0");
        #endregion 

        #region - Color -
        public static StringResourceKey LightGray => new StringResourceKey(typeof(BrushKeys), "S.Brush.LightGray");
        public static StringResourceKey LightGrayOpacity5 => new StringResourceKey(typeof(BrushKeys), "S.Brush.LightGrayOpacity.5");
        public static StringResourceKey Gray => new StringResourceKey(typeof(BrushKeys), "S.Brush.Gray");
        public static StringResourceKey GrayOpacity5 => new StringResourceKey(typeof(BrushKeys), "S.Brush.Gray.Opacity.5,");
        public static StringResourceKey Black => new StringResourceKey(typeof(BrushKeys), "S.Brush.Black");
        public static StringResourceKey Orange => new StringResourceKey(typeof(BrushKeys), "S.Brush.Orange");
        public static StringResourceKey Red => new StringResourceKey(typeof(BrushKeys), "S.Brush.Red");
        public static StringResourceKey Green => new StringResourceKey(typeof(BrushKeys), "S.Brush.Green");
        public static StringResourceKey Yellow => new StringResourceKey(typeof(BrushKeys), "S.Brush.Yellow");
        public static StringResourceKey Blue => new StringResourceKey(typeof(BrushKeys), "S.Brush.Blue");
        public static StringResourceKey Purple => new StringResourceKey(typeof(BrushKeys), "S.Brush.Purple");
        public static StringResourceKey Brown => new StringResourceKey(typeof(BrushKeys), "S.Brush.Brown");
        public static StringResourceKey LightBlue => new StringResourceKey(typeof(BrushKeys), "S.Brush.LightBlue");
        public static StringResourceKey Pink => new StringResourceKey(typeof(BrushKeys), "S.Brush.Pink");

        public static StringResourceKey White => new StringResourceKey(typeof(BrushKeys), "S.Brush.White");
        #endregion

        #region - System -
        public static StringResourceKey DialogCover => new StringResourceKey(typeof(BrushKeys), "S.Brush.Dialog.Cover");

        #endregion

        public static StringResourceKey Tranparent => new StringResourceKey(typeof(BrushKeys), "S.Brush.Tranparent");
    }
}
