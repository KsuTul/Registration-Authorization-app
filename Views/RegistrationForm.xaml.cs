using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace App
{
    /// <summary>
    /// Interaction logic for RegistrationForm.xaml
    /// </summary>
    public partial class RegistrationForm : Window
    {
        private Person person = new Person();
        private PersonViewModel _personViewModel;
        public RegistrationForm()
        {
            InitializeComponent();
            _personViewModel = new PersonViewModel(person);
            DataContext = new PersonViewModel(person);
            CityBox.ItemsSource = new List<string>()
            {
                "Nizhniy Novgorod",
                "Moscow",
                "Saint-Petersburg",
                "Kaliningrad",
                "Petrozavodsk",
                "Sochi"
            };
                   DateOfBirthBox.SelectedDate = DateTime.UtcNow;
        }



        private void NumberBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (_personViewModel.PhoneValidation(((TextBox) sender).Text) != null)
            {
                ErrorMessage.Text = _personViewModel.PhoneValidation(((TextBox)sender).Text);
                e.Handled = true;
            }

            //if (_personViewModel.PhoneValidation(((TextBox) sender).Text) == null)
            //{
            //    ErrorMessage.Text = null;
            //    e.Handled = false;
            //}
        }

        private void NumberBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
