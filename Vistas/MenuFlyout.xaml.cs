
using Newtonsoft.Json;
using Quantum.Service;


namespace Quantum.Vistas;

public partial class MenuFlyout : ContentPage
{
    ProyectUserService proyectUserService;
    public List<Project> Projects { get; set; }

    public MenuFlyout()
    {
        InitializeComponent();
        proyectUserService = new ProyectUserService();
        LoadProjects();
        LoadNavigationItems();
    }


    private void LoadNavigationItems()
    {
        var userResponseJson = Preferences.Get("UserResponse", string.Empty);
        if (!string.IsNullOrEmpty(userResponseJson))
        {
            var userResponse = JsonConvert.DeserializeObject<UserResponse>(userResponseJson);
            var navigationItems = userResponse?.Navigation;
            if (navigationItems != null)
            {
                var menuFlyoutItems = navigationItems.Take(3).Select(navItem => new MenuFlyoutItem
                {
                    Name = navItem.Name,
                    Description = navItem.Description,
                    IconName = navItem.IconName.ToLower(),
                    Href = navItem.Href,
                    TargetType = Type.GetType(navItem.Href) // Assuming href is the type name of the target page
                }).ToList();

                MenuItemsList.ItemsSource = menuFlyoutItems;
            }
        }
    }


    private async void LoadProjects()
    {
        try
        {
            var token = await SecureStorage.GetAsync("auth_token");
            if (token != null)
            {
                var projectResponse = await proyectUserService.GetUserProjectsAsync();
                projectCollectionView.ItemsSource = projectResponse.Projects;
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

    private void OnProjectSelected(object sender, EventArgs e)
    {

    }


    private async void btn_logout_Clicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Info", "Quieres cerrar Sessión?", "Si", "No");

        if (confirm)
        {
            SecureStorage.Remove("auth_token");

            Application.Current.MainPage = new NavigationPage(new Login());
        }
    }

    private void OnDropdownButtonClicked(object sender, EventArgs e)
    {
        dropdownFrame.IsVisible = !dropdownFrame.IsVisible;
    }

}