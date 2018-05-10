using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using wpfTask1;

namespace WpfLab1.ViewModels
{
    class MainWindowVM : INotifyPropertyChanged
    {
        public MainWindowVM()
        {
            loginContent = "Login";
            Emails = new BindingList<EmailMessage>();
            SentEmails = new BindingList<EmailMessage>();
            Email =null;
        }
        public BindingList<EmailMessage> Emails { get; set; }
        public BindingList<EmailMessage> SentEmails { get; set; }

        EmailUser _loggedUser;
        public EmailUser LoggedUser
        {
            get { return _loggedUser; }
            set
            {
                if (_loggedUser == value) return;
                _loggedUser = value;
                OnPropertyChanged("LoggedUser");
            }
        }

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

        string _loginContent;
        public string loginContent
        {
            get {return _loginContent; }
            set{
                 if (_loginContent == value) return;
                _loginContent = value;
                OnPropertyChanged("loginContent");
            }
        }

        internal void NewMail(Window owner)
        {
            var win = new SentMailWindow(owner);
            var wyn = win.ShowDialog().Value;
            if (wyn)
            {
                SentEmails.Add(win.NewEmail);
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
                LoggedUser = null;
                return;
            }
            var win = new LoginWindow();
            var wyn = win.ShowDialog().Value;
            LoggedUser = win.loggedUser;
            if (wyn)
            {
                Emails.Clear();
                loginContent = "Logout";
                foreach (var e in LoggedUser.MessagesReceived)
                    Emails.Add(e);
                foreach (var e in LoggedUser.MessagesSent)
                    SentEmails.Add(e);
            }
            else
                Emails.Clear();
        }
    }
}
