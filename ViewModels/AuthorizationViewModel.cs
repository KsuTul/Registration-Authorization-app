namespace WPF_APP.ViewModels
{
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using WPF_APP.Helpers;
    using WPF_APP.Models;
    using WPF_APP.Services;

    public class AuthorizationViewModel : INotifyPropertyChanged
    {
        private readonly Person person;
        private readonly PersonService personService;

        public event PropertyChangedEventHandler PropertyChanged;

        private RelayCommand readCommand;
        private string message;

        public AuthorizationViewModel(PersonService personService)
        {
            this.person = new Person();

            this.personService = personService;
        }

        public string Email
        {
            get => this.person.Email;

            set
            {
                if (this.person.Email == value) return;
                this.person.Email = value;
                this.OnPropertyChanged();
            }
        }

        public string Password
        {
            get => this.person.Password;

            set
            {
                if (this.person.Password == value) return;
                this.person.Password = value;
                this.OnPropertyChanged();
            }
        }

        public string Message
        {
            get => this.message;

            set
            {
                if (this.message == value) return;
                this.message = value;
                this.OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public RelayCommand ReadCommand
        {
            get
            {
                return this.readCommand ??= new RelayCommand(obj =>
                {
                    if (this.person.Email != null && person.Password != null)
                    {
                        this.Message = this.personService.GetAll()
                            .Any(x => x.Email == this.person.Email && x.Password == this.person.Password) == true ?
                            Messages.MessageAboutExistingUser : Messages.MessageAboutRegistration;
                    }
                });
            }
        }
    }
}
