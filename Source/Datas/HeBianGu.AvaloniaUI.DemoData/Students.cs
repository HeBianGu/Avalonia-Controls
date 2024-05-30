using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HeBianGu.AvaloniaUI.DemoData
{
    public class Students : ObservableCollection<Student>
    {
        public Students()
        {

        }
        public Students(IEnumerable<Student> collection) : base(collection)
        {

        }
    }
}
