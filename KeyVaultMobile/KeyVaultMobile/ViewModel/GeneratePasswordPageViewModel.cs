using KeyVaultMobile.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KeyVaultMobile.ViewModel
{
    internal class GeneratePasswordPageViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private GeneratePassword generate;
        public ICommand ToBack { get; }
        public ICommand Generation { get; }

        public GeneratePasswordPageViewModel()
        {
            generate = new GeneratePassword();
            ToBack = new Command(ToPasswordsPass);
            Generation = new Command(Generate);
        }

        public void Generate()
        {
            Password = generate.GeneratePass();
        }
        public void ToPasswordsPass()
        {
            Application.Current.MainPage = new NavigationPage(new PasswordsPage());
        }

        public string Password
        {
            get { return generate.Password; }
            set
            {
                if (generate.Password != value)
                {
                    generate.Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public bool Chars
        {
            get { return generate.Chars; }
            set
            {
                if (generate.Chars != value)
                {
                    generate.Chars = value;
                    OnPropertyChanged("Chars");
                }
            }
        }

        public bool Numbers
        {
            get { return generate.Numbers; }
            set
            {
                if (generate.Numbers != value)
                {
                    generate.Numbers = value;
                    OnPropertyChanged("Numbers");
                }
            }
        }

        public bool Letter
        {
            get { return generate.Letter; }
            set
            {
                if (generate.Letter != value)
                {
                    generate.Letter = value;
                    OnPropertyChanged("Letter");
                }
            }
        }

        public int Length
        {
            get { return generate.Length; }
            set
            {
                if (generate.Length != value)
                {
                    generate.Length = value;
                    OnPropertyChanged("Length");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
