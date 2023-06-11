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

namespace KeyVaultWindows.ViewModel
{
    class PageMainViewModel
    {
        public ICommand PageTransition { get; }

        public PageMainViewModel()
        {
            PageTransition = new LambdaCommand(OnPageTransitionCommandExecuted, CanPageTransitionCommandExecute);
        }

        private void OnPageTransitionCommandExecuted(object p) 
        { 
            switch (p) 
            { 
                case "PasswordManagement":
                    Context.management = new Management() 
                    { 
                        IsReadonly = true, 
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
