using Quantum.Service;

namespace Quantum.Vistas;

public partial class TicketSPM : ContentPage
{
    TicketSPMService ticketSPMService;
    public List<Project> Projects { get; set; }
    public TicketSPM()
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
               ticketSPMCollectionView.ItemsSource=ticketResponse.Datas;
            }
            else
            {
                await DisplayAlert("Error", "No se encontró el token de autenticación.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

}