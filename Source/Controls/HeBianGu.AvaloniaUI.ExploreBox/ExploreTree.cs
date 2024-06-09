using System.Linq;
using System;
using System.IO;
using System.Collections;
using HeBianGu.AvaloniaUI.Treeable;
using Avalonia.Media;

namespace HeBianGu.AvaloniaUI.ExploreBox
{

    public class ExploreTree : ITreeable, IParentable, IExploreTree
    {
        public string SearchPattern { get; set; } = "*";
        public SearchOption SearchOption { get; set; }

        public bool UseDirectoryOnly { get; set; }
        public string Root { get; set; }

        public object Get(string path)
        {
            if (Directory.Exists(path))
                return new DirectoryInfo(path);
            if (File.Exists(path))
                return new FileInfo(path);
            return null;
        }

        public IEnumerable GetChildren(object parent)
        {
            if (parent is DriveInfo drive)
                return drive.RootDirectory.GetFileSystemInfos(SearchPattern, SearchOption).Where(d => !d.Attributes.HasFlag(FileAttributes.Hidden | FileAttributes.System));

            if (parent is DirectoryInfo directory)
            {
                try
                {
                    var finds = directory.GetFileSystemInfos(SearchPattern, SearchOption).Where(d => !d.Attributes.HasFlag(FileAttributes.Hidden | FileAttributes.System)).OrderBy(x => x.Attributes);
                    if (this.UseDirectoryOnly)
                        return finds.Where(x => x.Attributes.HasFlag(FileAttributes.Directory));
                    return finds;
                }
                catch (Exception ex)
                {


                }
            }


            if (parent is FileInfo)
            {
                return Enumerable.Empty<string>();
            }

            //if (parent == null)
            //{
            //    if (!Directory.Exists(Root))
            //        return DriveInfo.GetDrives();
            //    return new DirectoryInfo[] { new DirectoryInfo(Root) };
            //}

            if (!Directory.Exists(Root))
                return DriveInfo.GetDrives();
            return new DirectoryInfo[] { new DirectoryInfo(Root) };
        }

        public object GetParent(object current)
        {
            if (current is FileInfo info)
                return info.Directory;
            if (current is DirectoryInfo dir)
                return dir.Parent == null ? new CustomPath() { Name = this.Root } : dir.Parent;
            if (current is DriveInfo driveInfo)
                return new CustomPath() { Name = this.Root };
            return null;
        }

        public bool IsFile(object current)
        {
            return current is FileInfo;
        }
    }

}
