using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using wpfTask1;

namespace WpfLab1
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        public EmailUser loggedUser;
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = loginBox.Text;
            string password = passBox.Password;
            bool success = EmailData.GetUserData(login, password, out loggedUser);
            if (success)
                this.DialogResult = true;
            else
            {
                this.DialogResult = false;
                MessageBox.Show("Login Failed");
            }
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
