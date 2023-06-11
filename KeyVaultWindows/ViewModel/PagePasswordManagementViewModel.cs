using KeyVaultWindows.Command;
using KeyVaultWindows.Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace KeyVaultWindows.ViewModel
{
    class PagePasswordManagementViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private Management _management;
        public ICommand PageTransitionCommand { get; }
        public ICommand PasswordCommand { get; }
        public ICommand PasswordEdit { get; }

        public PagePasswordManagementViewModel()
        {
            _management = Context.management;
            PageTransitionCommand = new LambdaCommand(OnPageTransitionCommandExecuted, CanPageTransitionCommandExecute);
            PasswordCommand = new LambdaCommand(OnPasswordCommandExecuted, CanPasswordCommandExecute);
            PasswordEdit = new LambdaCommand(OnEditPasswordCommandExecuted, CanEditPasswordCommandExecute);
        }

        public string Title
        {
            get
            {
                return _management.Title;
            }
            set
            {
                if (_management.Title != value)
                {
                    _management.Title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        public bool IsReadonly
        {
            get
            {
                return _management.IsReadonly;
            }
            set
            {
                if (_management.IsReadonly != value)
                {
                    _management.IsReadonly = value;
                    OnPropertyChanged("IsReadonly");
                }
            }
        }

        public string ButtonContent
        {
            get
            {
                return _management.ButtonContent;
            }
            set
            {
                if (_management.ButtonContent != value)
                {
                    _management.ButtonContent = value;
                    OnPropertyChanged("ButtonContent");
                }
            }
        }

        public GridLength GridLength
        {
            get
            {
                return _management.GridLength;
            }
            set
            {
                if (_management.GridLength != value)
                {
                    _management.GridLength = value;
                    OnPropertyChanged("GridLength");
                }
            }
        }

        public string Name
        {
            get
            {
                return _management.Name;
            }
            set
            {
                if (_management.Name != value)
                {
                    _management.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Pass
        {
            get
            {
                return _management.Pass;
            }
            set
            {
                if (_management.Pass != value)
                {
                    _management.Pass = value;
                    OnPropertyChanged("Pass");
                }
            }
        }

        public string Adress
        {
            get
            {
                return _management.Adress;
            }
            set
            {
                if (_management.Adress != value)
                {
                    _management.Adress = value;
                    OnPropertyChanged("Adress");
                }
            }
        }

        public string Login
        {
            get
            {
                return _management.Login;
            }
            set
            {
                if (_management.Login != value)
                {
                    _management.Login = value;
                    OnPropertyChanged("Login");
                }
            }
        }

        public string Addition
        {
            get
            {
                return _management.Addition;
            }
            set
            {
                if (_management.Addition != value)
                {
                    _management.Addition = value;
                    OnPropertyChanged("Addition");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void OnPasswordCommandExecuted(object p)
        {
            switch (Context.PasswordAction)
            {
                case "AddPassword":
                    Context.PasswordString.Add(Name);
                    Context.Passwords.Add(new Password(Name, Pass, Adress, Login, Addition));
                    Name = string.Empty;
                    Pass = string.Empty;
                    Adress = string.Empty;
                    Login = string.Empty;
                    Addition = string.Empty;
                    break;
                case "DeletePassword":
                    if (MessageBox.Show("Удалить пароль?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        Context.Passwords.RemoveAt(Context.PasswordIndex);
                        Context.PasswordString.RemoveAt(Context.PasswordIndex);
                        Context.PageMain.Content = new KeyVaultWindows.View.PageMain();
                        Context.PasswordIndex = -1;
                    }
                    break;
                case "SavePassword":
                    Context.PasswordString[Context.PasswordIndex] = Name;
                    Context.Passwords[Context.PasswordIndex].Name = Name;
                    Context.Passwords[Context.PasswordIndex].Pass = Pass;
                    Context.Passwords[Context.PasswordIndex].Adress = Adress;
                    Context.Passwords[Context.PasswordIndex].Login = Login;
                    Context.Passwords[Context.PasswordIndex].Addition = Addition;

                    IsReadonly = true;
                    Title = "Пароль";
                    ButtonContent = "Удалить";
                    GridLength = new GridLength(1, GridUnitType.Star);
                    Context.PasswordAction = "DeletePassword";
                    break;
            }
        }

        private bool CanPasswordCommandExecute(object p)
        {
            if (Context.PasswordAction == "AddPassword" || Context.PasswordAction == "SavePassword")
            {
                return Name.ToString().Length > 0 && Pass.ToString().Length > 0 && Adress.ToString().Length > 0;
            }
            else
            {
                return true;
            }
        }

        private void OnEditPasswordCommandExecuted(object p)
        {
            IsReadonly = false;
            Title = "Изменить пароль";
            ButtonContent = "Сохранить";
            GridLength = new GridLength(0, GridUnitType.Star);
            Context.PasswordAction = "SavePassword";
        }

        private bool CanEditPasswordCommandExecute(object p)
        {
            return true;
        }

        private void OnPageTransitionCommandExecuted(object p)
        {
            Context.PageMain.Content = new KeyVaultWindows.View.PageMain();
            Context.PasswordIndex = -1;
        }

        private bool CanPageTransitionCommandExecute(object p)
        {
            return true;
        }
    }
}
