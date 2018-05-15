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
            rEmails = new BindingList<EmailMessage>();
            sEmails = new BindingList<EmailMessage>();
            Email =null;
        }
        public BindingList<EmailMessage> Emails { get; set; }
        BindingList<EmailMessage> rEmails;
        public BindingList<EmailMessage> SentEmails { get; set; }
        BindingList<EmailMessage> sEmails;

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

        string _searchtxt;
        public string Searchtxt
        {
            get { return _searchtxt; }
            set
            {
                if (_searchtxt == value) return;
                _searchtxt = value;
                OnPropertyChanged("Searchtxt");
            }
        }
        public void UpdateList(bool recieve)
        {
            if(recieve)
            {
                Emails.Clear();
                if (Searchtxt.Length==0)
                {
                    foreach (var e in rEmails)
                        Emails.Add(e);
                    Email = Emails[0];
                    return;
                }
                var arr = Searchtxt.Split(' ');
                foreach (var w in arr)
                    foreach (var e in rEmails)
                    {
                        if (e.Title.Contains(w) || e.Date.ToString().Contains(w) || e.From.Contains(w))
                            Emails.Add(e);
                    }
                Email = Emails[0];
            }
            else
            {
                SentEmails.Clear();
                if (Searchtxt.Length == 0)
                {
                    foreach (var e in sEmails)
                        SentEmails.Add(e);
                    Email = SentEmails[0];
                    return;
                }
                var arr = Searchtxt.Split(' ');
                foreach (var w in arr)
                    foreach (var e in sEmails)
                    {
                        if (e.Title.Contains(w) || e.Date.ToString().Contains(w) || e.To.Contains(w))
                            SentEmails.Add(e);
                    }
                Email = SentEmails[0];
            }
            return;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        internal void NewMail(Window owner)
        {
            var win = new SentMailWindow(owner);
            var wyn = win.ShowDialog().Value;
            var e = win.NewEmail;
            if (wyn)
            {
                SentEmails.Add(e);
                sEmails.Add(e);
            }
        }

        internal void Login(Window owner)
        {
            if (Emails.Count != 0)
            {
                loginContent = "Login";
                Emails.Clear();
                LoggedUser = null;
                return;
            }
            var win = new LoginWindow(owner);
            var wyn = win.ShowDialog().Value;
            LoggedUser = win.loggedUser;
            if (wyn)
            {
                Emails.Clear();
                loginContent = "Logout";
                foreach (var e in LoggedUser.MessagesReceived)
                    Emails.Add(e);
                foreach (var e in LoggedUser.MessagesReceived)
                    rEmails.Add(e);
                foreach (var e in LoggedUser.MessagesSent)
                    SentEmails.Add(e);
                foreach (var e in LoggedUser.MessagesSent)
                    sEmails.Add(e);
            }
            else
                Emails.Clear();
        }
    }
}
