
using Newtonsoft.Json;
using Quantum.Service;

namespace Quantum.Vistas;

public partial class Login : ContentPage
{
    UserService userService;
	public Login()
    {
        InitializeComponent();
        userService=new UserService();
    }

    private async void btn_loguearse_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txt_email.Text) && !string.IsNullOrEmpty(txt_password.Text))
        {
            string email = txt_email.Text;
            string password = txt_password.Text;

            try
            {
                try
                {
                    loadingOverlay.IsVisible = true;
                    blockElemt();
                    var userResponse = await userService.LoginAsync(email, password);
                    Preferences.Set("UserResponse", JsonConvert.SerializeObject(userResponse));
                    await SecureStorage.SetAsync("auth_token", userResponse.Token);
                    await DisplayAlert("Info", $"Bienvenido: {userResponse.User.Name}", "OK");
                    Application.Current.MainPage = new Principal();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "OK");
                }
            }
            finally
            {
                loadingOverlay.IsVisible = false;
                enableElemt();
            }
        }
        else {
            await DisplayAlert("Error", "Existen campos vacios.", "OK");
        }
    }

    public void blockElemt()
    {
        txt_email.IsEnabled = false; txt_password.IsEnabled = false; btn_loguearse.IsEnabled = false;
    }

    public void enableElemt()
    {
        txt_email.IsEnabled = true; txt_password.IsEnabled = true; btn_loguearse.IsEnabled = true;
    }

    private void btn_registrar_Tapped(object sender, TappedEventArgs e)
    {
        if (btn_loguearse.IsEnabled == true)
        {
            DisplayAlert("Error", "Existen campos vacios.", "OK");
        }
    }
    
}