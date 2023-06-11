using KeyVaultWindows.Command;
using KeyVaultWindows.Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace KeyVaultWindows.ViewModel
{
    class PagePasswordManagementViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private Management _management;
        public ICommand PageTransition { get; }

        public PagePasswordManagementViewModel()
        {
            _management = Context.management;
            PageTransition = new LambdaCommand(OnPageTransitionCommandExecuted, CanPageTransitionCommandExecute);
        }

        public string Title
        {
            get
            {
                return _management.Title;
            }
            set
            {
                if (_management.Title != value)
                {
                    _management.Title = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public bool IsReadonly
        {
            get
            {
                return _management.IsReadonly;
            }
            set
            {
                if (_management.IsReadonly != value)
                {
                    _management.IsReadonly = value;
                    OnPropertyChanged("IsReadonly");
                }
            }
        }

        public string ButtonContent
        {
            get
            {
                return _management.ButtonContent;
            }
            set
            {
                if (_management.ButtonContent != value)
                {
                    _management.ButtonContent = value;
                    OnPropertyChanged("ButtonContent");
                }
            }
        }

        public GridLength GridLength 
        {
            get
            {
                return _management.GridLength;
            }
            set
            {
                if (_management.GridLength != value)
                {
                    _management.GridLength = value;
                    OnPropertyChanged("GridLength");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void OnPageTransitionCommandExecuted(object p)
        {
            Context.PageMain.Content = new KeyVaultWindows.View.PageMain();
        }

        private bool CanPageTransitionCommandExecute(object p)
        {
            return true;
        }
    }
}
