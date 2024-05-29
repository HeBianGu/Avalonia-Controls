using Avalonia.Controls.Primitives;
using System;

namespace Avalonia.Styles.Extension
{
    public class GroupBox : HeaderedContentControl
    {
        protected override Type StyleKeyOverride => typeof(GroupBox);
    }
}
