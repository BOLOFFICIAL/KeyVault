using KeyVaultWindows.Command;
using KeyVaultWindows.Model;
using KeyVaultWindows.View;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace KeyVaultWindows.ViewModel
{
    class PageAuthorizationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private Authorization _authorization;
        private Settings _settings;

        public PageAuthorizationViewModel()
        {
            _authorization = new Authorization();
            _settings = new Settings();
            EntryPasswordCommand = new LambdaCommand(OnEntryPasswordCommandExecuted, CanEntryPasswordCommandExecute);
        }

        public string Password
        {
            get
            {
                return _authorization.Password;
            }
            set
            {
                Error = string.Empty;
                if (_authorization.Password != value)
                {
                    _authorization.Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public string Error
        {
            get
            {
                return _authorization.Error;
            }
            set
            {
                if (_authorization.Error != value)
                {
                    _authorization.Error = value;
                    OnPropertyChanged("Error");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public ICommand EntryPasswordCommand { get; }

        private void OnEntryPasswordCommandExecuted(object p)
        {
            if (_authorization.Password.Length > 0) 
            {
                if (_authorization.Password == _settings.ProgrammPass)
                {
                    Context.PageMain.Content = new KeyVaultWindows.View.PageMain();
                }
                else
                {
                    Error = "Неправильный пароль";
                }
            }
        }

        private bool CanEntryPasswordCommandExecute(object p)
        {
            return true;
        }
    }
}
