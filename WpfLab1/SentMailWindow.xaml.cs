using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Windows;
using wpfTask1;

namespace WpfLab1
{
    /// <summary>
    /// Interaction logic for SentMailWindow.xaml
    /// </summary>
    public partial class SentMailWindow : Window, INotifyPropertyChanged
    {
        public SentMailWindow(Window owner)
        {
            Owner = owner;
            InitializeComponent();
            Height = Owner.Height * 0.8;
            Width = Owner.Width * 0.8;
            OkBtn.IsEnabled = false;
        }
        EmailMessage _newEmail;
        public EmailMessage NewEmail
        {
            get { return _newEmail; }
            set
            {
                if (_newEmail == value) return;
                _newEmail = value;
                OnPropertyChanged("NewEmail");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null&&propertyName=="NewEmail")
            {
                bool ok = CheckValidationOfEmail();
                if (ok)
                    OkBtn.IsEnabled = true;
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private bool CheckValidationOfEmail()
        {
            try
            {
                MailAddress m = new MailAddress(NewEmail.To);
                if (NewEmail.Title == "")
                    return false;
                if (NewEmail.Title.Trim(' ').Length==0)
                    return false;
                if (NewEmail.Body.Length>10&&NewEmail.Body.Trim(' ').Length>0)
                    return true;
                return false;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void CancelBtnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        private void OkBtnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
