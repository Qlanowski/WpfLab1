using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using wpfTask1;

namespace WpfLab1.ViewModels
{
    class MainWindowVM : INotifyPropertyChanged
    {
        public MainWindowVM()
        {
            loginContent = "Login";
            Emails = new BindingList<EmailMessage>();
            Email =null;
        }
        public EmailUser loggedUser;
        public BindingList<EmailMessage> Emails { get; set; }

        EmailMessage _email;
        public EmailMessage Email {
            get { return _email; }
            set
            {
                if (_email == value) return;
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _loginContent;
        public string loginContent
        {
            get {return _loginContent; }
            set{
                 if (_loginContent == value) return;
                _loginContent = value;
                OnPropertyChanged("loginContent");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        internal void Login()
        {
            if (Emails.Count != 0)
            {
                loginContent = "Login";
                Emails.Clear();
                loggedUser = null;
                return;
            }
            var win = new LoginWindow();
            var wyn = win.ShowDialog().Value;
            loggedUser = win.loggedUser;
            if (wyn)
            {
                Emails.Clear();
                loginContent = "Logout";
                foreach (var e in loggedUser.MessagesReceived)
                    Emails.Add(e);
            }
            else
                Emails.Clear();
        }
    }
}
