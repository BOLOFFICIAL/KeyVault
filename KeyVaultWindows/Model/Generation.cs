using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;

namespace KeyVaultWindows.Model
{
    internal class Generation
    {
        public string Password { get; set; } = string.Empty;
        public string Length { get; set; } = "8";
        public bool Numbers { get; set; } = true;
        public bool Chars { get; set; } = true;
        public bool Letters { get; set; } = true;

        public string GeneratePassword()
        {
            var random = new Random(); 
            var consts = new List<string>(); 
            if (Numbers)    consts.Add("0123456789"); 
            if (Chars)      consts.Add("@#%\"&*()_-+={}<>?:[].~"); 
            if (Letters)    consts.Add("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"); 
            int.TryParse(Length, out int length); 
            var password = new StringBuilder(length);

            for (var i = 0; i < length; i++)
            {
                var data = consts[random.Next(consts.Count)];
                password.Append(data[random.Next(data.Length)]);
            }

            return password.ToString();
        }
    }
}
