using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KeyVaultWindows.Model
{
    class Settings
    {
        public string ProgrammPass { get; set; } = "";

        public string PasswordName { get; set; }

        public GridLength GridNameLength { get; set; }

        public string Newpass = string.Empty;
        public string Oldpass = string.Empty;
    }
}
