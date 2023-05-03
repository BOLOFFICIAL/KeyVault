using KeyVaultMobile.ViewModel;
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
            this.BindingContext = new PasswordsPageViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}