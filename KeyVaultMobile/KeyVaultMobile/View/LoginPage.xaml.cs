using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KeyVaultMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (LoginPageEntry.Text == "2190")
            {
                Application.Current.MainPage = new NavigationPage(new PasswordsPage());
            }
            else 
            {
                LoginPageEntry.Text = "";
            }
        }
    }
}