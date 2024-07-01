

namespace Quantum.Vistas;

public partial class Principal : FlyoutPage
{
    public Principal()
    {
		InitializeComponent();
        NavigateTo("Home");
    }

    public void NavigateTo(string pageName)
    {
        var pageType = Type.GetType($"Quantum.Vistas.{pageName}");
        if (pageType != null)
        {
            // Crea una instancia de la p�gina
            var page = (Page)Activator.CreateInstance(pageType);
            if (page != null)
            {
                // Establece la nueva p�gina como detalle
                SetFlyoutPageForHeader(page);
                Detail = new NavigationPage(page);
                IsPresented = false; // Cierra el men� flyout
            }
        }
        else
        {
            // Maneja el caso donde no se encuentra el tipo de p�gina
            DisplayAlert("Error", $"La p�gina '{pageName}' no fue encontrada.", "OK");
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