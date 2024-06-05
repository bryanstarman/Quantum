﻿namespace Quantum
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Vistas.Login());
        }
        protected override async void OnStart()
        {
            base.OnStart();

            string token = await SecureStorage.GetAsync("auth_token");

            if (!string.IsNullOrEmpty(token))
            {
                MainPage = new NavigationPage(new Vistas.Home());
            }
            else
            {
                MainPage = new NavigationPage(new Vistas.Login());
            }
        }

        protected override async void OnResume()
        {
            base.OnResume();

            string token = await SecureStorage.GetAsync("auth_token");

            if (!string.IsNullOrEmpty(token))
            {
                MainPage = new NavigationPage(new Vistas.Home());
            }
            else
            {
                MainPage = new NavigationPage(new Vistas.Login());
            }
        }
    }
}
