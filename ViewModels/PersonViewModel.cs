using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static App.AppService;

namespace App
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person _person;
        public event PropertyChangedEventHandler PropertyChanged;
        private RelayCommand addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??= new RelayCommand(obj =>
                {
                    if (_person != null)
                    {
                        SavePerson(_person);
                    }
                });
            }
        }
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public PersonViewModel(Person person)
        {
            _person = person;
        }

        public string Name
        {
            get => _person.Name;

            set
            {
                if (_person.Name == value) return;
                _person.Name = value;
                OnPropertyChanged(nameof(_person.Name));
            }
        }

        public DateTime DateOfBirth
        {
            get => _person.DateOfBirth;
            set
            {
                if(_person.DateOfBirth == value) return;
                _person.DateOfBirth = value;
                OnPropertyChanged(nameof(_person.DateOfBirth));
            }
        }

        public string City
        {
            get => _person.City;

            set
            {
                if (_person.City == value) return;
                _person.City = value;
                OnPropertyChanged(nameof(_person.City));
            }
        }
        public string PhoneNumber
        {
            get => _person.PhoneNumber;

            set
            {
                if (_person.PhoneNumber == value) return;
                _person.PhoneNumber = value;
                OnPropertyChanged(nameof(_person.PhoneNumber));
            }
        }

        public string Email
        {
            get => _person.Email;

            set
            {
                if (_person.Email == value) return;
                _person.Email = value;
                OnPropertyChanged(nameof(_person.Email));
            }
        }
        public string Password
        {
            get => _person.Password;

            set
            {
                if (_person.Password == value) return;
                _person.Password = value;
                OnPropertyChanged(nameof(_person.Password));
            }
        }

        public string PhoneValidation(string phone)
        {
            int value;
            if (!int.TryParse(phone, out value) && !phone.Contains("+"))
            {
                return "You enter is not valid";

            }

            return null;
        }

    }
}
