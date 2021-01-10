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
    public partial class MainPage : ContentPage, INotifyPropertyChanged
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

            //このCommandが呼び出されたときに実行するメソッドを指定
            //RefreshCommand = new Command(async (o) => await ExecuteRefreshCommand(o));
            RefreshCommand = new Command(async (o) => {
                await Task.Delay(2000);

                People.Clear();

                People = GeneratePeople(DateTime.Now.ToString());

                //ぐるぐるを非表示にする
                IsRefreshing = false;
            });


            People = GeneratePeople();

            this.BindingContext = this;
        }

        private List<Person> GeneratePeople(string additional = "")
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

        //実行されるメソッド
        private async Task ExecuteRefreshCommand(object obj)
        {
            await Task.Delay(2000);

            People.Clear();

            People = GeneratePeople(DateTime.Now.ToString());

            //ぐるぐるを非表示にする
            IsRefreshing = false;
        }

        //XAML側でバインドするCommandプロパティを用意
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
