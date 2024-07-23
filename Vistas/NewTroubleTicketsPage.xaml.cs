using Newtonsoft.Json;
using Quantum.Modelo;
using Quantum.Service;

namespace Quantum.Vistas;

public partial class NewTroubleTicketsPage : ContentPage
{
    TroubleTicketsService troubleTicketsService;

    public NewTroubleTicketsPage()
	{
		InitializeComponent();
        troubleTicketsService = new TroubleTicketsService();
        var parentFlyoutPage = (FlyoutPage)Application.Current.MainPage;
        header.SetParentFlyoutPage(parentFlyoutPage);
        LoadTickets();
    }

    private async void LoadTickets()
    {
        try
        {
            loadingIndicator.IsVisible = true;
            gridForm.IsVisible = false;

            var token = await SecureStorage.GetAsync("auth_token");
            if (token != null)
            {
                var activeProyectJson = Preferences.Get("ActiveProyect", string.Empty);
                if (!string.IsNullOrEmpty(activeProyectJson))
                {
                    var activeProyect = JsonConvert.DeserializeObject<Project>(activeProyectJson);
                    var newTicketResponse = await troubleTicketsService.GetNewTicketSPAsync((int)activeProyect.ProjectId);

                    var failureCityResponse = await troubleTicketsService.GetFailureCityResponseAsync(activeProyect.BranchId);
                    var deliveryResponse = await troubleTicketsService.GetDeliveryResponseAsync(activeProyect.BranchId);

                    pck_failureCity.ItemsSource = failureCityResponse;
                    pck_deliveryCenter.ItemsSource = deliveryResponse;  
                    img_activeProyect.Source = activeProyect.Branch.Country.FlagUrl;
                    lbl_title.Text = "Ticket " + newTicketResponse.NewCode;
                    lbl_fecha.Text = newTicketResponse.CreatedAt;
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
            gridForm.IsVisible = true;
        }
    }

    private void pck_failureCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedItem = (FailureCityResponse)picker.SelectedItem;

        if (selectedItem != null)
        {
            DisplayAlert("Selected City", $"You selected: {selectedItem.City}", "OK");
        }
    }
}
