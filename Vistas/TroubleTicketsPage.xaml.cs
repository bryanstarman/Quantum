using Quantum.Service;
using Quantum.Modelo;
using Newtonsoft.Json;
using System.Collections.ObjectModel;


namespace Quantum.Vistas;

public partial class TroubleTicketsPage : ContentPage
{
    TroubleTicketsService troubleTicketsService;
    public ObservableCollection<OptionColum> OptionColum { get; set; }

    int from =0;
    int to = 0;
    int total_page = 0;
    int current_page = 0;
    int page_url = 0;
    int last_page = 0;
    int next_page = 0;
    int prev_page = 0;
    string column_search = null;
    string contain_search = null;

    public TroubleTicketsPage()
	{
		InitializeComponent();
        troubleTicketsService = new TroubleTicketsService();
        LoadTickets();
        loadPickerColum();
    }
    private async void LoadTickets()
    {
        try
        {
            troubleTicketCollectionView.ItemsSource = null;
            pnl_paginator.IsVisible = false;
            pnl_opciones.IsVisible = false;
            loadingIndicator.IsVisible = true; 

            var token = await SecureStorage.GetAsync("auth_token");
            if (token != null)
            {
                var activeProyectJson = Preferences.Get("ActiveProyect", string.Empty);
                if (!string.IsNullOrEmpty(activeProyectJson))
                {
                    var activeProyect = JsonConvert.DeserializeObject<Project>(activeProyectJson);  
                    var ticketResponse = await troubleTicketsService.GetTicketSPMAsync((int)activeProyect.ProjectId, page_url, column_search, contain_search);
                    troubleTicketCollectionView.ItemsSource = ticketResponse.Data;
                    from = (int)ticketResponse.From;
                    to = (int)ticketResponse.To; ;
                    total_page = (int)ticketResponse.Total;
                    last_page = (int)ticketResponse.LastPage;
                    current_page = (int)ticketResponse.CurrentPage;
                    next_page= current_page + 1;
                    prev_page = current_page - 1;
                    lbl_pageInfo.Text = $"Showing {from} to {to} of {last_page} entries";
                    if (next_page > last_page)
                    {
                        btn_lastPage.IsEnabled = false;
                        btn_nextPage.IsEnabled = false;
                    }
                    else
                    {
                        btn_lastPage.IsEnabled = true;
                        btn_nextPage.IsEnabled = true;
                    }
                    if (prev_page < 1)
                    {
                        btn_prevPage.IsEnabled = false;
                        btn_firstPage.IsEnabled = false;
                    }
                    else
                    {
                        btn_prevPage.IsEnabled = true;
                        btn_firstPage.IsEnabled = true;
                    }
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
            pnl_paginator.IsVisible = true;
            pnl_opciones.IsVisible = true;

        }
    }


    public void loadPickerColum()
    {
        OptionColum = new ObservableCollection<OptionColum>
        {
            new OptionColum { Column_search = "ticket.ticket_number", Titulo = "Ticket Number" },
            new OptionColum { Column_search = "detail.part_number", Titulo = "Part Number" },
            new OptionColum { Column_search = "detail.item_master.description", Titulo = "Item Master" },
            new OptionColum { Column_search = "detail.serial", Titulo = "Serial" },
            new OptionColum { Column_search = "ticket.status.code", Titulo = "Status" }
        };
        pck_columna.ItemsSource = OptionColum;
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

    private void btn_firstPage_Clicked(object sender, EventArgs e)
    {
        page_url = 0;
        LoadTickets();
    }

    private void btn_prevPage_Clicked(object sender, EventArgs e)
    {
        page_url = prev_page;
        LoadTickets();
    }

    private void btn_nextPage_Clicked(object sender, EventArgs e)
    {
        page_url = next_page;
        LoadTickets();
    }

    private void btn_lastPage_Clicked(object sender, EventArgs e)
    {
        page_url = last_page;
        LoadTickets();
    }

    private void btn_newTroubleTicket_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewTroubleTicketsPage());

    }

    private void btn_filtrar_Clicked(object sender, EventArgs e)
    {
        var selectedIndex = pck_columna.SelectedIndex;
        if (selectedIndex != -1)
        {
            var selectedItem = (OptionColum)pck_columna.SelectedItem;
            DisplayAlert("Info", $"El valor seleccionado: {selectedItem.Column_search}", "OK");
            page_url = 0;
            column_search = selectedItem.Column_search;
            if (column_search != null)
            {
                contain_search = txt_filtro.Text;
            }
            else{
                DisplayAlert("Alerta", "Ingresa un valor a buscar..", "OK");
            }
            LoadTickets();
        }
        else
        {
            DisplayAlert("Alerta", "Selecciona una columna a buscar.", "OK");
        }
    }
}

public class OptionColum
{
    public string Column_search { get; set; }
    public string Titulo { get; set; }

}