using KeyVaultWindows.Model;
using System.Collections.Generic;
using System.Windows.Input;
using KeyVaultWindows.Command;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;

namespace KeyVaultWindows.ViewModel
{
    class PageMainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand PageTransition { get; }
        private Main _main;

        public PageMainViewModel()
        {
            PageTransition = new LambdaCommand(OnPageTransitionCommandExecuted, CanPageTransitionCommandExecute);
            _main = new Main();
        }

        public string FindPassword
        {
            get
            {
                return _main.FindPassword;
            }
            set
            {
                if (_main.FindPassword != value)
                {
                    _main.FindPassword = value;
                    OnPropertyChanged("FindPassword");
                }
            }
        }

        public List<string> Passwords 
        {
            get
            {
                return Context.PasswordString;
            }
            set
            {
                if (Context.PasswordString != value)
                {
                    Context.PasswordString = value;
                    OnPropertyChanged("Passwords");
                    
                }
            }
        }

        public int PasswordIndex
        {
            get
            {
                return Context.PasswordIndex;
            }
            set
            {
                if (Context.PasswordIndex != value)
                {
                    Context.PasswordIndex = value;
                    OnPropertyChanged("PasswordIndex");
                    OpenPassword();
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void OpenPassword()
        {
            Context.management.IsReadonly = true;
            Context.management.Title = "Пароль";
            Context.management.ButtonContent = "Удалить";
            Context.management.GridLength = new GridLength(1, GridUnitType.Star);
            Context.PageMain.Content = new KeyVaultWindows.View.PagePasswordManagement();
            Context.PasswordAction = "DeletePassword";

            Context.management.Name = Context.Passwords[PasswordIndex].Name;
            Context.management.Pass = Context.Passwords[PasswordIndex].Pass;
            Context.management.Adress = Context.Passwords[PasswordIndex].Adress;
            Context.management.Login = Context.Passwords[PasswordIndex].Login;
            Context.management.Addition = Context.Passwords[PasswordIndex].Addition;
        }

        private void OnPageTransitionCommandExecuted(object p) 
        { 
            switch (p) 
            { 
                case "PasswordManagement":
                    Context.management.IsReadonly = false;
                    Context.management.Title = "Добавить пароль";
                    Context.management.ButtonContent = "Добавить";
                    Context.management.GridLength = new GridLength(0, GridUnitType.Star);
                    Context.PageMain.Content =  new KeyVaultWindows.View.PagePasswordManagement();
                    Context.PasswordAction = "AddPassword";

                    Context.management.Name = string.Empty;
                    Context.management.Pass = string.Empty;
                    Context.management.Adress = string.Empty;
                    Context.management.Login = string.Empty;
                    Context.management.Addition = string.Empty;
                    break; 
                case "PasswordGeneration":  
                    Context.PageMain.Content = new KeyVaultWindows.View.PagePasswordGeneration();  
                    break; 
                case "PasswordExport":
                    MessageBox.Show("Soon");
                    break; 
                case "Settings":            
                    Context.PageMain.Content = new KeyVaultWindows.View.PageSettings();            
                    break;
            } 
        }

        private bool CanPageTransitionCommandExecute(object p)
        {
            return true;
        }
    }
}
