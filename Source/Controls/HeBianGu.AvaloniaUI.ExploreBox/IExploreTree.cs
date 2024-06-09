using HeBianGu.AvaloniaUI.Treeable;

namespace HeBianGu.AvaloniaUI.ExploreBox
{
    public interface IExploreTree : ITreeable
    {
        string SearchPattern { get; set; }
        bool IsFile(object current);
        object Get(string path);
    }

}
