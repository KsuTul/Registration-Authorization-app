using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using App.Helpers;
using App.Mapping;
using App.Models;
using App.Services;

namespace App.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private readonly Person _person;
        private readonly PersonService _personService;
        public event PropertyChangedEventHandler PropertyChanged;
        private RelayCommand _addCommand;
        private string _validationMethod;

        public PersonViewModel(PersonService personService)
        {
           _person = new Person();

           _personService = personService;
        }

        public string Name
        {
            get => _person.Name;

            set
            {
                if (_person.Name == value) return;
                _person.Name = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateOfBirth
        {
            get => _person.DateOfBirth;
            set
            {
                if(_person.DateOfBirth == value) return;
                _person.DateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public string City
        {
            get => _person.City;

            set
            {
                if (_person.City == value) return;
                _person.City = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get => _person.PhoneNumber;

            set
            {
                if (_person.PhoneNumber == value) return;
                _person.PhoneNumber = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _person.Email;

            set
            {
                if (_person.Email == value) return;
                _person.Email = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => _person.Password;

            set
            {
                if (_person.Password == value) return;
                _person.Password = value;
                OnPropertyChanged();
            }
        }

        public string ValidationMessage
        {
            get => _validationMethod;

            set
            {
                if (_validationMethod == value) return;
                _validationMethod = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public RelayCommand SavePersonCommand
        {
            get
            {
                return _addCommand ??= new RelayCommand(obj =>
                {
                    //var existingUser = CheckExistingUser();

                    if (ValidationMessage == string.Empty)
                    {
                        PersonService.Insert(_person);
                    }
                });
            }
        }

        public void EmptyStringValidation(string data)
        {
           ValidationMessage =  string.IsNullOrEmpty(data) ? Messages.ErrorMessageEmptyValue: String.Empty;
        }

        public void DateOfBirthValidation(DateTime? dateOfBirth)
        {
            ValidationMessage =  dateOfBirth >= DateTime.Now ? Messages.ErrorMessageForDate : String.Empty;
        }

        public void CheckPhoneNumber(string password)
        {
            var pattern = Messages.PhonePattern;
            ValidationMessage = Regex.IsMatch(password, pattern, RegexOptions.IgnoreCase)
                ? String.Empty
                : Messages.ErrorMessageIncorrectPhone;
        }

        public void CheckEmail(string email)
        {
            var pattern = Messages.EmailPattern;
           ValidationMessage =  Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase) 
               ? String.Empty
               : Messages.ErrorMessageIncorrectEmail;
        }

        public void CheckPassword(string password)
        {
            var pattern = Messages.PasswordPattern;
            ValidationMessage =  Regex.IsMatch(password, pattern, RegexOptions.IgnoreCase)
                ? String.Empty
                : Messages.ErrorMessageIncorrectPassword;
        }

        public bool CheckExistingUser()
        {
            var people = _personService.GetAll();
            return people.Any(x => x.Email == _person.Email);
        }
    }
}
