using Quantum.Modelo;
using Quantum.Service;

namespace Quantum.Vistas;

public partial class TicketsPage : ContentPage
{
    TicketSPMService ticketSPMService;
    public List<Project> Projects;
    public TicketsPage()
	{
		InitializeComponent();
        ticketSPMService = new TicketSPMService();
        LoadTickets();
    }
    private async void LoadTickets()
    {
        try
        {
            var token = await SecureStorage.GetAsync("auth_token");
            if (token != null)
            {
                var ticketResponse = await ticketSPMService.GetTicketSPMAsync();
                ticketSPMCollectionView.ItemsSource = ticketResponse.Datas;
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
    }

}