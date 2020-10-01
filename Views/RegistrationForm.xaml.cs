using System.ComponentModel;
using System.Threading;

namespace App.Views
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using WPF_APP.Helpers;
    using WPF_APP.ViewModels;

    /// <summary>
    /// Interaction logic for RegistrationForm.xaml.
    /// </summary>
    public partial class RegistrationForm : Window
    {
        private readonly PersonViewModel personViewModel;

        public RegistrationForm(PersonViewModel personViewModel)
        {
            this.InitializeComponent();
            this.personViewModel = personViewModel;
            this.CityBox.ItemsSource = Messages.Cities;
            this.DateOfBirthBox.SelectedDate = DateTime.UtcNow;
        }

        private void TextBox_KeyDown(object sender, RoutedEventArgs routedEventArgs)
        {
            this.personViewModel.EmptyStringValidation(((TextBox)sender).Text);
            if ((TextBox)sender == this.EmailBox)
            {
                this.personViewModel.CheckEmail(((TextBox)sender).Text);
            }

            if ((TextBox)sender == this.NumberBox)
            {
                this.personViewModel.CheckPhoneNumber(((TextBox)sender).Text);
            }

            if ((TextBox)sender == this.PasswordBox)
            {
                this.personViewModel.CheckPassword(((TextBox)sender).Text);
            }
        }

        private void DateOfBirthBox_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            this.personViewModel.DateOfBirthValidation(((DatePicker)sender).SelectedDate);
        }

        private void SaveBut_OnClick(object sender, RoutedEventArgs e)
        {
            var worker = new BackgroundWorker { WorkerReportsProgress = true };
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (var i = 0; i < 100; i++)
            {
                (sender as BackgroundWorker)?.ReportProgress(i);
                Thread.Sleep(30);
            }

            MessageBox.Show(this.personViewModel.MessageForUser);
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Progress.Value = e.ProgressPercentage;
        }
    }
}
