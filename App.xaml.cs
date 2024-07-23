namespace Quantum
{
    public partial class App : Application
    {
        private bool _isAuthenticated;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Vistas.Login());
        }

        protected override async void OnStart()
        {
            base.OnStart();
            await HandleAuthenticationAsync();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            // No hacer nada aquí respecto a la autenticación
        }

        protected override void OnResume()
        {
            base.OnResume();
            // No hacer nada aquí respecto a la autenticación
        }

        private async Task HandleAuthenticationAsync()
        {
            if (!_isAuthenticated)
            {
                string token = await SecureStorage.GetAsync("auth_token");

                if (!string.IsNullOrEmpty(token))
                {
                    MainPage = new Vistas.Principal();
                    _isAuthenticated = true;
                }
                else
                {
                    MainPage = new NavigationPage(new Vistas.Login());
                }
            }
        }
    }
}
