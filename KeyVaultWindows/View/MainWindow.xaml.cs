using KeyVaultWindows.Model;
using KeyVaultWindows.View;
using System.Collections.Generic;
using System.Windows;

namespace KeyVaultWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PageMain : Window
    {
        public PageMain()
        {
            InitializeComponent();
            Context.PageMain = this;
            Context.filter = "";
            Context.PasswordString = new List<string>();
            Context.Passwords = new List<Password>();
            Context.AllPasswordString = new List<string>();
            Context.AllPasswords = new List<Password>();
            Context.management = new Management();
            Context.settings = new Settings();

            Content = Context.settings.ProgrammPass.Length > 0 ? new PageAuthorization() : new KeyVaultWindows.View.PageMain();

        }
    }
}
