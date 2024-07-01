using Newtonsoft.Json;
namespace Quantum.Vistas;

public partial class TemplateHeader : ContentView
{
    private FlyoutPage _parentFlyoutPage;

    public TemplateHeader()
	{
		InitializeComponent();
        var userResponseJson = Preferences.Get("UserResponse", string.Empty);
        if (!string.IsNullOrEmpty(userResponseJson))
        {
            var userResponse = JsonConvert.DeserializeObject<UserResponse>(userResponseJson);
            lbl.Text = userResponse.User.Name;
        }
    }

    public void SetParentFlyoutPage(FlyoutPage parentFlyoutPage)
    {
        _parentFlyoutPage = parentFlyoutPage;
    }


    private void btn_openMenuFlyout_Clicked(object sender, EventArgs e)
    {
        if (_parentFlyoutPage != null)
        {
            _parentFlyoutPage.IsPresented = !(_parentFlyoutPage.IsPresented);
        }
    }

    private void btn_openMenuUser_Clicked(object sender, EventArgs e)
    {
        var parentPage = GetParentPage();
        var userPopup = parentPage?.FindByName<ContentView>("userPopup");
        if (userPopup != null)
        {
            userPopup.IsVisible = !userPopup.IsVisible;
        }
    }

    private ContentPage GetParentPage()
    {
        Element parent = this;
        while (parent.Parent != null && !(parent is ContentPage))
        {
            parent = parent.Parent;
        }
        return parent as ContentPage;
    }
}