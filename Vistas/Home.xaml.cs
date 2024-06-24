using Newtonsoft.Json;
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
        var userResponseJson = Preferences.Get("UserResponse", string.Empty);
        if (!string.IsNullOrEmpty(userResponseJson))
        {
            var userResponse = JsonConvert.DeserializeObject<UserResponse>(userResponseJson);
            star.Text = "Bienvenido "+userResponse.User.Name;
        }
    }

}