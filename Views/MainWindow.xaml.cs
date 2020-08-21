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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegButton_OnClick(object sender, RoutedEventArgs e)
        {
            var regForm = new RegistrationForm();
            regForm.Show();
        }

        private void AuthoButton_OnClickButton_OnClick(object sender, RoutedEventArgs e)
        {
            var authorForm = new Authorization();
            authorForm.Show();
        }
    }
}
