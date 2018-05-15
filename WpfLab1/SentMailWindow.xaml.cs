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
            NewEmail = new EmailMessage();
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
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
            NewEmail.Body = Bodytxt.Text;
            NewEmail.Date = DateTime.Now.ToString().Split(' ')[0];
            NewEmail.Title = Titletxt.Text;
            NewEmail.To = Totxt.Text;
            this.Close();
        }
    }
}
