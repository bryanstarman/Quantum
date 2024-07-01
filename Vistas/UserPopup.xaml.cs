using Newtonsoft.Json;

namespace Quantum.Vistas;

public partial class UserPopup : ContentView
{
	public UserPopup()
	{
		InitializeComponent();
        var userResponseJson = Preferences.Get("UserResponse", string.Empty);
        if (!string.IsNullOrEmpty(userResponseJson))
        {
            var userResponse = JsonConvert.DeserializeObject<UserResponse>(userResponseJson);
            lbl_user.Text = userResponse.User.Name;
            lbl_userEmail.Text = userResponse.User.Email;
        }
    }

    private async void btn_logout_Clicked(object sender, EventArgs e)
    {
        SecureStorage.Remove("auth_token");
        Application.Current.MainPage = new NavigationPage(new Login());
    }
}