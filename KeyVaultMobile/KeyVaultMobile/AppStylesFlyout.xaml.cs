using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KeyVaultMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppStylesFlyout : ContentPage
    {
        public ListView ListView;

        public AppStylesFlyout()
        {
            InitializeComponent();

            BindingContext = new AppStylesFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class AppStylesFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<AppStylesFlyoutMenuItem> MenuItems { get; set; }
            
            public AppStylesFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<AppStylesFlyoutMenuItem>(new[]
                {
                    new AppStylesFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new AppStylesFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new AppStylesFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new AppStylesFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new AppStylesFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}