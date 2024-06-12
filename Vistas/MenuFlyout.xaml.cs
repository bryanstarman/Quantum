namespace Quantum.Vistas;

public partial class MenuFlyout : ContentPage
{
	public MenuFlyout()
	{
		InitializeComponent();
	}
    private async void btn_logout_Clicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Info", "Quieres cerrar Sessión?", "Si", "No");

        if (confirm)
        {
            SecureStorage.Remove("auth_token");

            Application.Current.MainPage = new NavigationPage(new Login());
        }
    }
}