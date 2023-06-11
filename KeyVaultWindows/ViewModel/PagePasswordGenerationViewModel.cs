using KeyVaultWindows.Command;
using KeyVaultWindows.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KeyVaultWindows.ViewModel
{
    class PagePasswordGenerationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand PageTransitionCommand { get; }
        public ICommand GenerationCommand { get; }
        private Generation _generation;

        public PagePasswordGenerationViewModel()
        {
            PageTransitionCommand = new LambdaCommand(OnPageTransitionCommandExecuted, CanPageTransitionCommandExecute);
            GenerationCommand = new LambdaCommand(OnGenerationCommandExecuted, CanGenerationCommandExecute);
            _generation = new Generation();
        }

        public string Password
        {
            get
            {
                return _generation.Password;
            }
            set
            {
                if (_generation.Password != value)
                {
                    _generation.Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public string Length
        {
            get
            {
                return _generation.Length;
            }
            set
            {
                if (_generation.Length != value)
                {
                    _generation.Length = value;
                    OnPropertyChanged("Length");
                }
            }
        }

        public bool Numbers
        {
            get
            {
                return _generation.Numbers;
            }
            set
            {
                if (_generation.Numbers != value)
                {
                    _generation.Numbers = value;
                    OnPropertyChanged("Numbers");
                }
            }
        }

        public bool Chars
        {
            get
            {
                return _generation.Chars;
            }
            set
            {
                if (_generation.Chars != value)
                {
                    _generation.Chars = value;
                    OnPropertyChanged("Chars");
                }
            }
        }

        public bool Letters
        {
            get
            {
                return _generation.Letters;
            }
            set
            {
                if (_generation.Letters != value)
                {
                    _generation.Letters = value;
                    OnPropertyChanged("Letters");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void OnGenerationCommandExecuted(object p)
        {
            Password = _generation.GeneratePassword();
        }

        private bool CanGenerationCommandExecute(object p)
        {
            return _generation.Length.Length > 0 && (Numbers|| Chars|| Letters);
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
