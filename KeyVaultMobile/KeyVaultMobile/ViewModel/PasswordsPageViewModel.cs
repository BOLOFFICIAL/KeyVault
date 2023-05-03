using KeyVaultMobile.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KeyVaultMobile.ViewModel
{
    internal class PasswordsPageViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Passwords passwords;
        public ICommand GeneratePass { get; }
        public ICommand OpenPass { get; }
        public ICommand Settings { get; }

        public PasswordsPageViewModel()
        {
            passwords = new Passwords();
            GeneratePass = new Command(ToGeneratePass);
            OpenPass = new Command(ToPasswordPass);
            Settings = new Command(ToSettingsPass);
        }

        public void ToGeneratePass()
        {
            Application.Current.MainPage = new NavigationPage(new GeneratePasswordPage());
        }
        public void ToPasswordPass()
        {
            Application.Current.MainPage = new NavigationPage(new PasswordPage());
        }
        public void ToSettingsPass()
        {
            Application.Current.MainPage = new NavigationPage(new SettingsPage());
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
