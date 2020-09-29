using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using App.Helpers;
using App.Mapping;
using App.Models;
using App.Services;

namespace App.ViewModels
{
    public class AuthorizationViewModel : INotifyPropertyChanged
    {
        private readonly Person person;
        private readonly PersonService _personService;
        public event PropertyChangedEventHandler PropertyChanged;
        private RelayCommand _readCommand;
        private string message;


        public AuthorizationViewModel(PersonService personService)
        {
            person = new Person();

            _personService = personService;
        }

        public string Email
        {
            get => person.Email;

            set
            {
                if (person.Email == value) return;
                person.Email = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => person.Password;

            set
            {
                if (person.Password == value) return;
                person.Password = value;
                OnPropertyChanged();
            }
        }

        public string Message
        {
            get => message;

            set
            {
                if (message == value) return;
               message = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public RelayCommand ReadCommand
        {
            get
            {
                return _readCommand ??= new RelayCommand(obj =>
                {
                    if (person.Email != null && person.Password != null)
                    {
                        _personService.GetAll()
                            .Where(x => x.Email == person.Email && x.Password == person.Password);
                    }
                });
            }
        }
    }
}
