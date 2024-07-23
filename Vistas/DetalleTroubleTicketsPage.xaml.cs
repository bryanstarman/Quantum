using Newtonsoft.Json;
using Quantum.Modelo;

namespace Quantum.Vistas;

public partial class DetalleTroubleTicketsPage : ContentPage
{
    public TroubleTicketData TicketData { get; set; }

    public DetalleTroubleTicketsPage()
	{
		InitializeComponent();
        LoadDetalle();

    }

    private async void LoadDetalle()
    {
        try
        {
            loadingIndicator.IsVisible = true;

            var token = await SecureStorage.GetAsync("auth_token");
            if (token != null)
            {
                base.OnAppearing();

                if (TicketData != null)
                {
                    troubleTicketCollectionView.ItemsSource = new List<TroubleTicketData> { TicketData };
                }

            }
            else
            {
                await DisplayAlert("Error", "No se encontr? el token de autenticaci?n.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            loadingIndicator.IsVisible = false;
        }
    }

    private void NextPageButton_Clicked(object sender, EventArgs e)
    {

    }

    private void LastPageButton_Clicked(object sender, EventArgs e)
    {

    }

    private void FirstPageButton_Clicked(object sender, EventArgs e)
    {

    }

    private void PrevPageButton_Clicked(object sender, EventArgs e)
    {

    }
}