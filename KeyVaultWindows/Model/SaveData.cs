using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyVaultWindows.Model
{
    internal class SaveData
    {
        public Settings settings;
        public List<string> AllPasswordString;
        public List<Password> AllPasswords;

        public SaveData(Settings s, List<string> AllPS, List<Password> AllP) 
        {
            settings = s;
            AllPasswordString = AllPS;
            AllPasswords = AllP;
        }

        public void Save() 
        {
            string json = JsonConvert.SerializeObject(this);
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "/ProgramData.KeyVault";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(json);
            }
        }
    }
}
