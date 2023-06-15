using KeyVaultWindows.Command;
using KeyVaultWindows.Model;
using KeyVaultWindows.ProgramFile;
using System.ComponentModel;
using System.Windows.Input;

namespace KeyVaultWindows.ViewModel
{
    class PageAuthorizationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private Authorization _authorization;
        private Settings _settings;
        public ICommand EntryPasswordCommand { get; }

        public PageAuthorizationViewModel()
        {
            _authorization = new Authorization();
            _settings = Context.settings;
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

        private void OnEntryPasswordCommandExecuted(object p)
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

        private bool CanEntryPasswordCommandExecute(object p)
        {
            return _authorization.Password.Length > 0;
        }
    }
}
