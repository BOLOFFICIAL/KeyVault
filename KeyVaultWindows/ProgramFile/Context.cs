using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using KeyVaultWindows.Model;

namespace KeyVaultWindows.ProgramFile
{
    internal class Context
    {
        public static Management management;
        public static SaveData savedata;
        public static string filter;
        public static Settings settings;
        public static List<string> AllPasswordString { get; set; }
        public static List<Password> AllPasswords { get; set; }
        public static List<string> PasswordString { get; set; }
        public static List<Password> Passwords { get; set; }
        public static int PasswordIndex { get; set; }
        public static PageMain PageMain { get; set; }
        public static string PasswordAction { get; set; }
    }
}
