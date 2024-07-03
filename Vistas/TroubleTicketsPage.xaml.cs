using Quantum.Service;
using Quantum.Modelo;
using Newtonsoft.Json;


namespace Quantum.Vistas;

public partial class TroubleTicketsPage : ContentPage
{
    TroubleTicketsService troubleTicketsService;
    public TroubleTicketsPage()
	{
		InitializeComponent();
        troubleTicketsService = new TroubleTicketsService();
        LoadTickets();
    }
    private async void LoadTickets()
    {
        try
        {
            loadingIndicator.IsVisible = true; 

            var token = await SecureStorage.GetAsync("auth_token");
            if (token != null)
            {
                var activeProyectJson = Preferences.Get("ActiveProyect", string.Empty);
                if (!string.IsNullOrEmpty(activeProyectJson))
                {
                    var activeProyect = JsonConvert.DeserializeObject<Project>(activeProyectJson);   
                    var ticketResponse = await troubleTicketsService.GetTicketSPMAsync((int)activeProyect.ProjectId);
                    troubleTicketCollectionView.ItemsSource = ticketResponse.Data;
                    //DisplayAlert("sdas", activeProyect.ProjectId.ToString(), "dsdfs");
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

    private void troubleTicketCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedtroubleTicket = e.CurrentSelection.FirstOrDefault() as TroubleTicketData;

    }

    private void OnFrameTapped(object sender, EventArgs e)
    {
        var frame = (Frame)sender;
        var selectedItem = (TroubleTicketData)frame.BindingContext; 
        troubleTicketCollectionView.SelectedItem = selectedItem;

        if (selectedItem != null)
        {
            HandleMenuItemSelection("DetalleTroubleTicketsPage", selectedItem);
            //DisplayAlert("Info", selectedItem.Ticket.TicketNumber, "ok");
        }
    }

    private void HandleMenuItemSelection(string namePage, TroubleTicketData data)
    {
        if (namePage != null && data != null)
        {
            var currentPage = Application.Current.MainPage;

            while (currentPage != null && !(currentPage is Principal))
            {
                if (currentPage is NavigationPage navigationPage)
                {
                    currentPage = navigationPage.CurrentPage;
                }
                else if (currentPage is FlyoutPage flyoutPage)
                {
                    currentPage = flyoutPage.Detail;
                }
                else
                {
                    break;
                }
            }

            if (currentPage is Principal principalPage)
            {
                principalPage.NavigateToData(namePage, data);
            }
            else
            {
                DisplayAlert("Error", "No se pudo encontrar la página principal.", "OK");
            }
        }
    }
}