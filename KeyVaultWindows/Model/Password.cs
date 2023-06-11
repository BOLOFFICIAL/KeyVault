namespace KeyVaultWindows.Model
{
    internal class Password
    {
        public string Name { get; set; }
        public string Pass { get; set; }
        public string Adress { get; set; }
        public string Login { get; set; }
        public string Addition { get; set; }

        public Password(string Name, string Pass, string Adress, string Login, string Addition)
        {
            this.Addition = Addition;
            this.Name = Name;
            this.Pass = Pass;
            this.Adress = Adress;
            this.Login = Login;
        }
    }
}
