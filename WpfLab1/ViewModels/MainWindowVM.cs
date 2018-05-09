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
            emails = new BindingList<EmailMessage>();
        }
        public EmailUser loggedUser;
        public BindingList<EmailMessage> emails { get; set; }

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
            if (emails.Count != 0)
            {
                loginContent = "Login";
                emails.Clear();
                loggedUser = null;
                return;
            }
            var win = new LoginWindow();
            var wyn = win.ShowDialog().Value;
            loggedUser = win.loggedUser;
            if (wyn)
            {
                emails.Clear();
                loginContent = "Logout";
                foreach (var e in loggedUser.MessagesReceived)
                    emails.Add(e);
            }
            else
                emails.Clear();
        }
    }
}
