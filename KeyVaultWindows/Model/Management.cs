using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KeyVaultWindows.Model
{
    internal class Management
    {
        public string Title { get; set; } = string.Empty;
        public bool IsReadonly { get; set; } = true;
        public string ButtonContent { get; set; } = string.Empty;
        public GridLength GridLength { get; set; }
    }
}
