using KeyVaultWindows.Model;
using KeyVaultWindows.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeyVaultWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PageMain : Window
    {
        private Settings _settings;
        public PageMain()
        {
            InitializeComponent();
            _settings = new Settings();
            Context.PageMain = this;
            Context.filter = "";
            Context.PasswordString = new List<string>();
            Context.Passwords = new List<Password>();
            Context.AllPasswordString = new List<string>();
            Context.AllPasswords = new List<Password>();
            Context.management = new Management();
            
            if (_settings.ProgrammPass.Length > 0)
            {
                Content = new PageAuthorization();
            }
            else
            {
                Content = new KeyVaultWindows.View.PageMain();
            }
        }
    }
}
