using KeyVaultMobile.Model;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace KeyVaultMobile.ViewModel
{
    internal class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Login login;
        public ICommand InserPass { get; }

        public LoginPageViewModel()
        {
            login = new Login();
            InserPass = new Command(InserPassword);
        }

        public void InserPassword()
        {
            if (login.Password == ProgrammData.password)
            {
                Application.Current.MainPage = new NavigationPage(new PasswordsPage());
            }
            else 
            {
                Password = "";
                ErrorMessage = "Неправильный пароль";
            }
                
        }

        public string Password
        {
            get { return login.Password; }
            set
            {
                if (login.Password != value)
                {
                    ErrorMessage = "";
                    login.Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public string ErrorMessage
        {
            get { return login.ErrorMessage; }
            set
            {
                if (login.ErrorMessage != value)
                {
                    login.ErrorMessage = value;
                    OnPropertyChanged("ErrorMessage");
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
