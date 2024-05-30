using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HeBianGu.AvaloniaUI.DemoData
{
    public class TestBindables : ObservableCollection<TestBindable>
    {
        public TestBindables()
        {

        }
        public TestBindables(IEnumerable<TestBindable> collection) : base(collection)
        {

        }
    }
}
