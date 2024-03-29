﻿using KeyVaultWindows.Model;
using KeyVaultWindows.ProgramFile;
using KeyVaultWindows.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KeyVaultWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PageMain : Window
    {
        public PageMain()
        {
            InitializeComponent();
            Initialization();
            InitializationDate();
            Content = Context.settings.ProgrammPass.Length > 0 ? new PageAuthorization() : new KeyVaultWindows.View.PageMain();

        }

        private void Initialization()
        {
            Context.PageMain = this;
            Context.filter = "";
            Context.PasswordString = new List<string>();
            Context.Passwords = new List<Password>();
            Context.AllPasswordString = new List<string>();
            Context.AllPasswords = new List<Password>();
            Context.management = new Management();
            Context.settings = new Settings();
            Context.savedata = new SaveData(Context.settings, Context.AllPasswordString, Context.AllPasswords);
        }

        private void InitializationDate()
        {
            string json = "";
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "/ProgramData.KeyVault";
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    json = reader.ReadToEnd();
                    if (json.Length > 0)
                    {
                        try
                        {
                            json = AESHelper.Cripto(json, "l3u46qH14p7@Rt&{5>4<.0Lg~%8Qh7x.");
                            json = json.Substring(0, json.Length - 2);
                            Context.savedata = JsonConvert.DeserializeObject<SaveData>(json);
                            Context.settings = Context.savedata.settings;
                            Context.AllPasswordString = Context.savedata.AllPasswordString;
                            Context.AllPasswords = Context.savedata.AllPasswords;
                            Context.PasswordIndex = -1;
                        }
                        catch
                        {
                            MessageBox.Show("Не удалось загрузить данные");
                        }
                    }
                }
            }
        }
    }
}
