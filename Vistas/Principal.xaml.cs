

using Quantum.Modelo;

namespace Quantum.Vistas;

public partial class Principal : FlyoutPage
{
    public Principal()
    {
		InitializeComponent();
        menuFlyout.SetMainPage(this);
        NavigateTo("Home");
    }

    public void NavigateTo(string pageName)
    {
        var pageType = Type.GetType($"Quantum.Vistas.{pageName}");
        if (pageType != null)
        {
            var page = (Page)Activator.CreateInstance(pageType);
            if (page != null)
            {
                SetFlyoutPageForHeader(page);
                Detail = new NavigationPage(page);
                IsPresented = false; 
            }
        }
        else
        {
            DisplayAlert("Error", $"La página '{pageName}' no fue encontrada.", "OK");
        }
    }

    public void NavigateToData(string pageName, TroubleTicketData data)
    {
        var pageType = Type.GetType($"Quantum.Vistas.{pageName}");
        if (pageType != null)
        {
            var page = (Page)Activator.CreateInstance(pageType);
            if (page != null)
            {
                if (page is DetalleTroubleTicketsPage detallePage)
                {
                    detallePage.TicketData = data;
                }

                SetFlyoutPageForHeader(page);
                Detail = new NavigationPage(page);
                IsPresented = false;
            }
        }
        else
        {
            DisplayAlert("Error", $"La página '{pageName}' no fue encontrada.", "OK");
        }
    }


    private void SetFlyoutPageForHeader(Page page)
    {
        if (page is ContentPage contentPage)
        {
            var header = contentPage.Content.FindByName<TemplateHeader>("header");
            if (header != null)
            {
                header.SetParentFlyoutPage(this);
            }
        }
    }

}