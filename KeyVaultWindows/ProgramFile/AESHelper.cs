using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace KeyVaultWindows.ProgramFile
{
    internal class AESHelper
    {
        public static string Cripto(string text, string key)
        {
            var result = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                result.Append((char)(text[i] ^ key[i% key.Length]));
            }

            return result.ToString();
        }
    }
}
