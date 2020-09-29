using System.IO;
using System.Windows;


namespace App.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RegistrationForm _registration;
        private Authorization _authorizationForm;
        public MainWindow(RegistrationForm registration,Authorization authorization)
        {
            InitializeComponent();
            _registration = registration;
            _authorizationForm = authorization;

        }

        private void RegButton_OnClick(object sender, RoutedEventArgs e)
        {
            _registration.Show();

        }

        private void AuthoButton_OnClickButton_OnClick(object sender, RoutedEventArgs e)
        {
            _authorizationForm.Show();
        }
    }
}
