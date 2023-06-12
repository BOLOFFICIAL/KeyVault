using KeyVaultWindows.Command;
using KeyVaultWindows.Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace KeyVaultWindows.ViewModel
{
    class PageSettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand PageTransition { get; }
        public ICommand SaveSettings { get; }

        private Settings _settings;

        public PageSettingsViewModel()
        {
            _settings = Context.settings;
            PageTransition = new LambdaCommand(OnPageTransitionCommandExecuted, CanPageTransitionCommandExecute);
            SaveSettings = new LambdaCommand(OnSaveSettingsCommandExecuted, CanSaveSettingsCommandExecute);
        }

        public GridLength GridNameLength
        {
            get
            {
                return _settings.GridNameLength;
            }
            set
            {
                if (_settings.GridNameLength != value)
                {
                    _settings.GridNameLength = value;
                    OnPropertyChanged("GridNameLength");
                }
            }
        }

        public string Oldpass
        {
            get
            {
                return _settings.Oldpass;
            }
            set
            {
                if (_settings.Oldpass != value)
                {
                    _settings.Oldpass = value;
                    OnPropertyChanged("Oldpass");
                }
            }
        }

        public string Newpass
        {
            get
            {
                return _settings.Newpass;
            }
            set
            {
                if (_settings.Newpass != value)
                {
                    _settings.Newpass = value;
                    OnPropertyChanged("Newpass");
                }
            }
        }

        public string PasswordName
        {
            get
            {
                return _settings.PasswordName;
            }
            set
            {
                if (_settings.PasswordName != value)
                {
                    _settings.PasswordName = value;
                    OnPropertyChanged("PasswordName1");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void OnPageTransitionCommandExecuted(object p)
        {
            Context.PageMain.Content = new KeyVaultWindows.View.PageMain();
        }

        private bool CanPageTransitionCommandExecute(object p)
        {
            return true;
        }

        private void OnSaveSettingsCommandExecuted(object p)
        {
            if (Oldpass.Length > 0) 
            {
                if (_settings.ProgrammPass.Length == 0)
                {
                    _settings.ProgrammPass = Oldpass;
                }
                else
                {
                    if (Oldpass == _settings.ProgrammPass)
                    {
                        _settings.ProgrammPass = Newpass;
                    }
                    else
                    {
                        MessageBox.Show("Неправильный старый пароль");
                        return;
                    }
                }
            }
            MessageBox.Show("Настройки успешно изменены");
        }

        private bool CanSaveSettingsCommandExecute(object p)
        {
            return true;
        }
    }
}
