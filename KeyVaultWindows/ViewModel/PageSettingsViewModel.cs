using KeyVaultWindows.Command;
using KeyVaultWindows.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KeyVaultWindows.ViewModel
{
    class PageSettingsViewModel
    {
        public ICommand PageTransition { get; }

        public PageSettingsViewModel()
        {
            PageTransition = new LambdaCommand(OnPageTransitionCommandExecuted, CanPageTransitionCommandExecute);
        }

        private void OnPageTransitionCommandExecuted(object p)
        {
            Context.PageMain.Content = new KeyVaultWindows.View.PageMain();
        }

        private bool CanPageTransitionCommandExecute(object p)
        {
            return true;
        }
    }
}
