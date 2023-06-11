using KeyVaultWindows.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Input;
using KeyVaultWindows.Command;
using System.Net;
using System.Runtime;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Windows.Shapes;
using System.Windows;
using System.ComponentModel;

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

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void OnPageTransitionCommandExecuted(object p) 
        { 
            switch (p) 
            { 
                case "PasswordManagement":
                    Context.management = new Management() 
                    { 
                        IsReadonly = false, 
                        Title = "Добавить пароль", 
                        ButtonContent = "Добавить",
                        GridLength = new GridLength(0, GridUnitType.Star)
                    };
                    Context.PageMain.Content =  new KeyVaultWindows.View.PagePasswordManagement();  
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
