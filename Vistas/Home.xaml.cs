using System.Windows.Input;

namespace Quantum.Vistas;

public partial class Home : ContentPage
{
    public ICommand ToggleFlyoutCommand { get; }

    public Home()
	{
		InitializeComponent();
        ToggleFlyoutCommand = new Command(() =>
        {
            var flyoutPage = this.Parent as FlyoutPage;
            flyoutPage.IsPresented = !flyoutPage.IsPresented;
        });
        BindingContext = this;
    }

    private async void btn_logout_Clicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Info", "Quieres cerrar Sessi�n?", "Si", "No");

        if (confirm)
        {
            SecureStorage.Remove("auth_token");

            Application.Current.MainPage = new NavigationPage(new Login());
        }
    }
}