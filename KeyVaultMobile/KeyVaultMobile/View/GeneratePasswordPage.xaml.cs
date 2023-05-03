using KeyVaultMobile.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KeyVaultMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeneratePasswordPage : ContentPage
    {
        public GeneratePasswordPage()
        {
            InitializeComponent();
            this.BindingContext = new GeneratePasswordPageViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}