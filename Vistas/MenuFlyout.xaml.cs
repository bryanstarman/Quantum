
using Newtonsoft.Json;
using Quantum.Modelo;
using Quantum.Service;
using System.Collections.ObjectModel;


namespace Quantum.Vistas;

public partial class MenuFlyout : ContentPage
{
    ProyectUserService proyectUserService;

    private ObservableCollection<ProjectResponse> projects;
    private List<Project> originalProjectsList;


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
    }


    private void activeProject(ProjectResponse projectResponse)
    {
        var activeProjectSelect = projectResponse.Projects.FirstOrDefault();
        if (activeProjectSelect != null)
        {
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
        }
    }


    private void OnDropdownButtonClicked(object sender, EventArgs e)
    {
        dropdownFrame.IsVisible = !dropdownFrame.IsVisible;
    }

    private void MenuItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedMenuItem = e.CurrentSelection.FirstOrDefault() as MenuFlyoutItem;

        /*var ativeProyectJson = Preferences.Get("ActiveProyect", string.Empty);
        if (!string.IsNullOrEmpty(ativeProyectJson))
        {
            var ativeProyect = JsonConvert.DeserializeObject<Project>(ativeProyectJson);
            DisplayAlert("Info", ativeProyect.Branch.Country.Name  + " --  " + ativeProyect.BranchId + "-- "+ selectedMenuItem.Name, "ok");
            openListProyect();
        }*/
        if (selectedMenuItem != null)
        {
            // Encontrar Principal en la jerarquía de páginas
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
                principalPage.NavigateTo(selectedMenuItem.Name);
            }
            else
            {
                DisplayAlert("Error", "No se pudo encontrar la página principal.", "OK");
            }
        }
    }

    public void openListProyect()
    {
        dropdownFrame.IsVisible = dropdownFrame.IsVisible ? false : dropdownFrame.IsVisible;

    }
}