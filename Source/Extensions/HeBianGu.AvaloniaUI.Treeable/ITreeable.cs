using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HeBianGu.AvaloniaUI.Treeable
{
    public interface ITreeable
    {
        IEnumerable GetChildren(object parent);
    }

}
