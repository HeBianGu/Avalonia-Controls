using System;
using System.Collections.Generic;
using System.Linq;
using HeBianGu.AvaloniaUI.Mvvm;

namespace HeBianGu.AvaloniaUI.ExploreBox
{
    public class ExploreFastTreeDataProviderExtension : ExploreTreeDataProviderExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
           return this.GetFastTreeNodes().Concat(this.GetTreeNodes());
        }
        private ExploreTree _tree = new ExploreTree();
        public IEnumerable<ITreeNode> GetFastTreeNodes()
        {
            var computer = new TreeNodeBase<object>(new CustomPath() { Name = "快速访问" });
            var sfs = this.GetSpecialFolderTreeNodes(Environment.SpecialFolder.Desktop, Environment.SpecialFolder.MyDocuments, Environment.SpecialFolder.MyPictures, Environment.SpecialFolder.Favorites, Environment.SpecialFolder.Recent, Environment.SpecialFolder.MyVideos, Environment.SpecialFolder.Recent);
            computer.Nodes = sfs.ToObservable();
            yield return computer;
        }

        private IEnumerable<TreeNodeBase<object>> GetSpecialFolderTreeNodes(params Environment.SpecialFolder[] specialFolders)
        {
            foreach (var item in specialFolders)
            {
                var m = _tree.Get(Environment.GetFolderPath(item));
                yield return new TreeNodeBase<object>(m);
            }
        }
    }
}
