namespace WPF_APP.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using WPF_APP.Helpers;
    using WPF_APP.Models;
    using WPF_APP.Services;

    public class PersonViewModel : INotifyPropertyChanged
    {
        private readonly Person person;
        private readonly PersonService personService;

        public event PropertyChangedEventHandler PropertyChanged;

        private RelayCommand addCommand;
        private string validationMethod;

        public PersonViewModel(PersonService personService)
        {
            this.person = new Person();

            this.personService = personService;
        }

        public string Name
        {
            get => this.person.Name;

            set
            {
                if (this.person.Name == value)
                {
                    return;
                }

                this.person.Name = value;
                this.OnPropertyChanged();
            }
        }

        public DateTime DateOfBirth
        {
            get => this.person.DateOfBirth;
            set
            {
                if (this.person.DateOfBirth == value)
                {
                    return;
                }

                this.person.DateOfBirth = value;
                this.OnPropertyChanged();
            }
        }

        public string City
        {
            get => this.person.City;

            set
            {
                if (this.person.City == value)
                {
                    return;
                }

                this.person.City = value;
                this.OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get => this.person.PhoneNumber;

            set
            {
                if (this.person.PhoneNumber == value)
                {
                    return;
                }

                this.person.PhoneNumber = value;
                this.OnPropertyChanged();
            }
        }

        public string Email
        {
            get => this.person.Email;

            set
            {
                if (this.person.Email == value)
                {
                    return;
                }

                this.person.Email = value;
                this.OnPropertyChanged();
            }
        }

        public string Password
        {
            get => this.person.Password;

            set
            {
                if (this.person.Password == value)
                {
                    return;
                }

                this.person.Password = value;
                this.OnPropertyChanged();
            }
        }

        public string ValidationMessage
        {
            get => this.validationMethod;

            set
            {
                if (this.validationMethod == value)
                {
                    return;
                }

                this.validationMethod = value;
                this.OnPropertyChanged();
            }
        }

        public string MessageForUser { get; set; }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public RelayCommand SavePersonCommand
        {
            get
            {
                return this.addCommand ??= new RelayCommand(obj =>
                {
                    var existingUser = this.CheckExistingUser();
                    if (existingUser == true)
                    {
                        this.MessageForUser = Messages.MessageAboutHavingAccount;
                    }

                    if (this.ValidationMessage == string.Empty && existingUser == false)
                    {
                        PersonService.Insert(this.person);
                        this.MessageForUser = Messages.MessageAboutSuccessRegistration;
                    }
                });
            }
        }

        public void EmptyStringValidation(string data)
        {
            this.ValidationMessage = string.IsNullOrEmpty(data) ? Messages.ErrorMessageEmptyValue : string.Empty;
        }

        public void DateOfBirthValidation(DateTime? dateOfBirth)
        {
            this.ValidationMessage = dateOfBirth >= DateTime.Now ? Messages.ErrorMessageForDate : string.Empty;
        }

        public void CheckPhoneNumber(string password)
        {
            var pattern = Messages.PhonePattern;
            this.ValidationMessage = Regex.IsMatch(password, pattern, RegexOptions.IgnoreCase)
                ? string.Empty
                : Messages.ErrorMessageIncorrectPhone;
        }

        public void CheckEmail(string email)
        {
            var pattern = Messages.EmailPattern;
            this.ValidationMessage = Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase) 
               ? string.Empty
               : Messages.ErrorMessageIncorrectEmail;
        }

        public void CheckPassword(string password)
        {
            var pattern = Messages.PasswordPattern;
            this.ValidationMessage = Regex.IsMatch(password, pattern, RegexOptions.IgnoreCase)
                ? string.Empty
                : Messages.ErrorMessageIncorrectPassword;
        }

        public bool CheckExistingUser()
        {
            var people = personService.GetAll();
            return people.Any(x => x.Email == this.person.Email);
        }
    }
}
