﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KeyVaultMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new SettingsPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
