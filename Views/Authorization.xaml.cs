namespace App.Views
{
    using System.Windows;
    using WPF_APP.ViewModels;

    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        private readonly AuthorizationViewModel authorizationViewModel;

        public Authorization(AuthorizationViewModel viewModel)
        {
            InitializeComponent();
            this.authorizationViewModel = viewModel;
        }
    }
}
