using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFRefreshViewPractice.Models;

namespace XFRefreshViewPractice.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage,INotifyPropertyChanged
    {
        private List<Person> _people;
        public List<Person> People
        {
            get => _people;
            set
            {
                _people = value;
                OnPropertyChanged(nameof(People));
            }
        }

        public MainPage()
        {
            InitializeComponent();
            RefreshCommand = new Command(ExecuteRefreshCommand);

            People = GeneratePeople();

            this.BindingContext = this;
        }

        private List<Person> GeneratePeople(string additional="")
        {
            var people = new List<Person>();

            for (int i = 0; i < 100; i++)
            {
                people.Add(new Person
                {
                    FirstName = $"FirstName {i}",
                    LastName = $"LastName {i} {additional}",
                });
            }

            return people;
        }

        private void ExecuteRefreshCommand(object obj)
        {
            People.Clear();

            People = GeneratePeople(DateTime.Now.ToString());

            //ぐるぐるを非表示にする
            IsRefreshing = false;
        }

        public ICommand RefreshCommand { get; }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

    }
}
