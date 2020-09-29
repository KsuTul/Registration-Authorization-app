using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using App.Helpers;
using App.Models;
using App.ViewModels;

namespace App.Views
{
    /// <summary>
    /// Interaction logic for RegistrationForm.xaml
    /// </summary>
    public partial class RegistrationForm : Window
    {
        private readonly PersonViewModel _personViewModel;
        public RegistrationForm(PersonViewModel personViewModel)
        {
            InitializeComponent();
            _personViewModel = personViewModel;
            CityBox.ItemsSource = Messages.Cities;
            DateOfBirthBox.SelectedDate = DateTime.UtcNow;
        }

        private void TextBox_KeyDown(object sender, RoutedEventArgs routedEventArgs)
        {

            _personViewModel.EmptyStringValidation(((TextBox)sender).Text);
            if ((TextBox)sender == EmailBox)
            {
                _personViewModel.CheckEmail(((TextBox)sender).Text);
            }

            if ((TextBox)sender == NumberBox)
            {
                _personViewModel.CheckPhoneNumber(((TextBox)sender).Text);
            }

            if ((TextBox)sender == PasswordBox)
            {
                _personViewModel.CheckPassword(((TextBox)sender).Text);
            }
        }

        private void DateOfBirthBox_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _personViewModel.DateOfBirthValidation(((DatePicker)sender).SelectedDate);
        }

        private void SaveBut_OnClick(object sender, RoutedEventArgs e)
        {
            ProgressBar progressBar = new ProgressBar();
            progressBar.Show();
        }
    }
}
