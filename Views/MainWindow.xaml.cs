namespace App.Views
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly RegistrationForm registration;
        private readonly Authorization authorizationForm;

        public MainWindow(RegistrationForm registration,Authorization authorization)
        {
            this.InitializeComponent();
            this.registration = registration;
            this.authorizationForm = authorization;

        }

        private void RegButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.registration.Show();

        }

        private void AuthoButton_OnClickButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.authorizationForm.Show();
        }
    }
}
