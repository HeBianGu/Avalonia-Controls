using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;
using HeBianGu.Test.Controls.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace HeBianGu.Test.Controls.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    private ObservableCollection<Person> _people;
    /// <summary> 说明  </summary>
    public ObservableCollection<Person> People
    {
        get { return _people; }
        set
        {
            _people = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Node> Nodes { get; }


    public FlatTreeDataGridSource<Person> PersonSource { get; }

    public MainViewModel()
    {
        var people = new List<Person>
            {
                new Person("Neil", "Armstrong"),
                new Person("Buzz", "Lightyear"),
                new Person("James", "Kirk")
            };
        People = new ObservableCollection<Person>(people);

        PersonSource = new FlatTreeDataGridSource<Person>(people)
        {
            Columns =
                {
                    new TextColumn<Person, string>
                        ("First Name", x => x.FirstName),
                    new TextColumn<Person, string>
                        ("Last Name", x => x.LastName)
                },
        };

        Nodes = new ObservableCollection<Node>
            {
                new Node("Animals", new ObservableCollection<Node>
                {
                    new Node("Mammals", new ObservableCollection<Node>
                    {
                        new Node("Lion"), new Node("Cat"), new Node("Zebra")
                    })
                })
            };
    }
}


