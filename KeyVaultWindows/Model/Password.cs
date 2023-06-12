namespace KeyVaultWindows.Model
{
    internal class Password
    {
        public string Name { get; set; } = string.Empty;
        public string Pass { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Addition { get; set; } = string.Empty;

        public Password(string Name, string Pass, string Adress, string Login, string Addition)
        {
            this.Name = Name;
            this.Pass = Pass;
            this.Adress = Adress;
            this.Login = Login;
            this.Addition = Addition;
        }
    }
}
