namespace Quantum.Vistas;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();
        if (Application.Current.MainPage is FlyoutPage flyoutPage)
        {
            header.SetParentFlyoutPage(flyoutPage);
        }
    }
}