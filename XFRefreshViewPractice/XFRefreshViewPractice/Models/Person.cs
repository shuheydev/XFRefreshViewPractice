using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XFRefreshViewPractice.Models
{
    public class Person: INotifyPropertyChanged
    {
        private string _firstName;
        public string FirstName {
            get => _firstName;
            set
            {
                if(_firstName==value)
                {
                    return;
                }
                _firstName = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(FullName));
                RaisePropertyChanged(nameof(AvatarUrl));
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName == value)
                {
                    return;
                }
                _lastName = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(FullName));
                RaisePropertyChanged(nameof(AvatarUrl));
            }
        }

        public string FullName => $"{FirstName} {LastName}";

        public string AvatarUrl => $"https://robohash.org/{LastName}-{FirstName}?set=set4";



        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
