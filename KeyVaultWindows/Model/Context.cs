using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KeyVaultWindows.Model
{
    internal class Context
    {
        public static Management management;
        public static List<string> PasswordString { get; set; }
        public static List<Password> Passwords { get; set; }
        public static int PasswordIndex { get; set; }
        public static KeyVaultWindows.PageMain PageMain { get; set; }
        public static string PasswordAction { get; set; }
    }
}
