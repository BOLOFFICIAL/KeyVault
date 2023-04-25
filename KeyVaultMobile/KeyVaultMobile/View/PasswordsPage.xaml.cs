using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KeyVaultMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordsPage : ContentPage
    {
        public PasswordsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new PasswordPage());
        }
    }
}