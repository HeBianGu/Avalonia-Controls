using System;
using System.Collections.Generic;

namespace HeBianGu.AvaloniaUI.Tree
{
    public static class ParentExtension
    {
        public static IEnumerable<object> GetParents(this IParentable tree, object current)
        {
            List<object> result = new List<object>();
            Action<object> getParent = null;
            getParent = x =>
            {
                object parent = tree.GetParent(x);
                result.Add(parent);
                if (parent != null)
                    getParent(parent);
            };
            getParent(current);
            return result;
        }
    }

}
