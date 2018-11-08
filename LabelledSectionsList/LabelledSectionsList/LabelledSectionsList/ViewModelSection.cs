using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using LabelledSections;
using Xamarin.Forms;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace LabelledSectionsList
{
    public class ViewModelSection : INotifyPropertyChanged
    {
        INavigation _navigation;

        public ViewModelSection(INavigation navigation)
        {
            _navigation = navigation;
            CreateData();
            PopulateList();
        }

        void CreateData()
        {
            // Data used to populate our list.
            List<ListItemValue> _people = new List<ListItemValue>();
            //_people.Add(new ListItemValue("Babbage"));
            _people.Add(new ListItemValue("Babbage"));
            _people.Add(new ListItemValue("Boole"));
            _people.Add(new ListItemValue("Berners-Lee"));
            _people.Add(new ListItemValue("Atanasoff"));
            _people.Add(new ListItemValue("Allen"));
            _people.Add(new ListItemValue("Cormack"));
            _people.Add(new ListItemValue("Cray"));
            _people.Add(new ListItemValue("Dijkstra"));
            _people.Add(new ListItemValue("Dix"));
            _people.Add(new ListItemValue("Dewey"));
            _people.Add(new ListItemValue("Erdos"));
            _people.Add(new ListItemValue("Gates"));
            _people.Add(new ListItemValue("Balmer"));
            _people.Add(new ListItemValue("Jobs"));
            _people.Add(new ListItemValue("Perot"));
            _people.Add(new ListItemValue("Packard"));
            _people.Add(new ListItemValue("Hewlett"));
            _people.Add(new ListItemValue("Bell"));
            _people.Add(new ListItemValue("Olsen"));
            _people.Add(new ListItemValue("Anderson"));
            _people.Add(new ListItemValue("Canion"));
            _people.Add(new ListItemValue("Harris"));
            _people.Add(new ListItemValue("Murto"));

            _people.Sort();
            ListItems = _people;
        }

        void PopulateList()
        {
            PeopleList = new ObservableCollection<ListItemCollection>();

            foreach (var item in ListItems)
            {
                // Attempt to find any existing groups where theg group title matches the first char of our ListItem's name.
                var listItemGroup = PeopleList.FirstOrDefault(g => g.Title == item.Label);

                // If the list group does not exist, we create it.
                if (listItemGroup == null)
                {
                    listItemGroup = new ListItemCollection(item.Label);
                    listItemGroup.Add(item);
                    PeopleList.Add(listItemGroup);
                }
                else
                { // If the group does exist, we simply add the demo to the existing group.
                    listItemGroup.Add(item);
                }
            }
        }

        public async void SelectedListItem(ListItemValue listItem)
        {
            await Application.Current.MainPage.DisplayAlert("View Model", "ListItemValue - You selected " + listItem.Name, "OK");

            NotifyPropertyChanged("SelectedListItem");
        }

        private List<ListItemValue> _listItems;
        List<ListItemValue> ListItems { 
            get => _listItems;
            set { 
                _listItems = value;
                NotifyPropertyChanged("ListItems");
            }
        }

        private ObservableCollection<ListItemCollection> _peopleList;
        public ObservableCollection<ListItemCollection> PeopleList {
            get => _peopleList;
            set
            {
                _peopleList = value;
                NotifyPropertyChanged("PeopleList");
            }
        }

        ListItemValue _yourSelectedItem;
        public ListItemValue YourSelectedItem
        {
            get { return _yourSelectedItem; }
            set
            {
                _yourSelectedItem = value;
                NotifyPropertyChanged("YourSelectedItem");
                SelectedListItem(value);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
