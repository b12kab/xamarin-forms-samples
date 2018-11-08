using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelledSections
{
    // Represents a group of items in our list.
    public class ListItemCollection : ObservableCollection<ListItemValue>
    {
        public string Title { get; private set; }

		public string LongTitle { get { return "The letter " + Title; } }

		public ListItemCollection(string title)
        {
            Title = title;
        }
    }
}
