using KeyVaultWindows.Command;
using KeyVaultWindows.Model;
using KeyVaultWindows.ProgramFile;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace KeyVaultWindows.ViewModel
{
    class PageMainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand PageTransition { get; }
        private Main _main;

        public PageMainViewModel()
        {
            PageTransition = new LambdaCommand(OnPageTransitionCommandExecuted, CanPageTransitionCommandExecute);
            _main = new Main();
        }

        public string FindPassword
        {
            get
            {
                if (Context.filter.Length == 0)
                {
                    Passwords = Context.AllPasswordString.ToList();
                    Context.Passwords = Context.AllPasswords.ToList();
                }
                else
                {
                    FilterPasswords();
                }
                return Context.filter;
            }
            set
            {
                if (Context.filter != value)
                {
                    Context.filter = value;
                    if (Context.filter.Length == 0)
                    {
                        Passwords = Context.AllPasswordString.ToList();
                        Context.Passwords = Context.AllPasswords.ToList();
                    }
                    else
                    {
                        FilterPasswords();
                        Passwords = Context.PasswordString.ToList();
                    }
                    OnPropertyChanged("FindPassword");
                }
            }
        }

        public List<string> Passwords
        {
            get
            {
                return Context.PasswordString;
            }
            set
            {
                if (Context.PasswordString != value)
                {
                    Context.PasswordString = value;
                    OnPropertyChanged("Passwords");
                }
            }
        }

        public int PasswordIndex
        {
            get
            {
                return Context.PasswordIndex;
            }
            set
            {
                if (Context.PasswordIndex != value)
                {
                    Context.PasswordIndex = value;
                    OnPropertyChanged("PasswordIndex");
                    OpenPassword();
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void OpenPassword()
        {
            Context.management.IsReadonly = true;
            Context.management.Title = "Пароль";
            Context.management.ButtonContent = "Удалить";
            Context.management.GridLength = new GridLength(1, GridUnitType.Star);
            Context.PageMain.Content = new KeyVaultWindows.View.PagePasswordManagement();
            Context.PasswordAction = "DeletePassword";

            Context.management.Name = Context.Passwords[PasswordIndex].Name;
            Context.management.Pass = Context.Passwords[PasswordIndex].Pass;
            Context.management.Adress = Context.Passwords[PasswordIndex].Adress;
            Context.management.Login = Context.Passwords[PasswordIndex].Login;
            Context.management.Addition = Context.Passwords[PasswordIndex].Addition;
        }

        private void OnPageTransitionCommandExecuted(object p)
        {
            switch (p)
            {
                case "PasswordManagement":
                    Context.management.IsReadonly = false;
                    Context.management.Title = "Добавление пароля";
                    Context.management.ButtonContent = "Добавить";
                    Context.management.GridLength = new GridLength(0, GridUnitType.Star);
                    Context.PageMain.Content = new KeyVaultWindows.View.PagePasswordManagement();
                    Context.PasswordAction = "AddPassword";

                    Context.management.Name = string.Empty;
                    Context.management.Pass = string.Empty;
                    Context.management.Adress = string.Empty;
                    Context.management.Login = string.Empty;
                    Context.management.Addition = string.Empty;
                    break;
                case "PasswordGeneration":
                    Context.PageMain.Content = new KeyVaultWindows.View.PagePasswordGeneration();
                    break;
                case "PasswordExport":
                    ExportPassword();
                    break;
                case "Settings":
                    if (Context.settings.ProgrammPass.Length == 0)
                    {
                        Context.settings.PasswordName = "Пароль программы";
                        Context.settings.GridNameLength = new GridLength(0, GridUnitType.Pixel);
                    }
                    else
                    {
                        Context.settings.PasswordName = "Старый пароль";
                        Context.settings.GridNameLength = new GridLength(1, GridUnitType.Star);
                    }
                    Context.settings.Oldpass = string.Empty;
                    Context.settings.Newpass = string.Empty;
                    Context.PageMain.Content = new KeyVaultWindows.View.PageSettings();
                    break;
            }
        }

        private bool CanPageTransitionCommandExecute(object p)
        {
            if ((string)p == "PasswordExport")
            {
                return Context.AllPasswords.Count > 0;
            }
            return true;
        }

        private void FilterPasswords()
        {
            Context.Passwords = Context.AllPasswords
                .Where(tmppass =>
                    tmppass.Name.ToUpper().Contains(Context.filter.ToUpper()) ||
                    tmppass.Pass.ToUpper().Contains(Context.filter.ToUpper()) ||
                    tmppass.Adress.ToUpper().Contains(Context.filter.ToUpper()) ||
                    tmppass.Login.ToUpper().Contains(Context.filter.ToUpper()) ||
                    tmppass.Addition.ToUpper().Contains(Context.filter.ToUpper()))
                .Select(tmppass =>
                    new Password(tmppass.Name, tmppass.Pass, tmppass.Adress, tmppass.Login, tmppass.Addition))
                .ToList();

            Context.PasswordString = Context.Passwords
                .Select(tmppass => tmppass.Name)
                .ToList();
        }

        private void ExportPassword()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "KeyVault";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.Filter = "KeyVault (.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == true)
            {

                using (StreamWriter writer = File.AppendText(saveFileDialog.FileName))
                {
                    string passwords = GetPasswordText();
                    writer.WriteLine(passwords); // Добавляем текст в файл
                }
                var result = MessageBox.Show("Пароли успешно сохранены.\nХотите открыть сохраненный файл?", "Сохранение завершено", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Process.Start("cmd", "/c start \"\" \"" + saveFileDialog.FileName + "\"");
                }
            }
        }

        private string GetPasswordText()
        {
            int count = Context.AllPasswords.Count;

            int maxname = 8;
            int maxpass = 6;
            int maxadres = 5;
            int maxlogin = 5;
            int maxaddition = 13;

            foreach (var tmppass in Context.AllPasswords)
            {
                maxname = Math.Max(maxname, tmppass.Name.Length);
                maxpass = Math.Max(maxpass, tmppass.Pass.Length);
                maxadres = Math.Max(maxadres, tmppass.Adress.Length);
                maxlogin = Math.Max(maxlogin, tmppass.Login.Length);
                maxaddition = Math.Max(maxaddition, tmppass.Addition.Length);
            }
            StringBuilder stringBuilder = new StringBuilder();
            string separator = "+" + new string('-', maxname + 2) + "+" + new string('-', maxpass + 2) + "+" + new string('-', maxadres + 2) + "+" + new string('-', maxlogin + 2) + "+" + new string('-', maxaddition + 2) + "+\n";
            stringBuilder.Append(separator);
            stringBuilder.Append(
                "| Название " + new string(' ', maxname - 8) +
                "| Пароль " + new string(' ', maxpass - 6) +
                "| Адрес " + new string(' ', maxadres - 5) +
                "| Логин " + new string(' ', maxlogin - 5) +
                "| Дополнительно " + new string(' ', maxaddition - 13) + "|\n");
            stringBuilder.Append(separator);

            foreach (var tmppass in Context.AllPasswords)
            {
                stringBuilder.Append(
                    "| " + PadRightWithSpaces(tmppass.Name, maxname) +
                    " | " + PadRightWithSpaces(tmppass.Pass, maxpass) +
                    " | " + PadRightWithSpaces(tmppass.Adress, maxadres) +
                    " | " + PadRightWithSpaces(tmppass.Login, maxlogin) +
                    " | " + PadRightWithSpaces(tmppass.Addition, maxaddition) + " |\n");
                stringBuilder.Append(separator);
            }

            return stringBuilder.ToString();
        }

        private string PadRightWithSpaces(string value, int length)
        {
            return value + new string(' ', length - value.Length);
        }
    }
}
