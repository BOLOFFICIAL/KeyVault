using System.Windows;

namespace KeyVaultWindows.Model
{
    internal class Management
    {
        public string Title { get; set; } = string.Empty;
        public bool IsReadonly { get; set; } = true;
        public string ButtonContent { get; set; } = string.Empty;
        public GridLength GridLength { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Pass { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Addition { get; set; } = string.Empty;
    }
}
