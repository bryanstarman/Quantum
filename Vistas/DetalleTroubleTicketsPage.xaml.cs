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
                    //TicketData.Ticket.Creator.Name = string.Empty;
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
}