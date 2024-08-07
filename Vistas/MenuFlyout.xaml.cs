using Newtonsoft.Json;
using Quantum.Modelo;
using Quantum.Service;
using System.Collections.ObjectModel;
namespace Quantum.Vistas;

public partial class MenuFlyout : ContentPage
{
    ProyectUserService proyectUserService;
    private Principal mainPage;

    private ObservableCollection<ProjectResponse> projects;
    private List<Project> originalProjectsList;

    public MenuFlyout()
    {
        InitializeComponent();
        proyectUserService = new ProyectUserService();
        LoadProjects();
    }

    public void SetMainPage(Principal principal)
    {
        mainPage = principal;
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
                    TargetType = Type.GetType(navItem.Href)
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

                projects = new ObservableCollection<ProjectResponse> { projectResponse };

                if (projects != null && projects.Any())
                {
                    var firstProjectResponse = projects.FirstOrDefault();
                    if (firstProjectResponse != null && firstProjectResponse.Projects.Any())
                    {
                        originalProjectsList = new List<Project>(firstProjectResponse.Projects);
                        activeProject(firstProjectResponse);
                        var firstProject = firstProjectResponse.Projects.FirstOrDefault();
                        firstProjectResponse.Projects.Remove(firstProject);
                        projectCollectionView.ItemsSource = new ObservableCollection<Project>(projectResponse.Projects);
                        LoadNavigationItems();

                    }
                }
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
        finally
        {
            SelectFirstMenuItem();
        }
    }

    private void activeProject(ProjectResponse projectResponse)
    {
        var activeProjectSelect = projectResponse.Projects.FirstOrDefault();
        if (activeProjectSelect != null)
        {
            //DisplayAlert("was", activeProjectSelect.ProjectId.ToString(), "wsd");
            Preferences.Set("ActiveProyect", JsonConvert.SerializeObject(activeProjectSelect));
            img_activeProyect.Source = activeProjectSelect.Branch.Country.FlagUrl;
            lbl_activeProjectName.Text = activeProjectSelect.Name;
            lbl_activeProjectDescription.Text = activeProjectSelect.Description;
        }
    }

    private void OnProjectSelected(object sender, SelectionChangedEventArgs e)
    {
        var selectedProject = e.CurrentSelection.FirstOrDefault() as Project;
        if (selectedProject != null)
        {
            activeProject(new ProjectResponse { Projects = new List<Project> { selectedProject } });

            var updatedProjectsList = originalProjectsList.Where(p => p != selectedProject).ToList();

            projectCollectionView.ItemsSource = new ObservableCollection<Project>(updatedProjectsList);

            projectCollectionView.SelectedItem = null;
            openListProyect();
            var menuFlyoutItemJson = Preferences.Get("MenuFlyoutItem", string.Empty);
            if (!string.IsNullOrEmpty(menuFlyoutItemJson))
            {
                var menuFlyoutItemResponse = JsonConvert.DeserializeObject<MenuFlyoutItem>(menuFlyoutItemJson);
                HandleMenuItemSelection(menuFlyoutItemResponse);
            }
        }
    }

    private void OnDropdownButtonClicked(object sender, EventArgs e)
    {
        dropdownFrame.IsVisible = !dropdownFrame.IsVisible;
    }

    private void MenuItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedMenuItem = e.CurrentSelection.FirstOrDefault() as MenuFlyoutItem;

        if (selectedMenuItem != null)
        {
            HandleMenuItemSelection(selectedMenuItem);
        }
    }

    private void HandleMenuItemSelection(MenuFlyoutItem selectedMenuItem)
    {
        try
        {
            if (selectedMenuItem != null)
            {
                Console.WriteLine($"HandleMenuItemSelection called with: {selectedMenuItem.Name}");

                if (mainPage != null)
                {
                    Preferences.Set("MenuFlyoutItem", JsonConvert.SerializeObject(selectedMenuItem));
                    mainPage.NavigateTo(selectedMenuItem.Name);
                }
                else
                {
                    DisplayAlert("Error", "No se pudo encontrar la página principal.", "OK");
                }
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"Error en HandleMenuItemSelection: {ex.Message}", "OK");
        }
    }

    private void SelectFirstMenuItem()
    {
        try
        {
            if (MenuItemsList.ItemsSource != null)
            {
                var itemsSource = MenuItemsList.ItemsSource as IList<MenuFlyoutItem>;
                if (itemsSource != null && itemsSource.Any())
                {
                    var firstItem = itemsSource.FirstOrDefault();
                    if (firstItem != null)
                    {
                        Console.WriteLine($"SelectFirstMenuItem: {firstItem.Name}");
                        MenuItemsList.SelectedItem = firstItem;
                        //await Task.Delay(100);
                        HandleMenuItemSelection(firstItem);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"Error selecting first menu item: {ex.Message}", "OK");
        }
    }

    public void openListProyect()
    {
        dropdownFrame.IsVisible = dropdownFrame.IsVisible ? false : dropdownFrame.IsVisible;
    }
}