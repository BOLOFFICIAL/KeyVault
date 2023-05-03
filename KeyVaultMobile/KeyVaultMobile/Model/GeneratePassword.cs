using System;
using System.Collections.Generic;
using System.Text;

namespace KeyVaultMobile.Model
{
    internal class GeneratePassword
    {
        public bool Numbers { get; set; }
        public bool Chars { get; set; }
        public bool Letter { get; set; }
        public int Length { get; set; }
        public string Password { get; set; }

        public GeneratePassword() 
        {
            Length = 8;
            Numbers = true;
            Chars = true;
            Letter = true;
            Password = "";
        }


        public string GeneratePass() 
        {
            return "Bolofficial"+ Length;
        }
    }
}
