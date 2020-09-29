using System.Windows;
using App.Models;
using App.ViewModels;

namespace App.Views
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        private readonly AuthorizationViewModel authorizationViewModel;
        public Authorization(AuthorizationViewModel viewModel)
        {
            InitializeComponent();
            authorizationViewModel = viewModel;
                
        }
    }
}
